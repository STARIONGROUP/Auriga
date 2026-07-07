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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IOperationalAnalysis : Auriga.Cs.IBlockArchitecture
    {
        Auriga.Oa.IRolePkg OwnedRolePkg { get; set; }

        Auriga.Oa.IEntityPkg OwnedEntityPkg { get; set; }

        Auriga.Oa.IConceptPkg OwnedConceptPkg { get; set; }

        Auriga.Oa.IOperationalCapabilityPkg ContainedOperationalCapabilityPkg { get; }

        Auriga.Oa.IOperationalActivityPkg ContainedOperationalActivityPkg { get; }

        IEnumerable<Auriga.Ctx.ISystemAnalysis> AllocatingSystemAnalyses { get; }

    }
}
