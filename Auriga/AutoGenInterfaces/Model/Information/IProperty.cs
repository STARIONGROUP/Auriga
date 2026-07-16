// ------------------------------------------------------------------------------------------------
// <copyright file="IProperty.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>Property</c> interface.
    /// </summary>
    public partial interface IProperty : Auriga.Model.Capellacore.IFeature, Auriga.Model.Capellacore.ITypedElement, Auriga.Model.Information.IMultiplicityElement, Auriga.Model.Modellingcore.IFinalizableElement
    {
        /// <summary>
        /// Gets or sets the aggregation kind.
        /// </summary>
        Auriga.Model.Information.AggregationKind? AggregationKind { get; set; }

        /// <summary>
        /// Gets the association.
        /// </summary>
        Auriga.Model.Information.IAssociation Association { get; }

        /// <summary>
        /// Gets or sets the is derived.
        /// </summary>
        bool? IsDerived { get; set; }

        /// <summary>
        /// Gets or sets the is part of key.
        /// </summary>
        bool? IsPartOfKey { get; set; }

        /// <summary>
        /// Gets or sets the is read only.
        /// </summary>
        bool? IsReadOnly { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
