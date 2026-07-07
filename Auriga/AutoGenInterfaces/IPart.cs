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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IPart : Auriga.Information.IAbstractInstance, Auriga.Modellingcore.IInformationsExchanger, Auriga.Cs.IDeployableElement, Auriga.Cs.IDeploymentTarget, Auriga.Cs.IAbstractPathInvolvedElement
    {
        IEnumerable<Auriga.Cs.IInterface> ProvidedInterfaces { get; }

        IEnumerable<Auriga.Cs.IInterface> RequiredInterfaces { get; }

        Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks { get; }

        IEnumerable<Auriga.Cs.IPart> DeployedParts { get; }

        IEnumerable<Auriga.Cs.IPart> DeployingParts { get; }

        Auriga.Modellingcore.IAbstractType OwnedAbstractType { get; set; }

    }
}
