// ------------------------------------------------------------------------------------------------
// <copyright file="IDeploymentTarget.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>DeploymentTarget</c> interface.
    /// </summary>
    public partial interface IDeploymentTarget : Auriga.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the deployment links.
        /// </summary>
        IEnumerable<Auriga.Cs.IAbstractDeploymentLink> DeploymentLinks { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
