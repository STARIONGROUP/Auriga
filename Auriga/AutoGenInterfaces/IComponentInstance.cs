// ------------------------------------------------------------------------------------------------
// <copyright file="IComponentInstance.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa.Deployment
{
    public partial interface IComponentInstance : global::Auriga.Pa.Deployment.IAbstractPhysicalInstance, global::Auriga.Cs.IDeployableElement, global::Auriga.Cs.IDeploymentTarget
    {
        global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.Deployment.IPortInstance> PortInstances { get; }

        global::Auriga.IContainerList<global::Auriga.Pa.Deployment.IAbstractPhysicalInstance> OwnedAbstractPhysicalInstances { get; }

        global::Auriga.IContainerList<global::Auriga.Pa.Deployment.IInstanceDeploymentLink> OwnedInstanceDeploymentLinks { get; }

        global::Auriga.Pa.IPhysicalComponent Type { get; set; }

    }
}
