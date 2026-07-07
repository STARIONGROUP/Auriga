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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Pa
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IPhysicalComponent : Auriga.Cs.IAbstractPhysicalArtifact, Auriga.Cs.IComponent, Auriga.Capellacommon.ICapabilityRealizationInvolvedElement, Auriga.Cs.IDeployableElement, Auriga.Cs.IDeploymentTarget
    {
        Auriga.Pa.PhysicalComponentKind? Kind { get; set; }

        Auriga.Pa.PhysicalComponentNature? Nature { get; set; }

        Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks { get; }

        Auriga.IContainerList<Auriga.Pa.IPhysicalComponent> OwnedPhysicalComponents { get; }

        Auriga.IContainerList<Auriga.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs { get; }

        IEnumerable<Auriga.Pa.ILogicalInterfaceRealization> LogicalInterfaceRealizations { get; }

        IEnumerable<Auriga.Pa.IPhysicalComponent> SubPhysicalComponents { get; }

        IEnumerable<Auriga.La.ILogicalComponent> RealizedLogicalComponents { get; }

        IEnumerable<Auriga.Pa.IPhysicalFunction> AllocatedPhysicalFunctions { get; }

        IEnumerable<Auriga.Pa.IPhysicalComponent> DeployedPhysicalComponents { get; }

        IEnumerable<Auriga.Pa.IPhysicalComponent> DeployingPhysicalComponents { get; }

    }
}
