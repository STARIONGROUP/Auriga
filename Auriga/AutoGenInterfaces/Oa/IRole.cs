// ------------------------------------------------------------------------------------------------
// <copyright file="IRole.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Role</c> interface.
    /// </summary>
    public partial interface IRole : Auriga.Information.IAbstractInstance
    {
        /// <summary>
        /// Gets the activity allocations.
        /// </summary>
        IEnumerable<Auriga.Oa.IActivityAllocation> ActivityAllocations { get; }

        /// <summary>
        /// Gets the allocated operational activities.
        /// </summary>
        IEnumerable<Auriga.Oa.IOperationalActivity> AllocatedOperationalActivities { get; }

        /// <summary>
        /// Gets the allocating entities.
        /// </summary>
        IEnumerable<Auriga.Oa.IEntity> AllocatingEntities { get; }

        /// <summary>
        /// Gets the owned activity allocations.
        /// </summary>
        Auriga.IContainerList<Auriga.Oa.IActivityAllocation> OwnedActivityAllocations { get; }

        /// <summary>
        /// Gets the owned role assembly usages.
        /// </summary>
        Auriga.IContainerList<Auriga.Oa.IRoleAssemblyUsage> OwnedRoleAssemblyUsages { get; }

        /// <summary>
        /// Gets the role allocations.
        /// </summary>
        IEnumerable<Auriga.Oa.IRoleAllocation> RoleAllocations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
