// ------------------------------------------------------------------------------------------------
// <copyright file="IComponentExchangeAllocation.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Fa
{
    /// <summary>
    /// Definition of the <c>ComponentExchangeAllocation</c> interface.
    /// </summary>
    public partial interface IComponentExchangeAllocation : Auriga.Model.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the component exchange allocated.
        /// </summary>
        Auriga.Model.Fa.IComponentExchange ComponentExchangeAllocated { get; }

        /// <summary>
        /// Gets the component exchange allocator.
        /// </summary>
        Auriga.Model.Fa.IComponentExchangeAllocator ComponentExchangeAllocator { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
