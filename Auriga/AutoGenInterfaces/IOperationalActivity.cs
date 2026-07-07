// ------------------------------------------------------------------------------------------------
// <copyright file="IOperationalActivity.cs" company="Starion Group S.A.">
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
    public partial interface IOperationalActivity : global::Auriga.Fa.IAbstractFunction
    {
        global::Auriga.IContainerList<global::Auriga.Oa.IOperationalActivityPkg> OwnedOperationalActivityPkgs { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IActivityAllocation> ActivityAllocations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.ISwimlane> OwnedSwimlanes { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IOperationalProcess> OwnedProcess { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IEntity> AllocatorEntities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemFunction> RealizingSystemFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IRole> AllocatingRoles { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IOperationalActivity> ContainedOperationalActivities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IOperationalActivity> ChildrenOperationalActivities { get; }

    }
}
