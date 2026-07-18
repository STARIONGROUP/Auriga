// ------------------------------------------------------------------------------------------------
// <copyright file="SystemColor.cs" company="Starion Group S.A.">
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
    /// A subtype of FixedColor which is only used in the system palette.
    /// Graphical elements which only support colors from the system
    /// palette can use this type instead of the more general FixedColor.
    /// </summary>
    public partial class SystemColor : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.ISystemColor
    {
        /// <summary>
        /// The blue value of the RGB color.
        /// </summary>
        public int Blue { get; set; } = 125;

        /// <summary>
        /// The green value of the RGB color.
        /// </summary>
        public int Green { get; set; } = 125;

        /// <summary>
        /// The name of the color description, as shown to the user in color palettes.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The red value of the RGB color.
        /// </summary>
        public int Red { get; set; } = 125;

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
