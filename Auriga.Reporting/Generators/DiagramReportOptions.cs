// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramReportOptions.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Generators
{
    using System;

    using Auriga.Reporting.Drawing;

    /// <summary>
    /// What <see cref="IDiagramReportGenerator"/> writes, and how. The defaults produce an SVG and
    /// a PNG of every representation in the model, at its persisted size.
    /// </summary>
    public sealed class DiagramReportOptions
    {
        /// <summary>
        /// The backing field of <see cref="Raster"/>.
        /// </summary>
        private RasterOptions raster = new();

        /// <summary>
        /// Gets or sets the artifacts to write, defaulting to an SVG and a PNG of each
        /// representation.
        /// </summary>
        public DiagramFormats Formats { get; set; } = DiagramFormats.Svg | DiagramFormats.Png;

        /// <summary>
        /// Gets or sets how the raster formats are drawn — the scale or resolution, the background
        /// and the JPEG quality. Ignored when neither <see cref="DiagramFormats.Png"/> nor
        /// <see cref="DiagramFormats.Jpeg"/> is asked for.
        /// </summary>
        /// <exception cref="ArgumentNullException">the raster options are null</exception>
        public RasterOptions Raster
        {
            get => this.raster;

            set => this.raster = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets a wildcard pattern the representation's name must match to be written —
        /// <c>*</c> for any run of characters and <c>?</c> for one, matched case-insensitively over
        /// the whole name, as in <c>[SAB]*</c>. <c>null</c> or empty writes every representation.
        /// </summary>
        public string? NameFilter { get; set; }
    }
}
