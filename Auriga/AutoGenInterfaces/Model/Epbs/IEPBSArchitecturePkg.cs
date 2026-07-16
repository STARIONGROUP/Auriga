// ------------------------------------------------------------------------------------------------
// <copyright file="IEPBSArchitecturePkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Epbs
{
    /// <summary>
    /// Definition of the <c>EPBSArchitecturePkg</c> interface.
    /// </summary>
    public partial interface IEPBSArchitecturePkg : Auriga.Model.Cs.IBlockArchitecturePkg
    {
        /// <summary>
        /// Gets the owned e p b s architectures.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Epbs.IEPBSArchitecture> OwnedEPBSArchitectures { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
