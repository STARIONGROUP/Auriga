// ------------------------------------------------------------------------------------------------
// <copyright file="ILogicalArchitecture.cs" company="Starion Group S.A.">
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

namespace Auriga.La
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ILogicalArchitecture : Auriga.Cs.IComponentArchitecture
    {
        Auriga.La.ILogicalComponentPkg OwnedLogicalComponentPkg { get; set; }

        Auriga.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg { get; }

        Auriga.La.ILogicalFunctionPkg ContainedLogicalFunctionPkg { get; }

        Auriga.IContainerList<Auriga.La.ISystemAnalysisRealization> OwnedSystemAnalysisRealizations { get; }

        IEnumerable<Auriga.La.ISystemAnalysisRealization> AllocatedSystemAnalysisRealizations { get; }

        IEnumerable<Auriga.Ctx.ISystemAnalysis> AllocatedSystemAnalyses { get; }

        IEnumerable<Auriga.Pa.IPhysicalArchitecture> AllocatingPhysicalArchitectures { get; }

    }
}
