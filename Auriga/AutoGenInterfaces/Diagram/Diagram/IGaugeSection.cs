// ------------------------------------------------------------------------------------------------
// <copyright file="IGaugeSection.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable disable

namespace Auriga.Diagram.Diagram
{
    /// <summary>
    /// The gauge section represents one gauge of a GaugeCompositeStyle.
    /// </summary>
    public partial interface IGaugeSection : Auriga.Diagram.Viewpoint.ICustomizable
    {
        /// <summary>
        /// The background color.
        /// </summary>
        string BackgroundColor { get; set; }

        /// <summary>
        /// The foreground color.
        /// </summary>
        string ForegroundColor { get; set; }

        /// <summary>
        /// The label of the gauge.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// The max value of the gauge.
        /// </summary>
        int? Max { get; set; }

        /// <summary>
        /// The min value of the gauge.
        /// </summary>
        int? Min { get; set; }

        /// <summary>
        /// The current value.
        /// </summary>
        int? Value { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
