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

namespace Auriga.Model.Oa
{
    /// <summary>
    /// Definition of the <c>ConceptPkg</c> interface.
    /// </summary>
    public partial interface IConceptPkg : Auriga.Model.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned concept pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Oa.IConceptPkg> OwnedConceptPkgs { get; }

        /// <summary>
        /// Gets the owned concepts.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Oa.IConcept> OwnedConcepts { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
