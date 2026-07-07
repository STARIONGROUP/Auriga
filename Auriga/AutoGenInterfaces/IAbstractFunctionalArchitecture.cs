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
    public partial interface IAbstractFunctionalArchitecture : Auriga.Capellacore.IModellingArchitecture
    {
        Auriga.Fa.IFunctionPkg OwnedFunctionPkg { get; set; }

        Auriga.IContainerList<Auriga.Fa.IComponentExchange> OwnedComponentExchanges { get; }

        Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories { get; }

        Auriga.IContainerList<Auriga.Fa.IExchangeLink> OwnedFunctionalLinks { get; }

        Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocations { get; }

        Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations { get; }

    }
}
