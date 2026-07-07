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

namespace Auriga.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Interface</c> interface.
    /// </summary>
    public partial interface IInterface : Auriga.Capellacore.IGeneralClass, Auriga.Cs.IInterfaceAllocator
    {
        /// <summary>
        /// Gets the allocating components.
        /// </summary>
        IEnumerable<Auriga.Cs.IComponent> AllocatingComponents { get; }

        /// <summary>
        /// Gets the allocating interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> AllocatingInterfaces { get; }

        /// <summary>
        /// Gets the exchange items.
        /// </summary>
        IEnumerable<Auriga.Information.IExchangeItem> ExchangeItems { get; }

        /// <summary>
        /// Gets the implementor components.
        /// </summary>
        IEnumerable<Auriga.Cs.IComponent> ImplementorComponents { get; }

        /// <summary>
        /// Gets the interface implementations.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterfaceImplementation> InterfaceImplementations { get; }

        /// <summary>
        /// Gets the interface uses.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterfaceUse> InterfaceUses { get; }

        /// <summary>
        /// Gets or sets the mechanism.
        /// </summary>
        string Mechanism { get; set; }

        /// <summary>
        /// Gets the owned exchange item allocations.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IExchangeItemAllocation> OwnedExchangeItemAllocations { get; }

        /// <summary>
        /// Gets the providing component ports.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentPort> ProvidingComponentPorts { get; }

        /// <summary>
        /// Gets the providing components.
        /// </summary>
        IEnumerable<Auriga.Cs.IComponent> ProvidingComponents { get; }

        /// <summary>
        /// Gets the provisioning interface allocations.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterfaceAllocation> ProvisioningInterfaceAllocations { get; }

        /// <summary>
        /// Gets the realized context interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> RealizedContextInterfaces { get; }

        /// <summary>
        /// Gets the realized logical interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> RealizedLogicalInterfaces { get; }

        /// <summary>
        /// Gets the realizing logical interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> RealizingLogicalInterfaces { get; }

        /// <summary>
        /// Gets the realizing physical interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> RealizingPhysicalInterfaces { get; }

        /// <summary>
        /// Gets the requiring component ports.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentPort> RequiringComponentPorts { get; }

        /// <summary>
        /// Gets the requiring components.
        /// </summary>
        IEnumerable<Auriga.Cs.IComponent> RequiringComponents { get; }

        /// <summary>
        /// Gets or sets the structural.
        /// </summary>
        bool? Structural { get; set; }

        /// <summary>
        /// Gets the user components.
        /// </summary>
        IEnumerable<Auriga.Cs.IComponent> UserComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
