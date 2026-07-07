// ------------------------------------------------------------------------------------------------
// <copyright file="IPort.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Port</c> interface.
    /// </summary>
    public partial interface IPort : Auriga.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the incoming port allocations.
        /// </summary>
        IEnumerable<Auriga.Information.IPortAllocation> IncomingPortAllocations { get; }

        /// <summary>
        /// Gets the incoming port realizations.
        /// </summary>
        IEnumerable<Auriga.Information.IPortRealization> IncomingPortRealizations { get; }

        /// <summary>
        /// Gets the outgoing port allocations.
        /// </summary>
        IEnumerable<Auriga.Information.IPortAllocation> OutgoingPortAllocations { get; }

        /// <summary>
        /// Gets the outgoing port realizations.
        /// </summary>
        IEnumerable<Auriga.Information.IPortRealization> OutgoingPortRealizations { get; }

        /// <summary>
        /// Gets the owned port allocations.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.IPortAllocation> OwnedPortAllocations { get; }

        /// <summary>
        /// Gets the owned port realizations.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.IPortRealization> OwnedPortRealizations { get; }

        /// <summary>
        /// Gets the owned protocols.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedProtocols { get; }

        /// <summary>
        /// Gets the provided interfaces.
        /// </summary>
        List<Auriga.Cs.IInterface> ProvidedInterfaces { get; }

        /// <summary>
        /// Gets the required interfaces.
        /// </summary>
        List<Auriga.Cs.IInterface> RequiredInterfaces { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
