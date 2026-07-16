// ------------------------------------------------------------------------------------------------
// <copyright file="IActivityAllocation.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ActivityAllocation</c> interface.
    /// </summary>
    public partial interface IActivityAllocation : Auriga.Model.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the activity.
        /// </summary>
        Auriga.Model.Oa.IOperationalActivity Activity { get; }

        /// <summary>
        /// Gets the role.
        /// </summary>
        Auriga.Model.Oa.IRole Role { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
