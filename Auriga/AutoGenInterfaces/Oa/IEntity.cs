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

namespace Auriga.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Entity</c> interface.
    /// </summary>
    public partial interface IEntity : Auriga.Oa.IAbstractConceptItem, Auriga.Modellingcore.IInformationsExchanger, Auriga.Capellacore.IInvolvedElement
    {
        /// <summary>
        /// Gets or sets the actual location.
        /// </summary>
        Auriga.Oa.ILocation ActualLocation { get; set; }

        /// <summary>
        /// Gets the allocated operational activities.
        /// </summary>
        IEnumerable<Auriga.Oa.IOperationalActivity> AllocatedOperationalActivities { get; }

        /// <summary>
        /// Gets the allocated roles.
        /// </summary>
        IEnumerable<Auriga.Oa.IRole> AllocatedRoles { get; }

        /// <summary>
        /// Gets the involving operational capabilities.
        /// </summary>
        IEnumerable<Auriga.Oa.IOperationalCapability> InvolvingOperationalCapabilities { get; }

        /// <summary>
        /// Gets the organisational unit memberships.
        /// </summary>
        List<Auriga.Oa.IOrganisationalUnitComposition> OrganisationalUnitMemberships { get; }

        /// <summary>
        /// Gets the owned communication means.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Oa.ICommunicationMean> OwnedCommunicationMeans { get; }

        /// <summary>
        /// Gets the owned entities.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Oa.IEntity> OwnedEntities { get; }

        /// <summary>
        /// Gets the owned role allocations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Oa.IRoleAllocation> OwnedRoleAllocations { get; }

        /// <summary>
        /// Gets the realizing system components.
        /// </summary>
        IEnumerable<Auriga.Ctx.ISystemComponent> RealizingSystemComponents { get; }

        /// <summary>
        /// Gets the role allocations.
        /// </summary>
        IEnumerable<Auriga.Oa.IRoleAllocation> RoleAllocations { get; }

        /// <summary>
        /// Gets the sub entities.
        /// </summary>
        IEnumerable<Auriga.Oa.IEntity> SubEntities { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
