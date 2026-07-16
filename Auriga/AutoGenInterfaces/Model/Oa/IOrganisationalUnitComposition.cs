// ------------------------------------------------------------------------------------------------
// <copyright file="IOrganisationalUnitComposition.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>OrganisationalUnitComposition</c> interface.
    /// </summary>
    public partial interface IOrganisationalUnitComposition : Auriga.Model.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets or sets the organisational unit.
        /// </summary>
        Auriga.Model.Oa.IOrganisationalUnit OrganisationalUnit { get; set; }

        /// <summary>
        /// Gets or sets the participating entity.
        /// </summary>
        Auriga.Model.Oa.IEntity ParticipatingEntity { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
