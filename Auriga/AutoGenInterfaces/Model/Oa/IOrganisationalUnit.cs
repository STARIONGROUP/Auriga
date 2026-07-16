// ------------------------------------------------------------------------------------------------
// <copyright file="IOrganisationalUnit.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>OrganisationalUnit</c> interface.
    /// </summary>
    public partial interface IOrganisationalUnit : Auriga.Model.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the community of interest memberships.
        /// </summary>
        List<Auriga.Model.Oa.ICommunityOfInterestComposition> CommunityOfInterestMemberships { get; }

        /// <summary>
        /// Gets the organisational unit compositions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Oa.IOrganisationalUnitComposition> OrganisationalUnitCompositions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
