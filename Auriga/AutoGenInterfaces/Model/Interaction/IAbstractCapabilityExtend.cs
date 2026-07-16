// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractCapabilityExtend.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>AbstractCapabilityExtend</c> interface.
    /// </summary>
    public partial interface IAbstractCapabilityExtend : Auriga.Model.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets or sets the extended.
        /// </summary>
        Auriga.Model.Interaction.IAbstractCapability Extended { get; set; }

        /// <summary>
        /// Gets the extension.
        /// </summary>
        Auriga.Model.Interaction.IAbstractCapability Extension { get; }

        /// <summary>
        /// Gets or sets the extension location.
        /// </summary>
        Auriga.Model.Interaction.IAbstractCapabilityExtensionPoint ExtensionLocation { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
