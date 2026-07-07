// ------------------------------------------------------------------------------------------------
// <copyright file="ICapellaOutgoingRelation.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>CapellaOutgoingRelation</c> interface.
    /// </summary>
    public partial interface ICapellaOutgoingRelation : Auriga.CapellaRequirements.ICapellaRelation, Auriga.Emde.IElementExtension
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Capellacore.ICapellaElement Source { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Requirements.IRequirement Target { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
