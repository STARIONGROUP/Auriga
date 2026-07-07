// ------------------------------------------------------------------------------------------------
// <copyright file="IComponentPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Cs
{
    public partial interface IComponentPkg : global::Auriga.Capellacore.IStructure
    {
        global::Auriga.IContainerList<global::Auriga.Cs.IPart> OwnedParts { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchange> OwnedComponentExchanges { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IExchangeLink> OwnedFunctionalLinks { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocations { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalLink> OwnedPhysicalLinks { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories { get; }

        global::Auriga.IContainerList<global::Auriga.Capellacommon.IStateMachine> OwnedStateMachines { get; }

    }
}
