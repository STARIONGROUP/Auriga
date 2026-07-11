// ------------------------------------------------------------------------------------------------
// <copyright file="IComponentExchangeAllocator.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ComponentExchangeAllocator</c> interface.
    /// </summary>
    public partial interface IComponentExchangeAllocator : Auriga.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the allocated component exchanges.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentExchange> AllocatedComponentExchanges { get; }

        /// <summary>
        /// Gets the owned component exchange allocations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Fa.IComponentExchangeAllocation> OwnedComponentExchangeAllocations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
