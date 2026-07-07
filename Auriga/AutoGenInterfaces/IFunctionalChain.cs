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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IFunctionalChain : Auriga.Capellacore.INamedElement, Auriga.Capellacore.IInvolverElement, Auriga.Capellacore.IInvolvedElement
    {
        Auriga.Fa.FunctionalChainKind? Kind { get; set; }

        Auriga.IContainerList<Auriga.Fa.IFunctionalChainInvolvement> OwnedFunctionalChainInvolvements { get; }

        Auriga.IContainerList<Auriga.Fa.IFunctionalChainRealization> OwnedFunctionalChainRealizations { get; }

        IEnumerable<Auriga.Fa.IFunctionalChainInvolvement> InvolvedFunctionalChainInvolvements { get; }

        IEnumerable<Auriga.Fa.IAbstractFunction> InvolvedFunctions { get; }

        IEnumerable<Auriga.Fa.IFunctionalExchange> InvolvedFunctionalExchanges { get; }

        IEnumerable<Auriga.Capellacore.IInvolvedElement> InvolvedElements { get; }

        IEnumerable<Auriga.Fa.IAbstractFunction> EnactedFunctions { get; }

        IEnumerable<Auriga.Fa.IAbstractFunctionalBlock> EnactedFunctionalBlocks { get; }

        List<Auriga.Capellacommon.IState> AvailableInStates { get; }

        IEnumerable<Auriga.Fa.IFunctionalChainInvolvement> FirstFunctionalChainInvolvements { get; }

        IEnumerable<Auriga.Ctx.ICapability> InvolvingCapabilities { get; }

        IEnumerable<Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations { get; }

        IEnumerable<Auriga.Fa.IFunctionalChain> RealizedFunctionalChains { get; }

        IEnumerable<Auriga.Fa.IFunctionalChain> RealizingFunctionalChains { get; }

        Auriga.Capellacore.IConstraint PreCondition { get; set; }

        Auriga.Capellacore.IConstraint PostCondition { get; set; }

        Auriga.IContainerList<Auriga.Fa.IControlNode> OwnedSequenceNodes { get; }

        Auriga.IContainerList<Auriga.Fa.ISequenceLink> OwnedSequenceLinks { get; }

    }
}
