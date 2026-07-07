// ------------------------------------------------------------------------------------------------
// <copyright file="IOperationalAnalysis.cs" company="Starion Group S.A.">
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
    public partial interface IOperationalAnalysis : global::Auriga.Cs.IBlockArchitecture
    {
        global::Auriga.Oa.IRolePkg OwnedRolePkg { get; set; }

        global::Auriga.Oa.IEntityPkg OwnedEntityPkg { get; set; }

        global::Auriga.Oa.IConceptPkg OwnedConceptPkg { get; set; }

        global::Auriga.Oa.IOperationalCapabilityPkg ContainedOperationalCapabilityPkg { get; }

        global::Auriga.Oa.IOperationalActivityPkg ContainedOperationalActivityPkg { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemAnalysis> AllocatingSystemAnalyses { get; }

    }
}
