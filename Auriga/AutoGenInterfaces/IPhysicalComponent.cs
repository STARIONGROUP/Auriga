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
    public partial interface IPhysicalComponent : global::Auriga.Cs.IAbstractPhysicalArtifact, global::Auriga.Cs.IComponent, global::Auriga.Capellacommon.ICapabilityRealizationInvolvedElement, global::Auriga.Cs.IDeployableElement, global::Auriga.Cs.IDeploymentTarget
    {
        global::Auriga.Pa.PhysicalComponentKind? Kind { get; set; }

        global::Auriga.Pa.PhysicalComponentNature? Nature { get; set; }

        global::Auriga.IContainerList<global::Auriga.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks { get; }

        global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalComponent> OwnedPhysicalComponents { get; }

        global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.ILogicalInterfaceRealization> LogicalInterfaceRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalComponent> SubPhysicalComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalComponent> RealizedLogicalComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalFunction> AllocatedPhysicalFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalComponent> DeployedPhysicalComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalComponent> DeployingPhysicalComponents { get; }

    }
}
