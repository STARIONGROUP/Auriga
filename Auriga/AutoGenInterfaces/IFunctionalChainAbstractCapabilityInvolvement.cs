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

namespace Auriga.Interaction
{
    /// <summary>
    /// Definition of the <c>FunctionalChainAbstractCapabilityInvolvement</c> interface.
    /// </summary>
    public partial interface IFunctionalChainAbstractCapabilityInvolvement : Auriga.Capellacore.IInvolvement
    {
        /// <summary>
        /// Gets the capability.
        /// </summary>
        Auriga.Interaction.IAbstractCapability Capability { get; }

        /// <summary>
        /// Gets the functional chain.
        /// </summary>
        Auriga.Fa.IFunctionalChain FunctionalChain { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
