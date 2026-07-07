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
    public partial interface ISystemAnalysis : global::Auriga.Cs.IComponentArchitecture
    {
        global::Auriga.Ctx.ISystemComponentPkg OwnedSystemComponentPkg { get; set; }

        global::Auriga.Ctx.IMissionPkg OwnedMissionPkg { get; set; }

        global::Auriga.Ctx.ICapabilityPkg ContainedCapabilityPkg { get; }

        global::Auriga.Ctx.ISystemFunctionPkg ContainedSystemFunctionPkg { get; }

        global::Auriga.IContainerList<global::Auriga.Ctx.IOperationalAnalysisRealization> OwnedOperationalAnalysisRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.IOperationalAnalysisRealization> AllocatedOperationalAnalysisRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IOperationalAnalysis> AllocatedOperationalAnalyses { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalArchitecture> AllocatingLogicalArchitectures { get; }

    }
}
