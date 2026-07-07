// ------------------------------------------------------------------------------------------------
// <copyright file="ISystemFunctionPkg.cs" company="Starion Group S.A.">
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
    public partial interface ISystemFunctionPkg : global::Auriga.Fa.IFunctionPkg
    {
        global::Auriga.IContainerList<global::Auriga.Ctx.ISystemFunction> OwnedSystemFunctions { get; }

        global::Auriga.IContainerList<global::Auriga.Ctx.ISystemFunctionPkg> OwnedSystemFunctionPkgs { get; }

    }
}
