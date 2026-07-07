// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractFunctionalBlock.cs" company="Starion Group S.A.">
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
    public partial interface IAbstractFunctionalBlock : global::Auriga.Capellacore.IModellingBlock
    {
        global::Auriga.IContainerList<global::Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocation { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchange> OwnedComponentExchanges { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentFunctionalAllocation> FunctionalAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunction> AllocatedFunctions { get; }

        global::System.Collections.Generic.List<global::Auriga.Fa.IExchangeLink> InExchangeLinks { get; }

        global::System.Collections.Generic.List<global::Auriga.Fa.IExchangeLink> OutExchangeLinks { get; }

    }
}
