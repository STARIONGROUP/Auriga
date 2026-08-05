// ------------------------------------------------------------------------------------------------
// <copyright file="RasterFormat.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Drawing
{
    /// <summary>
    /// The bitmap formats <see cref="IRasterExporter"/> encodes to.
    /// </summary>
    public enum RasterFormat
    {
        /// <summary>
        /// PNG: lossless and alpha-capable, so a diagram exported without a background keeps its
        /// transparency. The format to prefer for a diagram, whose flat fills and text compress
        /// well and suffer visibly from lossy artefacts.
        /// </summary>
        Png,

        /// <summary>
        /// JPEG: lossy and opaque. It has no alpha channel, so a diagram exported to JPEG is always
        /// composited onto a background — white, unless <see cref="RasterOptions.Background"/> says
        /// otherwise.
        /// </summary>
        Jpeg,
    }
}
