// ------------------------------------------------------------------------------------------------
// <copyright file="IComponentPortAllocationEnd.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ComponentPortAllocationEnd</c> interface.
    /// </summary>
    public partial interface IComponentPortAllocationEnd : Auriga.Capellacore.ICapellaElement
    {
        /// <summary>
        /// Gets the owning component port allocation.
        /// </summary>
        Auriga.Fa.IComponentPortAllocation OwningComponentPortAllocation { get; }

        /// <summary>
        /// Gets or sets the part.
        /// </summary>
        Auriga.Cs.IPart Part { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        Auriga.Information.IPort Port { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
