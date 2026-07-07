// ------------------------------------------------------------------------------------------------
// <copyright file="ICapabilityPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Ctx
{
    /// <summary>
    /// Definition of the <c>CapabilityPkg</c> interface.
    /// </summary>
    public partial interface ICapabilityPkg : Auriga.Capellacommon.IAbstractCapabilityPkg
    {
        /// <summary>
        /// Gets the owned capabilities.
        /// </summary>
        Auriga.IContainerList<Auriga.Ctx.ICapability> OwnedCapabilities { get; }

        /// <summary>
        /// Gets the owned capability pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.Ctx.ICapabilityPkg> OwnedCapabilityPkgs { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
