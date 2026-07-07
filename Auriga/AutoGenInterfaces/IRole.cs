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
    public partial interface IRole : global::Auriga.Information.IAbstractInstance
    {
        global::Auriga.IContainerList<global::Auriga.Oa.IRoleAssemblyUsage> OwnedRoleAssemblyUsages { get; }

        global::Auriga.IContainerList<global::Auriga.Oa.IActivityAllocation> OwnedActivityAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IRoleAllocation> RoleAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IActivityAllocation> ActivityAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IEntity> AllocatingEntities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IOperationalActivity> AllocatedOperationalActivities { get; }

    }
}
