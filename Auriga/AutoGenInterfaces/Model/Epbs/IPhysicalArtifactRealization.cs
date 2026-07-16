// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalArtifactRealization.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Epbs
{
    /// <summary>
    /// Definition of the <c>PhysicalArtifactRealization</c> interface.
    /// </summary>
    public partial interface IPhysicalArtifactRealization : Auriga.Model.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized physical artifact.
        /// </summary>
        Auriga.Model.Cs.IAbstractPhysicalArtifact RealizedPhysicalArtifact { get; }

        /// <summary>
        /// Gets the realizing configuration item.
        /// </summary>
        Auriga.Model.Epbs.IConfigurationItem RealizingConfigurationItem { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
