// ------------------------------------------------------------------------------------------------
// <copyright file="IConceptCompliance.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Oa
{
    /// <summary>
    /// Definition of the <c>ConceptCompliance</c> interface.
    /// </summary>
    public partial interface IConceptCompliance : Auriga.Model.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets or sets the compliant capability.
        /// </summary>
        Auriga.Model.Oa.IOperationalCapability CompliantCapability { get; set; }

        /// <summary>
        /// Gets or sets the comply with concept.
        /// </summary>
        Auriga.Model.Oa.IConcept ComplyWithConcept { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
