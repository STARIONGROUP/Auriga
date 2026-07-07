// ------------------------------------------------------------------------------------------------
// <copyright file="IComponentPortAllocation.cs" company="Starion Group S.A.">
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

namespace Auriga.Fa
{
    /// <summary>
    /// Definition of the <c>ComponentPortAllocation</c> interface.
    /// </summary>
    public partial interface IComponentPortAllocation : Auriga.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the allocated port.
        /// </summary>
        Auriga.Information.IPort AllocatedPort { get; }

        /// <summary>
        /// Gets the allocating port.
        /// </summary>
        Auriga.Information.IPort AllocatingPort { get; }

        /// <summary>
        /// Gets the owned component port allocation ends.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentPortAllocationEnd> OwnedComponentPortAllocationEnds { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
