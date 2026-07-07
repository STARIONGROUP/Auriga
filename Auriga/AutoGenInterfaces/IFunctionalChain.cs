// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionalChain.cs" company="Starion Group S.A.">
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

namespace Auriga.Fa
{
    public partial interface IFunctionalChain : global::Auriga.Capellacore.INamedElement, global::Auriga.Capellacore.IInvolverElement, global::Auriga.Capellacore.IInvolvedElement
    {
        global::Auriga.Fa.FunctionalChainKind? Kind { get; set; }

        global::Auriga.IContainerList<global::Auriga.Fa.IFunctionalChainInvolvement> OwnedFunctionalChainInvolvements { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IFunctionalChainRealization> OwnedFunctionalChainRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalChainInvolvement> InvolvedFunctionalChainInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunction> InvolvedFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalExchange> InvolvedFunctionalExchanges { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.IInvolvedElement> InvolvedElements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunction> EnactedFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunctionalBlock> EnactedFunctionalBlocks { get; }

        global::System.Collections.Generic.List<global::Auriga.Capellacommon.IState> AvailableInStates { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalChainInvolvement> FirstFunctionalChainInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ICapability> InvolvingCapabilities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalChain> RealizedFunctionalChains { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalChain> RealizingFunctionalChains { get; }

        global::Auriga.Capellacore.IConstraint PreCondition { get; set; }

        global::Auriga.Capellacore.IConstraint PostCondition { get; set; }

        global::Auriga.IContainerList<global::Auriga.Fa.IControlNode> OwnedSequenceNodes { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.ISequenceLink> OwnedSequenceLinks { get; }

    }
}
