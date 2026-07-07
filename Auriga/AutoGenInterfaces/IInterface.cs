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
    public partial interface IInterface : global::Auriga.Capellacore.IGeneralClass, global::Auriga.Cs.IInterfaceAllocator
    {
        string Mechanism { get; set; }

        bool? Structural { get; set; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IComponent> ImplementorComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IComponent> UserComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterfaceImplementation> InterfaceImplementations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterfaceUse> InterfaceUses { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterfaceAllocation> ProvisioningInterfaceAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> AllocatingInterfaces { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IComponent> AllocatingComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IExchangeItem> ExchangeItems { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IExchangeItemAllocation> OwnedExchangeItemAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IComponent> RequiringComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentPort> RequiringComponentPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IComponent> ProvidingComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentPort> ProvidingComponentPorts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> RealizingLogicalInterfaces { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> RealizedContextInterfaces { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> RealizingPhysicalInterfaces { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> RealizedLogicalInterfaces { get; }

    }
}
