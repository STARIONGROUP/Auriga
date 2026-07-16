// ------------------------------------------------------------------------------------------------
// <copyright file="IOperationalCapabilityPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Oa
{
    /// <summary>
    /// Definition of the <c>OperationalCapabilityPkg</c> interface.
    /// </summary>
    public partial interface IOperationalCapabilityPkg : Auriga.Model.Capellacommon.IAbstractCapabilityPkg
    {
        /// <summary>
        /// Gets the owned capability configurations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Oa.ICapabilityConfiguration> OwnedCapabilityConfigurations { get; }

        /// <summary>
        /// Gets the owned concept compliances.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Oa.IConceptCompliance> OwnedConceptCompliances { get; }

        /// <summary>
        /// Gets the owned operational capabilities.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Oa.IOperationalCapability> OwnedOperationalCapabilities { get; }

        /// <summary>
        /// Gets the owned operational capability pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Oa.IOperationalCapabilityPkg> OwnedOperationalCapabilityPkgs { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
