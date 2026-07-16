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

namespace Auriga.Model.Information
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Collection</c> interface.
    /// </summary>
    public partial interface ICollection : Auriga.Model.Capellacore.IClassifier, Auriga.Model.Information.IMultiplicityElement, Auriga.Model.Information.Datavalue.IDataValueContainer, Auriga.Model.Modellingcore.IFinalizableElement
    {
        /// <summary>
        /// Gets or sets the aggregation kind.
        /// </summary>
        Auriga.Model.Information.AggregationKind? AggregationKind { get; set; }

        /// <summary>
        /// Gets the contained operations.
        /// </summary>
        IEnumerable<Auriga.Model.Information.IOperation> ContainedOperations { get; }

        /// <summary>
        /// Gets the index.
        /// </summary>
        List<Auriga.Model.Information.Datatype.IDataType> Index { get; }

        /// <summary>
        /// Gets or sets the is primitive.
        /// </summary>
        bool? IsPrimitive { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Model.Information.CollectionKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        Auriga.Model.Capellacore.IType Type { get; set; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        Auriga.Model.Capellacore.VisibilityKind? Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
