// ------------------------------------------------------------------------------------------------
// <copyright file="IInterface.cs" company="Starion Group S.A.">
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

    public partial interface IInterface : Auriga.Capellacore.IGeneralClass, Auriga.Cs.IInterfaceAllocator
    {
        string Mechanism { get; set; }

        bool? Structural { get; set; }

        IEnumerable<Auriga.Cs.IComponent> ImplementorComponents { get; }

        IEnumerable<Auriga.Cs.IComponent> UserComponents { get; }

        IEnumerable<Auriga.Cs.IInterfaceImplementation> InterfaceImplementations { get; }

        IEnumerable<Auriga.Cs.IInterfaceUse> InterfaceUses { get; }

        IEnumerable<Auriga.Cs.IInterfaceAllocation> ProvisioningInterfaceAllocations { get; }

        IEnumerable<Auriga.Cs.IInterface> AllocatingInterfaces { get; }

        IEnumerable<Auriga.Cs.IComponent> AllocatingComponents { get; }

        IEnumerable<Auriga.Information.IExchangeItem> ExchangeItems { get; }

        Auriga.IContainerList<Auriga.Cs.IExchangeItemAllocation> OwnedExchangeItemAllocations { get; }

        IEnumerable<Auriga.Cs.IComponent> RequiringComponents { get; }

        IEnumerable<Auriga.Fa.IComponentPort> RequiringComponentPorts { get; }

        IEnumerable<Auriga.Cs.IComponent> ProvidingComponents { get; }

        IEnumerable<Auriga.Fa.IComponentPort> ProvidingComponentPorts { get; }

        IEnumerable<Auriga.Cs.IInterface> RealizingLogicalInterfaces { get; }

        IEnumerable<Auriga.Cs.IInterface> RealizedContextInterfaces { get; }

        IEnumerable<Auriga.Cs.IInterface> RealizingPhysicalInterfaces { get; }

        IEnumerable<Auriga.Cs.IInterface> RealizedLogicalInterfaces { get; }

    }
}
