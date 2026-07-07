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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IPhysicalArchitecture : Auriga.Cs.IComponentArchitecture
    {
        Auriga.Pa.IPhysicalComponentPkg OwnedPhysicalComponentPkg { get; set; }

        Auriga.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg { get; }

        Auriga.Pa.IPhysicalFunctionPkg ContainedPhysicalFunctionPkg { get; }

        Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeployments { get; }

        Auriga.IContainerList<Auriga.Pa.ILogicalArchitectureRealization> OwnedLogicalArchitectureRealizations { get; }

        IEnumerable<Auriga.Pa.ILogicalArchitectureRealization> AllocatedLogicalArchitectureRealizations { get; }

        IEnumerable<Auriga.La.ILogicalArchitecture> AllocatedLogicalArchitectures { get; }

        IEnumerable<Auriga.Epbs.IEPBSArchitecture> AllocatingEpbsArchitectures { get; }

    }
}
