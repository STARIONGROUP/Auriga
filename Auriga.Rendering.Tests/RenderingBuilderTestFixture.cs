// ------------------------------------------------------------------------------------------------
// <copyright file="RenderingBuilderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using Notation = Auriga.Diagram.Notation;
    using SiriusDescription = Auriga.Diagram.Viewpoint.Description;
    using SiriusDiagram = Auriga.Diagram.Diagram;

    /// <summary>
    /// Tests the composition root: <see cref="RenderingBuilder.Create"/> wires the full default graph,
    /// each fluent override actually reaches the service that consumes it (a substituted icon registry
    /// is called by the exporter, a substituted palette seeds the resolved styles), the terminals hand
    /// out the composed singletons, and disposing the scope disposes what it built.
    /// </summary>
    [TestFixture]
    public class RenderingBuilderTestFixture
    {
        [Test]
        public void Verify_that_the_default_scope_composes_the_whole_graph()
        {
            using var scope = RenderingBuilder.Create();

            var diagram = scope.BuildDiagramBuilder().Build(Representation(Node("node-1", "composed", 10, 20)), "composed");

            Assert.Multiple(() =>
            {
                Assert.That(diagram.Name, Is.EqualTo("composed"));
                Assert.That(diagram.Boxes, Has.Count.EqualTo(1));
                Assert.That(diagram.Boxes[0].Position, Is.EqualTo(new Point(10, 20)), "the node diagram builder ran");
                Assert.That(diagram.Boxes[0].Style.Resolved, Is.Not.Null, "the style resolver ran");
                Assert.That(scope.BuildSvgExporter().Export(diagram), Does.Contain("<svg"));
                Assert.That(scope.BuildTableBuilder(), Is.Not.Null);
                Assert.That(scope.BuildXlsxTableExporter(), Is.Not.Null);
            });
        }

        [Test]
        public void Verify_that_the_terminals_hand_out_the_same_singleton_within_a_scope()
        {
            using var scope = RenderingBuilder.Create();

            Assert.Multiple(() =>
            {
                Assert.That(scope.BuildDiagramBuilder(), Is.SameAs(scope.BuildDiagramBuilder()));
                Assert.That(scope.BuildTableBuilder(), Is.SameAs(scope.BuildTableBuilder()));
                Assert.That(scope.BuildSvgExporter(), Is.SameAs(scope.BuildSvgExporter()));
                Assert.That(scope.BuildXlsxTableExporter(), Is.SameAs(scope.BuildXlsxTableExporter()));
            });
        }

        [Test]
        public void Verify_that_a_substituted_icon_registry_is_the_one_the_exporter_calls()
        {
            var registry = new RecordingIconRegistry();

            using var scope = RenderingBuilder.Create().UsingIconRegistry(registry);

            var node = Node("node-image", "imaged", 0, 0);
            node.Element = new SiriusDiagram.DNode
            {
                Id = "sirius-image",
                Name = "imaged",
                OwnedStyle = new SiriusDiagram.WorkspaceImage { WorkspacePath = "Some Project/images/Substituted.svg" },
            };
            node.LayoutConstraint = new Notation.Bounds { X = 0, Y = 0, Width = 40, Height = 40 };

            var diagram = scope.BuildDiagramBuilder().Build(Representation(node));
            var svg = scope.BuildSvgExporter().Export(diagram);

            Assert.Multiple(() =>
            {
                Assert.That(registry.Requested, Does.Contain("Some Project/images/Substituted.svg"), "the exporter resolved through the substituted registry");
                Assert.That(svg, Does.Contain(RecordingIconRegistry.Content), "and rendered what that registry returned");
            });
        }

        [Test]
        public void Verify_that_a_substituted_palette_seeds_the_resolved_styles()
        {
            using var defaultScope = RenderingBuilder.Create();
            using var scope = RenderingBuilder.Create().UsingPalette(new GreenPalette());

            var representation = Representation(Node("node-palette", "palette", 0, 0));

            var fallback = defaultScope.BuildDiagramBuilder().Build(representation).Boxes[0].Style.Resolved;
            var substituted = scope.BuildDiagramBuilder().Build(representation).Boxes[0].Style.Resolved;

            Assert.Multiple(() =>
            {
                Assert.That(substituted.StrokeColor, Is.EqualTo(GreenPalette.Green), "the substituted palette seeded the box default");
                Assert.That(fallback.StrokeColor, Is.Not.EqualTo(GreenPalette.Green), "the Capella default palette does not");
            });
        }

        [Test]
        public void Verify_that_a_substituted_style_resolver_reaches_the_per_kind_builders()
        {
            var styleResolver = new RecordingStyleResolver();

            using var scope = RenderingBuilder.Create().UsingStyleResolver(styleResolver);

            scope.BuildDiagramBuilder().Build(Representation(Node("node-style", "styled", 0, 0)));

            Assert.That(styleResolver.BoxCalls, Is.GreaterThan(0), "the node diagram builder resolved through the substituted resolver");
        }

        [Test]
        public void Verify_that_the_fluent_methods_guard_their_arguments()
        {
            using var scope = RenderingBuilder.Create();

            Assert.Multiple(() =>
            {
                Assert.That(() => ((RenderingScope)null!).WithLogger(NullLoggerFactory.Instance), Throws.ArgumentNullException);
                Assert.That(() => scope.WithLogger(null!), Throws.ArgumentNullException);
                Assert.That(() => ((RenderingScope)null!).UsingIconRegistry(new RecordingIconRegistry()), Throws.ArgumentNullException);
                Assert.That(() => scope.UsingIconRegistry(null!), Throws.ArgumentNullException);
                Assert.That(() => ((RenderingScope)null!).UsingPalette(new GreenPalette()), Throws.ArgumentNullException);
                Assert.That(() => scope.UsingPalette(null!), Throws.ArgumentNullException);
                Assert.That(() => ((RenderingScope)null!).UsingStyleResolver(new RecordingStyleResolver()), Throws.ArgumentNullException);
                Assert.That(() => scope.UsingStyleResolver(null!), Throws.ArgumentNullException);
                Assert.That(() => ((RenderingScope)null!).BuildDiagramBuilder(), Throws.ArgumentNullException);
                Assert.That(() => ((RenderingScope)null!).BuildTableBuilder(), Throws.ArgumentNullException);
                Assert.That(() => ((RenderingScope)null!).BuildSvgExporter(), Throws.ArgumentNullException);
                Assert.That(() => ((RenderingScope)null!).BuildXlsxTableExporter(), Throws.ArgumentNullException);
            });
        }

        [Test]
        public void Verify_that_a_scope_disposes_cleanly_whether_or_not_it_built_anything()
        {
            var unused = RenderingBuilder.Create();
            var used = RenderingBuilder.Create().WithLogger(NullLoggerFactory.Instance);
            used.BuildDiagramBuilder();

            Assert.Multiple(() =>
            {
                Assert.That(() => unused.Dispose(), Throws.Nothing, "a scope no terminal ever ran on disposes");
                Assert.That(() => used.Dispose(), Throws.Nothing);
                Assert.That(() => used.BuildDiagramBuilder(), Throws.InstanceOf<ObjectDisposedException>(), "the disposed container hands out nothing more");
            });
        }

        /// <summary>
        /// Builds a top-level notation node at the supplied position.
        /// </summary>
        /// <param name="identifier">the notation identifier</param>
        /// <param name="name">the Sirius element name</param>
        /// <param name="x">the persisted x coordinate</param>
        /// <param name="y">the persisted y coordinate</param>
        /// <returns>the notation node</returns>
        private static Notation.Node Node(string identifier, string name, int x, int y)
        {
            return new Notation.Node
            {
                Id = identifier,
                Element = new SiriusDiagram.DNode { Id = $"sirius-{identifier}", Name = name },
                LayoutConstraint = new Notation.Bounds { X = x, Y = y, Width = 40, Height = 20 },
            };
        }

        /// <summary>
        /// Wraps the supplied top-level notation node in a representation carrying its GMF notation
        /// diagram, the shape the builder consumes.
        /// </summary>
        /// <param name="node">the top-level notation node</param>
        /// <returns>the Sirius representation</returns>
        private static SiriusDiagram.DSemanticDiagram Representation(Notation.INode node)
        {
            var notationDiagram = new Notation.Diagram { Id = "notation-scope" };
            notationDiagram.PersistedChildren.Add(node);

            var representation = new SiriusDiagram.DSemanticDiagram { Id = "rep-scope" };
            representation.OwnedAnnotationEntries.Add(new SiriusDescription.AnnotationEntry
            {
                Source = "GMF_DIAGRAMS",
                Data = notationDiagram,
            });

            return representation;
        }

        /// <summary>
        /// An <see cref="IIconRegistry"/> that records what it was asked for and always answers, so a
        /// test can tell whether the exporter really went through the registered registry.
        /// </summary>
        private sealed class RecordingIconRegistry : IIconRegistry
        {
            /// <summary>
            /// The data URI this registry answers every request with.
            /// </summary>
            internal const string Content = "data:image/svg+xml;base64,c3Vic3RpdHV0ZWQ=";

            /// <summary>
            /// Gets the workspace-image paths the registry was asked to resolve.
            /// </summary>
            internal List<string> Requested { get; } = new List<string>();

            /// <summary>
            /// Records the request and answers with <see cref="Content"/>.
            /// </summary>
            /// <param name="workspacePath">the workspace-image path</param>
            /// <returns>the substituted data URI</returns>
            public string? Resolve(string workspacePath)
            {
                this.Requested.Add(workspacePath);
                return Content;
            }
        }

        /// <summary>
        /// A palette whose stroke differs from every Capella default, so a test can tell which palette
        /// seeded a resolved style.
        /// </summary>
        private sealed class GreenPalette : ICapellaDefaultPalette
        {
            /// <summary>
            /// The stroke color this palette hands out, distinct from the Capella defaults.
            /// </summary>
            internal static readonly Color Green = new(0, 128, 0);

            /// <summary>
            /// The default visual properties of a box: no fill, and the substituted stroke.
            /// </summary>
            /// <param name="semanticTypeName">the Capella semantic element's type name, or <c>null</c></param>
            /// <returns>the default fill and stroke</returns>
            public (Color? Fill, Color Stroke) ForBox(string? semanticTypeName)
            {
                return (null, Green);
            }

            /// <summary>
            /// The default visual properties of an edge: the substituted stroke, at unit width.
            /// </summary>
            /// <param name="semanticTypeName">the Capella semantic element's type name, or <c>null</c></param>
            /// <returns>the default stroke and stroke width</returns>
            public (Color Stroke, double Width) ForEdge(string? semanticTypeName)
            {
                return (Green, 1);
            }
        }

        /// <summary>
        /// An <see cref="IStyleResolver"/> that counts the boxes it resolved, so a test can tell
        /// whether the per-kind builders were composed over the registered resolver.
        /// </summary>
        private sealed class RecordingStyleResolver : IStyleResolver
        {
            /// <summary>
            /// The resolver the recorder delegates to, so the diagrams it produces stay usable.
            /// </summary>
            private readonly StyleResolver inner = new(new CapellaDefaultPalette());

            /// <summary>
            /// Gets the number of boxes the resolver was asked to resolve.
            /// </summary>
            internal int BoxCalls { get; private set; }

            /// <summary>
            /// Counts the call and delegates to the default resolver.
            /// </summary>
            /// <param name="box">the box to resolve</param>
            /// <returns>the resolved style</returns>
            public ResolvedStyle Resolve(Box box)
            {
                this.BoxCalls++;
                return this.inner.Resolve(box);
            }

            /// <summary>
            /// Delegates to the default resolver.
            /// </summary>
            /// <param name="edge">the edge to resolve</param>
            /// <returns>the resolved style</returns>
            public ResolvedStyle Resolve(Edge edge)
            {
                return this.inner.Resolve(edge);
            }
        }
    }
}
