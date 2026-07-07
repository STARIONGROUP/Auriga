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
    public partial interface ILogicalArchitecture : global::Auriga.Cs.IComponentArchitecture
    {
        global::Auriga.La.ILogicalComponentPkg OwnedLogicalComponentPkg { get; set; }

        global::Auriga.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg { get; }

        global::Auriga.La.ILogicalFunctionPkg ContainedLogicalFunctionPkg { get; }

        global::Auriga.IContainerList<global::Auriga.La.ISystemAnalysisRealization> OwnedSystemAnalysisRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ISystemAnalysisRealization> AllocatedSystemAnalysisRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemAnalysis> AllocatedSystemAnalyses { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalArchitecture> AllocatingPhysicalArchitectures { get; }

    }
}
