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

namespace Auriga.Model.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>OperationalActivity</c> interface.
    /// </summary>
    public partial interface IOperationalActivity : Auriga.Model.Fa.IAbstractFunction
    {
        /// <summary>
        /// Gets the activity allocations.
        /// </summary>
        IEnumerable<Auriga.Model.Oa.IActivityAllocation> ActivityAllocations { get; }

        /// <summary>
        /// Gets the allocating roles.
        /// </summary>
        IEnumerable<Auriga.Model.Oa.IRole> AllocatingRoles { get; }

        /// <summary>
        /// Gets the allocator entities.
        /// </summary>
        IEnumerable<Auriga.Model.Oa.IEntity> AllocatorEntities { get; }

        /// <summary>
        /// Gets the children operational activities.
        /// </summary>
        IEnumerable<Auriga.Model.Oa.IOperationalActivity> ChildrenOperationalActivities { get; }

        /// <summary>
        /// Gets the contained operational activities.
        /// </summary>
        IEnumerable<Auriga.Model.Oa.IOperationalActivity> ContainedOperationalActivities { get; }

        /// <summary>
        /// Gets the owned operational activity pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Oa.IOperationalActivityPkg> OwnedOperationalActivityPkgs { get; }

        /// <summary>
        /// Gets the owned process.
        /// </summary>
        IEnumerable<Auriga.Model.Oa.IOperationalProcess> OwnedProcess { get; }

        /// <summary>
        /// Gets the owned swimlanes.
        /// </summary>
        IEnumerable<Auriga.Model.Oa.ISwimlane> OwnedSwimlanes { get; }

        /// <summary>
        /// Gets the realizing system functions.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ISystemFunction> RealizingSystemFunctions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
