// ------------------------------------------------------------------------------------------------
// <copyright file="IClassifier.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacore
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Classifier</c> interface.
    /// </summary>
    public partial interface IClassifier : Auriga.Capellacore.IGeneralizableElement
    {
        /// <summary>
        /// Gets the contained properties.
        /// </summary>
        IEnumerable<Auriga.Information.IProperty> ContainedProperties { get; }

        /// <summary>
        /// Gets the owned features.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacore.IFeature> OwnedFeatures { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
