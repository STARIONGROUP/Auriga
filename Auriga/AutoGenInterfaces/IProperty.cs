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
    public partial interface IProperty : Auriga.Capellacore.IFeature, Auriga.Capellacore.ITypedElement, Auriga.Information.IMultiplicityElement, Auriga.Modellingcore.IFinalizableElement
    {
        Auriga.Information.AggregationKind? AggregationKind { get; set; }

        bool? IsDerived { get; set; }

        bool? IsReadOnly { get; set; }

        bool? IsPartOfKey { get; set; }

        Auriga.Information.IAssociation Association { get; }

    }
}
