// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalComponent.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalComponent</c> interface.
    /// </summary>
    public partial interface IPhysicalComponent : Auriga.Cs.IAbstractPhysicalArtifact, Auriga.Cs.IComponent, Auriga.Capellacommon.ICapabilityRealizationInvolvedElement, Auriga.Cs.IDeployableElement, Auriga.Cs.IDeploymentTarget
    {
        /// <summary>
        /// Gets the allocated physical functions.
        /// </summary>
        IEnumerable<Auriga.Pa.IPhysicalFunction> AllocatedPhysicalFunctions { get; }

        /// <summary>
        /// Gets the deployed physical components.
        /// </summary>
        IEnumerable<Auriga.Pa.IPhysicalComponent> DeployedPhysicalComponents { get; }

        /// <summary>
        /// Gets the deploying physical components.
        /// </summary>
        IEnumerable<Auriga.Pa.IPhysicalComponent> DeployingPhysicalComponents { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Pa.PhysicalComponentKind? Kind { get; set; }

        /// <summary>
        /// Gets the logical interface realizations.
        /// </summary>
        IEnumerable<Auriga.Pa.ILogicalInterfaceRealization> LogicalInterfaceRealizations { get; }

        /// <summary>
        /// Gets or sets the nature.
        /// </summary>
        Auriga.Pa.PhysicalComponentNature? Nature { get; set; }

        /// <summary>
        /// Gets the owned deployment links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks { get; }

        /// <summary>
        /// Gets the owned physical component pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs { get; }

        /// <summary>
        /// Gets the owned physical components.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Pa.IPhysicalComponent> OwnedPhysicalComponents { get; }

        /// <summary>
        /// Gets the realized logical components.
        /// </summary>
        IEnumerable<Auriga.La.ILogicalComponent> RealizedLogicalComponents { get; }

        /// <summary>
        /// Gets the sub physical components.
        /// </summary>
        IEnumerable<Auriga.Pa.IPhysicalComponent> SubPhysicalComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
