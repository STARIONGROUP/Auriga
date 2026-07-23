// ------------------------------------------------------------------------------------------------
// <copyright file="TableBuilder.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using NotationModel = Auriga.Diagram.Notation;
    using SiriusTable = Auriga.Diagram.Table;

    /// <summary>
    /// Builds the intermediate <see cref="Diagram"/> model of a Sirius <b>table</b> representation
    /// (<see cref="SiriusTable.IDTable"/>) — a cross-table of lines against columns. Unlike a GMF
    /// diagram, a table persists no notation layout: only column widths, the header-column width and the
    /// line order. The builder synthesizes the grid from those, emitting one <see cref="Box"/> per header
    /// and per intersection so <see cref="SvgExporter"/> renders the familiar <c>&lt;rect&gt;</c> +
    /// <c>&lt;text&gt;</c> vocabulary — a grid — with no changes. Lines nest (sub-lines), rendered as
    /// indented rows in the header column; a collapsed line hides its descendants, an invisible line or
    /// column is omitted. Per-cell styling reuses the resolved-style bag the exporter already consumes,
    /// filled from the cell's persisted <c>currentStyle</c> when one exists.
    /// </summary>
    public sealed class TableBuilder
    {
        /// <summary>
        /// The width used for a data column that persists none.
        /// </summary>
        private const double DefaultColumnWidth = 64;

        /// <summary>
        /// The width used for the header (line-label) column when the table persists none.
        /// </summary>
        private const double DefaultHeaderColumnWidth = 150;

        /// <summary>
        /// The height of a data row.
        /// </summary>
        private const double RowHeight = 20;

        /// <summary>
        /// The height of the header (column-label) row.
        /// </summary>
        private const double HeaderRowHeight = 24;

        /// <summary>
        /// The horizontal indent applied per line-nesting level in the header column.
        /// </summary>
        private const double IndentPerLevel = 14;

        /// <summary>
        /// The left padding of a left-aligned header-column label.
        /// </summary>
        private const double CellPadding = 4;

        /// <summary>
        /// The default cell font size, matching <see cref="ResolvedStyle.FontSize"/>.
        /// </summary>
        private const double CellFontSize = 8;

        /// <summary>
        /// The fill of header cells (the top row and the left column).
        /// </summary>
        private static readonly Color HeaderFill = new(240, 240, 240);

        /// <summary>
        /// The fill of a data cell that carries no persisted background.
        /// </summary>
        private static readonly Color CellFill = new(255, 255, 255);

        /// <summary>
        /// The grid-line (cell border) color.
        /// </summary>
        private static readonly Color GridLine = new(170, 170, 170);

        /// <summary>
        /// The default label color.
        /// </summary>
        private static readonly Color TextColor = new(0, 0, 0);

        /// <summary>
        /// Builds the intermediate model of the supplied table representation as a grid of boxes.
        /// </summary>
        /// <param name="table">the parsed Sirius table representation</param>
        /// <param name="name">
        /// the table name, or <c>null</c>; like a diagram's, the name lives on the
        /// <c>DRepresentationDescriptor</c> rather than on the representation, so the caller supplies it
        /// </param>
        /// <returns>the intermediate model — a grid of boxes, no edges, no notation diagram</returns>
        /// <exception cref="ArgumentNullException">the table is null</exception>
        public Diagram Build(SiriusTable.IDTable table, string? name = null)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            var columns = table.Columns.Where(column => column.Visible).ToList();
            var headerColumnWidth = table.HeaderColumnWidth is { } persisted && persisted > 0 ? persisted : DefaultHeaderColumnWidth;

            var columnLefts = new double[columns.Count];
            var columnWidths = new double[columns.Count];
            var left = headerColumnWidth;
            for (var i = 0; i < columns.Count; i++)
            {
                columnLefts[i] = left;
                columnWidths[i] = columns[i].Width is { } width && width > 0 ? width : DefaultColumnWidth;
                left += columnWidths[i];
            }

            var boxes = new List<Box>();

            // Header row: the empty top-left corner, then the column-header cells.
            boxes.Add(HeaderCell($"{Identifier(table)}-corner", 0, 0, headerColumnWidth, HeaderRowHeight, label: null, indent: 0, centered: false));
            for (var i = 0; i < columns.Count; i++)
            {
                boxes.Add(HeaderCell($"col-{Identifier(columns[i])}", columnLefts[i], 0, columnWidths[i], HeaderRowHeight, NullIfBlank(columns[i].Label), indent: 0, centered: true));
            }

            // Data rows: the header-column cell (the line label, indented by nesting), then one cell per
            // column — a background cell that carries the intersection's label and style when one exists.
            var rows = new List<(SiriusTable.IDLine Line, int Depth)>();
            Flatten(table.Lines, 0, rows);

            var top = HeaderRowHeight;
            foreach (var (line, depth) in rows)
            {
                boxes.Add(HeaderCell($"row-{Identifier(line)}", 0, top, headerColumnWidth, RowHeight, NullIfBlank(line.Label), depth, centered: false));

                var cellsByColumn = new Dictionary<int, SiriusTable.IDCell>();
                foreach (var cell in line.Cells)
                {
                    var index = cell.Column == null ? -1 : columns.IndexOf(cell.Column);
                    if (index >= 0)
                    {
                        cellsByColumn[index] = cell;
                    }
                }

                for (var i = 0; i < columns.Count; i++)
                {
                    cellsByColumn.TryGetValue(i, out var cell);
                    var identifier = cell != null ? Identifier(cell) : $"{Identifier(line)}-{Identifier(columns[i])}";
                    boxes.Add(DataCell(identifier, columnLefts[i], top, columnWidths[i], NullIfBlank(cell?.Label), cell?.CurrentStyle));
                }

                top += RowHeight;
            }

            return new Diagram(Identifier(table), boxes, Array.Empty<Edge>(), null, null)
            {
                Name = name,
                SemanticElement = table.Target,
            };
        }

        /// <summary>
        /// Flattens the line tree depth-first into rows, recording each line's nesting depth for
        /// indentation. An invisible line is skipped; a collapsed line is shown but its descendants are
        /// not, mirroring the tool.
        /// </summary>
        /// <param name="lines">the lines to flatten</param>
        /// <param name="depth">the nesting depth of these lines</param>
        /// <param name="rows">the accumulating row list</param>
        private static void Flatten(IEnumerable<SiriusTable.IDLine> lines, int depth, List<(SiriusTable.IDLine Line, int Depth)> rows)
        {
            foreach (var line in lines)
            {
                if (!line.Visible)
                {
                    continue;
                }

                rows.Add((line, depth));

                if (!line.Collapsed)
                {
                    Flatten(line.Lines, depth + 1, rows);
                }
            }
        }

        /// <summary>
        /// Builds a header cell — a top-row column header or a left-column line header. A column header
        /// centers its label; a line header left-aligns it, indented by nesting depth.
        /// </summary>
        /// <param name="identifier">the box identifier</param>
        /// <param name="x">the cell's left</param>
        /// <param name="y">the cell's top</param>
        /// <param name="width">the cell width</param>
        /// <param name="height">the cell height</param>
        /// <param name="label">the header text, or <c>null</c> for the empty corner</param>
        /// <param name="indent">the nesting depth (line headers only; 0 for column headers)</param>
        /// <param name="centered">whether the label is centered (column header) rather than left-aligned</param>
        /// <returns>the header box</returns>
        private static Box HeaderCell(string identifier, double x, double y, double width, double height, string? label, int indent, bool centered)
        {
            var style = GridStyle(HeaderFill, CellFontSize, bold: true);
            var box = MakeBox(identifier, x, y, width, height, style);
            PlaceLabel(box, label, x, y, height, indent, centered, style.FontSize);
            return box;
        }

        /// <summary>
        /// Builds a data cell at a line/column intersection: a background cell carrying the persisted
        /// intersection label and style when one exists, otherwise an empty grid cell.
        /// </summary>
        /// <param name="identifier">the box identifier</param>
        /// <param name="x">the cell's left</param>
        /// <param name="y">the cell's top</param>
        /// <param name="width">the cell width</param>
        /// <param name="label">the cell text, or <c>null</c> for a blank cell</param>
        /// <param name="cellStyle">the persisted cell style, or <c>null</c></param>
        /// <returns>the data box</returns>
        private static Box DataCell(string identifier, double x, double y, double width, string? label, SiriusTable.IDCellStyle? cellStyle)
        {
            var style = GridStyle(CellFill, CellFontSize, bold: false);
            ApplyCellStyle(style, cellStyle);

            var box = MakeBox(identifier, x, y, width, RowHeight, style);
            PlaceLabel(box, label, x, y, RowHeight, indent: 0, centered: true, style.FontSize);
            return box;
        }

        /// <summary>
        /// Overlays the persisted table-element style onto a resolved style: the background and
        /// foreground <c>"r,g,b"</c> colors, the font size and the label format flags.
        /// </summary>
        /// <param name="style">the resolved style to mutate</param>
        /// <param name="cellStyle">the persisted style, or <c>null</c> to leave the defaults</param>
        private static void ApplyCellStyle(ResolvedStyle style, SiriusTable.IDTableElementStyle? cellStyle)
        {
            if (cellStyle == null)
            {
                return;
            }

            if (Color.TryParse(cellStyle.BackgroundColor, out var background))
            {
                style.FillColor = background;
            }

            if (Color.TryParse(cellStyle.ForegroundColor, out var foreground))
            {
                style.FontColor = foreground;
            }

            if (cellStyle.LabelSize is { } size && size > 0)
            {
                style.FontSize = size;
            }

            foreach (var format in cellStyle.LabelFormat)
            {
                switch (format)
                {
                    case Auriga.Diagram.Viewpoint.FontFormat.Bold:
                        style.Bold = true;
                        break;
                    case Auriga.Diagram.Viewpoint.FontFormat.Italic:
                        style.Italic = true;
                        break;
                    case Auriga.Diagram.Viewpoint.FontFormat.Underline:
                        style.Underline = true;
                        break;
                    case Auriga.Diagram.Viewpoint.FontFormat.Strike_through:
                        style.StrikeThrough = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Attaches the label to a cell when it has text: a centered label is placed by the exporter's
        /// box-centering; a left-aligned one is positioned at the cell's left, offset by the padding and
        /// the nesting indent and vertically centered. A blank cell gets no label.
        /// </summary>
        /// <param name="box">the cell box</param>
        /// <param name="text">the label text, or <c>null</c>/blank for no label</param>
        /// <param name="x">the cell's left</param>
        /// <param name="y">the cell's top</param>
        /// <param name="height">the cell height</param>
        /// <param name="indent">the nesting depth (left-aligned labels only)</param>
        /// <param name="centered">whether the label centers in the box rather than left-aligning</param>
        /// <param name="fontSize">the resolved font size, for vertical centering</param>
        private static void PlaceLabel(Box box, string? text, double x, double y, double height, int indent, bool centered, double fontSize)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            var label = new Label(text!);
            if (!centered)
            {
                label.Position = new Point(x + CellPadding + (indent * IndentPerLevel), y + ((height - fontSize) / 2));
            }

            box.Label = label;
        }

        /// <summary>
        /// Builds a rectangular grid box with the supplied geometry and resolved style.
        /// </summary>
        /// <param name="identifier">the box identifier</param>
        /// <param name="x">the box's left</param>
        /// <param name="y">the box's top</param>
        /// <param name="width">the box width</param>
        /// <param name="height">the box height</param>
        /// <param name="style">the resolved style</param>
        /// <returns>the box</returns>
        private static Box MakeBox(string identifier, double x, double y, double width, double height, ResolvedStyle style)
        {
            return new Box(identifier, new Point(x, y), new NotationModel.Node(), new Style(null, Array.Empty<NotationModel.IStyle>()) { Resolved = style })
            {
                Width = width,
                Height = height,
            };
        }

        /// <summary>
        /// Builds a resolved style for a grid cell: a rectangle with the supplied fill, a grid-line
        /// border and the default label color.
        /// </summary>
        /// <param name="fill">the cell fill</param>
        /// <param name="fontSize">the font size</param>
        /// <param name="bold">whether the label is bold (headers)</param>
        /// <returns>the resolved style</returns>
        private static ResolvedStyle GridStyle(Color fill, double fontSize, bool bold)
        {
            return new ResolvedStyle
            {
                Shape = ShapeKind.Rectangle,
                FillColor = fill,
                StrokeColor = GridLine,
                StrokeWidth = 1,
                FontColor = TextColor,
                FontSize = fontSize,
                Bold = bold,
            };
        }

        /// <summary>
        /// The stable identifier of a table element — its <c>uid</c> (the reader stores it as the
        /// element id), falling back to a placeholder when absent so a box always has an id.
        /// </summary>
        /// <param name="element">the table element</param>
        /// <returns>the identifier</returns>
        private static string Identifier(object element)
        {
            return (element as Auriga.Core.IAurigaElement)?.Id ?? "table-element";
        }

        /// <summary>
        /// Returns the trimmed text, or <c>null</c> when it is null, empty or whitespace.
        /// </summary>
        /// <param name="text">the text</param>
        /// <returns>the non-blank text, or <c>null</c></returns>
        private static string? NullIfBlank(string? text)
        {
            return string.IsNullOrWhiteSpace(text) ? null : text;
        }
    }
}
