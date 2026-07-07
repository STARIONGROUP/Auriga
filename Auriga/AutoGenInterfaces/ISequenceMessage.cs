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
    public partial interface ISequenceMessage : global::Auriga.Capellacore.INamedElement
    {
        global::Auriga.Interaction.MessageKind? Kind { get; set; }

        global::Auriga.Capellacore.IConstraint ExchangeContext { get; set; }

        global::Auriga.Interaction.IMessageEnd SendingEnd { get; set; }

        global::Auriga.Interaction.IMessageEnd ReceivingEnd { get; set; }

        global::Auriga.Information.IAbstractEventOperation InvokedOperation { get; }

        global::System.Collections.Generic.List<global::Auriga.Information.IExchangeItem> ExchangedItems { get; }

        global::Auriga.Cs.IPart SendingPart { get; }

        global::Auriga.Cs.IPart ReceivingPart { get; }

        global::Auriga.Fa.IAbstractFunction SendingFunction { get; }

        global::Auriga.Fa.IAbstractFunction ReceivingFunction { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.ISequenceMessageValuation> OwnedSequenceMessageValuations { get; }

    }
}
