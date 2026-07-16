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

namespace Auriga.Model.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>AbstractFunction</c> interface.
    /// </summary>
    public partial interface IAbstractFunction : Auriga.Model.Capellacore.INamespace, Auriga.Model.Capellacore.IInvolvedElement, Auriga.Model.Information.IAbstractInstance, Auriga.Model.Fa.IAbstractFunctionalChainContainer, Auriga.Model.Activity.ICallBehaviorAction, Auriga.Model.Behavior.IAbstractEvent
    {
        /// <summary>
        /// Gets the allocation blocks.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IAbstractFunctionalBlock> AllocationBlocks { get; }

        /// <summary>
        /// Gets the available in states.
        /// </summary>
        List<Auriga.Model.Capellacommon.IState> AvailableInStates { get; }

        /// <summary>
        /// Gets the component functional allocations.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentFunctionalAllocation> ComponentFunctionalAllocations { get; }

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        string Condition { get; set; }

        /// <summary>
        /// Gets the in function realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionRealization> InFunctionRealizations { get; }

        /// <summary>
        /// Gets the involving capabilities.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ICapability> InvolvingCapabilities { get; }

        /// <summary>
        /// Gets the involving capability realizations.
        /// </summary>
        IEnumerable<Auriga.Model.La.ICapabilityRealization> InvolvingCapabilityRealizations { get; }

        /// <summary>
        /// Gets the involving functional chains.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalChain> InvolvingFunctionalChains { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Model.Fa.FunctionKind? Kind { get; set; }

        /// <summary>
        /// Gets the linked function specification.
        /// </summary>
        Auriga.Model.Fa.IFunctionSpecification LinkedFunctionSpecification { get; }

        /// <summary>
        /// Gets the linked state machine.
        /// </summary>
        Auriga.Model.Capellacommon.IStateMachine LinkedStateMachine { get; }

        /// <summary>
        /// Gets the out function realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionRealization> OutFunctionRealizations { get; }

        /// <summary>
        /// Gets the owned function realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionRealization> OwnedFunctionRealizations { get; }

        /// <summary>
        /// Gets the owned functional exchanges.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalExchange> OwnedFunctionalExchanges { get; }

        /// <summary>
        /// Gets the owned functions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IAbstractFunction> OwnedFunctions { get; }

        /// <summary>
        /// Gets the sub functions.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IAbstractFunction> SubFunctions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
