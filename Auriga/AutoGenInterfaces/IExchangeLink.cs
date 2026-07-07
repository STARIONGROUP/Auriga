// ------------------------------------------------------------------------------------------------
// <copyright file="IExchangeLink.cs" company="Starion Group S.A.">
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

namespace Auriga.Fa
{
    public partial interface IExchangeLink : global::Auriga.Capellacore.INamedRelationship
    {
        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IExchangeSpecification> Exchanges { get; }

        global::System.Collections.Generic.List<global::Auriga.Fa.IExchangeContainment> ExchangeContainmentLinks { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IExchangeContainment> OwnedExchangeContainments { get; }

        global::System.Collections.Generic.List<global::Auriga.Fa.IFunctionSpecification> Sources { get; }

        global::System.Collections.Generic.List<global::Auriga.Fa.IFunctionSpecification> Destinations { get; }

    }
}
