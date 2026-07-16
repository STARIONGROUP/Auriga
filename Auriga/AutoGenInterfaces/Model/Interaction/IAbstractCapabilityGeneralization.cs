// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractCapabilityGeneralization.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>AbstractCapabilityGeneralization</c> interface.
    /// </summary>
    public partial interface IAbstractCapabilityGeneralization : Auriga.Model.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets the sub.
        /// </summary>
        Auriga.Model.Interaction.IAbstractCapability Sub { get; }

        /// <summary>
        /// Gets or sets the super.
        /// </summary>
        Auriga.Model.Interaction.IAbstractCapability Super { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
