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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Oa
{
    using System.Collections.Generic;

    public partial interface IOrganisationalUnit : Auriga.Capellacore.INamedElement
    {
        Auriga.IContainerList<Auriga.Oa.IOrganisationalUnitComposition> OrganisationalUnitCompositions { get; }

        List<Auriga.Oa.ICommunityOfInterestComposition> CommunityOfInterestMemberships { get; }

    }
}
