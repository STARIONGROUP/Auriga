// ------------------------------------------------------------------------------------------------
// <copyright file="ICapabilityRealizationPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.La
{
    /// <summary>
    /// Definition of the <c>CapabilityRealizationPkg</c> interface.
    /// </summary>
    public partial interface ICapabilityRealizationPkg : Auriga.Capellacommon.IAbstractCapabilityPkg
    {
        /// <summary>
        /// Gets the owned capability realization pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.La.ICapabilityRealizationPkg> OwnedCapabilityRealizationPkgs { get; }

        /// <summary>
        /// Gets the owned capability realizations.
        /// </summary>
        Auriga.IContainerList<Auriga.La.ICapabilityRealization> OwnedCapabilityRealizations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
