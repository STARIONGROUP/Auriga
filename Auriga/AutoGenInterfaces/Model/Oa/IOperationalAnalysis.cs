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

namespace Auriga.Model.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>OperationalAnalysis</c> interface.
    /// </summary>
    public partial interface IOperationalAnalysis : Auriga.Model.Cs.IBlockArchitecture
    {
        /// <summary>
        /// Gets the allocating system analyses.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ISystemAnalysis> AllocatingSystemAnalyses { get; }

        /// <summary>
        /// Gets the contained operational activity pkg.
        /// </summary>
        Auriga.Model.Oa.IOperationalActivityPkg ContainedOperationalActivityPkg { get; }

        /// <summary>
        /// Gets the contained operational capability pkg.
        /// </summary>
        Auriga.Model.Oa.IOperationalCapabilityPkg ContainedOperationalCapabilityPkg { get; }

        /// <summary>
        /// Gets or sets the owned concept pkg.
        /// </summary>
        Auriga.Model.Oa.IConceptPkg OwnedConceptPkg { get; set; }

        /// <summary>
        /// Gets or sets the owned entity pkg.
        /// </summary>
        Auriga.Model.Oa.IEntityPkg OwnedEntityPkg { get; set; }

        /// <summary>
        /// Gets or sets the owned role pkg.
        /// </summary>
        Auriga.Model.Oa.IRolePkg OwnedRolePkg { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
