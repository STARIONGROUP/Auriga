// ------------------------------------------------------------------------------------------------
// <copyright file="IEllipse.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram
{
    /// <summary>
    /// The ellipse style to display a node as an ellipse.
    /// </summary>
    public partial interface IEllipse : Auriga.Diagram.Diagram.INodeStyle
    {
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        string Color { get; set; }

        /// <summary>
        /// The horizontal diameter size of the ellipse. (Semimajor axis)
        /// </summary>
        int? HorizontalDiameter { get; set; }

        /// <summary>
        /// The vertical diameter of the ellipse. (Semiminor axis)
        /// </summary>
        int? VerticalDiameter { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
