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

namespace Auriga.Cs
{
    /// <summary>
    /// Definition of the <c>ComponentPkg</c> interface.
    /// </summary>
    public partial interface IComponentPkg : Auriga.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned component exchange categories.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories { get; }

        /// <summary>
        /// Gets the owned component exchange realizations.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations { get; }

        /// <summary>
        /// Gets the owned component exchanges.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentExchange> OwnedComponentExchanges { get; }

        /// <summary>
        /// Gets the owned functional allocations.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocations { get; }

        /// <summary>
        /// Gets the owned functional links.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IExchangeLink> OwnedFunctionalLinks { get; }

        /// <summary>
        /// Gets the owned parts.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IPart> OwnedParts { get; }

        /// <summary>
        /// Gets the owned physical link categories.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories { get; }

        /// <summary>
        /// Gets the owned physical links.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IPhysicalLink> OwnedPhysicalLinks { get; }

        /// <summary>
        /// Gets the owned state machines.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedStateMachines { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
