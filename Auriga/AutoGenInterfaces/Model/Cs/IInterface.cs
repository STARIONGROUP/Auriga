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

namespace Auriga.Model.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Interface</c> interface.
    /// </summary>
    public partial interface IInterface : Auriga.Model.Capellacore.IGeneralClass, Auriga.Model.Cs.IInterfaceAllocator
    {
        /// <summary>
        /// Gets the allocating components.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IComponent> AllocatingComponents { get; }

        /// <summary>
        /// Gets the allocating interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> AllocatingInterfaces { get; }

        /// <summary>
        /// Gets the exchange items.
        /// </summary>
        IEnumerable<Auriga.Model.Information.IExchangeItem> ExchangeItems { get; }

        /// <summary>
        /// Gets the implementor components.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IComponent> ImplementorComponents { get; }

        /// <summary>
        /// Gets the interface implementations.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterfaceImplementation> InterfaceImplementations { get; }

        /// <summary>
        /// Gets the interface uses.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterfaceUse> InterfaceUses { get; }

        /// <summary>
        /// Gets or sets the mechanism.
        /// </summary>
        string Mechanism { get; set; }

        /// <summary>
        /// Gets the owned exchange item allocations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IExchangeItemAllocation> OwnedExchangeItemAllocations { get; }

        /// <summary>
        /// Gets the providing component ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentPort> ProvidingComponentPorts { get; }

        /// <summary>
        /// Gets the providing components.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IComponent> ProvidingComponents { get; }

        /// <summary>
        /// Gets the provisioning interface allocations.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterfaceAllocation> ProvisioningInterfaceAllocations { get; }

        /// <summary>
        /// Gets the realized context interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> RealizedContextInterfaces { get; }

        /// <summary>
        /// Gets the realized logical interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> RealizedLogicalInterfaces { get; }

        /// <summary>
        /// Gets the realizing logical interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> RealizingLogicalInterfaces { get; }

        /// <summary>
        /// Gets the realizing physical interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> RealizingPhysicalInterfaces { get; }

        /// <summary>
        /// Gets the requiring component ports.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentPort> RequiringComponentPorts { get; }

        /// <summary>
        /// Gets the requiring components.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IComponent> RequiringComponents { get; }

        /// <summary>
        /// Gets or sets the structural.
        /// </summary>
        bool? Structural { get; set; }

        /// <summary>
        /// Gets the user components.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IComponent> UserComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
