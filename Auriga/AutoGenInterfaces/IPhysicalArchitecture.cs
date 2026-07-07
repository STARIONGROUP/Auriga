// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalArchitecture.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa
{
    public partial interface IPhysicalArchitecture : global::Auriga.Cs.IComponentArchitecture
    {
        global::Auriga.Pa.IPhysicalComponentPkg OwnedPhysicalComponentPkg { get; set; }

        global::Auriga.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg { get; }

        global::Auriga.Pa.IPhysicalFunctionPkg ContainedPhysicalFunctionPkg { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IAbstractDeploymentLink> OwnedDeployments { get; }

        global::Auriga.IContainerList<global::Auriga.Pa.ILogicalArchitectureRealization> OwnedLogicalArchitectureRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.ILogicalArchitectureRealization> AllocatedLogicalArchitectureRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalArchitecture> AllocatedLogicalArchitectures { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Epbs.IEPBSArchitecture> AllocatingEpbsArchitectures { get; }

    }
}
