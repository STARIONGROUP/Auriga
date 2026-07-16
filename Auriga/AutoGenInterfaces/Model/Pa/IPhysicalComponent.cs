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

namespace Auriga.Model.Pa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalComponent</c> interface.
    /// </summary>
    public partial interface IPhysicalComponent : Auriga.Model.Cs.IAbstractPhysicalArtifact, Auriga.Model.Cs.IComponent, Auriga.Model.Capellacommon.ICapabilityRealizationInvolvedElement, Auriga.Model.Cs.IDeployableElement, Auriga.Model.Cs.IDeploymentTarget
    {
        /// <summary>
        /// Gets the allocated physical functions.
        /// </summary>
        IEnumerable<Auriga.Model.Pa.IPhysicalFunction> AllocatedPhysicalFunctions { get; }

        /// <summary>
        /// Gets the deployed physical components.
        /// </summary>
        IEnumerable<Auriga.Model.Pa.IPhysicalComponent> DeployedPhysicalComponents { get; }

        /// <summary>
        /// Gets the deploying physical components.
        /// </summary>
        IEnumerable<Auriga.Model.Pa.IPhysicalComponent> DeployingPhysicalComponents { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Model.Pa.PhysicalComponentKind? Kind { get; set; }

        /// <summary>
        /// Gets the logical interface realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Pa.ILogicalInterfaceRealization> LogicalInterfaceRealizations { get; }

        /// <summary>
        /// Gets or sets the nature.
        /// </summary>
        Auriga.Model.Pa.PhysicalComponentNature? Nature { get; set; }

        /// <summary>
        /// Gets the owned deployment links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks { get; }

        /// <summary>
        /// Gets the owned physical component pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs { get; }

        /// <summary>
        /// Gets the owned physical components.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Pa.IPhysicalComponent> OwnedPhysicalComponents { get; }

        /// <summary>
        /// Gets the realized logical components.
        /// </summary>
        IEnumerable<Auriga.Model.La.ILogicalComponent> RealizedLogicalComponents { get; }

        /// <summary>
        /// Gets the sub physical components.
        /// </summary>
        IEnumerable<Auriga.Model.Pa.IPhysicalComponent> SubPhysicalComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
