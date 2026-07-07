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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IInterfaceAllocator : Auriga.Capellacore.ICapellaElement
    {
        Auriga.IContainerList<Auriga.Cs.IInterfaceAllocation> OwnedInterfaceAllocations { get; }

        IEnumerable<Auriga.Cs.IInterfaceAllocation> ProvisionedInterfaceAllocations { get; }

        IEnumerable<Auriga.Cs.IInterface> AllocatedInterfaces { get; }

    }
}
