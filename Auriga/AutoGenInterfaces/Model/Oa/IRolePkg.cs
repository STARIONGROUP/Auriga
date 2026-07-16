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

namespace Auriga.Model.Oa
{
    /// <summary>
    /// Definition of the <c>RolePkg</c> interface.
    /// </summary>
    public partial interface IRolePkg : Auriga.Model.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned role pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Oa.IRolePkg> OwnedRolePkgs { get; }

        /// <summary>
        /// Gets the owned roles.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Oa.IRole> OwnedRoles { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
