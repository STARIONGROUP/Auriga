// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalArchitecturePkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa
{
    /// <summary>
    /// Definition of the <c>PhysicalArchitecturePkg</c> interface.
    /// </summary>
    public partial interface IPhysicalArchitecturePkg : Auriga.Cs.IBlockArchitecturePkg
    {
        /// <summary>
        /// Gets the owned physical architecture pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.Pa.IPhysicalArchitecturePkg> OwnedPhysicalArchitecturePkgs { get; }

        /// <summary>
        /// Gets the owned physical architectures.
        /// </summary>
        Auriga.IContainerList<Auriga.Pa.IPhysicalArchitecture> OwnedPhysicalArchitectures { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
