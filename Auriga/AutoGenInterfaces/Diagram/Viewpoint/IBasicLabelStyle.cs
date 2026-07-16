// ------------------------------------------------------------------------------------------------
// <copyright file="IBasicLabelStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint
{
    using System.Collections.Generic;

    /// <summary>
    /// The style of a label.
    /// </summary>
    public partial interface IBasicLabelStyle : Auriga.Diagram.Viewpoint.ICustomizable
    {
        /// <summary>
        /// The path of the icon to display on the element. If unset, the icon corresponding to the semantic element will be displayed.
        /// </summary>
        string IconPath { get; set; }

        /// <summary>
        /// Gets or sets the label color.
        /// </summary>
        string LabelColor { get; set; }

        /// <summary>
        /// The font format.
        /// </summary>
        List<Auriga.Diagram.Viewpoint.FontFormat> LabelFormat { get; }

        /// <summary>
        /// The font size.
        /// </summary>
        int? LabelSize { get; set; }

        /// <summary>
        /// True, if the icon shoud be dispayed on the element.
        /// </summary>
        bool? ShowIcon { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
