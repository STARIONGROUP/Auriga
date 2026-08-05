// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramFormats.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Generators
{
    using System;

    /// <summary>
    /// The artifacts <see cref="IDiagramReportGenerator"/> writes for a representation. A flags
    /// enumeration because one run usually wants more than one: the SVG to embed and the PNG to
    /// paste, from a single load and a single build.
    /// </summary>
    [Flags]
    public enum DiagramFormats
    {
        /// <summary>
        /// Nothing. A report asked for no format writes no file, which the generator treats as a
        /// mistake rather than as an empty run.
        /// </summary>
        None = 0,

        /// <summary>
        /// A scalable <c>.svg</c> per representation.
        /// </summary>
        Svg = 1,

        /// <summary>
        /// A <c>.png</c> per representation.
        /// </summary>
        Png = 2,

        /// <summary>
        /// A <c>.jpg</c> per representation.
        /// </summary>
        Jpeg = 4,

        /// <summary>
        /// One <c>.xlsx</c> workbook of the model's table representations, a worksheet each. It
        /// applies to tables alone: a graphical diagram has no rows and columns to put in a
        /// spreadsheet, and a model with no table writes no workbook.
        /// </summary>
        Xlsx = 8,
    }
}
