// ------------------------------------------------------------------------------------------------
// <copyright file="IComputedColor.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description
{
    /// <summary>
    /// Describes a color which each value red, blue and green are computed expressions.
    /// </summary>
    public partial interface IComputedColor : Auriga.Diagram.Viewpoint.Description.IUserColor, Auriga.Diagram.Viewpoint.Description.IColorDescription
    {
        /// <summary>
        /// Gets or sets the blue.
        /// </summary>
        string Blue { get; set; }

        /// <summary>
        /// Gets or sets the green.
        /// </summary>
        string Green { get; set; }

        /// <summary>
        /// An expression computing the value of the color.
        /// </summary>
        string Red { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
