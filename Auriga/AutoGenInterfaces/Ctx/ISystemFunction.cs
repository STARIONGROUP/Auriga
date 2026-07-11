// ------------------------------------------------------------------------------------------------
// <copyright file="ISystemFunction.cs" company="Starion Group S.A.">
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

namespace Auriga.Ctx
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>SystemFunction</c> interface.
    /// </summary>
    public partial interface ISystemFunction : Auriga.Fa.IAbstractFunction
    {
        /// <summary>
        /// Gets the allocating system components.
        /// </summary>
        IEnumerable<Auriga.Ctx.ISystemComponent> AllocatingSystemComponents { get; }

        /// <summary>
        /// Gets the children system functions.
        /// </summary>
        IEnumerable<Auriga.Ctx.ISystemFunction> ChildrenSystemFunctions { get; }

        /// <summary>
        /// Gets the contained system functions.
        /// </summary>
        IEnumerable<Auriga.Ctx.ISystemFunction> ContainedSystemFunctions { get; }

        /// <summary>
        /// Gets the owned system function pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Ctx.ISystemFunctionPkg> OwnedSystemFunctionPkgs { get; }

        /// <summary>
        /// Gets the realized operational activities.
        /// </summary>
        IEnumerable<Auriga.Oa.IOperationalActivity> RealizedOperationalActivities { get; }

        /// <summary>
        /// Gets the realizing logical functions.
        /// </summary>
        IEnumerable<Auriga.La.ILogicalFunction> RealizingLogicalFunctions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
