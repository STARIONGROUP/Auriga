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

namespace Auriga.Ctx
{
    /// <summary>
    /// Definition of the <c>MissionPkg</c> interface.
    /// </summary>
    public partial interface IMissionPkg : Auriga.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned mission pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Ctx.IMissionPkg> OwnedMissionPkgs { get; }

        /// <summary>
        /// Gets the owned missions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Ctx.IMission> OwnedMissions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
