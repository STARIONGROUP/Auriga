// ------------------------------------------------------------------------------------------------
// <copyright file="IXlsxTableExporter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting
{
    using System.Collections.Generic;
    using System.IO;

    using SiriusTable = Auriga.Diagram.Table;

    /// <summary>
    /// Serializes Sirius table representations to an Excel <c>.xlsx</c> workbook. A table is tabular data,
    /// so a spreadsheet is the editable counterpart of the SVG grid <see cref="ISvgExporter"/> produces —
    /// the same content, laid out by Excel rather than at persisted pixel widths.
    /// </summary>
    public interface IXlsxTableExporter
    {
        /// <summary>
        /// Writes a single table to a workbook file, as one worksheet.
        /// </summary>
        /// <param name="table">the parsed Sirius table representation</param>
        /// <param name="path">the path of the <c>.xlsx</c> file to write</param>
        /// <param name="name">the table name, used as the worksheet name, or <c>null</c> for a default</param>
        void Export(SiriusTable.IDTable table, string path, string? name = null);

        /// <summary>
        /// Writes a single table to a stream, as one worksheet.
        /// </summary>
        /// <param name="table">the parsed Sirius table representation</param>
        /// <param name="stream">the stream to write the workbook to</param>
        /// <param name="name">the table name, used as the worksheet name, or <c>null</c> for a default</param>
        void Export(SiriusTable.IDTable table, Stream stream, string? name = null);

        /// <summary>
        /// Writes several tables to one workbook, a worksheet each — the natural export of a whole
        /// <c>.aird</c> session's table representations.
        /// </summary>
        /// <param name="tables">the tables, paired with the name each worksheet takes</param>
        /// <param name="path">the path of the <c>.xlsx</c> file to write</param>
        void Export(IEnumerable<KeyValuePair<string, SiriusTable.IDTable>> tables, string path);

        /// <summary>
        /// Writes several tables to one workbook on a stream, a worksheet each.
        /// </summary>
        /// <param name="tables">the tables, paired with the name each worksheet takes</param>
        /// <param name="stream">the stream to write the workbook to</param>
        void Export(IEnumerable<KeyValuePair<string, SiriusTable.IDTable>> tables, Stream stream);
    }
}
