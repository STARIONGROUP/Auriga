// ------------------------------------------------------------------------------------------------
// <copyright file="XlsxTableExporter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using ClosedXML.Excel;

    using SiriusTable = Auriga.Diagram.Table;

    /// <summary>
    /// Writes Sirius table representations to an Excel <c>.xlsx</c> workbook: the header row of column
    /// labels, the header column of line labels indented by nesting, and one cell per intersection.
    ///
    /// <para>It shares <see cref="TableGrid"/> with <see cref="TableBuilder"/>, so the SVG grid and the
    /// worksheet always contain the same lines, columns and intersections. What it deliberately does not
    /// share is the geometry: a table persists column widths from the tool's last interactive layout, and
    /// the SVG builder grows them to fit wrapped text because SVG has no layout engine. Excel does, so the
    /// persisted widths are converted to column widths and the rest is left to auto-fit — the pixel
    /// wrapping, synthesized row heights and clamps have no meaning in a spreadsheet.</para>
    /// </summary>
    public sealed class XlsxTableExporter : IXlsxTableExporter
    {
        /// <summary>
        /// Excel's limit on a worksheet name.
        /// </summary>
        private const int MaxSheetNameLength = 31;

        /// <summary>
        /// The worksheet name used when the caller supplies none.
        /// </summary>
        private const string DefaultSheetName = "Table";

        /// <summary>
        /// The characters Excel forbids in a worksheet name.
        /// </summary>
        private static readonly char[] IllegalSheetNameCharacters = { ':', '\\', '/', '?', '*', '[', ']' };

        /// <summary>
        /// The fill of the header row and header column, mirroring the SVG grid's header shading.
        /// </summary>
        private static readonly XLColor HeaderFill = XLColor.FromArgb(240, 240, 240);

        /// <summary>
        /// The cell border color, mirroring the SVG grid lines.
        /// </summary>
        private static readonly XLColor GridLine = XLColor.FromArgb(170, 170, 170);

        /// <summary>
        /// Writes a single table to a workbook file, as one worksheet.
        /// </summary>
        /// <param name="table">the parsed Sirius table representation</param>
        /// <param name="path">the path of the <c>.xlsx</c> file to write</param>
        /// <param name="name">the table name, used as the worksheet name, or <c>null</c> for a default</param>
        /// <exception cref="ArgumentNullException">the table is null</exception>
        /// <exception cref="ArgumentException">the path is null or empty</exception>
        public void Export(SiriusTable.IDTable table, string path, string? name = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The path is required.", nameof(path));
            }

            using var workbook = Build(new[] { new KeyValuePair<string, SiriusTable.IDTable>(name ?? DefaultSheetName, table) });
            workbook.SaveAs(path);
        }

        /// <summary>
        /// Writes a single table to a stream, as one worksheet.
        /// </summary>
        /// <param name="table">the parsed Sirius table representation</param>
        /// <param name="stream">the stream to write the workbook to</param>
        /// <param name="name">the table name, used as the worksheet name, or <c>null</c> for a default</param>
        /// <exception cref="ArgumentNullException">the table or the stream is null</exception>
        public void Export(SiriusTable.IDTable table, Stream stream, string? name = null)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            using var workbook = Build(new[] { new KeyValuePair<string, SiriusTable.IDTable>(name ?? DefaultSheetName, table) });
            workbook.SaveAs(stream);
        }

        /// <summary>
        /// Writes several tables to one workbook, a worksheet each.
        /// </summary>
        /// <param name="tables">the tables, paired with the name each worksheet takes</param>
        /// <param name="path">the path of the <c>.xlsx</c> file to write</param>
        /// <exception cref="ArgumentNullException">the tables are null</exception>
        /// <exception cref="ArgumentException">the path is null or empty</exception>
        public void Export(IEnumerable<KeyValuePair<string, SiriusTable.IDTable>> tables, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The path is required.", nameof(path));
            }

            using var workbook = Build(tables);
            workbook.SaveAs(path);
        }

        /// <summary>
        /// Writes several tables to one workbook on a stream, a worksheet each.
        /// </summary>
        /// <param name="tables">the tables, paired with the name each worksheet takes</param>
        /// <param name="stream">the stream to write the workbook to</param>
        /// <exception cref="ArgumentNullException">the tables or the stream is null</exception>
        public void Export(IEnumerable<KeyValuePair<string, SiriusTable.IDTable>> tables, Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            using var workbook = Build(tables);
            workbook.SaveAs(stream);
        }

        /// <summary>
        /// Builds the workbook, one worksheet per table.
        /// </summary>
        /// <param name="tables">the tables, paired with the name each worksheet takes</param>
        /// <returns>the workbook, which the caller disposes</returns>
        /// <exception cref="ArgumentNullException">the tables, or one of them, is null</exception>
        private static XLWorkbook Build(IEnumerable<KeyValuePair<string, SiriusTable.IDTable>> tables)
        {
            if (tables == null)
            {
                throw new ArgumentNullException(nameof(tables));
            }

            var workbook = new XLWorkbook();

            try
            {
                var used = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                foreach (var entry in tables)
                {
                    if (entry.Value == null)
                    {
                        throw new ArgumentNullException(nameof(tables), "A table is null.");
                    }

                    WriteSheet(workbook.Worksheets.Add(UniqueSheetName(entry.Key, used)), entry.Value);
                }

                if (!workbook.Worksheets.Any())
                {
                    // A workbook with no sheet is not a valid xlsx, so an empty export still gets one.
                    workbook.Worksheets.Add(DefaultSheetName);
                }

                return workbook;
            }
            catch
            {
                workbook.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Writes one table onto a worksheet: the header row, the header column and the intersections,
        /// then the freeze panes and column widths.
        /// </summary>
        /// <param name="sheet">the worksheet to write to</param>
        /// <param name="table">the table</param>
        private static void WriteSheet(IXLWorksheet sheet, SiriusTable.IDTable table)
        {
            var grid = TableGrid.From(table);

            // Row 1 is the column headers and column 1 the line headers, so the data starts at B2 and the
            // top-left corner cell stays empty — the same shape the SVG grid draws.
            for (var column = 0; column < grid.Columns.Count; column++)
            {
                var cell = sheet.Cell(1, column + 2);
                cell.Value = grid.Columns[column].Label ?? string.Empty;
                StyleHeader(cell);
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            StyleHeader(sheet.Cell(1, 1));

            for (var row = 0; row < grid.Rows.Count; row++)
            {
                var tableRow = grid.Rows[row];

                var header = sheet.Cell(row + 2, 1);
                header.Value = tableRow.Line.Label ?? string.Empty;
                StyleHeader(header);

                // Nesting is an indent level rather than the SVG's pixel offset, so Excel keeps it when
                // the column is resized and a reader can still outline the rows.
                header.Style.Alignment.Indent = tableRow.Depth;

                for (var column = 0; column < grid.Columns.Count; column++)
                {
                    var cell = sheet.Cell(row + 2, column + 2);
                    StyleBorder(cell);

                    if (!tableRow.Cells.TryGetValue(column, out var dCell))
                    {
                        continue;
                    }

                    cell.Value = dCell.Label ?? string.Empty;
                    ApplyCellStyle(cell, dCell.CurrentStyle);
                }
            }

            sheet.SheetView.FreezeRows(1);
            sheet.SheetView.FreezeColumns(1);

            SetColumnWidths(sheet, grid);
        }

        /// <summary>
        /// Applies the persisted Sirius cell style — background, foreground, label size and label format —
        /// to a worksheet cell. The same style bag the SVG grid resolves, mapped to Excel's vocabulary.
        /// </summary>
        /// <param name="cell">the worksheet cell</param>
        /// <param name="cellStyle">the persisted style, or <c>null</c> when the cell has none</param>
        private static void ApplyCellStyle(IXLCell cell, SiriusTable.IDTableElementStyle? cellStyle)
        {
            if (cellStyle == null)
            {
                return;
            }

            if (Color.TryParse(cellStyle.BackgroundColor, out var background))
            {
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(background.Red, background.Green, background.Blue);
            }

            if (Color.TryParse(cellStyle.ForegroundColor, out var foreground))
            {
                cell.Style.Font.FontColor = XLColor.FromArgb(foreground.Red, foreground.Green, foreground.Blue);
            }

            if (cellStyle.LabelSize is { } size && size > 0)
            {
                cell.Style.Font.FontSize = size;
            }

            foreach (var format in cellStyle.LabelFormat)
            {
                switch (format)
                {
                    case Auriga.Diagram.Viewpoint.FontFormat.Bold:
                        cell.Style.Font.Bold = true;
                        break;
                    case Auriga.Diagram.Viewpoint.FontFormat.Italic:
                        cell.Style.Font.Italic = true;
                        break;
                    case Auriga.Diagram.Viewpoint.FontFormat.Underline:
                        cell.Style.Font.Underline = XLFontUnderlineValues.Single;
                        break;
                    case Auriga.Diagram.Viewpoint.FontFormat.Strike_through:
                        cell.Style.Font.Strikethrough = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Sizes the columns: a data column takes its persisted width when the table records one, and
        /// auto-fits otherwise. The header column always auto-fits — a table routinely persists a
        /// header-column width of a few pixels, the tool's collapsed resize handle, which would hide every
        /// line label.
        /// </summary>
        /// <param name="sheet">the worksheet</param>
        /// <param name="grid">the table grid</param>
        private static void SetColumnWidths(IXLWorksheet sheet, TableGrid grid)
        {
            sheet.Column(1).AdjustToContents();

            for (var column = 0; column < grid.Columns.Count; column++)
            {
                var width = grid.Columns[column].Width;

                if (width is { } persisted && persisted > 0)
                {
                    // Excel measures a column in characters of the default font, not pixels; the
                    // conventional conversion is 7 pixels per character plus 5 pixels of padding.
                    sheet.Column(column + 2).Width = Math.Max(1, (persisted - 5) / 7.0);
                }
                else
                {
                    sheet.Column(column + 2).AdjustToContents();
                }
            }
        }

        /// <summary>
        /// Applies the header shading and border to a cell.
        /// </summary>
        /// <param name="cell">the worksheet cell</param>
        private static void StyleHeader(IXLCell cell)
        {
            cell.Style.Fill.BackgroundColor = HeaderFill;
            cell.Style.Font.Bold = true;
            StyleBorder(cell);
        }

        /// <summary>
        /// Applies the thin grid border to a cell, mirroring the SVG grid lines.
        /// </summary>
        /// <param name="cell">the worksheet cell</param>
        private static void StyleBorder(IXLCell cell)
        {
            cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.OutsideBorderColor = GridLine;
        }

        /// <summary>
        /// A worksheet name Excel accepts and the workbook does not already use: the supplied name with
        /// the forbidden characters replaced, trimmed to 31 characters, and suffixed when it collides.
        /// </summary>
        /// <param name="name">the requested name</param>
        /// <param name="used">the names already taken, which this call adds to</param>
        /// <returns>the worksheet name</returns>
        private static string UniqueSheetName(string? name, HashSet<string> used)
        {
            var sanitized = new StringBuilder();

            foreach (var character in (name ?? string.Empty).Trim())
            {
                sanitized.Append(Array.IndexOf(IllegalSheetNameCharacters, character) >= 0 ? '-' : character);
            }

            var candidate = sanitized.ToString().Trim('\'');
            if (string.IsNullOrEmpty(candidate))
            {
                candidate = DefaultSheetName;
            }

            if (candidate.Length > MaxSheetNameLength)
            {
                candidate = candidate.Substring(0, MaxSheetNameLength);
            }

            var unique = candidate;
            var suffix = 2;

            while (!used.Add(unique))
            {
                var tail = $" ({suffix++})";
                var head = candidate.Length + tail.Length > MaxSheetNameLength
                    ? candidate.Substring(0, MaxSheetNameLength - tail.Length)
                    : candidate;

                unique = head + tail;
            }

            return unique;
        }
    }
}
