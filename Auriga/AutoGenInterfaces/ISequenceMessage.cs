// ------------------------------------------------------------------------------------------------
// <copyright file="ISequenceMessage.cs" company="Starion Group S.A.">
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

namespace Auriga.Interaction
{
    using System.Collections.Generic;

    public partial interface ISequenceMessage : Auriga.Capellacore.INamedElement
    {
        Auriga.Interaction.MessageKind? Kind { get; set; }

        Auriga.Capellacore.IConstraint ExchangeContext { get; set; }

        Auriga.Interaction.IMessageEnd SendingEnd { get; set; }

        Auriga.Interaction.IMessageEnd ReceivingEnd { get; set; }

        Auriga.Information.IAbstractEventOperation InvokedOperation { get; }

        List<Auriga.Information.IExchangeItem> ExchangedItems { get; }

        Auriga.Cs.IPart SendingPart { get; }

        Auriga.Cs.IPart ReceivingPart { get; }

        Auriga.Fa.IAbstractFunction SendingFunction { get; }

        Auriga.Fa.IAbstractFunction ReceivingFunction { get; }

        Auriga.IContainerList<Auriga.Interaction.ISequenceMessageValuation> OwnedSequenceMessageValuations { get; }

    }
}
