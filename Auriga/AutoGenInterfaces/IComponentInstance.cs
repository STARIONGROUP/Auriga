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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IComponentInstance : Auriga.Pa.Deployment.IAbstractPhysicalInstance, Auriga.Cs.IDeployableElement, Auriga.Cs.IDeploymentTarget
    {
        IEnumerable<Auriga.Pa.Deployment.IPortInstance> PortInstances { get; }

        Auriga.IContainerList<Auriga.Pa.Deployment.IAbstractPhysicalInstance> OwnedAbstractPhysicalInstances { get; }

        Auriga.IContainerList<Auriga.Pa.Deployment.IInstanceDeploymentLink> OwnedInstanceDeploymentLinks { get; }

        Auriga.Pa.IPhysicalComponent Type { get; set; }

    }
}
