// ------------------------------------------------------------------------------------------------
// <copyright file="IDeploymentAspect.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DeploymentAspect</c> interface.
    /// </summary>
    public partial interface IDeploymentAspect : Auriga.Model.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned configurations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Pa.Deployment.IDeploymentConfiguration> OwnedConfigurations { get; }

        /// <summary>
        /// Gets the owned deployment aspects.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Pa.Deployment.IDeploymentAspect> OwnedDeploymentAspects { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
