// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractFunction.cs" company="Starion Group S.A.">
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

namespace Auriga.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>AbstractFunction</c> interface.
    /// </summary>
    public partial interface IAbstractFunction : Auriga.Capellacore.INamespace, Auriga.Capellacore.IInvolvedElement, Auriga.Information.IAbstractInstance, Auriga.Fa.IAbstractFunctionalChainContainer, Auriga.Activity.ICallBehaviorAction, Auriga.Behavior.IAbstractEvent
    {
        /// <summary>
        /// Gets the allocation blocks.
        /// </summary>
        IEnumerable<Auriga.Fa.IAbstractFunctionalBlock> AllocationBlocks { get; }

        /// <summary>
        /// Gets the available in states.
        /// </summary>
        List<Auriga.Capellacommon.IState> AvailableInStates { get; }

        /// <summary>
        /// Gets the component functional allocations.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentFunctionalAllocation> ComponentFunctionalAllocations { get; }

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        string Condition { get; set; }

        /// <summary>
        /// Gets the in function realizations.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionRealization> InFunctionRealizations { get; }

        /// <summary>
        /// Gets the involving capabilities.
        /// </summary>
        IEnumerable<Auriga.Ctx.ICapability> InvolvingCapabilities { get; }

        /// <summary>
        /// Gets the involving capability realizations.
        /// </summary>
        IEnumerable<Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations { get; }

        /// <summary>
        /// Gets the involving functional chains.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalChain> InvolvingFunctionalChains { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Fa.FunctionKind? Kind { get; set; }

        /// <summary>
        /// Gets the linked function specification.
        /// </summary>
        Auriga.Fa.IFunctionSpecification LinkedFunctionSpecification { get; }

        /// <summary>
        /// Gets the linked state machine.
        /// </summary>
        Auriga.Capellacommon.IStateMachine LinkedStateMachine { get; }

        /// <summary>
        /// Gets the out function realizations.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionRealization> OutFunctionRealizations { get; }

        /// <summary>
        /// Gets the owned function realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Fa.IFunctionRealization> OwnedFunctionRealizations { get; }

        /// <summary>
        /// Gets the owned functional exchanges.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Fa.IFunctionalExchange> OwnedFunctionalExchanges { get; }

        /// <summary>
        /// Gets the owned functions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Fa.IAbstractFunction> OwnedFunctions { get; }

        /// <summary>
        /// Gets the sub functions.
        /// </summary>
        IEnumerable<Auriga.Fa.IAbstractFunction> SubFunctions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
