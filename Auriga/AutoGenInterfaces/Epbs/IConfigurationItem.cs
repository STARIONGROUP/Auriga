// ------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationItem.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ConfigurationItem</c> interface.
    /// </summary>
    public partial interface IConfigurationItem : Auriga.Capellacommon.ICapabilityRealizationInvolvedElement, Auriga.Cs.IComponent
    {
        /// <summary>
        /// Gets the allocated physical artifacts.
        /// </summary>
        IEnumerable<Auriga.Cs.IAbstractPhysicalArtifact> AllocatedPhysicalArtifacts { get; }

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        string ItemIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Epbs.ConfigurationItemKind? Kind { get; set; }

        /// <summary>
        /// Gets the owned configuration item pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Epbs.IConfigurationItemPkg> OwnedConfigurationItemPkgs { get; }

        /// <summary>
        /// Gets the owned configuration items.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Epbs.IConfigurationItem> OwnedConfigurationItems { get; }

        /// <summary>
        /// Gets the owned physical artifact realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Epbs.IPhysicalArtifactRealization> OwnedPhysicalArtifactRealizations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
