// ------------------------------------------------------------------------------------------------
// <copyright file="ICommunicationLinkExchanger.cs" company="Starion Group S.A.">
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

namespace Auriga.Information.Communication
{
    public partial interface ICommunicationLinkExchanger : global::Auriga.IAurigaElement
    {
        global::Auriga.IContainerList<global::Auriga.Information.Communication.ICommunicationLink> OwnedCommunicationLinks { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Produce { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Consume { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Send { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Receive { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Call { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Execute { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Write { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Access { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Acquire { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Transmit { get; }

    }
}
