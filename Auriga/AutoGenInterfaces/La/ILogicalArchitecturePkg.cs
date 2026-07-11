// ------------------------------------------------------------------------------------------------
// <copyright file="ILogicalArchitecturePkg.cs" company="Starion Group S.A.">
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

namespace Auriga.La
{
    /// <summary>
    /// Definition of the <c>LogicalArchitecturePkg</c> interface.
    /// </summary>
    public partial interface ILogicalArchitecturePkg : Auriga.Cs.IBlockArchitecturePkg
    {
        /// <summary>
        /// Gets the owned logical architectures.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.La.ILogicalArchitecture> OwnedLogicalArchitectures { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
