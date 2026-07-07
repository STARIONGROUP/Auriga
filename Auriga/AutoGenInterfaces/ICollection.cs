// ------------------------------------------------------------------------------------------------
// <copyright file="ICollection.cs" company="Starion Group S.A.">
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
    public partial interface ICollection : global::Auriga.Capellacore.IClassifier, global::Auriga.Information.IMultiplicityElement, global::Auriga.Information.Datavalue.IDataValueContainer, global::Auriga.Modellingcore.IFinalizableElement
    {
        bool? IsPrimitive { get; set; }

        global::Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        global::Auriga.Information.CollectionKind? Kind { get; set; }

        global::Auriga.Information.AggregationKind? AggregationKind { get; set; }

        global::Auriga.Capellacore.IType Type { get; set; }

        global::System.Collections.Generic.List<global::Auriga.Information.Datatype.IDataType> Index { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IOperation> ContainedOperations { get; }

    }
}
