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

namespace Auriga.Model.Capellacore
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>CapellaElement</c> interface.
    /// </summary>
    public partial interface ICapellaElement : Auriga.Model.Modellingcore.ITraceableElement, Auriga.Model.Modellingcore.IPublishableElement
    {
        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        List<Auriga.Model.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; }

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        List<Auriga.Model.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets the features.
        /// </summary>
        List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; }

        /// <summary>
        /// Gets the owned enumeration property types.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes { get; }

        /// <summary>
        /// Gets the owned property value groups.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups { get; }

        /// <summary>
        /// Gets the owned property values.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue> OwnedPropertyValues { get; }

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        string Review { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        Auriga.Model.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        string Summary { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
