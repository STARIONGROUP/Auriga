// ------------------------------------------------------------------------------------------------
// <copyright file="TooltipTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using NUnit.Framework;

    using Notation = Auriga.Diagram.Notation;
    using SiriusDescription = Auriga.Diagram.Viewpoint.Description;
    using SiriusDiagram = Auriga.Diagram.Diagram;

    /// <summary>
    /// Tests the hover tooltips: what a built item says about itself — the semantic element's type
    /// and name, the model's own description reduced to plain text, and the fallbacks for a
    /// diagram-only session and a pure notation element — and that the SVG exporter emits it as the
    /// group's <c>title</c>, the native tooltip of a browser or SVG viewer, without any scripting.
    /// </summary>
    [TestFixture]
    public class TooltipTestFixture : RenderingTestFixtureBase
    {
        private static readonly XNamespace Svg = "http://www.w3.org/2000/svg";

        [Test]
        public void Verify_that_a_semantic_element_names_itself_and_carries_its_description()
        {
            var function = new Auriga.Model.La.LogicalFunction
            {
                Id = "fn-1",
                Name = "Broadcast Audio Video Streams",
                Description = "<p>Streams the <b>audio</b> and video&nbsp;content.</p>\r\n<p>Second paragraph.</p>",
            };

            var diagram = this.DiagramBuilder.Build(Representation(Node("n-fn", "Broadcast Audio Video Streams", function)));

            Assert.That(
                diagram.Boxes.Single().Tooltip,
                Is.EqualTo("LogicalFunction: Broadcast Audio Video Streams\nStreams the audio and video content. Second paragraph."),
                "the heading names what the box represents and the description follows as plain text");
        }

        [Test]
        public void Verify_that_the_tooltip_falls_back_to_the_sirius_element_and_the_notation_type()
        {
            var diagramOnly = this.DiagramBuilder.Build(Representation(Node("n-unresolved", "Unresolved Target", semanticElement: null)));

            var note = new Notation.Shape { Id = "note-tip", Type = "Note", Description = "A sticky note" };
            note.LayoutConstraint = new Notation.Bounds { X = 0, Y = 0, Width = 120, Height = 60 };
            var notes = this.DiagramBuilder.Build(Representation(note));

            Assert.Multiple(() =>
            {
                Assert.That(
                    diagramOnly.Boxes.Single().Tooltip,
                    Is.EqualTo("DNode: Unresolved Target"),
                    "a session without its semantic model still names the element the diagram shows");
                Assert.That(notes.Boxes.Single().Tooltip, Is.EqualTo("Note"), "a pure notation element names its notation type");
            });
        }

        [Test]
        public void Verify_that_the_persisted_sirius_tooltip_serves_when_there_is_no_description()
        {
            var node = Node("n-tooltiptext", "Described by Sirius", semanticElement: null);
            ((SiriusDiagram.DNode)node.Element!).TooltipText = "  what Sirius persisted  ";

            var diagram = this.DiagramBuilder.Build(Representation(node));

            Assert.That(diagram.Boxes.Single().Tooltip, Is.EqualTo("DNode: Described by Sirius\nwhat Sirius persisted"));
        }

        [Test]
        public void Verify_that_a_synthetic_artifact_has_no_tooltip_and_renders_no_title()
        {
            var listElement = new SiriusDiagram.DNodeListElement { Id = "item-1", Name = "attribute : String" };
            var itemNode = new Notation.Node { Id = "n-item", Element = listElement };
            itemNode.LayoutConstraint = new Notation.Bounds { X = 0, Y = 20, Width = 100, Height = 14 };

            var listSirius = new SiriusDiagram.DNodeList { Id = "list-1", Name = "AudioStream" };
            var listNode = new Notation.Node { Id = "n-list", Element = listSirius };
            listNode.LayoutConstraint = new Notation.Bounds { X = 0, Y = 0, Width = -1, Height = -1 };
            listNode.PersistedChildren.Add(itemNode);

            var diagram = this.DiagramBuilder.Build(Representation(listNode));
            var document = XDocument.Parse(this.SvgExporter.Export(diagram));

            var container = diagram.Boxes.Single();
            var separator = container.Children.Single(child => child.Identifier.EndsWith("-title-separator"));
            var separatorGroup = document.Descendants(Svg + "g").Single(group => (string?)group.Attribute("id") == separator.Identifier);

            Assert.Multiple(() =>
            {
                Assert.That(separator.Tooltip, Is.Null, "the synthesized title rule represents nothing in the model");
                Assert.That(separatorGroup.Element(Svg + "title"), Is.Null, "so its group carries no title element");
                Assert.That(container.Tooltip, Is.EqualTo("DNodeList: AudioStream"), "while the container it belongs to still names itself");
            });
        }

        [Test]
        public void Verify_that_the_exporter_renders_the_tooltip_as_the_groups_first_child()
        {
            var exchange = new Auriga.Model.Fa.ComponentExchange { Id = "cex-1", Name = "Audio Stream", Description = "<div>Carries the stream</div>" };

            var sourceNode = Node("n-src-tip", "source", semanticElement: null);
            sourceNode.LayoutConstraint = new Notation.Bounds { X = 0, Y = 0, Width = 60, Height = 40 };
            var targetNode = Node("n-tgt-tip", "target", semanticElement: null);
            targetNode.LayoutConstraint = new Notation.Bounds { X = 200, Y = 0, Width = 60, Height = 40 };

            var notationEdge = new Notation.Edge
            {
                Id = "n-edge-tip",
                Element = new SiriusDiagram.DEdge { Id = "e-tip", Name = "Audio Stream", Target = exchange },
                Source = sourceNode,
                Target = targetNode,
            };

            var diagram = this.DiagramBuilder.Build(Representation(new Notation.INode[] { sourceNode, targetNode }, new[] { notationEdge }));
            var document = XDocument.Parse(this.SvgExporter.Export(diagram));

            var boxGroup = document.Descendants(Svg + "g").Single(group => (string?)group.Attribute("id") == "sirius-n-src-tip");
            var edgeGroup = document.Descendants(Svg + "g").Single(group => (string?)group.Attribute("id") == "e-tip");

            Assert.Multiple(() =>
            {
                Assert.That(edgeGroup.Elements().First().Name, Is.EqualTo(Svg + "title"), "the title is the group's first child");
                Assert.That(edgeGroup.Element(Svg + "title")!.Value, Is.EqualTo("ComponentExchange: Audio Stream\nCarries the stream"));
                Assert.That(boxGroup.Elements().First().Name, Is.EqualTo(Svg + "title"), "and so it is on a box group");
                Assert.That(boxGroup.Element(Svg + "title")!.Value, Is.EqualTo("DNode: source"));
                Assert.That(document.Descendants(Svg + "script"), Is.Empty, "the export stays script-free");
            });
        }

        /// <summary>
        /// Builds a top-level notation node displaying a named Sirius node, optionally resolved to a
        /// Capella semantic element.
        /// </summary>
        /// <param name="identifier">the notation identifier</param>
        /// <param name="name">the Sirius element name</param>
        /// <param name="semanticElement">the Capella semantic element the Sirius element targets, or <c>null</c></param>
        /// <returns>the notation node</returns>
        private static Notation.Node Node(string identifier, string name, object? semanticElement)
        {
            return new Notation.Node
            {
                Id = identifier,
                Element = new SiriusDiagram.DNode { Id = $"sirius-{identifier}", Name = name, Target = semanticElement },
                LayoutConstraint = new Notation.Bounds { X = 0, Y = 0, Width = 80, Height = 40 },
            };
        }

        /// <summary>
        /// Wraps the supplied top-level notation nodes in a representation carrying their GMF
        /// notation diagram, the shape the builder consumes.
        /// </summary>
        /// <param name="nodes">the top-level notation nodes</param>
        /// <param name="edges">the notation edges, if any</param>
        /// <returns>the Sirius representation</returns>
        private static SiriusDiagram.DSemanticDiagram Representation(IEnumerable<Notation.INode> nodes, IEnumerable<Notation.IEdge>? edges = null)
        {
            var notationDiagram = new Notation.Diagram { Id = "notation-tooltip" };

            foreach (var node in nodes)
            {
                notationDiagram.PersistedChildren.Add(node);
            }

            foreach (var edge in edges ?? Enumerable.Empty<Notation.IEdge>())
            {
                notationDiagram.PersistedEdges.Add(edge);
            }

            var representation = new SiriusDiagram.DSemanticDiagram { Id = "rep-tooltip" };
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
