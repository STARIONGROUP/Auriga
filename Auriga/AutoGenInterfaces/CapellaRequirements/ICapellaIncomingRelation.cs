// ------------------------------------------------------------------------------------------------
// <copyright file="ICapellaIncomingRelation.cs" company="Starion Group S.A.">
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

namespace Auriga.CapellaRequirements
{
    /// <summary>
    /// Definition of the <c>CapellaIncomingRelation</c> interface.
    /// </summary>
    public partial interface ICapellaIncomingRelation : Auriga.CapellaRequirements.ICapellaRelation
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Requirements.IRequirement Source { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Capellacore.ICapellaElement Target { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
