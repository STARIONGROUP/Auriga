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
    public partial interface ICapellaElement : global::Auriga.Modellingcore.ITraceableElement, global::Auriga.Modellingcore.IPublishableElement
    {
        string Summary { get; set; }

        string Description { get; set; }

        string Review { get; set; }

        global::Auriga.IContainerList<global::Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues { get; }

        global::Auriga.IContainerList<global::Auriga.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes { get; }

        global::System.Collections.Generic.List<global::Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; }

        global::Auriga.IContainerList<global::Auriga.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups { get; }

        global::System.Collections.Generic.List<global::Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; }

        global::Auriga.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        global::System.Collections.Generic.List<global::Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; }

    }
}
