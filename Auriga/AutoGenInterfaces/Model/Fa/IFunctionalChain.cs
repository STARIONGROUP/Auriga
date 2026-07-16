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

namespace Auriga.Model.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FunctionalChain</c> interface.
    /// </summary>
    public partial interface IFunctionalChain : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Capellacore.IInvolverElement, Auriga.Model.Capellacore.IInvolvedElement
    {
        /// <summary>
        /// Gets the available in states.
        /// </summary>
        List<Auriga.Model.Capellacommon.IState> AvailableInStates { get; }

        /// <summary>
        /// Gets the enacted functional blocks.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IAbstractFunctionalBlock> EnactedFunctionalBlocks { get; }

        /// <summary>
        /// Gets the enacted functions.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IAbstractFunction> EnactedFunctions { get; }

        /// <summary>
        /// Gets the first functional chain involvements.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalChainInvolvement> FirstFunctionalChainInvolvements { get; }

        /// <summary>
        /// Gets the involved elements.
        /// </summary>
        IEnumerable<Auriga.Model.Capellacore.IInvolvedElement> InvolvedElements { get; }

        /// <summary>
        /// Gets the involved functional chain involvements.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalChainInvolvement> InvolvedFunctionalChainInvolvements { get; }

        /// <summary>
        /// Gets the involved functional exchanges.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalExchange> InvolvedFunctionalExchanges { get; }

        /// <summary>
        /// Gets the involved functions.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IAbstractFunction> InvolvedFunctions { get; }

        /// <summary>
        /// Gets the involving capabilities.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ICapability> InvolvingCapabilities { get; }

        /// <summary>
        /// Gets the involving capability realizations.
        /// </summary>
        IEnumerable<Auriga.Model.La.ICapabilityRealization> InvolvingCapabilityRealizations { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Model.Fa.FunctionalChainKind? Kind { get; set; }

        /// <summary>
        /// Gets the owned functional chain involvements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalChainInvolvement> OwnedFunctionalChainInvolvements { get; }

        /// <summary>
        /// Gets the owned functional chain realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalChainRealization> OwnedFunctionalChainRealizations { get; }

        /// <summary>
        /// Gets the owned sequence links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.ISequenceLink> OwnedSequenceLinks { get; }

        /// <summary>
        /// Gets the owned sequence nodes.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IControlNode> OwnedSequenceNodes { get; }

        /// <summary>
        /// Gets or sets the post condition.
        /// </summary>
        Auriga.Model.Capellacore.IConstraint PostCondition { get; set; }

        /// <summary>
        /// Gets or sets the pre condition.
        /// </summary>
        Auriga.Model.Capellacore.IConstraint PreCondition { get; set; }

        /// <summary>
        /// Gets the realized functional chains.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalChain> RealizedFunctionalChains { get; }

        /// <summary>
        /// Gets the realizing functional chains.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalChain> RealizingFunctionalChains { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
