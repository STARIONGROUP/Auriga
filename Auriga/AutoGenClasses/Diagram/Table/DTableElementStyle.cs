// ------------------------------------------------------------------------------------------------
// <copyright file="DTableElementStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Table
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>DTableElementStyle</c> class.
    /// </summary>
    public partial class DTableElementStyle : Auriga.Core.AurigaElement, Auriga.Diagram.Table.IDTableElementStyle
    {
        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Determine if the background part of the style is computed from a conditional style or not (default style).
        /// </summary>
        public bool? DefaultBackgroundStyle { get; set; }

        /// <summary>
        /// Determine if the foreground part of the style is computed from a conditional style or not (default style).
        /// </summary>
        public bool? DefaultForegroundStyle { get; set; }

        /// <summary>
        /// Gets or sets the foreground color.
        /// </summary>
        public string ForegroundColor { get; set; }

        /// <summary>
        /// The font format.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.FontFormat> LabelFormat { get; } = new List<Auriga.Diagram.Viewpoint.FontFormat>();

        /// <summary>
        /// The font size.
        /// </summary>
        public int? LabelSize { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
