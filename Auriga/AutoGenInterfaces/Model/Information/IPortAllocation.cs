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

namespace Auriga.Model.Information
{
    /// <summary>
    /// Definition of the <c>PortAllocation</c> interface.
    /// </summary>
    public partial interface IPortAllocation : Auriga.Model.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the allocated port.
        /// </summary>
        Auriga.Model.Information.IPort AllocatedPort { get; }

        /// <summary>
        /// Gets the allocating port.
        /// </summary>
        Auriga.Model.Information.IPort AllocatingPort { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
