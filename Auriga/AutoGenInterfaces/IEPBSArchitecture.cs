// ------------------------------------------------------------------------------------------------
// <copyright file="IEPBSArchitecture.cs" company="Starion Group S.A.">
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
    public partial interface IEPBSArchitecture : global::Auriga.Cs.IComponentArchitecture
    {
        global::Auriga.Epbs.IConfigurationItemPkg OwnedConfigurationItemPkg { get; set; }

        global::Auriga.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg { get; }

        global::Auriga.IContainerList<global::Auriga.Epbs.IPhysicalArchitectureRealization> OwnedPhysicalArchitectureRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Epbs.IPhysicalArchitectureRealization> AllocatedPhysicalArchitectureRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalArchitecture> AllocatedPhysicalArchitectures { get; }

    }
}
