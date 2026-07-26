// ------------------------------------------------------------------------------------------------
// <copyright file="TableGrid.cs" company="Starion Group S.A.">
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

    using SiriusTable = Auriga.Diagram.Table;

    /// <summary>
    /// The shape of a Sirius table representation, independent of how it is rendered: the visible columns
    /// in order, and the visible lines flattened into rows that carry their nesting depth and their cells
    /// keyed by column index.
    ///
    /// <para>This is the one traversal of a <see cref="SiriusTable.IDTable"/>, shared by every exporter so
    /// they agree on which lines and columns are shown and how the intersections line up.
    /// <see cref="TableBuilder"/> lays it out as a pixel grid for SVG; <see cref="XlsxTableExporter"/>
    /// writes it as worksheet cells and lets Excel do the layout. Neither owns the traversal, so a
    /// visibility or nesting rule cannot drift between the two outputs.</para>
    /// </summary>
    public sealed class TableGrid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableGrid"/> class.
        /// </summary>
        /// <param name="columns">the visible columns, in order</param>
        /// <param name="rows">the visible lines, flattened depth-first</param>
        private TableGrid(IReadOnlyList<SiriusTable.IDColumn> columns, IReadOnlyList<TableRow> rows)
        {
            this.Columns = columns;
            this.Rows = rows;
        }

        /// <summary>
        /// Gets the visible columns, in the order the table declares them.
        /// </summary>
        public IReadOnlyList<SiriusTable.IDColumn> Columns { get; }

        /// <summary>
        /// Gets the visible lines flattened depth-first, each carrying its nesting depth and cells.
        /// </summary>
        public IReadOnlyList<TableRow> Rows { get; }

        /// <summary>
        /// Reads the grid of a table: its visible columns, and its line tree flattened depth-first. An
        /// invisible line or column is omitted; a collapsed line is shown but its descendants are not,
        /// mirroring the tool.
        /// </summary>
        /// <param name="table">the parsed Sirius table representation</param>
        /// <returns>the grid</returns>
        /// <exception cref="ArgumentNullException">the table is null</exception>
        public static TableGrid From(SiriusTable.IDTable table)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            var columns = table.Columns.Where(column => column.Visible).ToList();

            var rows = new List<TableRow>();
            Flatten(table.Lines, 0, columns, rows);

            return new TableGrid(columns, rows);
        }

        /// <summary>
        /// Flattens the line tree depth-first into rows, recording each line's nesting depth and mapping
        /// its cells to column indices.
        /// </summary>
        /// <param name="lines">the lines to flatten</param>
        /// <param name="depth">the nesting depth of these lines</param>
        /// <param name="columns">the visible columns, for mapping cells to their index</param>
        /// <param name="rows">the accumulating row list</param>
        private static void Flatten(IEnumerable<SiriusTable.IDLine> lines, int depth, List<SiriusTable.IDColumn> columns, List<TableRow> rows)
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

                rows.Add(new TableRow(line, depth, cells));

                if (!line.Collapsed)
                {
                    Flatten(line.Lines, depth + 1, columns, rows);
                }
            }
        }
    }
}
