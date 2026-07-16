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

namespace Auriga.Model.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Part</c> interface.
    /// </summary>
    public partial interface IPart : Auriga.Model.Information.IAbstractInstance, Auriga.Model.Modellingcore.IInformationsExchanger, Auriga.Model.Cs.IDeployableElement, Auriga.Model.Cs.IDeploymentTarget, Auriga.Model.Cs.IAbstractPathInvolvedElement
    {
        /// <summary>
        /// Gets the deployed parts.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IPart> DeployedParts { get; }

        /// <summary>
        /// Gets the deploying parts.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IPart> DeployingParts { get; }

        /// <summary>
        /// Gets or sets the owned abstract type.
        /// </summary>
        Auriga.Model.Modellingcore.IAbstractType OwnedAbstractType { get; set; }

        /// <summary>
        /// Gets the owned deployment links.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks { get; }

        /// <summary>
        /// Gets the provided interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> ProvidedInterfaces { get; }

        /// <summary>
        /// Gets the required interfaces.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IInterface> RequiredInterfaces { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
