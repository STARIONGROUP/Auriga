// ------------------------------------------------------------------------------------------------
// <copyright file="ICybersecurityPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Cybersecurity
{
    /// <summary>
    /// Definition of the <c>CybersecurityPkg</c> interface.
    /// </summary>
    public partial interface ICybersecurityPkg : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Emde.IElementExtension
    {
        /// <summary>
        /// Gets the owned cybersecurity pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cybersecurity.ICybersecurityPkg> OwnedCybersecurityPkgs { get; }

        /// <summary>
        /// Gets the owned primary assets.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cybersecurity.IPrimaryAsset> OwnedPrimaryAssets { get; }

        /// <summary>
        /// Gets the owned threats.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cybersecurity.IThreat> OwnedThreats { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
