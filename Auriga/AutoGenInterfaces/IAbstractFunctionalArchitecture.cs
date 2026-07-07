// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractFunctionalArchitecture.cs" company="Starion Group S.A.">
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
    public partial interface IAbstractFunctionalArchitecture : global::Auriga.Capellacore.IModellingArchitecture
    {
        global::Auriga.Fa.IFunctionPkg OwnedFunctionPkg { get; set; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchange> OwnedComponentExchanges { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IExchangeLink> OwnedFunctionalLinks { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocations { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations { get; }

    }
}
