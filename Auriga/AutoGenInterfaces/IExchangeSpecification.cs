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
    public partial interface IExchangeSpecification : global::Auriga.Capellacore.INamedElement, global::Auriga.Activity.IActivityExchange
    {
        global::Auriga.Fa.IExchangeLink ContainingLink { get; }

        global::Auriga.Fa.IExchangeContainment Link { get; set; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IExchangeSpecificationRealization> OutgoingExchangeSpecificationRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IExchangeSpecificationRealization> IncomingExchangeSpecificationRealizations { get; }

    }
}
