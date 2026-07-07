// ------------------------------------------------------------------------------------------------
// <copyright file="IArchitectureAllocation.cs" company="Starion Group S.A.">
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

namespace Auriga.Cs
{
    /// <summary>
    /// Definition of the <c>ArchitectureAllocation</c> interface.
    /// </summary>
    public partial interface IArchitectureAllocation : Auriga.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the allocated architecture.
        /// </summary>
        Auriga.Cs.IBlockArchitecture AllocatedArchitecture { get; }

        /// <summary>
        /// Gets the allocating architecture.
        /// </summary>
        Auriga.Cs.IBlockArchitecture AllocatingArchitecture { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
