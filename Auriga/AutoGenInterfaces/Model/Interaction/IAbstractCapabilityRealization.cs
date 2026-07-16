// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractCapabilityRealization.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Interaction
{
    /// <summary>
    /// Definition of the <c>AbstractCapabilityRealization</c> interface.
    /// </summary>
    public partial interface IAbstractCapabilityRealization : Auriga.Model.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized capability.
        /// </summary>
        Auriga.Model.Interaction.IAbstractCapability RealizedCapability { get; }

        /// <summary>
        /// Gets the realizing capability.
        /// </summary>
        Auriga.Model.Interaction.IAbstractCapability RealizingCapability { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
