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
    public partial interface IPort : global::Auriga.Capellacore.INamedElement
    {
        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IPortRealization> IncomingPortRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IPortRealization> OutgoingPortRealizations { get; }

        global::Auriga.IContainerList<global::Auriga.Capellacommon.IStateMachine> OwnedProtocols { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IPortAllocation> IncomingPortAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IPortAllocation> OutgoingPortAllocations { get; }

        global::System.Collections.Generic.List<global::Auriga.Cs.IInterface> ProvidedInterfaces { get; }

        global::System.Collections.Generic.List<global::Auriga.Cs.IInterface> RequiredInterfaces { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IPortRealization> OwnedPortRealizations { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IPortAllocation> OwnedPortAllocations { get; }

    }
}
