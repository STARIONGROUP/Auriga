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

namespace Auriga.Model.Cs
{
    /// <summary>
    /// Definition of the <c>ComponentPkg</c> interface.
    /// </summary>
    public partial interface IComponentPkg : Auriga.Model.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned component exchange categories.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories { get; }

        /// <summary>
        /// Gets the owned component exchange realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations { get; }

        /// <summary>
        /// Gets the owned component exchanges.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchange> OwnedComponentExchanges { get; }

        /// <summary>
        /// Gets the owned functional allocations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocations { get; }

        /// <summary>
        /// Gets the owned functional links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IExchangeLink> OwnedFunctionalLinks { get; }

        /// <summary>
        /// Gets the owned parts.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IPart> OwnedParts { get; }

        /// <summary>
        /// Gets the owned physical link categories.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories { get; }

        /// <summary>
        /// Gets the owned physical links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalLink> OwnedPhysicalLinks { get; }

        /// <summary>
        /// Gets the owned state machines.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IStateMachine> OwnedStateMachines { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
