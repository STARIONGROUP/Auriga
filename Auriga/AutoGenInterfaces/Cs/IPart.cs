// ------------------------------------------------------------------------------------------------
// <copyright file="IPart.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Part</c> interface.
    /// </summary>
    public partial interface IPart : Auriga.Information.IAbstractInstance, Auriga.Modellingcore.IInformationsExchanger, Auriga.Cs.IDeployableElement, Auriga.Cs.IDeploymentTarget, Auriga.Cs.IAbstractPathInvolvedElement
    {
        /// <summary>
        /// Gets the deployed parts.
        /// </summary>
        IEnumerable<Auriga.Cs.IPart> DeployedParts { get; }

        /// <summary>
        /// Gets the deploying parts.
        /// </summary>
        IEnumerable<Auriga.Cs.IPart> DeployingParts { get; }

        /// <summary>
        /// Gets or sets the owned abstract type.
        /// </summary>
        Auriga.Modellingcore.IAbstractType OwnedAbstractType { get; set; }

        /// <summary>
        /// Gets the owned deployment links.
        /// </summary>
        Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks { get; }

        /// <summary>
        /// Gets the provided interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> ProvidedInterfaces { get; }

        /// <summary>
        /// Gets the required interfaces.
        /// </summary>
        IEnumerable<Auriga.Cs.IInterface> RequiredInterfaces { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
