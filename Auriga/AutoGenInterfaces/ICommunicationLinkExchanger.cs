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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ICommunicationLinkExchanger : Auriga.IAurigaElement
    {
        Auriga.IContainerList<Auriga.Information.Communication.ICommunicationLink> OwnedCommunicationLinks { get; }

        IEnumerable<Auriga.Information.Communication.ICommunicationLink> Produce { get; }

        IEnumerable<Auriga.Information.Communication.ICommunicationLink> Consume { get; }

        IEnumerable<Auriga.Information.Communication.ICommunicationLink> Send { get; }

        IEnumerable<Auriga.Information.Communication.ICommunicationLink> Receive { get; }

        IEnumerable<Auriga.Information.Communication.ICommunicationLink> Call { get; }

        IEnumerable<Auriga.Information.Communication.ICommunicationLink> Execute { get; }

        IEnumerable<Auriga.Information.Communication.ICommunicationLink> Write { get; }

        IEnumerable<Auriga.Information.Communication.ICommunicationLink> Access { get; }

        IEnumerable<Auriga.Information.Communication.ICommunicationLink> Acquire { get; }

        IEnumerable<Auriga.Information.Communication.ICommunicationLink> Transmit { get; }

    }
}
