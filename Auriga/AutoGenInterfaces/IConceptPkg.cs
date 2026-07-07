// ------------------------------------------------------------------------------------------------
// <copyright file="IConceptPkg.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ConceptPkg</c> interface.
    /// </summary>
    public partial interface IConceptPkg : Auriga.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned concept pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.Oa.IConceptPkg> OwnedConceptPkgs { get; }

        /// <summary>
        /// Gets the owned concepts.
        /// </summary>
        Auriga.IContainerList<Auriga.Oa.IConcept> OwnedConcepts { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
