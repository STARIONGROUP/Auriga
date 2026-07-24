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
    /// <remarks>
    /// Column and row-header widths are grown to fit their text: a table's persisted widths are the
    /// tool's last interactive layout and are routinely far too small for a static export (Capella wraps
    /// or clips, and collapses the header column to a resize handle — one fixture persists
    /// <c>headerColumnWidth="15"</c> against multi-word row labels). Each column is therefore sized to the
    /// widest of its persisted width and its content, clamped to a sane range; text still wider than the
    /// clamp wraps, and the row grows to fit the wrapped lines — so no label overflows its cell.
    /// </remarks>
    public sealed class TableBuilder
    {
        /// <summary>
        /// The narrowest a data column is drawn, so a short-labelled column is still a usable cell.
        /// </summary>
        private const double MinColumnWidth = 28;

        /// <summary>
        /// The widest a data column grows to fit its content before the text wraps instead.
        /// </summary>
        private const double MaxColumnWidth = 240;

        /// <summary>
        /// The narrowest the header (line-label) column is drawn.
        /// </summary>
        private const double MinHeaderColumnWidth = 60;

        /// <summary>
        /// The widest the header (line-label) column grows to fit its content before the text wraps.
        /// </summary>
        private const double MaxHeaderColumnWidth = 320;

        /// <summary>
        /// The shortest a data row is drawn (a single line of text with padding).
        /// </summary>
        private const double MinRowHeight = 18;

        /// <summary>
        /// The shortest the header (column-label) row is drawn.
        /// </summary>
        private const double MinHeaderRowHeight = 22;

        /// <summary>
        /// The horizontal indent applied per line-nesting level in the header column.
        /// </summary>
        private const double IndentPerLevel = 14;

        /// <summary>
        /// The horizontal padding on each side of a cell's text.
        /// </summary>
        private const double CellPadding = 4;

        /// <summary>
        /// The combined top-and-bottom padding added to a row's text height.
        /// </summary>
        private const double RowPadding = 6;

        /// <summary>
        /// The line height as a multiple of the font size (matching the exporter's wrapping).
        /// </summary>
        private const double LineHeightRatio = 1.2;

        /// <summary>
        /// The estimated glyph width as a fraction of the font size — the exporter's text metric, reused
        /// so the widths computed here agree with how the text actually wraps.
        /// </summary>
        private const double GlyphRatio = 0.6;

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

            var rows = new List<Row>();
            Flatten(table.Lines, 0, columns, rows);

            var headerColumnWidth = HeaderColumnWidth(table, rows);
            var columnWidths = ColumnWidths(columns, rows);

            var columnLefts = new double[columns.Count];
            var left = headerColumnWidth;
            for (var i = 0; i < columns.Count; i++)
            {
                columnLefts[i] = left;
                left += columnWidths[i];
            }

            var boxes = new List<Box>();

            // Header row: the empty top-left corner, then the column-header cells. Its height fits the
            // tallest wrapped column header.
            var headerRowHeight = HeaderRowHeight(columns, columnWidths);
            boxes.Add(HeaderCell($"{Identifier(table)}-corner", 0, 0, headerColumnWidth, headerRowHeight, label: null, indent: 0, centered: false));
            for (var i = 0; i < columns.Count; i++)
            {
                boxes.Add(HeaderCell($"col-{Identifier(columns[i])}", columnLefts[i], 0, columnWidths[i], headerRowHeight, NullIfBlank(columns[i].Label), indent: 0, centered: true));
            }

            // Data rows: the header-column cell (the line label, indented by nesting), then one cell per
            // column — a background cell that carries the intersection's label and style when one exists.
            var top = headerRowHeight;
            foreach (var row in rows)
            {
                var rowHeight = RowHeight(row, columns, columnWidths, headerColumnWidth);

                boxes.Add(HeaderCell($"row-{Identifier(row.Line)}", 0, top, headerColumnWidth, rowHeight, NullIfBlank(row.Line.Label), row.Depth, centered: false));

                for (var i = 0; i < columns.Count; i++)
                {
                    row.Cells.TryGetValue(i, out var cell);
                    var identifier = cell != null ? Identifier(cell) : $"{Identifier(row.Line)}-{Identifier(columns[i])}";
                    boxes.Add(DataCell(identifier, columnLefts[i], top, columnWidths[i], rowHeight, NullIfBlank(cell?.Label), cell?.CurrentStyle));
                }

                top += rowHeight;
            }

            return new Diagram(Identifier(table), boxes, Array.Empty<Edge>(), null, null)
            {
                Name = name,
                SemanticElement = table.Target,
            };
        }

        /// <summary>
        /// Flattens the line tree depth-first into rows, recording each line's nesting depth and mapping
        /// its cells to column indices. An invisible line is skipped; a collapsed line is shown but its
        /// descendants are not, mirroring the tool.
        /// </summary>
        /// <param name="lines">the lines to flatten</param>
        /// <param name="depth">the nesting depth of these lines</param>
        /// <param name="columns">the visible columns, for mapping cells to their index</param>
        /// <param name="rows">the accumulating row list</param>
        private static void Flatten(IEnumerable<SiriusTable.IDLine> lines, int depth, List<SiriusTable.IDColumn> columns, List<Row> rows)
        {
            foreach (var line in lines)
            {
                if (!line.Visible)
                {
                    continue;
                }

                var cells = new Dictionary<int, SiriusTable.IDCell>();
                foreach (var cell in line.Cells)
                {
                    var index = cell.Column == null ? -1 : columns.IndexOf(cell.Column);
                    if (index >= 0)
                    {
                        cells[index] = cell;
                    }
                }

                rows.Add(new Row(line, depth, cells));

                if (!line.Collapsed)
                {
                    Flatten(line.Lines, depth + 1, columns, rows);
                }
            }
        }

        /// <summary>
        /// The header (line-label) column width: the widest of the table's persisted width and the widest
        /// row label (including its nesting indent), clamped so a static export stays readable and no
        /// label overflows the cell without wrapping.
        /// </summary>
        /// <param name="table">the table</param>
        /// <param name="rows">the flattened rows</param>
        /// <returns>the header column width</returns>
        private static double HeaderColumnWidth(SiriusTable.IDTable table, List<Row> rows)
        {
            var content = rows.Count == 0
                ? 0
                : rows.Max(row => TextWidth(row.Line.Label, CellFontSize) + (row.Depth * IndentPerLevel));

            var persisted = table.HeaderColumnWidth is { } width && width > 0 ? width : 0;

            return Clamp(Math.Max(persisted, content + (2 * CellPadding)), MinHeaderColumnWidth, MaxHeaderColumnWidth);
        }

        /// <summary>
        /// The width of each data column: the widest of the column's persisted width and the widest of its
        /// header label and cell labels, clamped to a readable range.
        /// </summary>
        /// <param name="columns">the visible columns</param>
        /// <param name="rows">the flattened rows</param>
        /// <returns>the per-column widths, indexed as <paramref name="columns"/></returns>
        private static double[] ColumnWidths(List<SiriusTable.IDColumn> columns, List<Row> rows)
        {
            var widths = new double[columns.Count];
            for (var i = 0; i < columns.Count; i++)
            {
                var content = TextWidth(columns[i].Label, CellFontSize);
                foreach (var row in rows)
                {
                    if (row.Cells.TryGetValue(i, out var cell))
                    {
                        content = Math.Max(content, TextWidth(cell.Label, CellFontSizeOf(cell.CurrentStyle)));
                    }
                }

                var persisted = columns[i].Width is { } width && width > 0 ? width : 0;
                widths[i] = Clamp(Math.Max(persisted, content + (2 * CellPadding)), MinColumnWidth, MaxColumnWidth);
            }

            return widths;
        }

        /// <summary>
        /// The header-row height: enough to fit the tallest wrapped column header.
        /// </summary>
        /// <param name="columns">the visible columns</param>
        /// <param name="columnWidths">the resolved column widths</param>
        /// <returns>the header-row height</returns>
        private static double HeaderRowHeight(List<SiriusTable.IDColumn> columns, double[] columnWidths)
        {
            var lines = 1;
            for (var i = 0; i < columns.Count; i++)
            {
                lines = Math.Max(lines, LineCount(columns[i].Label, columnWidths[i], CellFontSize));
            }

            return Math.Max(MinHeaderRowHeight, (lines * CellFontSize * LineHeightRatio) + RowPadding);
        }

        /// <summary>
        /// A data row's height: enough to fit the tallest wrapped cell — the row header (in the header
        /// column, less its indent) or any data cell (in its column width).
        /// </summary>
        /// <param name="row">the row</param>
        /// <param name="columns">the visible columns</param>
        /// <param name="columnWidths">the resolved column widths</param>
        /// <param name="headerColumnWidth">the resolved header-column width</param>
        /// <returns>the row height</returns>
        private static double RowHeight(Row row, List<SiriusTable.IDColumn> columns, double[] columnWidths, double headerColumnWidth)
        {
            var lines = LineCount(row.Line.Label, headerColumnWidth - (row.Depth * IndentPerLevel) - (2 * CellPadding), CellFontSize);

            for (var i = 0; i < columns.Count; i++)
            {
                if (row.Cells.TryGetValue(i, out var cell))
                {
                    lines = Math.Max(lines, LineCount(cell.Label, columnWidths[i] - (2 * CellPadding), CellFontSizeOf(cell.CurrentStyle)));
                }
            }

            return Math.Max(MinRowHeight, (lines * CellFontSize * LineHeightRatio) + RowPadding);
        }

        /// <summary>
        /// Builds a header cell — a top-row column header or a left-column line header. A column header
        /// centers its (wrapped) label; a line header left-aligns it, indented by nesting depth and
        /// wrapped to the header column.
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
            PlaceLabel(box, label, x, y, width, height, indent, centered, style.FontSize);
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
        /// <param name="height">the cell height</param>
        /// <param name="label">the cell text, or <c>null</c> for a blank cell</param>
        /// <param name="cellStyle">the persisted cell style, or <c>null</c></param>
        /// <returns>the data box</returns>
        private static Box DataCell(string identifier, double x, double y, double width, double height, string? label, SiriusTable.IDCellStyle? cellStyle)
        {
            var style = GridStyle(CellFill, CellFontSize, bold: false);
            ApplyCellStyle(style, cellStyle);

            var box = MakeBox(identifier, x, y, width, height, style);
            PlaceLabel(box, label, x, y, width, height, indent: 0, centered: true, style.FontSize);
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
        /// Attaches the label to a cell when it has text. A centered label is placed and wrapped by the
        /// exporter's box-centering; a left-aligned one is positioned at the cell's left — offset by the
        /// padding and the nesting indent, wrapped to the remaining width and vertically centered over its
        /// wrapped lines. A blank cell gets no label.
        /// </summary>
        /// <param name="box">the cell box</param>
        /// <param name="text">the label text, or <c>null</c>/blank for no label</param>
        /// <param name="x">the cell's left</param>
        /// <param name="y">the cell's top</param>
        /// <param name="width">the cell width</param>
        /// <param name="height">the cell height</param>
        /// <param name="indent">the nesting depth (left-aligned labels only)</param>
        /// <param name="centered">whether the label centers in the box rather than left-aligning</param>
        /// <param name="fontSize">the resolved font size, for wrapping and vertical centering</param>
        private static void PlaceLabel(Box box, string? text, double x, double y, double width, double height, int indent, bool centered, double fontSize)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            var label = new Label(text!);
            if (!centered)
            {
                var indentOffset = indent * IndentPerLevel;
                var wrapWidth = Math.Max(1, width - indentOffset - (2 * CellPadding));
                var lines = LineCount(text, wrapWidth, fontSize);
                var top = y + Math.Max(CellPadding / 2, (height - (lines * fontSize * LineHeightRatio)) / 2);

                label.Position = new Point(x + CellPadding + indentOffset, top);
                label.Width = wrapWidth;
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
        /// The estimated single-line width of a label at a font size, using the exporter's glyph metric.
        /// </summary>
        /// <param name="text">the label text (may be <c>null</c>)</param>
        /// <param name="fontSize">the font size</param>
        /// <returns>the estimated width in pixels</returns>
        private static double TextWidth(string? text, double fontSize)
        {
            return string.IsNullOrEmpty(text) ? 0 : text!.Length * fontSize * GlyphRatio;
        }

        /// <summary>
        /// The number of lines a label wraps to in the available width, measured exactly as the exporter
        /// wraps it so the reserved height matches the rendered text.
        /// </summary>
        /// <param name="text">the label text (may be <c>null</c>)</param>
        /// <param name="width">the available width</param>
        /// <param name="fontSize">the font size</param>
        /// <returns>the line count (at least one)</returns>
        private static int LineCount(string? text, double width, double fontSize)
        {
            return string.IsNullOrEmpty(text)
                ? 1
                : Math.Max(1, SvgExporter.WrapLines(text!, width, new ResolvedStyle { FontSize = fontSize }).Count);
        }

        /// <summary>
        /// The font size a cell renders at — its persisted <c>labelSize</c> when set, otherwise the
        /// default — used to measure the cell before its box style is built.
        /// </summary>
        /// <param name="cellStyle">the persisted cell style, or <c>null</c></param>
        /// <returns>the font size</returns>
        private static double CellFontSizeOf(SiriusTable.IDCellStyle? cellStyle)
        {
            return cellStyle?.LabelSize is { } size && size > 0 ? size : CellFontSize;
        }

        /// <summary>
        /// Clamps a value to the inclusive range.
        /// </summary>
        /// <param name="value">the value</param>
        /// <param name="min">the lower bound</param>
        /// <param name="max">the upper bound</param>
        /// <returns>the clamped value</returns>
        private static double Clamp(double value, double min, double max)
        {
            return Math.Min(max, Math.Max(min, value));
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

        /// <summary>
        /// A flattened table row: the line, its nesting depth and the cells that occupy each column index.
        /// </summary>
        private sealed class Row
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Row"/> class.
            /// </summary>
            /// <param name="line">the line</param>
            /// <param name="depth">the nesting depth</param>
            /// <param name="cells">the cells keyed by column index</param>
            public Row(SiriusTable.IDLine line, int depth, Dictionary<int, SiriusTable.IDCell> cells)
            {
                this.Line = line;
                this.Depth = depth;
                this.Cells = cells;
            }

            /// <summary>
            /// Gets the line the row was flattened from.
            /// </summary>
            public SiriusTable.IDLine Line { get; }

            /// <summary>
            /// Gets the nesting depth (0 for a top-level line).
            /// </summary>
            public int Depth { get; }

            /// <summary>
            /// Gets the cells of the row, keyed by their column index.
            /// </summary>
            public Dictionary<int, SiriusTable.IDCell> Cells { get; }
        }
    }
}
