// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractDeploymentLink.cs" company="Starion Group S.A.">
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

namespace Auriga.Cs
{
    /// <summary>
    /// Definition of the <c>AbstractDeploymentLink</c> interface.
    /// </summary>
    public partial interface IAbstractDeploymentLink : Auriga.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets or sets the deployed element.
        /// </summary>
        Auriga.Cs.IDeployableElement DeployedElement { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        Auriga.Cs.IDeploymentTarget Location { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
