// ------------------------------------------------------------------------------------------------
// <copyright file="SvgExporterTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using NUnit.Framework;

    using Notation = Auriga.Diagram.Notation;
    using SiriusDiagram = Auriga.Diagram.Diagram;

    /// <summary>
    /// Tests the <see cref="SvgExporter"/> against hand-built intermediate models: the generated
    /// document structure (rects, nested groups, paths, labels, tspan wrapping), the on-demand
    /// defs (gradients, arrow markers, deduplicated), the padded view box, XML escaping and the
    /// export overloads.
    /// </summary>
    [TestFixture]
    public class SvgExporterTestFixture
    {
        private static readonly XNamespace Svg = "http://www.w3.org/2000/svg";

        [Test]
        public void Verify_that_the_exporter_guards_its_arguments()
        {
            var diagram = Diagram(new List<Box>(), new List<Edge>());

            Assert.Multiple(() =>
            {
                Assert.That(() => SvgExporter.Export(null!), Throws.ArgumentNullException);
                Assert.That(() => SvgExporter.Export(null!, new MemoryStream()), Throws.ArgumentNullException);
                Assert.That(() => SvgExporter.Export(diagram, (Stream)null!), Throws.ArgumentNullException);
                Assert.That(() => SvgExporter.ExportToFile(diagram, string.Empty), Throws.ArgumentException);
                Assert.That(() => SvgExporter.ExportToFile(null!, "out.svg"), Throws.ArgumentNullException);
            });
        }

        [Test]
        public void Verify_that_a_box_renders_as_a_styled_rect_with_nested_children()
        {
            var child = MakeBox("child", 110, 70, 30, 20);
            child.Style.Resolved.FillColor = null;

            var parent = MakeBox("parent", 100, 50, 200, 120);
            parent.Style.Resolved.FillColor = new Color(150, 177, 218);
            parent.Style.Resolved.StrokeColor = new Color(74, 74, 151);
            parent.Style.Resolved.StrokeWidth = 2;
            parent.Style.Resolved.Pattern = LinePattern.Dash;
            parent.Add(child);

            var document = XDocument.Parse(SvgExporter.Export(Diagram(new List<Box> { parent }, new List<Edge>())));

            var parentGroup = document.Root!.Element(Svg + "g")!.Elements(Svg + "g").Single(g => (string?)g.Attribute("id") == "parent");
            var rect = parentGroup.Element(Svg + "rect")!;
            var childGroup = parentGroup.Elements(Svg + "g").Single(g => (string?)g.Attribute("id") == "child");

            Assert.Multiple(() =>
            {
                Assert.That((string?)rect.Attribute("x"), Is.EqualTo("100"));
                Assert.That((string?)rect.Attribute("y"), Is.EqualTo("50"));
                Assert.That((string?)rect.Attribute("width"), Is.EqualTo("200"));
                Assert.That((string?)rect.Attribute("height"), Is.EqualTo("120"));
                Assert.That((string?)rect.Attribute("fill"), Is.EqualTo("#96B1DA"));
                Assert.That((string?)rect.Attribute("stroke"), Is.EqualTo("#4A4A97"));
                Assert.That((string?)rect.Attribute("stroke-width"), Is.EqualTo("2"));
                Assert.That((string?)rect.Attribute("stroke-dasharray"), Is.EqualTo("5 3"));

                Assert.That((string?)childGroup.Element(Svg + "rect")!.Attribute("fill"), Is.EqualTo("none"), "an unfilled child renders inside its parent's group");
            });
        }

        [Test]
        public void Verify_that_labels_render_centered_or_at_their_persisted_geometry()
        {
            var centered = MakeBox("centered", 0, 0, 100, 40);
            centered.Label = new Label("centered label");

            var positioned = MakeBox("positioned", 200, 0, 100, 40);
            positioned.Label = new Label("a label that is long enough to wrap over lines")
            {
                Position = new Point(205, 45),
                Width = 60,
            };

            var document = XDocument.Parse(SvgExporter.Export(Diagram(new List<Box> { centered, positioned }, new List<Edge>())));
            var texts = document.Descendants(Svg + "text").ToList();

            Assert.Multiple(() =>
            {
                var centeredText = texts.Single(t => t.Value == "centered label");
                Assert.That((string?)centeredText.Attribute("text-anchor"), Is.EqualTo("middle"));
                Assert.That((string?)centeredText.Attribute("x"), Is.EqualTo("50"));

                var wrapped = texts.Single(t => t.Elements(Svg + "tspan").Any());
                Assert.That((string?)wrapped.Attribute("text-anchor"), Is.EqualTo("start"));
                Assert.That(wrapped.Elements(Svg + "tspan").Count(), Is.GreaterThan(1), "the narrow label wraps into tspan lines");
                Assert.That(wrapped.Elements(Svg + "tspan").Skip(1), Has.All.Matches<XElement>(t => (string?)t.Attribute("dy") == "1.2em"));
            });
        }

        [Test]
        public void Verify_that_an_edge_renders_as_a_marked_path_with_its_label()
        {
            var edge = MakeEdge("flow", new[] { new Point(0, 20), new Point(50, 20), new Point(50, 80) });
            edge.Label = new Label("flow label");
            edge.Style.Resolved.StrokeColor = new Color(114, 73, 110);
            edge.Style.Resolved.Pattern = LinePattern.Dot;
            edge.Style.Resolved.TargetArrow = SiriusDiagram.EdgeArrows.InputArrow;

            var document = XDocument.Parse(SvgExporter.Export(Diagram(new List<Box>(), new List<Edge> { edge })));

            var path = document.Descendants(Svg + "path").Single(p => p.Parent!.Name.LocalName == "g" && (string?)p.Parent.Attribute("id") == "flow");
            var marker = document.Descendants(Svg + "marker").Single();

            Assert.Multiple(() =>
            {
                Assert.That((string?)path.Attribute("d"), Is.EqualTo("M 0 20 L 50 20 L 50 80"));
                Assert.That((string?)path.Attribute("stroke"), Is.EqualTo("#72496E"));
                Assert.That((string?)path.Attribute("stroke-dasharray"), Is.EqualTo("1 3"));
                Assert.That((string?)path.Attribute("fill"), Is.EqualTo("none"));
                Assert.That((string?)path.Attribute("marker-end"), Is.EqualTo("url(#marker-arrow-72496e)"));
                Assert.That((string?)marker.Attribute("id"), Is.EqualTo("marker-arrow-72496e"));

                var label = document.Descendants(Svg + "text").Single();
                Assert.That(label.Value, Is.EqualTo("flow label"));
                Assert.That((string?)label.Attribute("text-anchor"), Is.EqualTo("middle"));
            });
        }

        [Test]
        public void Verify_that_gradients_and_markers_are_defined_once()
        {
            var first = MakeBox("first", 0, 0, 10, 10);
            first.Style.Resolved.FillColor = new Color(249, 248, 245);
            first.Style.Resolved.GradientColor = new Color(242, 238, 225);

            var second = MakeBox("second", 20, 0, 10, 10);
            second.Style.Resolved.FillColor = new Color(249, 248, 245);
            second.Style.Resolved.GradientColor = new Color(242, 238, 225);

            var edges = new[] { "e1", "e2" }
                .Select(id =>
                {
                    var edge = MakeEdge(id, new[] { new Point(0, 0), new Point(10, 10) });
                    edge.Style.Resolved.TargetArrow = SiriusDiagram.EdgeArrows.InputFillClosedArrow;
                    return edge;
                })
                .ToList();

            var document = XDocument.Parse(SvgExporter.Export(Diagram(new List<Box> { first, second }, edges)));

            Assert.Multiple(() =>
            {
                Assert.That(document.Descendants(Svg + "linearGradient").Count(), Is.EqualTo(1), "one gradient def for the shared color pair");
                Assert.That(document.Descendants(Svg + "marker").Count(), Is.EqualTo(1), "one marker def for the shared shape+color");
                Assert.That(document.Descendants(Svg + "rect").Select(r => (string?)r.Attribute("fill")), Has.All.EqualTo("url(#gradient-f9f8f5-f2eee1)"));
            });
        }

        [Test]
        public void Verify_the_view_box_and_the_escaping()
        {
            var box = MakeBox("only", 100, 50, 200, 100);
            box.Label = new Label("A <B> & C");

            var text = SvgExporter.Export(Diagram(new List<Box> { box }, new List<Edge>()));
            var document = XDocument.Parse(text);

            Assert.Multiple(() =>
            {
                // Bounding box (100,50)-(300,150) padded by 20 on each side.
                Assert.That((string?)document.Root!.Attribute("viewBox"), Is.EqualTo("80 30 240 140"));
                Assert.That((string?)document.Root.Attribute("width"), Is.EqualTo("240"));
                Assert.That((string?)document.Root.Attribute("height"), Is.EqualTo("140"));

                Assert.That(text, Contains.Substring("&lt;B&gt; &amp; C"), "reserved characters escape");
                Assert.That(document.Descendants(Svg + "text").Single().Value, Is.EqualTo("A <B> & C"));
            });
        }

        [Test]
        public void Verify_the_stream_and_file_overloads()
        {
            var box = MakeBox("box", 0, 0, 10, 10);
            var diagram = Diagram(new List<Box> { box }, new List<Edge>());

            using var stream = new MemoryStream();
            SvgExporter.Export(diagram, stream);
            stream.Position = 0;

            var path = Path.Combine(TestContext.CurrentContext.WorkDirectory, "svg-exporter-test.svg");
            SvgExporter.ExportToFile(diagram, path);

            Assert.Multiple(() =>
            {
                Assert.That(XDocument.Load(stream).Root!.Name.LocalName, Is.EqualTo("svg"));
                Assert.That(File.Exists(path), Is.True);
                Assert.That(XDocument.Load(path).Root!.Name.LocalName, Is.EqualTo("svg"));
            });

            File.Delete(path);
        }

        /// <summary>
        /// Builds an intermediate diagram over empty Sirius/notation carriers.
        /// </summary>
        /// <param name="boxes">the top-level boxes</param>
        /// <param name="edges">the edges</param>
        /// <returns>the diagram</returns>
        private static Diagram Diagram(IReadOnlyList<Box> boxes, IReadOnlyList<Edge> edges)
        {
            return new Diagram("diagram", boxes, edges, new SiriusDiagram.DSemanticDiagram(), new Notation.Diagram());
        }

        /// <summary>
        /// Builds a box with the supplied geometry and a default resolved style.
        /// </summary>
        /// <param name="identifier">the box identifier</param>
        /// <param name="x">the absolute x coordinate</param>
        /// <param name="y">the absolute y coordinate</param>
        /// <param name="width">the width</param>
        /// <param name="height">the height</param>
        /// <returns>the box</returns>
        private static Box MakeBox(string identifier, double x, double y, double? width, double? height)
        {
            return new Box(identifier, new Point(x, y), new Notation.Node(), new Style(null, new List<Notation.IStyle>()))
            {
                Width = width,
                Height = height,
            };
        }

        /// <summary>
        /// Builds an edge with the supplied route and a default resolved style.
        /// </summary>
        /// <param name="identifier">the edge identifier</param>
        /// <param name="route">the absolute route</param>
        /// <returns>the edge</returns>
        private static Edge MakeEdge(string identifier, IReadOnlyList<Point> route)
        {
            return new Edge(identifier, route, new Notation.Edge(), new Style(null, new List<Notation.IStyle>()));
        }
    }
}
