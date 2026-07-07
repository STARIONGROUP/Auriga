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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Information
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IExchangeItem : Auriga.Modellingcore.IAbstractExchangeItem, Auriga.Behavior.IAbstractEvent, Auriga.Behavior.IAbstractSignal, Auriga.Modellingcore.IFinalizableElement, Auriga.Capellacore.IGeneralizableElement
    {
        Auriga.Information.ExchangeMechanism ExchangeMechanism { get; set; }

        Auriga.IContainerList<Auriga.Information.IExchangeItemElement> OwnedElements { get; }

        Auriga.IContainerList<Auriga.Information.IInformationRealization> OwnedInformationRealizations { get; }

        Auriga.IContainerList<Auriga.Information.IExchangeItemInstance> OwnedExchangeItemInstances { get; }

        IEnumerable<Auriga.Cs.IInterface> AllocatorInterfaces { get; }

        IEnumerable<Auriga.Information.IExchangeItem> RealizedExchangeItems { get; }

        IEnumerable<Auriga.Information.IExchangeItem> RealizingExchangeItems { get; }

        IEnumerable<Auriga.Information.IOperation> RealizingOperations { get; }

    }
}
