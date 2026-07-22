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
    using System.Globalization;
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

        /// <summary>
        /// The exporter under test.
        /// </summary>
        private readonly SvgExporter svgExporter = new();

        [Test]
        public void Verify_that_the_exporter_guards_its_arguments()
        {
            var diagram = Diagram(new List<Box>(), new List<Edge>());

            Assert.Multiple(() =>
            {
                Assert.That(() => new SvgExporter(null!), Throws.ArgumentNullException);
                Assert.That(() => this.svgExporter.Export(null!), Throws.ArgumentNullException);
                Assert.That(() => this.svgExporter.Export(null!, new MemoryStream()), Throws.ArgumentNullException);
                Assert.That(() => this.svgExporter.Export(diagram, (Stream)null!), Throws.ArgumentNullException);
                Assert.That(() => this.svgExporter.ExportToFile(diagram, string.Empty), Throws.ArgumentException);
                Assert.That(() => this.svgExporter.ExportToFile(null!, "out.svg"), Throws.ArgumentNullException);
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

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { parent }, new List<Edge>())));

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
        public void Verify_that_the_capella_icon_registry_resolves_vendored_artwork()
        {
            var registry = new CapellaIconRegistry();

            Assert.Multiple(() =>
            {
                Assert.That(
                    registry.Resolve("/org.polarsys.capella.core.sirius.analysis/description/images/Capability.svg"),
                    Does.StartWith("data:image/svg+xml;base64,"));
                Assert.That(
                    registry.Resolve("/org.polarsys.capella.core.sirius.analysis/icons/full/obj16/Blank.gif"),
                    Does.StartWith("data:image/gif;base64,"));
                Assert.That(registry.Resolve("Class.png"), Does.StartWith("data:image/png;base64,"), "the metaclass icon set");
                Assert.That(registry.Resolve("/some.plugin/images/NotVendored.svg"), Is.Null);
                Assert.That(registry.Resolve(string.Empty), Is.Null);
            });
        }

        [Test]
        public void Verify_that_a_workspace_image_box_renders_as_an_inlined_image()
        {
            var actor = MakeBox("actor", 20, 274, 70, 61);
            actor.Label = new Label("Cabin Crew") { Position = new Point(91, 322) };
            actor.Style.Resolved.ImagePath = "/org.polarsys.capella.core.sirius.analysis/description/images/Actor.svg";

            var unresolved = MakeBox("unresolved", 150, 274, 70, 61);
            unresolved.Style.Resolved.ImagePath = "Some Project/images/custom.png";

            var lifeline = MakeBox("lifeline", 100, 0, 1, 200);
            lifeline.Style.Resolved.Shape = ShapeKind.Line;
            lifeline.Style.Resolved.ImagePath = "/org.polarsys.capella.core.sirius.analysis/description/images/handlelifeline.svg";

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { actor, unresolved, lifeline }, new List<Edge>())));

            var actorGroup = document.Descendants(Svg + "g").Single(g => (string?)g.Attribute("id") == "actor");
            var image = actorGroup.Element(Svg + "image")!;
            var unresolvedGroup = document.Descendants(Svg + "g").Single(g => (string?)g.Attribute("id") == "unresolved");
            var lifelineGroup = document.Descendants(Svg + "g").Single(g => (string?)g.Attribute("id") == "lifeline");

            Assert.Multiple(() =>
            {
                Assert.That((string?)image.Attribute("x"), Is.EqualTo("20"));
                Assert.That((string?)image.Attribute("y"), Is.EqualTo("274"));
                Assert.That((string?)image.Attribute("width"), Is.EqualTo("70"));
                Assert.That((string?)image.Attribute("height"), Is.EqualTo("61"));
                Assert.That((string?)image.Attribute("href"), Does.StartWith("data:image/svg+xml;base64,"));
                Assert.That(actorGroup.Element(Svg + "rect"), Is.Null, "no outline behind a resolved image");
                Assert.That(actorGroup.Element(Svg + "text"), Is.Not.Null, "the caption still renders");

                Assert.That(unresolvedGroup.Element(Svg + "image"), Is.Null, "an unknown image degrades to the outline");
                Assert.That(unresolvedGroup.Element(Svg + "rect"), Is.Not.Null);

                Assert.That(lifelineGroup.Element(Svg + "image"), Is.Null, "a line-shaped box never renders as an image");
                Assert.That(lifelineGroup.Element(Svg + "line"), Is.Not.Null);
            });
        }

        [Test]
        public void Verify_that_a_top_pinned_title_renders_at_the_top_with_a_clamped_icon()
        {
            var box = MakeBox("titled", 485, 674, 124, 68);
            box.Label = new Label("Synchronize Audio Video") { PinTop = true, IconPath = "PhysicalFunction.png" };
            box.Add(MakeBox("port", 483, 704, 10, 10));

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { box }, new List<Edge>())));
            var group = document.Descendants(Svg + "g").Single(g => (string?)g.Attribute("id") == "titled");
            var icon = group.Elements(Svg + "image").First();
            var text = group.Element(Svg + "text")!;

            Assert.Multiple(() =>
            {
                Assert.That((double)text.Attribute("y")!, Is.LessThan(690), "the title sits in the top band, not the box center");
                Assert.That((string?)text.Attribute("text-anchor"), Is.EqualTo("middle"));
                Assert.That((double)icon.Attribute("y")!, Is.LessThan(690), "the icon sits at the top too");
                Assert.That((double)icon.Attribute("x")!, Is.GreaterThan(485), "the icon is clamped inside the box, clear of the left-border port at x=483");
            });
        }

        [Test]
        public void Verify_that_a_label_icon_renders_before_the_shifted_text()
        {
            var box = MakeBox("classbox", 0, 0, 100, 40);
            box.Label = new Label("Passenger") { Position = new Point(10, 10), IconPath = "Class.png" };

            var unresolvable = MakeBox("plain", 200, 0, 100, 40);
            unresolvable.Label = new Label("plain") { Position = new Point(210, 10), IconPath = "NoSuchType.png" };

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { box, unresolvable }, new List<Edge>())));

            var classGroup = document.Descendants(Svg + "g").Single(g => (string?)g.Attribute("id") == "classbox");
            var icon = classGroup.Element(Svg + "image")!;
            var text = classGroup.Element(Svg + "text")!;
            var plainGroup = document.Descendants(Svg + "g").Single(g => (string?)g.Attribute("id") == "plain");

            Assert.Multiple(() =>
            {
                Assert.That((string?)icon.Attribute("x"), Is.EqualTo("10"), "the icon sits at the label position");
                Assert.That((string?)icon.Attribute("y"), Is.EqualTo("8"), "vertically centered on the text line");
                Assert.That((string?)icon.Attribute("width"), Is.EqualTo("12"));
                Assert.That((string?)icon.Attribute("href"), Does.StartWith("data:image/png;base64,"));
                Assert.That((string?)text.Attribute("x"), Is.EqualTo("24"), "the text shifts right of the icon");

                Assert.That(plainGroup.Element(Svg + "image"), Is.Null, "an unresolvable icon renders text only");
                Assert.That((string?)plainGroup.Element(Svg + "text")!.Attribute("x"), Is.EqualTo("210"), "and the text does not shift");
            });
        }

        [Test]
        public void Verify_that_edge_end_labels_render_backed_off_from_the_route_ends()
        {
            var edge = MakeEdge("association", new List<Point> { new(0, 100), new(100, 100) });
            edge.BeginLabel = new Label("0..1");
            edge.EndLabel = new Label("[1..*]");

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box>(), new List<Edge> { edge })));
            var texts = document.Descendants(Svg + "text").ToList();

            var begin = texts.Single(text => text.Value == "0..1");
            var end = texts.Single(text => text.Value == "[1..*]");

            Assert.Multiple(() =>
            {
                Assert.That((string?)begin.Attribute("x"), Is.EqualTo("15"), "backed off 15 units from the start");
                Assert.That((string?)begin.Attribute("y"), Is.EqualTo("98"));
                Assert.That((string?)end.Attribute("x"), Is.EqualTo("85"), "backed off 15 units from the end");
                Assert.That((string?)end.Attribute("y"), Is.EqualTo("98"));
            });
        }

        [Test]
        public void Verify_that_font_decorations_and_dot_markers_render()
        {
            var box = MakeBox("decorated", 0, 0, 100, 40);
            box.Label = new Label("decorated");
            box.Style.Resolved.Italic = true;
            box.Style.Resolved.Underline = true;
            box.Style.Resolved.StrikeThrough = true;

            var edge = MakeEdge("dotted", new List<Point> { new(0, 100), new(100, 100) });
            edge.Style.Resolved.TargetArrow = SiriusDiagram.EdgeArrows.Dot;

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { box }, new List<Edge> { edge })));
            var text = document.Descendants(Svg + "text").Single();

            Assert.Multiple(() =>
            {
                Assert.That((string?)text.Attribute("font-style"), Is.EqualTo("italic"));
                Assert.That((string?)text.Attribute("text-decoration"), Is.EqualTo("underline line-through"));
                Assert.That(
                    document.Descendants(Svg + "marker").Select(marker => (string?)marker.Attribute("id")).Single(),
                    Does.StartWith("marker-dot"),
                    "the dot arrow renders as a circle marker");
            });
        }

        [Test]
        public void Verify_that_an_elliptic_style_renders_as_an_ellipse()
        {
            var state = MakeBox("state", 232, 102, 126, 37);
            state.Style.Resolved.Shape = ShapeKind.Ellipse;
            state.Style.Resolved.FillColor = new Color(228, 228, 228);

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { state }, new List<Edge>())));
            var ellipse = document.Descendants(Svg + "ellipse").Single();

            Assert.Multiple(() =>
            {
                Assert.That((string?)ellipse.Attribute("cx"), Is.EqualTo("295"));
                Assert.That((string?)ellipse.Attribute("cy"), Is.EqualTo("120.5"));
                Assert.That((string?)ellipse.Attribute("rx"), Is.EqualTo("63"));
                Assert.That((string?)ellipse.Attribute("ry"), Is.EqualTo("18.5"));
                Assert.That((string?)ellipse.Attribute("fill"), Is.EqualTo("#E4E4E4"));
                Assert.That(document.Descendants(Svg + "rect"), Is.Empty, "the ellipse replaces the rect");
            });
        }

        [Test]
        public void Verify_that_a_lozenge_style_renders_as_a_diamond()
        {
            var choice = MakeBox("choice", 100, 100, 50, 50);
            choice.Style.Resolved.Shape = ShapeKind.Diamond;
            choice.Style.Resolved.FillColor = new Color(228, 228, 228);

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { choice }, new List<Edge>())));
            var diamond = document.Descendants(Svg + "path").Single();

            Assert.Multiple(() =>
            {
                // The rhombus inscribed in the 50x50 box at (100,100): top, right, bottom, left.
                Assert.That((string?)diamond.Attribute("d"), Is.EqualTo("M 125 100 L 150 125 L 125 150 L 100 125 Z"));
                Assert.That((string?)diamond.Attribute("fill"), Is.EqualTo("#E4E4E4"));
                Assert.That(document.Descendants(Svg + "rect"), Is.Empty, "the diamond replaces the rect");
            });
        }

        [Test]
        public void Verify_that_a_rotated_image_carries_a_rotate_transform()
        {
            var port = MakeBox("port", 100, 100, 10, 10);
            port.Style.Resolved.ImagePath = "/org.polarsys.capella.core.sirius.analysis/description/images/Actor.svg";
            port.Style.Resolved.ImageRotation = 90;

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { port }, new List<Edge>())));
            var image = document.Descendants(Svg + "image").Single();

            Assert.Multiple(() =>
            {
                // Rotated about the 10x10 port's centre (105, 105).
                Assert.That((string?)image.Attribute("transform"), Is.EqualTo("rotate(90 105 105)"));
                Assert.That((string?)image.Attribute("href"), Does.StartWith("data:image/svg+xml;base64,"));
            });
        }

        [Test]
        public void Verify_that_an_unrotated_image_carries_no_transform()
        {
            var box = MakeBox("actor", 20, 274, 70, 61);
            box.Style.Resolved.ImagePath = "/org.polarsys.capella.core.sirius.analysis/description/images/Actor.svg";

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { box }, new List<Edge>())));
            var image = document.Descendants(Svg + "image").Single();

            Assert.That(image.Attribute("transform"), Is.Null, "an unrotated image needs no transform");
        }

        [Test]
        public void Verify_that_a_note_renders_with_a_dog_ear()
        {
            var note = MakeBox("note", 0, 0, 100, 60);
            note.Style.Resolved.Shape = ShapeKind.Note;
            note.Style.Resolved.FillColor = new Color(255, 255, 197);

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { note }, new List<Edge>())));
            var group = document.Descendants(Svg + "g").Single(g => (string?)g.Attribute("id") == "note");
            var paths = group.Descendants(Svg + "path").ToList();

            Assert.Multiple(() =>
            {
                Assert.That(paths, Has.Count.EqualTo(2), "the note body and the folded corner");
                // The body: a rectangle whose top-right corner is cut on the diagonal (fold 12).
                Assert.That((string?)paths[0].Attribute("d"), Is.EqualTo("M 0 0 L 88 0 L 100 12 L 100 60 L 0 60 Z"));
                Assert.That((string?)paths[0].Attribute("fill"), Is.EqualTo("#FFFFC5"));
                // The dog-ear: the folded corner drawn in the cut.
                Assert.That((string?)paths[1].Attribute("d"), Is.EqualTo("M 88 0 L 88 12 L 100 12"));
                Assert.That(document.Descendants(Svg + "rect"), Is.Empty, "a note is not a plain rectangle");
            });
        }

        [Test]
        public void Verify_that_a_widthless_label_splits_on_its_newlines()
        {
            var box = MakeBox("multiline", 0, 0, 100, 40);
            box.Label = new Label("Maintenance-Aircraft\nDigital Network") { Position = new Point(5, 5) };

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { box }, new List<Edge>())));
            var tspans = document.Descendants(Svg + "text").Single().Elements(Svg + "tspan").ToList();

            Assert.Multiple(() =>
            {
                Assert.That(tspans, Has.Count.EqualTo(2), "the newline splits the label into two rows");
                Assert.That(tspans[0].Value, Is.EqualTo("Maintenance-Aircraft"));
                Assert.That(tspans[1].Value, Is.EqualTo("Digital Network"));
                Assert.That((string?)tspans[1].Attribute("dy"), Is.EqualTo("1.2em"));
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

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { centered, positioned }, new List<Edge>())));
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
        public void Verify_that_a_centered_label_wraps_inside_its_box()
        {
            var box = MakeBox("wrapped", 0, 0, 100, 50);
            box.Label = new Label("Seat TV Airline-Specific Interactions Manager");

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { box }, new List<Edge>())));
            var text = document.Descendants(Svg + "text").Single();
            var tspans = text.Elements(Svg + "tspan").ToList();

            Assert.Multiple(() =>
            {
                // 96px of room at 8pt wraps the name into three centered lines, as Capella keeps a
                // node label inside its shape.
                Assert.That(tspans, Has.Count.EqualTo(3));
                Assert.That((string?)text.Attribute("text-anchor"), Is.EqualTo("middle"));
                Assert.That(tspans.Select(t => (string?)t.Attribute("x")), Has.All.EqualTo("50"), "every line re-anchors at the box center");

                // The three-line block centers vertically: first baseline at 25 + 4 - 9.6 = 19.4.
                Assert.That((string?)text.Attribute("y"), Is.EqualTo("19.4"));
                Assert.That(tspans[0].Value, Is.EqualTo("Seat TV"));
                Assert.That(tspans[2].Value, Is.EqualTo("Interactions Manager"));
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

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box>(), new List<Edge> { edge })));

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
        public void Verify_that_a_line_shape_renders_as_a_capless_line()
        {
            var lifeline = MakeBox("lifeline", 99.5, 100, 1, 830);
            lifeline.Style.Resolved.Shape = ShapeKind.Line;
            lifeline.Style.Resolved.Pattern = LinePattern.LongDash;
            lifeline.Style.Resolved.StrokeColor = new Color(128, 128, 128);

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { lifeline }, new List<Edge>())));
            var line = document.Descendants(Svg + "line").Single();

            Assert.Multiple(() =>
            {
                Assert.That((string?)line.Attribute("x1"), Is.EqualTo("100"));
                Assert.That((string?)line.Attribute("x2"), Is.EqualTo("100"));
                Assert.That((string?)line.Attribute("y1"), Is.EqualTo("100"));
                Assert.That((string?)line.Attribute("y2"), Is.EqualTo("930"));
                Assert.That((string?)line.Attribute("stroke-dasharray"), Is.EqualTo("10 5"));
                Assert.That(document.Descendants(Svg + "rect"), Is.Empty, "a line replaces the capped rectangle");
            });
        }

        [Test]
        public void Verify_that_a_framed_label_renders_in_a_title_tab()
        {
            var frame = MakeBox("frame", 320, 402, 985, 931);
            frame.Style.Resolved.FillColor = null;
            frame.Label = new Label("PAR") { Position = new Point(324, 404), Framed = true };

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { frame }, new List<Edge>())));
            var tab = document.Descendants(Svg + "path").Single();

            Assert.Multiple(() =>
            {
                Assert.That((string?)tab.Attribute("d"), Does.StartWith("M 320 402 L "), "anchored at the frame's corner");
                Assert.That((string?)tab.Attribute("d"), Does.EndWith("Z"), "a closed pentagon");
                Assert.That((string?)tab.Attribute("fill"), Is.EqualTo("#FFFFFF"));
            });
        }

        [Test]
        public void Verify_that_a_two_point_edge_labels_above_its_center()
        {
            var edge = MakeEdge("straight", new[] { new Point(0, 20), new Point(100, 20) });
            edge.Label = new Label("centered");

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box>(), new List<Edge> { edge })));
            var label = document.Descendants(Svg + "text").Single();

            Assert.Multiple(() =>
            {
                Assert.That((string?)label.Attribute("x"), Is.EqualTo("50"), "above the segment's center, not its target end");
                Assert.That((string?)label.Attribute("y"), Is.EqualTo("18"));
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

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { first, second }, edges)));

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

            var text = this.svgExporter.Export(Diagram(new List<Box> { box }, new List<Edge>()));
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
        public void Verify_that_the_view_box_covers_labels_that_overflow_their_box()
        {
            // A box label persisted to the left of its box (as Capella positions the mission labels
            // on an [MCB]) and a wide edge label reaching past the right box edge would both fall
            // outside a viewBox computed from box and route geometry alone.
            var box = MakeBox("mission", 100, 50, 60, 30);
            box.Label = new Label("Provide Entertainment Solutions") { Position = new Point(-44, 60) };

            var edge = MakeEdge("assoc", new List<Point> { new(100, 200), new(160, 200) });
            edge.Label = new Label("a long association label off the right edge");

            var document = XDocument.Parse(this.svgExporter.Export(Diagram(new List<Box> { box }, new List<Edge> { edge })));

            var viewBox = ((string)document.Root!.Attribute("viewBox")!)
                .Split(' ')
                .Select(part => double.Parse(part, CultureInfo.InvariantCulture))
                .ToArray();
            var minX = viewBox[0];
            var maxX = viewBox[0] + viewBox[2];

            Assert.Multiple(() =>
            {
                Assert.That(minX, Is.LessThanOrEqualTo(-64), "the viewBox reaches the label left of the box (x=-44), padded by 20");
                Assert.That(maxX, Is.GreaterThan(180), "the viewBox reaches the wide edge label, past the geometry's right edge at x=160");
            });
        }

        [Test]
        public void Verify_the_stream_and_file_overloads()
        {
            var box = MakeBox("box", 0, 0, 10, 10);
            var diagram = Diagram(new List<Box> { box }, new List<Edge>());

            using var stream = new MemoryStream();
            this.svgExporter.Export(diagram, stream);
            stream.Position = 0;

            var path = Path.Combine(TestContext.CurrentContext.WorkDirectory, "svg-exporter-test.svg");
            this.svgExporter.ExportToFile(diagram, path);

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
