// ------------------------------------------------------------------------------------------------
// <copyright file="IDTableElementStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Table
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>DTableElementStyle</c> interface.
    /// </summary>
    public partial interface IDTableElementStyle : Auriga.Sirius.Viewpoint.IIdentifiedElement
    {
        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        string BackgroundColor { get; set; }

        /// <summary>
        /// Determine if the background part of the style is computed from a conditional style or not (default style).
        /// </summary>
        bool? DefaultBackgroundStyle { get; set; }

        /// <summary>
        /// Determine if the foreground part of the style is computed from a conditional style or not (default style).
        /// </summary>
        bool? DefaultForegroundStyle { get; set; }

        /// <summary>
        /// Gets or sets the foreground color.
        /// </summary>
        string ForegroundColor { get; set; }

        /// <summary>
        /// The font format.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.FontFormat> LabelFormat { get; }

        /// <summary>
        /// The font size.
        /// </summary>
        int? LabelSize { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
