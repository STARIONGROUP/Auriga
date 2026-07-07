// ------------------------------------------------------------------------------------------------
// <copyright file="IPortAllocation.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    /// <summary>
    /// Definition of the <c>PortAllocation</c> interface.
    /// </summary>
    public partial interface IPortAllocation : Auriga.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the allocated port.
        /// </summary>
        Auriga.Information.IPort AllocatedPort { get; }

        /// <summary>
        /// Gets the allocating port.
        /// </summary>
        Auriga.Information.IPort AllocatingPort { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
