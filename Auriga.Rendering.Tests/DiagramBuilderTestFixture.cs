// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramBuilderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System.Linq;

    using Autofac;

    using NUnit.Framework;

    using Notation = Auriga.Diagram.Notation;
    using SiriusDiagram = Auriga.Diagram.Diagram;
    using SiriusDescription = Auriga.Diagram.Viewpoint.Description;
    using SiriusViewpoint = Auriga.Diagram.Viewpoint;

    /// <summary>
    /// Tests the <see cref="DiagramBuilder"/> against hand-built object graphs: absolute position
    /// accumulation, GMF size sentinels, label-node folding, auxiliary-node (compartment) nesting,
    /// anchor and bendpoint route math, and the Sirius/semantic back-links — the coordinate rules
    /// that must hold regardless of fixture content.
    /// </summary>
    [TestFixture]
    public class DiagramBuilderTestFixture
    {
        /// <summary>
        /// The builder under test, composed with the default per-kind builders.
        /// </summary>
        private readonly DiagramBuilder diagramBuilder = new();

        [Test]
        public void Verify_that_the_builder_guards_its_arguments()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => this.diagramBuilder.Build(null!), Throws.ArgumentNullException);
                Assert.That(
                    () => this.diagramBuilder.Build(new SiriusDiagram.DSemanticDiagram()),
                    Throws.InvalidOperationException.With.Message.Contains("no GMF notation diagram"));
                Assert.That(() => new DiagramBuilder(null!, new SequenceDiagramBuilder()), Throws.ArgumentNullException);
                Assert.That(() => new DiagramBuilder(new NodeDiagramBuilder(), null!), Throws.ArgumentNullException);
                Assert.That(() => new NodeDiagramBuilder(null!), Throws.ArgumentNullException);
                Assert.That(() => new SequenceDiagramBuilder(null!), Throws.ArgumentNullException);
                Assert.That(() => this.diagramBuilder.BuildAll(null!), Throws.ArgumentNullException);
            });
        }

        [Test]
        public void Verify_that_build_all_resolves_names_and_skips_what_it_cannot_build()
        {
            var named = Representation(new Notation.Node { Id = "node-named", Element = new SiriusDiagram.DNode { Id = "sirius-a", Name = "a" } });
            var unmatched = Representation(new Notation.Node { Id = "node-unmatched", Element = new SiriusDiagram.DNode { Id = "sirius-b", Name = "b" } });
            unmatched.Id = "rep-2";
            var anonymous = Representation(new Notation.Node { Id = "node-anonymous", Element = new SiriusDiagram.DNode { Id = "sirius-c", Name = "c" } });
            anonymous.Id = null;
            var withoutNotation = new SiriusDiagram.DSemanticDiagram { Id = "rep-3" };

            var descriptor = new SiriusViewpoint.DRepresentationDescriptor { RepPath = "#rep-1", Name = "named" };
            var nameless = new SiriusViewpoint.DRepresentationDescriptor { RepPath = "#rep-2" };
            var pathless = new SiriusViewpoint.DRepresentationDescriptor { Name = "orphan" };

            var diagrams = this.diagramBuilder.BuildAll(new Auriga.Core.IAurigaElement[] { named, unmatched, anonymous, withoutNotation, descriptor, nameless, pathless });

            Assert.Multiple(() =>
            {
                Assert.That(diagrams, Has.Count.EqualTo(3), "the representation without a notation diagram is skipped");
                Assert.That(diagrams[0].Name, Is.EqualTo("named"), "named through its descriptor");
                Assert.That(diagrams[0].NotationDiagram, Is.Not.Null);
                Assert.That(diagrams[1].Name, Is.Null, "its descriptor carries no name");
                Assert.That(diagrams[2].Name, Is.Null, "no identifier to match a descriptor on");
            });
        }

        [Test]
        public void Verify_the_point_value_semantics()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Point(1, 2) + new Point(3, 4), Is.EqualTo(new Point(4, 6)));
                Assert.That(new Point(1, 2) == new Point(1, 2), Is.True);
                Assert.That(new Point(1, 2) != new Point(1, 3), Is.True);
                Assert.That(new Point(1, 2) != new Point(2, 2), Is.True);
                Assert.That(new Point(1, 2).Equals((object)new Point(1, 2)), Is.True);
                Assert.That(new Point(1, 2).Equals("not a point"), Is.False);
                Assert.That(new Point(1, 2).GetHashCode(), Is.EqualTo(new Point(1, 2).GetHashCode()));
            });
        }

        [Test]
        public void Verify_that_the_builder_composes_through_an_autofac_container()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<CapellaDefaultPalette>().As<ICapellaDefaultPalette>();
            containerBuilder.RegisterType<StyleResolver>().As<IStyleResolver>();
            containerBuilder.RegisterType<NodeDiagramBuilder>().AsSelf();
            containerBuilder.RegisterType<SequenceDiagramBuilder>().AsSelf();
            containerBuilder.RegisterType<DiagramBuilder>().As<IDiagramBuilder>();
            containerBuilder.RegisterType<SvgExporter>().As<ISvgExporter>();

            using var container = containerBuilder.Build();
            var resolved = container.Resolve<IDiagramBuilder>();
            var exporter = container.Resolve<ISvgExporter>();

            var node = new Notation.Node
            {
                Id = "node-1",
                Element = new SiriusDiagram.DNode { Id = "sirius-1", Name = "injected" },
                LayoutConstraint = new Notation.Bounds { X = 10, Y = 20 },
            };

            var diagram = resolved.Build(Representation(node), "composed");

            Assert.Multiple(() =>
            {
                Assert.That(diagram.Name, Is.EqualTo("composed"));
                Assert.That(diagram.Boxes, Has.Count.EqualTo(1));
                Assert.That(diagram.Boxes[0].Position, Is.EqualTo(new Point(10, 20)));
                Assert.That(exporter.Export(diagram), Does.Contain("<svg"));
            });
        }

        [Test]
        public void Verify_that_nested_positions_accumulate_to_absolute_coordinates()
        {
            var semanticTarget = new object();
            var childSirius = new SiriusDiagram.DNode { Id = "child-1", Name = "child" };
            var parentSirius = new SiriusDiagram.DNodeContainer { Id = "parent-1", Name = "parent", Target = semanticTarget };

            var childNode = new Notation.Node { Id = "n-child", Element = childSirius };
            childNode.LayoutConstraint = new Notation.Bounds { X = 10, Y = 20, Width = 30, Height = -1 };

            var parentNode = new Notation.Node { Id = "n-parent", Element = parentSirius };
            parentNode.LayoutConstraint = new Notation.Bounds { X = 100, Y = 50, Width = 200, Height = 120 };
            parentNode.PersistedChildren.Add(childNode);

            var diagram = this.diagramBuilder.Build(Representation(parentNode), "synthetic");

            var parent = diagram.Boxes.Single();
            var child = parent.Children.Single();

            Assert.Multiple(() =>
            {
                Assert.That(diagram.Name, Is.EqualTo("synthetic"));
                Assert.That(parent.Position, Is.EqualTo(new Point(100, 50)));
                Assert.That(parent.Width, Is.EqualTo(200));
                Assert.That(parent.Height, Is.EqualTo(120));

                // The child's persisted (10, 20) is relative to its parent; -1 means "no persisted height".
                Assert.That(child.Position, Is.EqualTo(new Point(110, 70)));
                Assert.That(child.Width, Is.EqualTo(30));
                Assert.That(child.Height, Is.Null);
                Assert.That(child.Parent, Is.SameAs(parent));

                Assert.That(parent.SiriusElement, Is.SameAs(parentSirius));
                Assert.That(parent.SemanticElement, Is.SameAs(semanticTarget));
                Assert.That(parent.NotationView, Is.SameAs(parentNode));
                Assert.That(parent.Label!.Text, Is.EqualTo("parent"));
                Assert.That(diagram.QueryAllBoxes().Count(), Is.EqualTo(2));
            });
        }

        [Test]
        public void Verify_that_an_absolute_bounds_filter_overrides_the_relative_geometry()
        {
            var sirius = new SiriusDiagram.DNode { Id = "d-abs", Name = "filtered" };
            sirius.GraphicalFilters.Add(new SiriusDiagram.AbsoluteBoundsFilter { X = 300, Y = 400, Width = 20, Height = 60 });

            var node = new Notation.Node { Id = "n-abs", Element = sirius };
            node.LayoutConstraint = new Notation.Bounds { X = 5, Y = 6, Width = 1, Height = 1 };

            var diagram = this.diagramBuilder.Build(Representation(node));
            var box = diagram.Boxes.Single();

            Assert.Multiple(() =>
            {
                Assert.That(box.Position, Is.EqualTo(new Point(300, 400)), "the filter's absolute position replaces the accumulated offset");
                Assert.That(box.Width, Is.EqualTo(20));
                Assert.That(box.Height, Is.EqualTo(60));
                Assert.That(box.HasAbsoluteBounds, Is.True);
            });
        }

        [Test]
        public void Verify_that_a_gmf_note_builds_from_the_notation_alone()
        {
            var note = new Notation.Shape { Id = "note-1", Description = "A note\r\n\r\nwith paragraphs", FillColor = (0xCC << 16) | (0xFF << 8) | 0xFF };
            note.LayoutConstraint = new Notation.Bounds { X = 700, Y = 20, Width = 300, Height = 120 };

            var diagram = this.diagramBuilder.Build(Representation(note));
            var box = diagram.Boxes.Single();

            Assert.Multiple(() =>
            {
                Assert.That(box.SiriusElement, Is.Null, "a note has no Sirius counterpart");
                Assert.That(box.Position, Is.EqualTo(new Point(700, 20)));
                Assert.That(box.Label!.Text, Is.EqualTo("A note\r\n\r\nwith paragraphs"));
                Assert.That(box.Label.Position, Is.EqualTo(new Point(704, 22)), "the text starts at the note's top-left");
                Assert.That(box.Label.Width, Is.EqualTo(292), "wrapped to the note's width");
                Assert.That(box.Style.Resolved.FillColor, Is.EqualTo(new Color(255, 255, 204)), "the note's own fill applies");
            });
        }

        [Test]
        public void Verify_that_a_label_node_contributes_the_label_geometry()
        {
            var sirius = new SiriusDiagram.DNode { Id = "d-1", Name = "labelled" };

            var labelNode = new Notation.Node();
            labelNode.LayoutConstraint = new Notation.Location { X = -9, Y = 32 };

            var node = new Notation.Node { Id = "n-1", Element = sirius };
            node.LayoutConstraint = new Notation.Bounds { X = 380, Y = 237, Width = 41, Height = 31 };
            node.PersistedChildren.Add(labelNode);

            var diagram = this.diagramBuilder.Build(Representation(node));

            var box = diagram.Boxes.Single();

            Assert.Multiple(() =>
            {
                Assert.That(box.Label!.Text, Is.EqualTo("labelled"));
                Assert.That(box.Label.Position, Is.EqualTo(new Point(371, 269)), "the label offset is relative to its box");
                Assert.That(box.Children, Is.Empty, "a label node is folded into its box, not a nested box");
            });
        }

        [Test]
        public void Verify_that_an_auxiliary_compartment_nests_its_children_into_the_enclosing_box()
        {
            var containerSirius = new SiriusDiagram.DNodeContainer { Id = "c-1", Name = "container" };
            var nestedSirius = new SiriusDiagram.DNode { Id = "d-2", Name = "nested" };

            var nestedNode = new Notation.Node { Id = "n-nested", Element = nestedSirius };
            nestedNode.LayoutConstraint = new Notation.Bounds { X = 5, Y = 6 };

            // The compartment carries the container's own Sirius element (not a distinct one) and an
            // offset of its own, as GMF persists scrollable compartments.
            var compartment = new Notation.Node { Id = "n-compartment", Element = containerSirius };
            compartment.LayoutConstraint = new Notation.Location { X = 2, Y = 30 };
            compartment.PersistedChildren.Add(nestedNode);

            var containerNode = new Notation.Node { Id = "n-container", Element = containerSirius };
            containerNode.LayoutConstraint = new Notation.Bounds { X = 100, Y = 100 };
            containerNode.PersistedChildren.Add(compartment);

            var diagram = this.diagramBuilder.Build(Representation(containerNode));

            var container = diagram.Boxes.Single();
            var nested = container.Children.Single();

            Assert.Multiple(() =>
            {
                Assert.That(nested.SiriusElement, Is.SameAs(nestedSirius));
                Assert.That(nested.Parent, Is.SameAs(container), "the compartment is transparent in the box tree");
                Assert.That(nested.Position, Is.EqualTo(new Point(107, 136)), "the compartment's offset still accumulates");
            });
        }

        [Test]
        public void Verify_that_an_edge_routes_from_the_persisted_bendpoints_and_anchors()
        {
            var sourceSirius = new SiriusDiagram.DNode { Id = "src-1", Name = "source" };
            var targetSirius = new SiriusDiagram.DNode { Id = "tgt-1", Name = "target" };
            var edgeSirius = new SiriusDiagram.DEdge { Id = "e-1", Name = "flow", Target = new object() };

            var sourceNode = new Notation.Node { Id = "n-src", Element = sourceSirius };
            sourceNode.LayoutConstraint = new Notation.Bounds { X = 0, Y = 0, Width = 100, Height = 40 };

            var targetNode = new Notation.Node { Id = "n-tgt", Element = targetSirius };
            targetNode.LayoutConstraint = new Notation.Bounds { X = 300, Y = 200, Width = 60, Height = 20 };

            var notationEdge = new Notation.Edge
            {
                Id = "n-edge",
                Element = edgeSirius,
                Source = sourceNode,
                Target = targetNode,
                SourceAnchor = new Notation.IdentityAnchor { Id = "(0.0,0.5)" },
                TargetAnchor = new Notation.IdentityAnchor { Id = "(1.0,0.5)" },
                Bendpoints = new Notation.RelativeBendpoints { Points = "[2, 5, 51, 5]$[-49, 5, 0, 5]" },
            };

            var diagram = this.diagramBuilder.Build(Representation(new[] { sourceNode, targetNode }, new[] { notationEdge }));

            var edge = diagram.Edges.Single();

            Assert.Multiple(() =>
            {
                Assert.That(edge.Source!.SiriusElement, Is.SameAs(sourceSirius));
                Assert.That(edge.Target!.SiriusElement, Is.SameAs(targetSirius));
                Assert.That(edge.SiriusElement, Is.SameAs(edgeSirius));
                Assert.That(edge.SemanticElement, Is.SameAs(edgeSirius.Target));
                Assert.That(edge.Label!.Text, Is.EqualTo("flow"));

                // Source anchor (0.0, 0.5) of a 100x40 box at (0, 0) is (0, 20); leading bendpoints
                // resolve source-relative, and the final point glues to the target anchor —
                // (1.0, 0.5) of the 60x20 box at (300, 200) is (360, 210), plus the persisted
                // target-relative (0, 5).
                Assert.That(edge.Route, Is.EqualTo(new[] { new Point(2, 25), new Point(360, 215) }));
            });
        }

        [Test]
        public void Verify_that_an_edge_without_bendpoints_routes_anchor_to_anchor()
        {
            var sourceSirius = new SiriusDiagram.DNode { Id = "src-2", Name = "source" };
            var targetSirius = new SiriusDiagram.DNode { Id = "tgt-2", Name = "target" };

            var sourceNode = new Notation.Node { Id = "n-src2", Element = sourceSirius };
            sourceNode.LayoutConstraint = new Notation.Bounds { X = 10, Y = 10, Width = 20, Height = 20 };

            var targetNode = new Notation.Node { Id = "n-tgt2", Element = targetSirius };
            targetNode.LayoutConstraint = new Notation.Bounds { X = 110, Y = 10, Width = 20, Height = 20 };

            // No anchors and no bendpoints persisted: both ends default to the view centers.
            var notationEdge = new Notation.Edge { Id = "n-edge2", Source = sourceNode, Target = targetNode };

            var diagram = this.diagramBuilder.Build(Representation(new[] { sourceNode, targetNode }, new[] { notationEdge }));

            var edge = diagram.Edges.Single();

            Assert.Multiple(() =>
            {
                Assert.That(edge.Route, Is.EqualTo(new[] { new Point(20, 20), new Point(120, 20) }));
                Assert.That(edge.SiriusElement, Is.Null, "a notation edge without a Sirius element still routes");
                Assert.That(edge.Identifier, Is.EqualTo("n-edge2"), "the identifier falls back to the notation id");
                Assert.That(edge.Label, Is.Null);
            });
        }

        [Test]
        public void Verify_the_fallbacks_for_malformed_and_unmapped_geometry()
        {
            var targetSirius = new SiriusDiagram.DNode { Id = "tgt-3", Name = "target" };

            var targetNode = new Notation.Node { Id = "n-tgt3", Element = targetSirius };
            targetNode.LayoutConstraint = new Notation.Bounds { X = 50, Y = 50, Width = 10, Height = 10 };

            // The source view is an auxiliary node at diagram level: it maps to no box, so the route
            // falls back to the target-relative bendpoint offsets; the malformed target anchor falls
            // back to the view center.
            var auxiliarySource = new Notation.Node { Id = "n-aux" };

            var withBendpoints = new Notation.Edge
            {
                Id = "n-edge3",
                Source = auxiliarySource,
                Target = targetNode,
                TargetAnchor = new Notation.IdentityAnchor { Id = "not-a-fraction" },
                Bendpoints = new Notation.RelativeBendpoints { Points = "[1, 2, -5, -10]$garbage$[not,numbers,at,all]" },
            };

            // Neither end maps to a box and no bendpoints parse: the route is empty.
            var unroutable = new Notation.Edge { Id = "n-edge4", Source = auxiliarySource, Bendpoints = new Notation.RelativeBendpoints() };

            var diagram = this.diagramBuilder.Build(Representation(new[] { auxiliarySource, targetNode }, new[] { withBendpoints, unroutable }));

            Assert.Multiple(() =>
            {
                // Target center (55, 55) plus the single well-formed target-relative offset (-5, -10).
                Assert.That(diagram.Edges[0].Route, Is.EqualTo(new[] { new Point(50, 45) }));
                Assert.That(diagram.Edges[0].Source, Is.Null, "a diagram-level auxiliary view maps to no box");
                Assert.That(diagram.Edges[1].Route, Is.Empty);
                Assert.That(diagram.Boxes, Has.Count.EqualTo(1), "the auxiliary node contributes no box");
            });
        }

        [Test]
        public void Verify_that_styles_are_carried_from_both_models()
        {
            var siriusStyle = new SiriusDiagram.FlatContainerStyle { Id = "s-1" };
            var containerSirius = new SiriusDiagram.DNodeContainer { Id = "c-2", Name = "styled", OwnedStyle = siriusStyle };

            var fontStyle = new Notation.FontStyle { FontName = "Ubuntu" };
            var node = new Notation.Node { Id = "n-styled", Element = containerSirius };
            node.Styles.Add(fontStyle);

            var diagram = this.diagramBuilder.Build(Representation(node));

            var box = diagram.Boxes.Single();

            Assert.Multiple(() =>
            {
                Assert.That(box.Style.SiriusStyle, Is.SameAs(siriusStyle));
                Assert.That(box.Style.NotationStyles, Is.EqualTo(new[] { fontStyle }));
            });
        }

        /// <summary>
        /// Wraps the supplied top-level notation nodes and edges in a representation carrying its
        /// GMF notation diagram, the shape the builder consumes.
        /// </summary>
        /// <param name="nodes">the top-level notation nodes</param>
        /// <param name="edges">the notation edges</param>
        /// <returns>the Sirius representation</returns>
        private static SiriusDiagram.DSemanticDiagram Representation(Notation.INode[] nodes, Notation.Edge[]? edges = null)
        {
            var notationDiagram = new Notation.Diagram { Id = "notation-1" };

            foreach (var node in nodes)
            {
                notationDiagram.PersistedChildren.Add(node);
            }

            foreach (var edge in edges ?? System.Array.Empty<Notation.Edge>())
            {
                notationDiagram.PersistedEdges.Add(edge);
            }

            var representation = new SiriusDiagram.DSemanticDiagram { Id = "rep-1" };
            representation.OwnedAnnotationEntries.Add(new SiriusDescription.AnnotationEntry
            {
                Source = "GMF_DIAGRAMS",
                Data = notationDiagram,
            });

            return representation;
        }

        /// <summary>
        /// Wraps a single top-level notation node in a representation.
        /// </summary>
        /// <param name="node">the top-level notation node</param>
        /// <returns>the Sirius representation</returns>
        private static SiriusDiagram.DSemanticDiagram Representation(Notation.INode node)
        {
            return Representation(new[] { node });
        }
    }
}
