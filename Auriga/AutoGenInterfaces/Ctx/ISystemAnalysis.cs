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

namespace Auriga.Ctx
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>SystemAnalysis</c> interface.
    /// </summary>
    public partial interface ISystemAnalysis : Auriga.Cs.IComponentArchitecture
    {
        /// <summary>
        /// Gets the allocated operational analyses.
        /// </summary>
        IEnumerable<Auriga.Oa.IOperationalAnalysis> AllocatedOperationalAnalyses { get; }

        /// <summary>
        /// Gets the allocated operational analysis realizations.
        /// </summary>
        IEnumerable<Auriga.Ctx.IOperationalAnalysisRealization> AllocatedOperationalAnalysisRealizations { get; }

        /// <summary>
        /// Gets the allocating logical architectures.
        /// </summary>
        IEnumerable<Auriga.La.ILogicalArchitecture> AllocatingLogicalArchitectures { get; }

        /// <summary>
        /// Gets the contained capability pkg.
        /// </summary>
        Auriga.Ctx.ICapabilityPkg ContainedCapabilityPkg { get; }

        /// <summary>
        /// Gets the contained system function pkg.
        /// </summary>
        Auriga.Ctx.ISystemFunctionPkg ContainedSystemFunctionPkg { get; }

        /// <summary>
        /// Gets or sets the owned mission pkg.
        /// </summary>
        Auriga.Ctx.IMissionPkg OwnedMissionPkg { get; set; }

        /// <summary>
        /// Gets the owned operational analysis realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Ctx.IOperationalAnalysisRealization> OwnedOperationalAnalysisRealizations { get; }

        /// <summary>
        /// Gets or sets the owned system component pkg.
        /// </summary>
        Auriga.Ctx.ISystemComponentPkg OwnedSystemComponentPkg { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
