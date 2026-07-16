// ------------------------------------------------------------------------------------------------
// <copyright file="ISquareDescription.cs" company="Starion Group S.A.">
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
    /// The square style to display a node as a square.
    /// </summary>
    public partial interface ISquareDescription : Auriga.Diagram.Diagram.Description.Style.INodeStyleDescription
    {
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IColorDescription Color { get; set; }

        /// <summary>
        /// The height of the square.
        /// </summary>
        int? Height { get; set; }

        /// <summary>
        /// Return all nodes that have been created with the specified mapping.
        /// </summary>
        int? Width { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
