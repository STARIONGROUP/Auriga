// ------------------------------------------------------------------------------------------------
// <copyright file="ITableBuilder.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;

    using SiriusTable = Auriga.Diagram.Table;

    /// <summary>
    /// The service that builds intermediate <see cref="Diagram"/> models from parsed Sirius <b>table</b>
    /// representations — the table counterpart of <see cref="IDiagramBuilder"/>. The default
    /// implementation, <see cref="TableBuilder"/>, synthesizes the grid a table does not persist; register
    /// it in the application's container, or construct it directly.
    /// </summary>
    /// <remarks>
    /// A table has two exports. This builder lays it out as a pixel grid of boxes for
    /// <see cref="ISvgExporter"/>, while <see cref="IXlsxTableExporter"/> writes it to a worksheet and
    /// leaves the layout to Excel. Both read the same <see cref="TableGrid"/>, so they agree on what the
    /// table contains and differ only in how it is presented.
    /// </remarks>
    public interface ITableBuilder
    {
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
        Diagram Build(SiriusTable.IDTable table, string? name = null);
    }
}
