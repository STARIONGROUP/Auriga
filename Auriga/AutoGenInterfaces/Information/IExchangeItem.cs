// ------------------------------------------------------------------------------------------------
// <copyright file="IExchangeItem.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ExchangeItem</c> interface.
    /// </summary>
    public partial interface IExchangeItem : Auriga.Modellingcore.IAbstractExchangeItem, Auriga.Behavior.IAbstractEvent, Auriga.Behavior.IAbstractSignal, Auriga.Modellingcore.IFinalizableElement, Auriga.Capellacore.IGeneralizableElement
    {
        /// <summary>
        /// Gets the allocator interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> AllocatorInterfaces { get; }

        /// <summary>
        /// Gets or sets the exchange mechanism.
        /// </summary>
        Auriga.Information.ExchangeMechanism ExchangeMechanism { get; set; }

        /// <summary>
        /// Gets the owned elements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Information.IExchangeItemElement> OwnedElements { get; }

        /// <summary>
        /// Gets the owned exchange item instances.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Information.IExchangeItemInstance> OwnedExchangeItemInstances { get; }

        /// <summary>
        /// Gets the owned information realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Information.IInformationRealization> OwnedInformationRealizations { get; }

        /// <summary>
        /// Gets the realized exchange items.
        /// </summary>
        IEnumerable<Auriga.Information.IExchangeItem> RealizedExchangeItems { get; }

        /// <summary>
        /// Gets the realizing exchange items.
        /// </summary>
        IEnumerable<Auriga.Information.IExchangeItem> RealizingExchangeItems { get; }

        /// <summary>
        /// Gets the realizing operations.
        /// </summary>
        IEnumerable<Auriga.Information.IOperation> RealizingOperations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
