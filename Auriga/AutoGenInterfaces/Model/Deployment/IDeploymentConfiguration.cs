// ------------------------------------------------------------------------------------------------
// <copyright file="IDeploymentConfiguration.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>DeploymentConfiguration</c> interface.
    /// </summary>
    public partial interface IDeploymentConfiguration : Auriga.Model.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the owned deployment links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks { get; }

        /// <summary>
        /// Gets the owned physical instances.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Pa.Deployment.IAbstractPhysicalInstance> OwnedPhysicalInstances { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
