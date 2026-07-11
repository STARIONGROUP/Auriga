// ------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationItemPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Epbs
{
    /// <summary>
    /// Definition of the <c>ConfigurationItemPkg</c> interface.
    /// </summary>
    public partial interface IConfigurationItemPkg : Auriga.Cs.IComponentPkg
    {
        /// <summary>
        /// Gets the owned configuration item pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Epbs.IConfigurationItemPkg> OwnedConfigurationItemPkgs { get; }

        /// <summary>
        /// Gets the owned configuration items.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Epbs.IConfigurationItem> OwnedConfigurationItems { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
