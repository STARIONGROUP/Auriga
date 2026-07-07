// ------------------------------------------------------------------------------------------------
// <copyright file="ICapellaElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacore
{
    using System.Collections.Generic;

    public partial interface ICapellaElement : Auriga.Modellingcore.ITraceableElement, Auriga.Modellingcore.IPublishableElement
    {
        string Summary { get; set; }

        string Description { get; set; }

        string Review { get; set; }

        Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues { get; }

        Auriga.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes { get; }

        List<Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; }

        Auriga.IContainerList<Auriga.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups { get; }

        List<Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; }

        Auriga.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; }

    }
}
