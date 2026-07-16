// ------------------------------------------------------------------------------------------------
// <copyright file="IEPBSArchitecture.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Epbs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>EPBSArchitecture</c> interface.
    /// </summary>
    public partial interface IEPBSArchitecture : Auriga.Model.Cs.IComponentArchitecture
    {
        /// <summary>
        /// Gets the allocated physical architecture realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Epbs.IPhysicalArchitectureRealization> AllocatedPhysicalArchitectureRealizations { get; }

        /// <summary>
        /// Gets the allocated physical architectures.
        /// </summary>
        IEnumerable<Auriga.Model.Pa.IPhysicalArchitecture> AllocatedPhysicalArchitectures { get; }

        /// <summary>
        /// Gets the contained capability realization pkg.
        /// </summary>
        Auriga.Model.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg { get; }

        /// <summary>
        /// Gets or sets the owned configuration item pkg.
        /// </summary>
        Auriga.Model.Epbs.IConfigurationItemPkg OwnedConfigurationItemPkg { get; set; }

        /// <summary>
        /// Gets the owned physical architecture realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Epbs.IPhysicalArchitectureRealization> OwnedPhysicalArchitectureRealizations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
