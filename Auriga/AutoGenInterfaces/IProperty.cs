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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Information
{
    public partial interface IProperty : global::Auriga.Capellacore.IFeature, global::Auriga.Capellacore.ITypedElement, global::Auriga.Information.IMultiplicityElement, global::Auriga.Modellingcore.IFinalizableElement
    {
        global::Auriga.Information.AggregationKind? AggregationKind { get; set; }

        bool? IsDerived { get; set; }

        bool? IsReadOnly { get; set; }

        bool? IsPartOfKey { get; set; }

        global::Auriga.Information.IAssociation Association { get; }

    }
}
