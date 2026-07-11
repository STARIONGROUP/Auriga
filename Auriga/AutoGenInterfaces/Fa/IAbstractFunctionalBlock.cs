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

namespace Auriga.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>AbstractFunctionalBlock</c> interface.
    /// </summary>
    public partial interface IAbstractFunctionalBlock : Auriga.Capellacore.IModellingBlock
    {
        /// <summary>
        /// Gets the allocated functions.
        /// </summary>
        IEnumerable<Auriga.Fa.IAbstractFunction> AllocatedFunctions { get; }

        /// <summary>
        /// Gets the functional allocations.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentFunctionalAllocation> FunctionalAllocations { get; }

        /// <summary>
        /// Gets the in exchange links.
        /// </summary>
        List<Auriga.Fa.IExchangeLink> InExchangeLinks { get; }

        /// <summary>
        /// Gets the out exchange links.
        /// </summary>
        List<Auriga.Fa.IExchangeLink> OutExchangeLinks { get; }

        /// <summary>
        /// Gets the owned component exchange categories.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories { get; }

        /// <summary>
        /// Gets the owned component exchanges.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Fa.IComponentExchange> OwnedComponentExchanges { get; }

        /// <summary>
        /// Gets the owned functional allocation.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocation { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
