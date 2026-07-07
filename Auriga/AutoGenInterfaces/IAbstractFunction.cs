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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IAbstractFunction : Auriga.Capellacore.INamespace, Auriga.Capellacore.IInvolvedElement, Auriga.Information.IAbstractInstance, Auriga.Fa.IAbstractFunctionalChainContainer, Auriga.Activity.ICallBehaviorAction, Auriga.Behavior.IAbstractEvent
    {
        Auriga.Fa.FunctionKind? Kind { get; set; }

        string Condition { get; set; }

        Auriga.IContainerList<Auriga.Fa.IAbstractFunction> OwnedFunctions { get; }

        Auriga.IContainerList<Auriga.Fa.IFunctionRealization> OwnedFunctionRealizations { get; }

        Auriga.IContainerList<Auriga.Fa.IFunctionalExchange> OwnedFunctionalExchanges { get; }

        IEnumerable<Auriga.Fa.IAbstractFunction> SubFunctions { get; }

        IEnumerable<Auriga.Fa.IFunctionRealization> OutFunctionRealizations { get; }

        IEnumerable<Auriga.Fa.IFunctionRealization> InFunctionRealizations { get; }

        IEnumerable<Auriga.Fa.IComponentFunctionalAllocation> ComponentFunctionalAllocations { get; }

        IEnumerable<Auriga.Fa.IAbstractFunctionalBlock> AllocationBlocks { get; }

        List<Auriga.Capellacommon.IState> AvailableInStates { get; }

        IEnumerable<Auriga.Ctx.ICapability> InvolvingCapabilities { get; }

        IEnumerable<Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations { get; }

        IEnumerable<Auriga.Fa.IFunctionalChain> InvolvingFunctionalChains { get; }

        Auriga.Capellacommon.IStateMachine LinkedStateMachine { get; }

        Auriga.Fa.IFunctionSpecification LinkedFunctionSpecification { get; }

    }
}
