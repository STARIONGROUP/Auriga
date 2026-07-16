// ------------------------------------------------------------------------------------------------
// <copyright file="ISystemEngineering.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Capellamodeller
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>SystemEngineering</c> interface.
    /// </summary>
    public partial interface ISystemEngineering : Auriga.Model.Capellacore.IAbstractModellingStructure, Auriga.Model.Capellamodeller.IModelRoot
    {
        /// <summary>
        /// Gets the contained e p b s architectures.
        /// </summary>
        IEnumerable<Auriga.Model.Epbs.IEPBSArchitecture> ContainedEPBSArchitectures { get; }

        /// <summary>
        /// Gets the contained logical architectures.
        /// </summary>
        IEnumerable<Auriga.Model.La.ILogicalArchitecture> ContainedLogicalArchitectures { get; }

        /// <summary>
        /// Gets the contained operational analysis.
        /// </summary>
        IEnumerable<Auriga.Model.Oa.IOperationalAnalysis> ContainedOperationalAnalysis { get; }

        /// <summary>
        /// Gets the contained physical architectures.
        /// </summary>
        IEnumerable<Auriga.Model.Pa.IPhysicalArchitecture> ContainedPhysicalArchitectures { get; }

        /// <summary>
        /// Gets the contained shared pkgs.
        /// </summary>
        IEnumerable<Auriga.Model.Sharedmodel.ISharedPkg> ContainedSharedPkgs { get; }

        /// <summary>
        /// Gets the contained system analysis.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ISystemAnalysis> ContainedSystemAnalysis { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
