// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionalChainAbstractCapabilityInvolvement.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>FunctionalChainAbstractCapabilityInvolvement</c> interface.
    /// </summary>
    public partial interface IFunctionalChainAbstractCapabilityInvolvement : Auriga.Model.Capellacore.IInvolvement
    {
        /// <summary>
        /// Gets the capability.
        /// </summary>
        Auriga.Model.Interaction.IAbstractCapability Capability { get; }

        /// <summary>
        /// Gets the functional chain.
        /// </summary>
        Auriga.Model.Fa.IFunctionalChain FunctionalChain { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
