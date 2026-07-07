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
    public partial interface IExchangeItem : global::Auriga.Modellingcore.IAbstractExchangeItem, global::Auriga.Behavior.IAbstractEvent, global::Auriga.Behavior.IAbstractSignal, global::Auriga.Modellingcore.IFinalizableElement, global::Auriga.Capellacore.IGeneralizableElement
    {
        global::Auriga.Information.ExchangeMechanism ExchangeMechanism { get; set; }

        global::Auriga.IContainerList<global::Auriga.Information.IExchangeItemElement> OwnedElements { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IInformationRealization> OwnedInformationRealizations { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IExchangeItemInstance> OwnedExchangeItemInstances { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> AllocatorInterfaces { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IExchangeItem> RealizedExchangeItems { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IExchangeItem> RealizingExchangeItems { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IOperation> RealizingOperations { get; }

    }
}
