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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IOperationalActivity : Auriga.Fa.IAbstractFunction
    {
        Auriga.IContainerList<Auriga.Oa.IOperationalActivityPkg> OwnedOperationalActivityPkgs { get; }

        IEnumerable<Auriga.Oa.IActivityAllocation> ActivityAllocations { get; }

        IEnumerable<Auriga.Oa.ISwimlane> OwnedSwimlanes { get; }

        IEnumerable<Auriga.Oa.IOperationalProcess> OwnedProcess { get; }

        IEnumerable<Auriga.Oa.IEntity> AllocatorEntities { get; }

        IEnumerable<Auriga.Ctx.ISystemFunction> RealizingSystemFunctions { get; }

        IEnumerable<Auriga.Oa.IRole> AllocatingRoles { get; }

        IEnumerable<Auriga.Oa.IOperationalActivity> ContainedOperationalActivities { get; }

        IEnumerable<Auriga.Oa.IOperationalActivity> ChildrenOperationalActivities { get; }

    }
}
