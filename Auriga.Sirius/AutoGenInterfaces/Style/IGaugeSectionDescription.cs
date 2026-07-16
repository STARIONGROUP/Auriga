// ------------------------------------------------------------------------------------------------
// <copyright file="IGaugeSectionDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Style
{
    /// <summary>
    /// The gauge section represents one gauge of a GaugeCompositeStyle.
    /// </summary>
    public partial interface IGaugeSectionDescription : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// The background color.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.IColorDescription BackgroundColor { get; set; }

        /// <summary>
        /// The foreground color.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.IColorDescription ForegroundColor { get; set; }

        /// <summary>
        /// The label of the gauge.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Gets or sets the max value expression.
        /// </summary>
        string MaxValueExpression { get; set; }

        /// <summary>
        /// Gets or sets the min value expression.
        /// </summary>
        string MinValueExpression { get; set; }

        /// <summary>
        /// Gets or sets the value expression.
        /// </summary>
        string ValueExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
