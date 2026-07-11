// ------------------------------------------------------------------------------------------------
// <copyright file="ISystemColor.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description
{
    /// <summary>
    /// A subtype of FixedColor which is only used in the system palette.
    /// Graphical elements which only support colors from the system
    /// palette can use this type instead of the more general FixedColor.
    /// </summary>
    public partial interface ISystemColor : Auriga.Sirius.Viewpoint.Description.IFixedColor
    {
        /// <summary>
        /// The name of the color description, as shown to the user in color palettes.
        /// </summary>
        string Name { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
