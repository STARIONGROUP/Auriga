// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramReportStage.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Generators
{
    /// <summary>
    /// The stages a run passes through, in order. They are reported because they cost markedly
    /// different amounts of time: reading a fragmented model is slow and silent, where writing is
    /// steady and countable.
    /// </summary>
    public enum DiagramReportStage
    {
        /// <summary>
        /// Reading the <c>.aird</c>, its fragments and the Capella documents it references.
        /// </summary>
        Loading,

        /// <summary>
        /// Turning the read representations into diagrams.
        /// </summary>
        Building,

        /// <summary>
        /// Writing a representation's artifacts.
        /// </summary>
        Writing,

        /// <summary>
        /// Writing the workbook of the model's tables.
        /// </summary>
        WritingWorkbook,
    }
}
