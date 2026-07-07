// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractCapability.cs" company="Starion Group S.A.">
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Interaction
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IAbstractCapability : Auriga.Capellacore.IStructure, Auriga.Capellacore.IInvolverElement, Auriga.Fa.IAbstractFunctionalChainContainer
    {
        Auriga.Capellacore.IConstraint PreCondition { get; set; }

        Auriga.Capellacore.IConstraint PostCondition { get; set; }

        Auriga.IContainerList<Auriga.Interaction.IScenario> OwnedScenarios { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapabilityRealization> IncomingCapabilityAllocation { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapabilityRealization> OutgoingCapabilityAllocation { get; }

        Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityExtend> Extends { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapabilityExtend> Extending { get; }

        Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityExtensionPoint> AbstractCapabilityExtensionPoints { get; }

        Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityGeneralization> SuperGeneralizations { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapabilityGeneralization> SubGeneralizations { get; }

        Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityInclude> Includes { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapabilityInclude> Including { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapability> Super { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapability> Sub { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapability> IncludedAbstractCapabilities { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapability> IncludingAbstractCapabilities { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapability> ExtendedAbstractCapabilities { get; }

        IEnumerable<Auriga.Interaction.IAbstractCapability> ExtendingAbstractCapabilities { get; }

        Auriga.IContainerList<Auriga.Interaction.IFunctionalChainAbstractCapabilityInvolvement> OwnedFunctionalChainAbstractCapabilityInvolvements { get; }

        Auriga.IContainerList<Auriga.Interaction.IAbstractFunctionAbstractCapabilityInvolvement> OwnedAbstractFunctionAbstractCapabilityInvolvements { get; }

        List<Auriga.Capellacommon.IState> AvailableInStates { get; }

        Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityRealization> OwnedAbstractCapabilityRealizations { get; }

        IEnumerable<Auriga.Fa.IAbstractFunction> InvolvedAbstractFunctions { get; }

        IEnumerable<Auriga.Fa.IFunctionalChain> InvolvedFunctionalChains { get; }

    }
}
