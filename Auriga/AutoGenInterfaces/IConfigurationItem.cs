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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Epbs
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IConfigurationItem : Auriga.Capellacommon.ICapabilityRealizationInvolvedElement, Auriga.Cs.IComponent
    {
        string ItemIdentifier { get; set; }

        Auriga.Epbs.ConfigurationItemKind? Kind { get; set; }

        Auriga.IContainerList<Auriga.Epbs.IConfigurationItem> OwnedConfigurationItems { get; }

        Auriga.IContainerList<Auriga.Epbs.IConfigurationItemPkg> OwnedConfigurationItemPkgs { get; }

        Auriga.IContainerList<Auriga.Epbs.IPhysicalArtifactRealization> OwnedPhysicalArtifactRealizations { get; }

        IEnumerable<Auriga.Cs.IAbstractPhysicalArtifact> AllocatedPhysicalArtifacts { get; }

    }
}
