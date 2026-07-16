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

namespace Auriga.Model.Pa.Deployment
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ComponentInstance</c> interface.
    /// </summary>
    public partial interface IComponentInstance : Auriga.Model.Pa.Deployment.IAbstractPhysicalInstance, Auriga.Model.Cs.IDeployableElement, Auriga.Model.Cs.IDeploymentTarget
    {
        /// <summary>
        /// Gets the owned abstract physical instances.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Pa.Deployment.IAbstractPhysicalInstance> OwnedAbstractPhysicalInstances { get; }

        /// <summary>
        /// Gets the owned instance deployment links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Pa.Deployment.IInstanceDeploymentLink> OwnedInstanceDeploymentLinks { get; }

        /// <summary>
        /// Gets the port instances.
        /// </summary>
        IEnumerable<Auriga.Model.Pa.Deployment.IPortInstance> PortInstances { get; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        Auriga.Model.Pa.IPhysicalComponent Type { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
