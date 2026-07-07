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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Oa
{
    public partial interface IOperationalCapabilityPkg : global::Auriga.Capellacommon.IAbstractCapabilityPkg
    {
        global::Auriga.IContainerList<global::Auriga.Oa.IOperationalCapability> OwnedOperationalCapabilities { get; }

        global::Auriga.IContainerList<global::Auriga.Oa.IOperationalCapabilityPkg> OwnedOperationalCapabilityPkgs { get; }

        global::Auriga.IContainerList<global::Auriga.Oa.ICapabilityConfiguration> OwnedCapabilityConfigurations { get; }

        global::Auriga.IContainerList<global::Auriga.Oa.IConceptCompliance> OwnedConceptCompliances { get; }

    }
}
