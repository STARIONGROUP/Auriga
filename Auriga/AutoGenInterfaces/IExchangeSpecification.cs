// ------------------------------------------------------------------------------------------------
// <copyright file="IExchangeSpecification.cs" company="Starion Group S.A.">
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

    public partial interface IExchangeSpecification : Auriga.Capellacore.INamedElement, Auriga.Activity.IActivityExchange
    {
        Auriga.Fa.IExchangeLink ContainingLink { get; }

        Auriga.Fa.IExchangeContainment Link { get; set; }

        IEnumerable<Auriga.Fa.IExchangeSpecificationRealization> OutgoingExchangeSpecificationRealizations { get; }

        IEnumerable<Auriga.Fa.IExchangeSpecificationRealization> IncomingExchangeSpecificationRealizations { get; }

    }
}
