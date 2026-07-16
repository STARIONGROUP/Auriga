// ------------------------------------------------------------------------------------------------
// <copyright file="IBorderedStyleDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Style
{
    /// <summary>
    /// Definition of the <c>BorderedStyleDescription</c> interface.
    /// </summary>
    public partial interface IBorderedStyleDescription : Auriga.Diagram.Viewpoint.Description.Style.IStyleDescription
    {
        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IColorDescription BorderColor { get; set; }

        /// <summary>
        /// The style of the border line.
        /// </summary>
        Auriga.Diagram.Diagram.LineStyle? BorderLineStyle { get; set; }

        /// <summary>
        /// An expression computing the size of the border.
        /// </summary>
        string BorderSizeComputationExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
