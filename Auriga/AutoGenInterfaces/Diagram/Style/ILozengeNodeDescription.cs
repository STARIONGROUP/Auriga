// ------------------------------------------------------------------------------------------------
// <copyright file="ILozengeNodeDescription.cs" company="Starion Group S.A.">
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
    /// The diamond style to display a node as a diamond.
    /// </summary>
    public partial interface ILozengeNodeDescription : Auriga.Diagram.Diagram.Description.Style.INodeStyleDescription
    {
        /// <summary>
        /// The color of the lozenge.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IColorDescription Color { get; set; }

        /// <summary>
        /// An expression to computes the height of the lozenge.
        /// </summary>
        string HeightComputationExpression { get; set; }

        /// <summary>
        /// An expression to compute the width of the lozenge.
        /// </summary>
        string WidthComputationExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
