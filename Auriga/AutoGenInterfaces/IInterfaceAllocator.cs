// ------------------------------------------------------------------------------------------------
// <copyright file="IInterfaceAllocator.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>InterfaceAllocator</c> interface.
    /// </summary>
    public partial interface IInterfaceAllocator : Auriga.Capellacore.ICapellaElement
    {
        /// <summary>
        /// Gets the allocated interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> AllocatedInterfaces { get; }

        /// <summary>
        /// Gets the owned interface allocations.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IInterfaceAllocation> OwnedInterfaceAllocations { get; }

        /// <summary>
        /// Gets the provisioned interface allocations.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterfaceAllocation> ProvisionedInterfaceAllocations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
