// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractInformationFlow.cs" company="Starion Group S.A.">
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

namespace Auriga.Modellingcore
{
    public partial interface IAbstractInformationFlow : global::Auriga.Modellingcore.IAbstractNamedElement, global::Auriga.Modellingcore.IAbstractRelationship
    {
        global::System.Collections.Generic.List<global::Auriga.Modellingcore.IAbstractRelationship> Realizations { get; }

        global::System.Collections.Generic.List<global::Auriga.Modellingcore.IAbstractExchangeItem> ConvoyedInformations { get; }

        global::Auriga.Modellingcore.IInformationsExchanger Source { get; set; }

        global::Auriga.Modellingcore.IInformationsExchanger Target { get; set; }

    }
}
