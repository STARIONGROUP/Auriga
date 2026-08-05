// ------------------------------------------------------------------------------------------------
// <copyright file="TableRow.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting
{
    using System.Collections.Generic;

    using SiriusTable = Auriga.Diagram.Table;

    /// <summary>
    /// One visible line of a <see cref="TableGrid"/>: the line itself, how deeply it nests, and the cells
    /// it holds keyed by the index of the column they sit under. An intersection with no cell is simply
    /// absent from <see cref="Cells"/>.
    /// </summary>
    public sealed class TableRow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableRow"/> class.
        /// </summary>
        /// <param name="line">the line the row was flattened from</param>
        /// <param name="depth">the nesting depth, 0 for a top-level line</param>
        /// <param name="cells">the cells, keyed by column index</param>
        public TableRow(SiriusTable.IDLine line, int depth, IReadOnlyDictionary<int, SiriusTable.IDCell> cells)
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
        /// Gets the nesting depth, 0 for a top-level line.
        /// </summary>
        public int Depth { get; }

        /// <summary>
        /// Gets the cells of the row, keyed by their column index.
        /// </summary>
        public IReadOnlyDictionary<int, SiriusTable.IDCell> Cells { get; }
    }
}
