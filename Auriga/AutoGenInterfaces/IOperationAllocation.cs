// ------------------------------------------------------------------------------------------------
// <copyright file="IOperationAllocation.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>OperationAllocation</c> interface.
    /// </summary>
    public partial interface IOperationAllocation : Auriga.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the allocated operation.
        /// </summary>
        Auriga.Information.IOperation AllocatedOperation { get; }

        /// <summary>
        /// Gets the allocating operation.
        /// </summary>
        Auriga.Information.IOperation AllocatingOperation { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
