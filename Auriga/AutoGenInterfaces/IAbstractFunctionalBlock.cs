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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IAbstractFunctionalBlock : Auriga.Capellacore.IModellingBlock
    {
        Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocation { get; }

        Auriga.IContainerList<Auriga.Fa.IComponentExchange> OwnedComponentExchanges { get; }

        Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories { get; }

        IEnumerable<Auriga.Fa.IComponentFunctionalAllocation> FunctionalAllocations { get; }

        IEnumerable<Auriga.Fa.IAbstractFunction> AllocatedFunctions { get; }

        List<Auriga.Fa.IExchangeLink> InExchangeLinks { get; }

        List<Auriga.Fa.IExchangeLink> OutExchangeLinks { get; }

    }
}
