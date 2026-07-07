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
    public partial interface IAbstractCapability : global::Auriga.Capellacore.IStructure, global::Auriga.Capellacore.IInvolverElement, global::Auriga.Fa.IAbstractFunctionalChainContainer
    {
        global::Auriga.Capellacore.IConstraint PreCondition { get; set; }

        global::Auriga.Capellacore.IConstraint PostCondition { get; set; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IScenario> OwnedScenarios { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapabilityRealization> IncomingCapabilityAllocation { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapabilityRealization> OutgoingCapabilityAllocation { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IAbstractCapabilityExtend> Extends { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapabilityExtend> Extending { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IAbstractCapabilityExtensionPoint> AbstractCapabilityExtensionPoints { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IAbstractCapabilityGeneralization> SuperGeneralizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapabilityGeneralization> SubGeneralizations { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IAbstractCapabilityInclude> Includes { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapabilityInclude> Including { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapability> Super { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapability> Sub { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapability> IncludedAbstractCapabilities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapability> IncludingAbstractCapabilities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapability> ExtendedAbstractCapabilities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IAbstractCapability> ExtendingAbstractCapabilities { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IFunctionalChainAbstractCapabilityInvolvement> OwnedFunctionalChainAbstractCapabilityInvolvements { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IAbstractFunctionAbstractCapabilityInvolvement> OwnedAbstractFunctionAbstractCapabilityInvolvements { get; }

        global::System.Collections.Generic.List<global::Auriga.Capellacommon.IState> AvailableInStates { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IAbstractCapabilityRealization> OwnedAbstractCapabilityRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunction> InvolvedAbstractFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalChain> InvolvedFunctionalChains { get; }

    }
}
