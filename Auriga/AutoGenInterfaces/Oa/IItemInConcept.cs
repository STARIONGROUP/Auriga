// ------------------------------------------------------------------------------------------------
// <copyright file="IItemInConcept.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>ItemInConcept</c> interface.
    /// </summary>
    public partial interface IItemInConcept : Auriga.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets or sets the concept.
        /// </summary>
        Auriga.Oa.IConcept Concept { get; set; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        Auriga.Oa.IAbstractConceptItem Item { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
