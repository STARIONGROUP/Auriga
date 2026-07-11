// ------------------------------------------------------------------------------------------------
// <copyright file="GaugeSection.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram
{
    using System.Collections.Generic;

    /// <summary>
    /// The gauge section represents one gauge of a GaugeCompositeStyle.
    /// </summary>
    public partial class GaugeSection : Auriga.AurigaElement, Auriga.Sirius.Diagram.IGaugeSection
    {
        /// <summary>
        /// The background color.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets the custom features.
        /// </summary>
        public List<string> CustomFeatures { get; } = new List<string>();

        /// <summary>
        /// The foreground color.
        /// </summary>
        public string ForegroundColor { get; set; }

        /// <summary>
        /// The label of the gauge.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The max value of the gauge.
        /// </summary>
        public int? Max { get; set; }

        /// <summary>
        /// The min value of the gauge.
        /// </summary>
        public int? Min { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// The current value.
        /// </summary>
        public int? Value { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
