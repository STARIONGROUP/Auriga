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

namespace Auriga.Model.Information.Communication
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>CommunicationLinkExchanger</c> interface.
    /// </summary>
    public partial interface ICommunicationLinkExchanger : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets the access.
        /// </summary>
        IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Access { get; }

        /// <summary>
        /// Gets the acquire.
        /// </summary>
        IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Acquire { get; }

        /// <summary>
        /// Gets the call.
        /// </summary>
        IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Call { get; }

        /// <summary>
        /// Gets the consume.
        /// </summary>
        IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Consume { get; }

        /// <summary>
        /// Gets the execute.
        /// </summary>
        IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Execute { get; }

        /// <summary>
        /// Gets the owned communication links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.Communication.ICommunicationLink> OwnedCommunicationLinks { get; }

        /// <summary>
        /// Gets the produce.
        /// </summary>
        IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Produce { get; }

        /// <summary>
        /// Gets the receive.
        /// </summary>
        IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Receive { get; }

        /// <summary>
        /// Gets the send.
        /// </summary>
        IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Send { get; }

        /// <summary>
        /// Gets the transmit.
        /// </summary>
        IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Transmit { get; }

        /// <summary>
        /// Gets the write.
        /// </summary>
        IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Write { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
