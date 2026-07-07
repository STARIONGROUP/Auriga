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

namespace Auriga.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>OperationalActivity</c> interface.
    /// </summary>
    public partial interface IOperationalActivity : Auriga.Fa.IAbstractFunction
    {
        /// <summary>
        /// Gets the activity allocations.
        /// </summary>
        IEnumerable<Auriga.Oa.IActivityAllocation> ActivityAllocations { get; }

        /// <summary>
        /// Gets the allocating roles.
        /// </summary>
        IEnumerable<Auriga.Oa.IRole> AllocatingRoles { get; }

        /// <summary>
        /// Gets the allocator entities.
        /// </summary>
        IEnumerable<Auriga.Oa.IEntity> AllocatorEntities { get; }

        /// <summary>
        /// Gets the children operational activities.
        /// </summary>
        IEnumerable<Auriga.Oa.IOperationalActivity> ChildrenOperationalActivities { get; }

        /// <summary>
        /// Gets the contained operational activities.
        /// </summary>
        IEnumerable<Auriga.Oa.IOperationalActivity> ContainedOperationalActivities { get; }

        /// <summary>
        /// Gets the owned operational activity pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.Oa.IOperationalActivityPkg> OwnedOperationalActivityPkgs { get; }

        /// <summary>
        /// Gets the owned process.
        /// </summary>
        IEnumerable<Auriga.Oa.IOperationalProcess> OwnedProcess { get; }

        /// <summary>
        /// Gets the owned swimlanes.
        /// </summary>
        IEnumerable<Auriga.Oa.ISwimlane> OwnedSwimlanes { get; }

        /// <summary>
        /// Gets the realizing system functions.
        /// </summary>
        IEnumerable<Auriga.Ctx.ISystemFunction> RealizingSystemFunctions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
