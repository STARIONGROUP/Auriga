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
    using System.Collections.Generic;

    public partial interface IAbstractInformationFlow : Auriga.Modellingcore.IAbstractNamedElement, Auriga.Modellingcore.IAbstractRelationship
    {
        List<Auriga.Modellingcore.IAbstractRelationship> Realizations { get; }

        List<Auriga.Modellingcore.IAbstractExchangeItem> ConvoyedInformations { get; }

        Auriga.Modellingcore.IInformationsExchanger Source { get; set; }

        Auriga.Modellingcore.IInformationsExchanger Target { get; set; }

    }
}
