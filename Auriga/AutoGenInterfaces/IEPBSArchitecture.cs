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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IEPBSArchitecture : Auriga.Cs.IComponentArchitecture
    {
        Auriga.Epbs.IConfigurationItemPkg OwnedConfigurationItemPkg { get; set; }

        Auriga.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg { get; }

        Auriga.IContainerList<Auriga.Epbs.IPhysicalArchitectureRealization> OwnedPhysicalArchitectureRealizations { get; }

        IEnumerable<Auriga.Epbs.IPhysicalArchitectureRealization> AllocatedPhysicalArchitectureRealizations { get; }

        IEnumerable<Auriga.Pa.IPhysicalArchitecture> AllocatedPhysicalArchitectures { get; }

    }
}
