// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalArchitecture.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Pa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalArchitecture</c> interface.
    /// </summary>
    public partial interface IPhysicalArchitecture : Auriga.Model.Cs.IComponentArchitecture
    {
        /// <summary>
        /// Gets the allocated logical architecture realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Pa.ILogicalArchitectureRealization> AllocatedLogicalArchitectureRealizations { get; }

        /// <summary>
        /// Gets the allocated logical architectures.
        /// </summary>
        IEnumerable<Auriga.Model.La.ILogicalArchitecture> AllocatedLogicalArchitectures { get; }

        /// <summary>
        /// Gets the allocating epbs architectures.
        /// </summary>
        IEnumerable<Auriga.Model.Epbs.IEPBSArchitecture> AllocatingEpbsArchitectures { get; }

        /// <summary>
        /// Gets the contained capability realization pkg.
        /// </summary>
        Auriga.Model.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg { get; }

        /// <summary>
        /// Gets the contained physical function pkg.
        /// </summary>
        Auriga.Model.Pa.IPhysicalFunctionPkg ContainedPhysicalFunctionPkg { get; }

        /// <summary>
        /// Gets the owned deployments.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IAbstractDeploymentLink> OwnedDeployments { get; }

        /// <summary>
        /// Gets the owned logical architecture realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Pa.ILogicalArchitectureRealization> OwnedLogicalArchitectureRealizations { get; }

        /// <summary>
        /// Gets or sets the owned physical component pkg.
        /// </summary>
        Auriga.Model.Pa.IPhysicalComponentPkg OwnedPhysicalComponentPkg { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
