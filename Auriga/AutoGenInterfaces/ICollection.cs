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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ICollection : Auriga.Capellacore.IClassifier, Auriga.Information.IMultiplicityElement, Auriga.Information.Datavalue.IDataValueContainer, Auriga.Modellingcore.IFinalizableElement
    {
        bool? IsPrimitive { get; set; }

        Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        Auriga.Information.CollectionKind? Kind { get; set; }

        Auriga.Information.AggregationKind? AggregationKind { get; set; }

        Auriga.Capellacore.IType Type { get; set; }

        List<Auriga.Information.Datatype.IDataType> Index { get; }

        IEnumerable<Auriga.Information.IOperation> ContainedOperations { get; }

    }
}
