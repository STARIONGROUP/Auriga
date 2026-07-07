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
    public partial interface IOperationalCapabilityPkg : Auriga.Capellacommon.IAbstractCapabilityPkg
    {
        Auriga.IContainerList<Auriga.Oa.IOperationalCapability> OwnedOperationalCapabilities { get; }

        Auriga.IContainerList<Auriga.Oa.IOperationalCapabilityPkg> OwnedOperationalCapabilityPkgs { get; }

        Auriga.IContainerList<Auriga.Oa.ICapabilityConfiguration> OwnedCapabilityConfigurations { get; }

        Auriga.IContainerList<Auriga.Oa.IConceptCompliance> OwnedConceptCompliances { get; }

    }
}
