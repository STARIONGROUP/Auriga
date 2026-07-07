// ------------------------------------------------------------------------------------------------
// <copyright file="IMissionPkg.cs" company="Starion Group S.A.">
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
    public partial interface IMissionPkg : global::Auriga.Capellacore.IStructure
    {
        global::Auriga.IContainerList<global::Auriga.Ctx.IMissionPkg> OwnedMissionPkgs { get; }

        global::Auriga.IContainerList<global::Auriga.Ctx.IMission> OwnedMissions { get; }

    }
}
