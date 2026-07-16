// ------------------------------------------------------------------------------------------------
// <copyright file="IEntityOperationalCapabilityInvolvement.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>EntityOperationalCapabilityInvolvement</c> interface.
    /// </summary>
    public partial interface IEntityOperationalCapabilityInvolvement : Auriga.Model.Capellacore.IInvolvement
    {
        /// <summary>
        /// Gets the capability.
        /// </summary>
        Auriga.Model.Oa.IOperationalCapability Capability { get; }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        Auriga.Model.Oa.IEntity Entity { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
