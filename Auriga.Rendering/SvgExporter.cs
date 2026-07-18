// ------------------------------------------------------------------------------------------------
// <copyright file="SvgExporter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Serializes the intermediate <see cref="Diagram"/> model to plain SVG using
    /// <see cref="XDocument"/> — no external dependency. Boxes render as nested
    /// <c>&lt;g&gt;</c>/<c>&lt;rect&gt;</c> groups with their labels as <c>&lt;text&gt;</c>
    /// (wrapped into <c>&lt;tspan&gt;</c> lines when the label has a persisted width), edges as
    /// <c>&lt;path&gt;</c> polylines drawn over the boxes, with gradients and arrow markers
    /// collected in <c>&lt;defs&gt;</c>. The <c>viewBox</c> is the padded bounding box of the
    /// diagram's persisted geometry.
    /// </summary>
    public static class SvgExporter
    {
        /// <summary>
        /// The SVG XML namespace.
        /// </summary>
        private static readonly XNamespace Svg = "http://www.w3.org/2000/svg";

        /// <summary>
        /// The padding around the diagram's bounding box, in pixels.
        /// </summary>
        private const double Padding = 20;

        /// <summary>
        /// The width and height a box without a persisted size renders with (ports and label-less
        /// icons persist no size; GMF's default port footprint is a small square).
        /// </summary>
        private const double DefaultBoxSize = 10;

        /// <summary>
        /// Exports the diagram to an SVG document string.
        /// </summary>
        /// <param name="diagram">the diagram to export</param>
        /// <returns>the SVG document text</returns>
        /// <exception cref="ArgumentNullException">the diagram is null</exception>
        public static string Export(Diagram diagram)
        {
            return BuildDocument(diagram).ToString();
        }

        /// <summary>
        /// Exports the diagram as an SVG document to the supplied stream.
        /// </summary>
        /// <param name="diagram">the diagram to export</param>
        /// <param name="stream">the stream the SVG document is written to</param>
        /// <exception cref="ArgumentNullException">the diagram or the stream is null</exception>
        public static void Export(Diagram diagram, Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            BuildDocument(diagram).Save(stream);
        }

        /// <summary>
        /// Exports the diagram as an SVG file.
        /// </summary>
        /// <param name="diagram">the diagram to export</param>
        /// <param name="path">the file path the SVG document is written to</param>
        /// <exception cref="ArgumentNullException">the diagram is null</exception>
        /// <exception cref="ArgumentException">the path is null or empty</exception>
        public static void ExportToFile(Diagram diagram, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The path must be provided.", nameof(path));
            }

            BuildDocument(diagram).Save(path);
        }

        /// <summary>
        /// Builds the complete SVG document for the diagram.
        /// </summary>
        /// <param name="diagram">the diagram to export</param>
        /// <returns>the SVG document</returns>
        private static XDocument BuildDocument(Diagram diagram)
        {
            if (diagram == null)
            {
                throw new ArgumentNullException(nameof(diagram));
            }

            var defs = new XElement(Svg + "defs");
            var root = new XElement(
                Svg + "svg",
                new XAttribute("xmlns", Svg.NamespaceName),
                ViewBox(diagram),
                defs);

            var boxLayer = new XElement(Svg + "g", new XAttribute("class", "boxes"));
            foreach (var box in diagram.Boxes)
            {
                boxLayer.Add(BuildBox(box, defs));
            }

            var edgeLayer = new XElement(Svg + "g", new XAttribute("class", "edges"));
            foreach (var edge in diagram.Edges)
            {
                edgeLayer.Add(BuildEdge(edge, defs));
            }

            root.Add(boxLayer, edgeLayer);

            return new XDocument(root);
        }

        /// <summary>
        /// The <c>viewBox</c> (and matching <c>width</c>/<c>height</c>) attributes from the padded
        /// bounding box of every box and edge route point of the diagram.
        /// </summary>
        /// <param name="diagram">the diagram</param>
        /// <returns>the sizing attributes of the SVG root</returns>
        private static IEnumerable<XAttribute> ViewBox(Diagram diagram)
        {
            var minX = 0d;
            var minY = 0d;
            var maxX = 100d;
            var maxY = 100d;
            var first = true;

            foreach (var box in diagram.QueryAllBoxes())
            {
                var right = box.Position.X + (box.Width ?? DefaultBoxSize);
                var bottom = box.Position.Y + (box.Height ?? DefaultBoxSize);
                Accumulate(box.Position.X, box.Position.Y, right, bottom, ref minX, ref minY, ref maxX, ref maxY, ref first);
            }

            foreach (var point in diagram.Edges.SelectMany(edge => edge.Route))
            {
                Accumulate(point.X, point.Y, point.X, point.Y, ref minX, ref minY, ref maxX, ref maxY, ref first);
            }

            var x = minX - Padding;
            var y = minY - Padding;
            var width = maxX - minX + (2 * Padding);
            var height = maxY - minY + (2 * Padding);

            yield return new XAttribute("viewBox", $"{N(x)} {N(y)} {N(width)} {N(height)}");
            yield return new XAttribute("width", N(width));
            yield return new XAttribute("height", N(height));
        }

        /// <summary>
        /// Widens the running bounding box with the supplied extent.
        /// </summary>
        /// <param name="left">the extent's left coordinate</param>
        /// <param name="top">the extent's top coordinate</param>
        /// <param name="right">the extent's right coordinate</param>
        /// <param name="bottom">the extent's bottom coordinate</param>
        /// <param name="minX">the running minimum x</param>
        /// <param name="minY">the running minimum y</param>
        /// <param name="maxX">the running maximum x</param>
        /// <param name="maxY">the running maximum y</param>
        /// <param name="first">whether this is the first extent (seeds the box instead of widening it)</param>
        private static void Accumulate(double left, double top, double right, double bottom, ref double minX, ref double minY, ref double maxX, ref double maxY, ref bool first)
        {
            if (first)
            {
                minX = left;
                minY = top;
                maxX = right;
                maxY = bottom;
                first = false;
                return;
            }

            minX = Math.Min(minX, left);
            minY = Math.Min(minY, top);
            maxX = Math.Max(maxX, right);
            maxY = Math.Max(maxY, bottom);
        }

        /// <summary>
        /// Builds the group of a box: its outline (a rectangle, or an ellipse when the resolved
        /// style says so), its label and, nested, its child boxes.
        /// </summary>
        /// <param name="box">the box to render</param>
        /// <param name="defs">the document's <c>&lt;defs&gt;</c>, receiving gradients on demand</param>
        /// <returns>the box group</returns>
        private static XElement BuildBox(Box box, XElement defs)
        {
            var style = box.Style.Resolved;
            var width = box.Width ?? DefaultBoxSize;
            var height = box.Height ?? DefaultBoxSize;

            XElement outline;
            if (style.Shape == ShapeKind.Ellipse)
            {
                outline = new XElement(
                    Svg + "ellipse",
                    new XAttribute("cx", N(box.Position.X + (width / 2))),
                    new XAttribute("cy", N(box.Position.Y + (height / 2))),
                    new XAttribute("rx", N(width / 2)),
                    new XAttribute("ry", N(height / 2)),
                    new XAttribute("fill", Fill(style, defs)));
            }
            else if (style.Shape == ShapeKind.Line)
            {
                if (height >= width)
                {
                    var centerX = box.Position.X + (width / 2);
                    outline = new XElement(
                        Svg + "line",
                        new XAttribute("x1", N(centerX)),
                        new XAttribute("y1", N(box.Position.Y)),
                        new XAttribute("x2", N(centerX)),
                        new XAttribute("y2", N(box.Position.Y + height)));
                }
                else
                {
                    var centerY = box.Position.Y + (height / 2);
                    outline = new XElement(
                        Svg + "line",
                        new XAttribute("x1", N(box.Position.X)),
                        new XAttribute("y1", N(centerY)),
                        new XAttribute("x2", N(box.Position.X + width)),
                        new XAttribute("y2", N(centerY)));
                }
            }
            else
            {
                outline = new XElement(
                    Svg + "rect",
                    new XAttribute("x", N(box.Position.X)),
                    new XAttribute("y", N(box.Position.Y)),
                    new XAttribute("width", N(width)),
                    new XAttribute("height", N(height)),
                    new XAttribute("fill", Fill(style, defs)));
            }

            outline.Add(
                new XAttribute("stroke", style.StrokeColor.ToHex()),
                new XAttribute("stroke-width", N(style.StrokeWidth)));

            AddDashArray(outline, style.Pattern);

            var group = new XElement(Svg + "g", new XAttribute("id", box.Identifier), outline);

            if (box.Label != null)
            {
                if (box.Label.Framed)
                {
                    group.Add(BuildLabelTab(box, style));
                }

                group.Add(BuildBoxLabel(box, style));
            }

            foreach (var child in box.Children)
            {
                group.Add(BuildBox(child, defs));
            }

            return group;
        }

        /// <summary>
        /// Builds the pentagon title tab a framed label sits in — the corner tab Capella draws
        /// around a combined fragment's operator — anchored at the box's top-left corner and sized
        /// to the label text.
        /// </summary>
        /// <param name="box">the box whose label is framed</param>
        /// <param name="style">the box's resolved style, supplying the tab's stroke and font size</param>
        /// <returns>the tab path element</returns>
        private static XElement BuildLabelTab(Box box, ResolvedStyle style)
        {
            var width = (box.Label!.Text.Trim().Length * style.FontSize * 0.6) + 12;
            var height = style.FontSize + 6;
            var x = box.Position.X;
            var y = box.Position.Y;

            return new XElement(
                Svg + "path",
                new XAttribute("d", $"M {N(x)} {N(y)} L {N(x + width)} {N(y)} L {N(x + width)} {N(y + height - 5)} L {N(x + width - 5)} {N(y + height)} L {N(x)} {N(y + height)} Z"),
                new XAttribute("fill", "#FFFFFF"),
                new XAttribute("stroke", style.StrokeColor.ToHex()),
                new XAttribute("stroke-width", "1"));
        }

        /// <summary>
        /// Builds the label text of a box: at the persisted label geometry when one was folded in
        /// (wrapped into <c>&lt;tspan&gt;</c> lines when it has a width), or centered in the box —
        /// wrapped to the box's width and vertically centered as a block, the way Capella keeps a
        /// node label inside its shape.
        /// </summary>
        /// <param name="box">the labelled box</param>
        /// <param name="style">the box's resolved style</param>
        /// <returns>the label text element</returns>
        private static XElement BuildBoxLabel(Box box, ResolvedStyle style)
        {
            var label = box.Label!;

            if (label.Position is { } position)
            {
                var text = BuildText(label.Text, position.X, position.Y + style.FontSize, "start", style);

                if (label.Width is { } labelWidth)
                {
                    AddWrappedLines(text, WrapLines(label.Text, labelWidth, style), position.X);
                }

                return text;
            }

            var width = box.Width ?? DefaultBoxSize;
            var centerX = box.Position.X + (width / 2);
            var centerY = box.Position.Y + ((box.Height ?? DefaultBoxSize) / 2);

            var lines = WrapLines(label.Text, Math.Max(1, width - 4), style);
            var lineHeight = style.FontSize * 1.2;
            var firstBaseline = centerY + (style.FontSize / 2) - ((lines.Count - 1) * lineHeight / 2);

            var centered = BuildText(label.Text, centerX, firstBaseline, "middle", style);
            AddWrappedLines(centered, lines, centerX);

            return centered;
        }

        /// <summary>
        /// Builds the path of an edge over its absolute route, with its stroke, pattern, arrow
        /// markers and midpoint label.
        /// </summary>
        /// <param name="edge">the edge to render</param>
        /// <param name="defs">the document's <c>&lt;defs&gt;</c>, receiving markers on demand</param>
        /// <returns>the edge group</returns>
        private static XElement BuildEdge(Edge edge, XElement defs)
        {
            var style = edge.Style.Resolved;
            var group = new XElement(Svg + "g", new XAttribute("id", edge.Identifier));

            if (edge.Route.Count >= 2)
            {
                var path = new XElement(
                    Svg + "path",
                    new XAttribute("d", PathData(edge.Route)),
                    new XAttribute("fill", "none"),
                    new XAttribute("stroke", style.StrokeColor.ToHex()),
                    new XAttribute("stroke-width", N(style.StrokeWidth)));

                AddDashArray(path, style.Pattern);
                AddMarker(path, "marker-start", style.SourceArrow, style.StrokeColor, defs);
                AddMarker(path, "marker-end", style.TargetArrow, style.StrokeColor, defs);

                group.Add(path);
            }

            if (edge.Label != null && edge.Route.Count >= 2)
            {
                var (midpoint, vertical) = Midpoint(edge.Route);

                // A label on a horizontal segment sits centered above it; a label on a vertical
                // segment (a self-message hook) sits beside it, to the right.
                group.Add(vertical
                    ? BuildText(edge.Label.Text, midpoint.X + 4, midpoint.Y + (style.FontSize / 2), "start", style)
                    : BuildText(edge.Label.Text, midpoint.X, midpoint.Y - 2, "middle", style));
            }

            return group;
        }

        /// <summary>
        /// The geometric midpoint of a route — the middle point when the count is odd, the center
        /// of the middle segment when it is even (so a two-point message labels above its center,
        /// not above its target end) — and whether that middle segment runs vertically.
        /// </summary>
        /// <param name="route">the route points</param>
        /// <returns>the midpoint and the middle segment's orientation</returns>
        private static (Point Point, bool Vertical) Midpoint(IReadOnlyList<Point> route)
        {
            if (route.Count % 2 == 1)
            {
                return (route[route.Count / 2], false);
            }

            var before = route[(route.Count / 2) - 1];
            var after = route[route.Count / 2];

            var midpoint = new Point((before.X + after.X) / 2, (before.Y + after.Y) / 2);
            return (midpoint, Math.Abs(before.X - after.X) < 0.001 && Math.Abs(before.Y - after.Y) > 0.001);
        }

        /// <summary>
        /// Builds a positioned, styled SVG text element.
        /// </summary>
        /// <param name="content">the text content</param>
        /// <param name="x">the x coordinate</param>
        /// <param name="y">the baseline y coordinate</param>
        /// <param name="anchor">the SVG <c>text-anchor</c></param>
        /// <param name="style">the resolved style supplying the font properties</param>
        /// <returns>the text element</returns>
        private static XElement BuildText(string content, double x, double y, string anchor, ResolvedStyle style)
        {
            var text = new XElement(
                Svg + "text",
                new XAttribute("x", N(x)),
                new XAttribute("y", N(y)),
                new XAttribute("text-anchor", anchor),
                new XAttribute("font-family", style.FontName),
                new XAttribute("font-size", N(style.FontSize)),
                new XAttribute("fill", style.FontColor.ToHex()),
                content);

            if (style.Bold)
            {
                text.Add(new XAttribute("font-weight", "bold"));
            }

            if (style.Italic)
            {
                text.Add(new XAttribute("font-style", "italic"));
            }

            var decorations = new List<string>();
            if (style.Underline)
            {
                decorations.Add("underline");
            }

            if (style.StrikeThrough)
            {
                decorations.Add("line-through");
            }

            if (decorations.Count > 0)
            {
                text.Add(new XAttribute("text-decoration", string.Join(" ", decorations)));
            }

            return text;
        }

        /// <summary>
        /// Splits the label text into the lines that fit the available width, estimating glyph
        /// width from the font size. Explicit line breaks (a note's paragraphs) are honored, a
        /// blank line is preserved as a spacer, and a single word longer than the width is kept
        /// whole.
        /// </summary>
        /// <param name="content">the label text</param>
        /// <param name="width">the available width</param>
        /// <param name="style">the resolved style supplying the font size</param>
        /// <returns>the wrapped lines, in order</returns>
        private static List<string> WrapLines(string content, double width, ResolvedStyle style)
        {
            var glyphWidth = style.FontSize * 0.6;
            var charactersPerLine = Math.Max(1, (int)(width / glyphWidth));

            var lines = new List<string>();

            foreach (var paragraph in content.Replace("\r", string.Empty).Split('\n'))
            {
                if (paragraph.Length == 0)
                {
                    lines.Add(" ");
                    continue;
                }

                if (paragraph.Length <= charactersPerLine)
                {
                    lines.Add(paragraph);
                    continue;
                }

                var line = string.Empty;
                foreach (var word in paragraph.Split(' '))
                {
                    var candidate = line.Length == 0 ? word : line + " " + word;
                    if (candidate.Length > charactersPerLine && line.Length > 0)
                    {
                        lines.Add(line);
                        line = word;
                    }
                    else
                    {
                        line = candidate;
                    }
                }

                lines.Add(line);
            }

            return lines;
        }

        /// <summary>
        /// Replaces a text element's plain content with one <c>&lt;tspan&gt;</c> per wrapped line,
        /// each starting at the same x (so the element's <c>text-anchor</c> keeps applying per
        /// line) and advancing one line height. A single line is left as plain content.
        /// </summary>
        /// <param name="text">the text element to fill</param>
        /// <param name="lines">the wrapped lines</param>
        /// <param name="x">the x coordinate every line anchors at</param>
        private static void AddWrappedLines(XElement text, List<string> lines, double x)
        {
            if (lines.Count < 2)
            {
                return;
            }

            text.RemoveNodes();
            for (var i = 0; i < lines.Count; i++)
            {
                text.Add(new XElement(
                    Svg + "tspan",
                    new XAttribute("x", N(x)),
                    i == 0 ? null : new XAttribute("dy", "1.2em"),
                    lines[i]));
            }
        }

        /// <summary>
        /// The SVG path data of an absolute polyline route.
        /// </summary>
        /// <param name="route">the route points</param>
        /// <returns>the <c>d</c> attribute value</returns>
        private static string PathData(IReadOnlyList<Point> route)
        {
            var segments = new List<string> { $"M {N(route[0].X)} {N(route[0].Y)}" };
            for (var i = 1; i < route.Count; i++)
            {
                segments.Add($"L {N(route[i].X)} {N(route[i].Y)}");
            }

            return string.Join(" ", segments);
        }

        /// <summary>
        /// The fill attribute value of a box: a gradient reference (registered in
        /// <c>&lt;defs&gt;</c> on first use) when the style has a gradient, the plain fill color,
        /// or <c>none</c>.
        /// </summary>
        /// <param name="style">the resolved style</param>
        /// <param name="defs">the document's <c>&lt;defs&gt;</c></param>
        /// <returns>the fill attribute value</returns>
        private static string Fill(ResolvedStyle style, XElement defs)
        {
            if (style.FillColor is not { } fill)
            {
                return "none";
            }

            if (style.GradientColor is not { } gradient)
            {
                return fill.ToHex();
            }

            var id = $"gradient-{Hex(fill)}-{Hex(gradient)}";
            if (defs.Elements(Svg + "linearGradient").All(candidate => (string?)candidate.Attribute("id") != id))
            {
                defs.Add(new XElement(
                    Svg + "linearGradient",
                    new XAttribute("id", id),
                    new XAttribute("x1", "0"),
                    new XAttribute("y1", "0"),
                    new XAttribute("x2", "0"),
                    new XAttribute("y2", "1"),
                    new XElement(Svg + "stop", new XAttribute("offset", "0"), new XAttribute("stop-color", fill.ToHex())),
                    new XElement(Svg + "stop", new XAttribute("offset", "1"), new XAttribute("stop-color", gradient.ToHex()))));
            }

            return $"url(#{id})";
        }

        /// <summary>
        /// Adds the <c>stroke-dasharray</c> of a non-solid line pattern.
        /// </summary>
        /// <param name="element">the rect or path element</param>
        /// <param name="pattern">the resolved pattern</param>
        private static void AddDashArray(XElement element, LinePattern pattern)
        {
            var dashArray = pattern switch
            {
                LinePattern.Dash => "5 3",
                LinePattern.Dot => "1 3",
                LinePattern.DashDot => "5 3 1 3",
                LinePattern.LongDash => "10 5",
                _ => null,
            };

            if (dashArray != null)
            {
                element.Add(new XAttribute("stroke-dasharray", dashArray));
            }
        }

        /// <summary>
        /// Adds an arrow marker reference to an edge path, registering the (shape, color) marker in
        /// <c>&lt;defs&gt;</c> on first use. <c>NoDecoration</c> and unmapped decorations add
        /// nothing.
        /// </summary>
        /// <param name="path">the edge path</param>
        /// <param name="attribute">the marker attribute (<c>marker-start</c> or <c>marker-end</c>)</param>
        /// <param name="arrow">the resolved arrow decoration, or <c>null</c></param>
        /// <param name="color">the edge's stroke color, which the marker renders in</param>
        /// <param name="defs">the document's <c>&lt;defs&gt;</c></param>
        private static void AddMarker(XElement path, string attribute, Auriga.Diagram.Diagram.EdgeArrows? arrow, Color color, XElement defs)
        {
            var shape = MarkerShape(arrow);
            if (shape == null)
            {
                return;
            }

            var (name, data, filled) = shape.Value;
            var id = $"marker-{name}-{Hex(color)}";

            if (defs.Elements(Svg + "marker").All(candidate => (string?)candidate.Attribute("id") != id))
            {
                defs.Add(new XElement(
                    Svg + "marker",
                    new XAttribute("id", id),
                    new XAttribute("viewBox", "0 0 10 10"),
                    new XAttribute("refX", "9"),
                    new XAttribute("refY", "5"),
                    new XAttribute("markerWidth", "8"),
                    new XAttribute("markerHeight", "8"),
                    new XAttribute("orient", "auto-start-reverse"),
                    new XElement(
                        Svg + "path",
                        new XAttribute("d", data),
                        new XAttribute("fill", filled ? color.ToHex() : "#FFFFFF"),
                        new XAttribute("stroke", color.ToHex()))));
            }

            path.Add(new XAttribute(attribute, $"url(#{id})"));
        }

        /// <summary>
        /// The marker geometry of an arrow decoration: a stable shape name, the marker path data
        /// (in the marker's 10x10 view box, pointing right), and whether the shape is filled with
        /// the stroke color (a light fill otherwise). Open arrows render as un-closed chevrons,
        /// closed/filled arrows as triangles, diamonds as rhombi and dots as squares-approximating
        /// circles.
        /// </summary>
        /// <param name="arrow">the resolved arrow decoration, or <c>null</c></param>
        /// <returns>the shape, or <c>null</c> for no decoration</returns>
        private static (string Name, string Data, bool Filled)? MarkerShape(Auriga.Diagram.Diagram.EdgeArrows? arrow)
        {
            switch (arrow)
            {
                case Auriga.Diagram.Diagram.EdgeArrows.InputArrow:
                case Auriga.Diagram.Diagram.EdgeArrows.OutputArrow:
                    return ("arrow", "M 1 1 L 9 5 L 1 9", false);
                case Auriga.Diagram.Diagram.EdgeArrows.InputClosedArrow:
                case Auriga.Diagram.Diagram.EdgeArrows.OutputClosedArrow:
                    return ("closed", "M 1 1 L 9 5 L 1 9 Z", false);
                case Auriga.Diagram.Diagram.EdgeArrows.InputFillClosedArrow:
                case Auriga.Diagram.Diagram.EdgeArrows.OutputFillClosedArrow:
                    return ("filled", "M 1 1 L 9 5 L 1 9 Z", true);
                case Auriga.Diagram.Diagram.EdgeArrows.Diamond:
                    return ("diamond", "M 1 5 L 5 1 L 9 5 L 5 9 Z", false);
                case Auriga.Diagram.Diagram.EdgeArrows.FillDiamond:
                    return ("filldiamond", "M 1 5 L 5 1 L 9 5 L 5 9 Z", true);
                case Auriga.Diagram.Diagram.EdgeArrows.Dot:
                    return ("dot", "M 5 2 A 3 3 0 1 0 5 8 A 3 3 0 1 0 5 2 Z", true);
                default:
                    return null;
            }
        }

        /// <summary>
        /// The lowercase <c>rrggbb</c> hex of a color, for use in generated ids.
        /// </summary>
        /// <param name="color">the color</param>
        /// <returns>the id-safe hex representation</returns>
        private static string Hex(Color color)
        {
            return color.ToHex().TrimStart('#').ToLowerInvariant();
        }

        /// <summary>
        /// Formats a coordinate invariantly with up to three decimals.
        /// </summary>
        /// <param name="value">the value to format</param>
        /// <returns>the formatted value</returns>
        private static string N(double value)
        {
            return value.ToString("0.###", CultureInfo.InvariantCulture);
        }
    }
}
