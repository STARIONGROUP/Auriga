// ------------------------------------------------------------------------------------------------
// <copyright file="ISystemComponentPkg.cs" company="Starion Group S.A.">
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
    public partial interface ISystemComponentPkg : Auriga.Cs.IComponentPkg
    {
        Auriga.IContainerList<Auriga.Ctx.ISystemComponent> OwnedSystemComponents { get; }

        Auriga.IContainerList<Auriga.Ctx.ISystemComponentPkg> OwnedSystemComponentPkgs { get; }

    }
}
