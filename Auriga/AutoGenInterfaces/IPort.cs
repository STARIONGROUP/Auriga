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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Information
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IPort : Auriga.Capellacore.INamedElement
    {
        IEnumerable<Auriga.Information.IPortRealization> IncomingPortRealizations { get; }

        IEnumerable<Auriga.Information.IPortRealization> OutgoingPortRealizations { get; }

        Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedProtocols { get; }

        IEnumerable<Auriga.Information.IPortAllocation> IncomingPortAllocations { get; }

        IEnumerable<Auriga.Information.IPortAllocation> OutgoingPortAllocations { get; }

        List<Auriga.Cs.IInterface> ProvidedInterfaces { get; }

        List<Auriga.Cs.IInterface> RequiredInterfaces { get; }

        Auriga.IContainerList<Auriga.Information.IPortRealization> OwnedPortRealizations { get; }

        Auriga.IContainerList<Auriga.Information.IPortAllocation> OwnedPortAllocations { get; }

    }
}
