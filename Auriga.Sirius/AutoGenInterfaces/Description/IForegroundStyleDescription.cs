// ------------------------------------------------------------------------------------------------
// <copyright file="IForegroundStyleDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Table.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>ForegroundStyleDescription</c> interface.
    /// </summary>
    public partial interface IForegroundStyleDescription : Auriga.IAurigaElement
    {
        /// <summary>
        /// Gets or sets the fore ground color.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.IColorDescription ForeGroundColor { get; set; }

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
