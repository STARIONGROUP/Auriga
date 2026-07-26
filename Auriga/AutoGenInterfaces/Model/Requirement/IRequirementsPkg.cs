// ------------------------------------------------------------------------------------------------
// <copyright file="IRequirementsPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Requirement
{
    /// <summary>
    /// Definition of the <c>RequirementsPkg</c> interface.
    /// </summary>
    public partial interface IRequirementsPkg : Auriga.Model.Capellacore.IStructure, Auriga.Model.Emde.IElementExtension
    {
        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        string AdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        string Level { get; set; }

        /// <summary>
        /// Gets the owned requirement pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Requirement.IRequirementsPkg> OwnedRequirementPkgs { get; }

        /// <summary>
        /// Gets the owned requirements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Requirement.IRequirement> OwnedRequirements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
