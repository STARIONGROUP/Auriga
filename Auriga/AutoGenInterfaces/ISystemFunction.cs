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
    public partial interface ISystemFunction : global::Auriga.Fa.IAbstractFunction
    {
        global::Auriga.IContainerList<global::Auriga.Ctx.ISystemFunctionPkg> OwnedSystemFunctionPkgs { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemComponent> AllocatingSystemComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IOperationalActivity> RealizedOperationalActivities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalFunction> RealizingLogicalFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemFunction> ContainedSystemFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemFunction> ChildrenSystemFunctions { get; }

    }
}
