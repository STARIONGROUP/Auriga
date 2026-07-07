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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Cs
{
    public partial interface IExchangeItemAllocation : Auriga.Capellacore.IRelationship, Auriga.Information.IAbstractEventOperation, Auriga.Modellingcore.IFinalizableElement
    {
        Auriga.Information.Communication.CommunicationLinkProtocol? SendProtocol { get; set; }

        Auriga.Information.Communication.CommunicationLinkProtocol? ReceiveProtocol { get; set; }

        Auriga.Information.IExchangeItem AllocatedItem { get; set; }

        Auriga.Cs.IInterface AllocatingInterface { get; }

    }
}
