// ------------------------------------------------------------------------------------------------
// <copyright file="IFlatContainerStyleDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>FlatContainerStyleDescription</c> interface.
    /// </summary>
    public partial interface IFlatContainerStyleDescription : Auriga.Diagram.Diagram.Description.Style.IContainerStyleDescription, Auriga.Diagram.Diagram.Description.Style.ISizeComputationContainerStyleDescription
    {
        /// <summary>
        /// The color to use.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IColorDescription BackgroundColor { get; set; }

        /// <summary>
        /// The background style.
        /// </summary>
        Auriga.Diagram.Diagram.BackgroundStyle BackgroundStyle { get; set; }

        /// <summary>
        /// The color to use.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IColorDescription ForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets the label border style.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Style.ILabelBorderStyleDescription LabelBorderStyle { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
