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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ILogicalFunction : Auriga.Fa.IAbstractFunction
    {
        Auriga.IContainerList<Auriga.La.ILogicalFunctionPkg> OwnedLogicalFunctionPkgs { get; }

        IEnumerable<Auriga.La.ILogicalComponent> AllocatingLogicalComponents { get; }

        IEnumerable<Auriga.Ctx.ISystemFunction> RealizedSystemFunctions { get; }

        IEnumerable<Auriga.Pa.IPhysicalFunction> RealizingPhysicalFunctions { get; }

        IEnumerable<Auriga.La.ILogicalFunction> ContainedLogicalFunctions { get; }

        IEnumerable<Auriga.La.ILogicalFunction> ChildrenLogicalFunctions { get; }

    }
}
