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
    public partial interface IAbstractFunction : global::Auriga.Capellacore.INamespace, global::Auriga.Capellacore.IInvolvedElement, global::Auriga.Information.IAbstractInstance, global::Auriga.Fa.IAbstractFunctionalChainContainer, global::Auriga.Activity.ICallBehaviorAction, global::Auriga.Behavior.IAbstractEvent
    {
        global::Auriga.Fa.FunctionKind? Kind { get; set; }

        string Condition { get; set; }

        global::Auriga.IContainerList<global::Auriga.Fa.IAbstractFunction> OwnedFunctions { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IFunctionRealization> OwnedFunctionRealizations { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IFunctionalExchange> OwnedFunctionalExchanges { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunction> SubFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionRealization> OutFunctionRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionRealization> InFunctionRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentFunctionalAllocation> ComponentFunctionalAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunctionalBlock> AllocationBlocks { get; }

        global::System.Collections.Generic.List<global::Auriga.Capellacommon.IState> AvailableInStates { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ICapability> InvolvingCapabilities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalChain> InvolvingFunctionalChains { get; }

        global::Auriga.Capellacommon.IStateMachine LinkedStateMachine { get; }

        global::Auriga.Fa.IFunctionSpecification LinkedFunctionSpecification { get; }

    }
}
