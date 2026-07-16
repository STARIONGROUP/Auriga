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

namespace Auriga.Model.Information
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ExchangeItem</c> interface.
    /// </summary>
    public partial interface IExchangeItem : Auriga.Model.Modellingcore.IAbstractExchangeItem, Auriga.Model.Behavior.IAbstractEvent, Auriga.Model.Behavior.IAbstractSignal, Auriga.Model.Modellingcore.IFinalizableElement, Auriga.Model.Capellacore.IGeneralizableElement
    {
        /// <summary>
        /// Gets the allocator interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> AllocatorInterfaces { get; }

        /// <summary>
        /// Gets or sets the exchange mechanism.
        /// </summary>
        Auriga.Model.Information.ExchangeMechanism ExchangeMechanism { get; set; }

        /// <summary>
        /// Gets the owned elements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.IExchangeItemElement> OwnedElements { get; }

        /// <summary>
        /// Gets the owned exchange item instances.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.IExchangeItemInstance> OwnedExchangeItemInstances { get; }

        /// <summary>
        /// Gets the owned information realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.IInformationRealization> OwnedInformationRealizations { get; }

        /// <summary>
        /// Gets the realized exchange items.
        /// </summary>
        IEnumerable<Auriga.Model.Information.IExchangeItem> RealizedExchangeItems { get; }

        /// <summary>
        /// Gets the realizing exchange items.
        /// </summary>
        IEnumerable<Auriga.Model.Information.IExchangeItem> RealizingExchangeItems { get; }

        /// <summary>
        /// Gets the realizing operations.
        /// </summary>
        IEnumerable<Auriga.Model.Information.IOperation> RealizingOperations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
