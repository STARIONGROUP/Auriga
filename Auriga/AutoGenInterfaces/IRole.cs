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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IRole : Auriga.Information.IAbstractInstance
    {
        Auriga.IContainerList<Auriga.Oa.IRoleAssemblyUsage> OwnedRoleAssemblyUsages { get; }

        Auriga.IContainerList<Auriga.Oa.IActivityAllocation> OwnedActivityAllocations { get; }

        IEnumerable<Auriga.Oa.IRoleAllocation> RoleAllocations { get; }

        IEnumerable<Auriga.Oa.IActivityAllocation> ActivityAllocations { get; }

        IEnumerable<Auriga.Oa.IEntity> AllocatingEntities { get; }

        IEnumerable<Auriga.Oa.IOperationalActivity> AllocatedOperationalActivities { get; }

    }
}
