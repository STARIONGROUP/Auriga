// ------------------------------------------------------------------------------------------------
// <copyright file="ISystemAnalysis.cs" company="Starion Group S.A.">
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

namespace Auriga.Ctx
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ISystemAnalysis : Auriga.Cs.IComponentArchitecture
    {
        Auriga.Ctx.ISystemComponentPkg OwnedSystemComponentPkg { get; set; }

        Auriga.Ctx.IMissionPkg OwnedMissionPkg { get; set; }

        Auriga.Ctx.ICapabilityPkg ContainedCapabilityPkg { get; }

        Auriga.Ctx.ISystemFunctionPkg ContainedSystemFunctionPkg { get; }

        Auriga.IContainerList<Auriga.Ctx.IOperationalAnalysisRealization> OwnedOperationalAnalysisRealizations { get; }

        IEnumerable<Auriga.Ctx.IOperationalAnalysisRealization> AllocatedOperationalAnalysisRealizations { get; }

        IEnumerable<Auriga.Oa.IOperationalAnalysis> AllocatedOperationalAnalyses { get; }

        IEnumerable<Auriga.La.ILogicalArchitecture> AllocatingLogicalArchitectures { get; }

    }
}
