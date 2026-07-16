// ------------------------------------------------------------------------------------------------
// <copyright file="IExchangeItemAllocation.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>ExchangeItemAllocation</c> interface.
    /// </summary>
    public partial interface IExchangeItemAllocation : Auriga.Model.Capellacore.IRelationship, Auriga.Model.Information.IAbstractEventOperation, Auriga.Model.Modellingcore.IFinalizableElement
    {
        /// <summary>
        /// Gets or sets the allocated item.
        /// </summary>
        Auriga.Model.Information.IExchangeItem AllocatedItem { get; set; }

        /// <summary>
        /// Gets the allocating interface.
        /// </summary>
        Auriga.Model.Cs.IInterface AllocatingInterface { get; }

        /// <summary>
        /// Gets or sets the receive protocol.
        /// </summary>
        Auriga.Model.Information.Communication.CommunicationLinkProtocol? ReceiveProtocol { get; set; }

        /// <summary>
        /// Gets or sets the send protocol.
        /// </summary>
        Auriga.Model.Information.Communication.CommunicationLinkProtocol? SendProtocol { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
