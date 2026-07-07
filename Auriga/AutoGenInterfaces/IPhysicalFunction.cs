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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IPhysicalFunction : Auriga.Fa.IAbstractFunction
    {
        Auriga.IContainerList<Auriga.Pa.IPhysicalFunctionPkg> OwnedPhysicalFunctionPkgs { get; }

        IEnumerable<Auriga.Pa.IPhysicalComponent> AllocatingPhysicalComponents { get; }

        IEnumerable<Auriga.La.ILogicalFunction> RealizedLogicalFunctions { get; }

        IEnumerable<Auriga.Pa.IPhysicalFunction> ContainedPhysicalFunctions { get; }

        IEnumerable<Auriga.Pa.IPhysicalFunction> ChildrenPhysicalFunctions { get; }

    }
}
