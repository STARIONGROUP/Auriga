// ------------------------------------------------------------------------------------------------
// <copyright file="ICommunicationLink.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>CommunicationLink</c> interface.
    /// </summary>
    public partial interface ICommunicationLink : Auriga.Model.Capellacore.ICapellaElement
    {
        /// <summary>
        /// Gets or sets the exchange item.
        /// </summary>
        Auriga.Model.Information.IExchangeItem ExchangeItem { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Model.Information.Communication.CommunicationLinkKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the protocol.
        /// </summary>
        Auriga.Model.Information.Communication.CommunicationLinkProtocol? Protocol { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
