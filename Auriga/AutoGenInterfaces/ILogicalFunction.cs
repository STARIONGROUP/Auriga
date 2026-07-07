// ------------------------------------------------------------------------------------------------
// <copyright file="ILogicalFunction.cs" company="Starion Group S.A.">
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

namespace Auriga.La
{
    public partial interface ILogicalFunction : global::Auriga.Fa.IAbstractFunction
    {
        global::Auriga.IContainerList<global::Auriga.La.ILogicalFunctionPkg> OwnedLogicalFunctionPkgs { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalComponent> AllocatingLogicalComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemFunction> RealizedSystemFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalFunction> RealizingPhysicalFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalFunction> ContainedLogicalFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalFunction> ChildrenLogicalFunctions { get; }

    }
}
