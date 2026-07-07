// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalFunction.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa
{
    public partial interface IPhysicalFunction : global::Auriga.Fa.IAbstractFunction
    {
        global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalFunctionPkg> OwnedPhysicalFunctionPkgs { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalComponent> AllocatingPhysicalComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalFunction> RealizedLogicalFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalFunction> ContainedPhysicalFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalFunction> ChildrenPhysicalFunctions { get; }

    }
}
