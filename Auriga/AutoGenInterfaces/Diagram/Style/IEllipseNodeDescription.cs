// ------------------------------------------------------------------------------------------------
// <copyright file="IEllipseNodeDescription.cs" company="Starion Group S.A.">
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
    /// The ellipse style to display a node as an ellipse.
    /// </summary>
    public partial interface IEllipseNodeDescription : Auriga.Diagram.Diagram.Description.Style.INodeStyleDescription
    {
        /// <summary>
        /// The color of the ellipse.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IColorDescription Color { get; set; }

        /// <summary>
        /// An expression to compute the horizontal diameter of the ellipse. (Semimajor axis)
        /// </summary>
        string HorizontalDiameterComputationExpression { get; set; }

        /// <summary>
        /// An expression to compute the vertical diameter of the ellipse. (Semiminor axis)
        /// </summary>
        string VerticalDiameterComputationExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
