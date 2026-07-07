// ------------------------------------------------------------------------------------------------
// <copyright file="IFeature.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacore
{
    /// <summary>
    /// Definition of the <c>Feature</c> interface.
    /// </summary>
    public partial interface IFeature : Auriga.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets or sets the is abstract.
        /// </summary>
        bool? IsAbstract { get; set; }

        /// <summary>
        /// Gets or sets the is static.
        /// </summary>
        bool? IsStatic { get; set; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
