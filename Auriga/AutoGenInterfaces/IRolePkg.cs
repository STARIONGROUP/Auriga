// ------------------------------------------------------------------------------------------------
// <copyright file="IRolePkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Oa
{
    /// <summary>
    /// Definition of the <c>RolePkg</c> interface.
    /// </summary>
    public partial interface IRolePkg : Auriga.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned role pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.Oa.IRolePkg> OwnedRolePkgs { get; }

        /// <summary>
        /// Gets the owned roles.
        /// </summary>
        Auriga.IContainerList<Auriga.Oa.IRole> OwnedRoles { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
