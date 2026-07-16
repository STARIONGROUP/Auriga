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

namespace Auriga.Model.La
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>LogicalArchitecture</c> interface.
    /// </summary>
    public partial interface ILogicalArchitecture : Auriga.Model.Cs.IComponentArchitecture
    {
        /// <summary>
        /// Gets the allocated system analyses.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ISystemAnalysis> AllocatedSystemAnalyses { get; }

        /// <summary>
        /// Gets the allocated system analysis realizations.
        /// </summary>
        IEnumerable<Auriga.Model.La.ISystemAnalysisRealization> AllocatedSystemAnalysisRealizations { get; }

        /// <summary>
        /// Gets the allocating physical architectures.
        /// </summary>
        IEnumerable<Auriga.Model.Pa.IPhysicalArchitecture> AllocatingPhysicalArchitectures { get; }

        /// <summary>
        /// Gets the contained capability realization pkg.
        /// </summary>
        Auriga.Model.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg { get; }

        /// <summary>
        /// Gets the contained logical function pkg.
        /// </summary>
        Auriga.Model.La.ILogicalFunctionPkg ContainedLogicalFunctionPkg { get; }

        /// <summary>
        /// Gets or sets the owned logical component pkg.
        /// </summary>
        Auriga.Model.La.ILogicalComponentPkg OwnedLogicalComponentPkg { get; set; }

        /// <summary>
        /// Gets the owned system analysis realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.La.ISystemAnalysisRealization> OwnedSystemAnalysisRealizations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
