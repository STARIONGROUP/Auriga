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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IExchangeLink : Auriga.Capellacore.INamedRelationship
    {
        IEnumerable<Auriga.Fa.IExchangeSpecification> Exchanges { get; }

        List<Auriga.Fa.IExchangeContainment> ExchangeContainmentLinks { get; }

        Auriga.IContainerList<Auriga.Fa.IExchangeContainment> OwnedExchangeContainments { get; }

        List<Auriga.Fa.IFunctionSpecification> Sources { get; }

        List<Auriga.Fa.IFunctionSpecification> Destinations { get; }

    }
}
