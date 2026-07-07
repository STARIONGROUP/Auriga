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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Ctx
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ISystemFunction : Auriga.Fa.IAbstractFunction
    {
        Auriga.IContainerList<Auriga.Ctx.ISystemFunctionPkg> OwnedSystemFunctionPkgs { get; }

        IEnumerable<Auriga.Ctx.ISystemComponent> AllocatingSystemComponents { get; }

        IEnumerable<Auriga.Oa.IOperationalActivity> RealizedOperationalActivities { get; }

        IEnumerable<Auriga.La.ILogicalFunction> RealizingLogicalFunctions { get; }

        IEnumerable<Auriga.Ctx.ISystemFunction> ContainedSystemFunctions { get; }

        IEnumerable<Auriga.Ctx.ISystemFunction> ChildrenSystemFunctions { get; }

    }
}
