// ------------------------------------------------------------------------------------------------
// <copyright file="IConcept.cs" company="Starion Group S.A.">
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

namespace Auriga.Oa
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>Concept</c> interface.
    /// </summary>
    public partial interface IConcept : Auriga.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the compliances.
        /// </summary>
        List<Auriga.Oa.IConceptCompliance> Compliances { get; }

        /// <summary>
        /// Gets the composite links.
        /// </summary>
        Auriga.IContainerList<Auriga.Oa.IItemInConcept> CompositeLinks { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
