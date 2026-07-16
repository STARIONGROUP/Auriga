// ------------------------------------------------------------------------------------------------
// <copyright file="IColorStep.cs" company="Starion Group S.A.">
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
    /// A ColorStep is identified by its associatedValue and references an associatedColor (FixedColor).
    /// </summary>
    public partial interface IColorStep : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets or sets the associated color.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.IFixedColor AssociatedColor { get; set; }

        /// <summary>
        /// Gets or sets the associated value.
        /// </summary>
        string AssociatedValue { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
