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

namespace Auriga.Interaction
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>SequenceMessage</c> interface.
    /// </summary>
    public partial interface ISequenceMessage : Auriga.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets or sets the exchange context.
        /// </summary>
        Auriga.Capellacore.IConstraint ExchangeContext { get; set; }

        /// <summary>
        /// Gets the exchanged items.
        /// </summary>
        List<Auriga.Information.IExchangeItem> ExchangedItems { get; }

        /// <summary>
        /// Gets the invoked operation.
        /// </summary>
        Auriga.Information.IAbstractEventOperation InvokedOperation { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Interaction.MessageKind? Kind { get; set; }

        /// <summary>
        /// Gets the owned sequence message valuations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Interaction.ISequenceMessageValuation> OwnedSequenceMessageValuations { get; }

        /// <summary>
        /// Gets or sets the receiving end.
        /// </summary>
        Auriga.Interaction.IMessageEnd ReceivingEnd { get; set; }

        /// <summary>
        /// Gets the receiving function.
        /// </summary>
        Auriga.Fa.IAbstractFunction ReceivingFunction { get; }

        /// <summary>
        /// Gets the receiving part.
        /// </summary>
        Auriga.Cs.IPart ReceivingPart { get; }

        /// <summary>
        /// Gets or sets the sending end.
        /// </summary>
        Auriga.Interaction.IMessageEnd SendingEnd { get; set; }

        /// <summary>
        /// Gets the sending function.
        /// </summary>
        Auriga.Fa.IAbstractFunction SendingFunction { get; }

        /// <summary>
        /// Gets the sending part.
        /// </summary>
        Auriga.Cs.IPart SendingPart { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
