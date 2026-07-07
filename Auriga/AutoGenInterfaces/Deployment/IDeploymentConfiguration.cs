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

namespace Auriga.Pa.Deployment
{
    /// <summary>
    /// Definition of the <c>DeploymentConfiguration</c> interface.
    /// </summary>
    public partial interface IDeploymentConfiguration : Auriga.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the owned deployment links.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks { get; }

        /// <summary>
        /// Gets the owned physical instances.
        /// </summary>
        Auriga.IContainerList<Auriga.Pa.Deployment.IAbstractPhysicalInstance> OwnedPhysicalInstances { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
