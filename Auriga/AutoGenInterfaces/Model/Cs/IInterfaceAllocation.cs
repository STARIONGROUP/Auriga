// ------------------------------------------------------------------------------------------------
// <copyright file="IInterfaceAllocation.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>InterfaceAllocation</c> interface.
    /// </summary>
    public partial interface IInterfaceAllocation : Auriga.Model.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the allocated interface.
        /// </summary>
        Auriga.Model.Cs.IInterface AllocatedInterface { get; }

        /// <summary>
        /// Gets the allocating interface allocator.
        /// </summary>
        Auriga.Model.Cs.IInterfaceAllocator AllocatingInterfaceAllocator { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
