// ------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="Starion Group S.A.">
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
    using System.Linq;

    public partial interface IEntity : Auriga.Oa.IAbstractConceptItem, Auriga.Modellingcore.IInformationsExchanger, Auriga.Capellacore.IInvolvedElement
    {
        IEnumerable<Auriga.Oa.IRoleAllocation> RoleAllocations { get; }

        List<Auriga.Oa.IOrganisationalUnitComposition> OrganisationalUnitMemberships { get; }

        Auriga.Oa.ILocation ActualLocation { get; set; }

        IEnumerable<Auriga.Oa.IEntity> SubEntities { get; }

        Auriga.IContainerList<Auriga.Oa.IEntity> OwnedEntities { get; }

        Auriga.IContainerList<Auriga.Oa.ICommunicationMean> OwnedCommunicationMeans { get; }

        Auriga.IContainerList<Auriga.Oa.IRoleAllocation> OwnedRoleAllocations { get; }

        IEnumerable<Auriga.Oa.IOperationalActivity> AllocatedOperationalActivities { get; }

        IEnumerable<Auriga.Oa.IRole> AllocatedRoles { get; }

        IEnumerable<Auriga.Oa.IOperationalCapability> InvolvingOperationalCapabilities { get; }

        IEnumerable<Auriga.Ctx.ISystemComponent> RealizingSystemComponents { get; }

    }
}
