// ------------------------------------------------------------------------------------------------
// <copyright file="ForegroundStyleDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Table.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>ForegroundStyleDescription</c> class.
    /// </summary>
    public partial class ForegroundStyleDescription : Auriga.Core.AurigaElement, Auriga.Diagram.Table.Description.IForegroundStyleDescription
    {
        /// <summary>
        /// Gets or sets the fore ground color.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IColorDescription ForeGroundColor { get; set; }

        /// <summary>
        /// The font format.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.FontFormat> LabelFormat { get; } = new List<Auriga.Diagram.Viewpoint.FontFormat>();

        /// <summary>
        /// The font size.
        /// </summary>
        public int? LabelSize { get; set; } = 12;

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
