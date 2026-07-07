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
    public partial interface IPart : global::Auriga.Information.IAbstractInstance, global::Auriga.Modellingcore.IInformationsExchanger, global::Auriga.Cs.IDeployableElement, global::Auriga.Cs.IDeploymentTarget, global::Auriga.Cs.IAbstractPathInvolvedElement
    {
        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> ProvidedInterfaces { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> RequiredInterfaces { get; }

        global::Auriga.IContainerList<global::Auriga.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPart> DeployedParts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPart> DeployingParts { get; }

        global::Auriga.Modellingcore.IAbstractType OwnedAbstractType { get; set; }

    }
}
