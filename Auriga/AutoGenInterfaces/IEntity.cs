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
    public partial interface IEntity : global::Auriga.Oa.IAbstractConceptItem, global::Auriga.Modellingcore.IInformationsExchanger, global::Auriga.Capellacore.IInvolvedElement
    {
        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IRoleAllocation> RoleAllocations { get; }

        global::System.Collections.Generic.List<global::Auriga.Oa.IOrganisationalUnitComposition> OrganisationalUnitMemberships { get; }

        global::Auriga.Oa.ILocation ActualLocation { get; set; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IEntity> SubEntities { get; }

        global::Auriga.IContainerList<global::Auriga.Oa.IEntity> OwnedEntities { get; }

        global::Auriga.IContainerList<global::Auriga.Oa.ICommunicationMean> OwnedCommunicationMeans { get; }

        global::Auriga.IContainerList<global::Auriga.Oa.IRoleAllocation> OwnedRoleAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IOperationalActivity> AllocatedOperationalActivities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IRole> AllocatedRoles { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IOperationalCapability> InvolvingOperationalCapabilities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemComponent> RealizingSystemComponents { get; }

    }
}
