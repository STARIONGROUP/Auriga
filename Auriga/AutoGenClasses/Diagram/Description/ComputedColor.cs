// ------------------------------------------------------------------------------------------------
// <copyright file="ComputedColor.cs" company="Starion Group S.A.">
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
    public partial class ComputedColor : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.IComputedColor
    {
        /// <summary>
        /// Gets or sets the blue.
        /// </summary>
        public string Blue { get; set; } = "";

        /// <summary>
        /// Gets or sets the green.
        /// </summary>
        public string Green { get; set; } = "";

        /// <summary>
        /// The name of the color description, as shown to the user in color palettes.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An expression computing the value of the color.
        /// </summary>
        public string Red { get; set; } = "";

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
