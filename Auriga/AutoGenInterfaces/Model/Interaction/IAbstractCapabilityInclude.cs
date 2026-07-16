// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractCapabilityInclude.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Interaction
{
    /// <summary>
    /// Definition of the <c>AbstractCapabilityInclude</c> interface.
    /// </summary>
    public partial interface IAbstractCapabilityInclude : Auriga.Model.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets or sets the included.
        /// </summary>
        Auriga.Model.Interaction.IAbstractCapability Included { get; set; }

        /// <summary>
        /// Gets the inclusion.
        /// </summary>
        Auriga.Model.Interaction.IAbstractCapability Inclusion { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
