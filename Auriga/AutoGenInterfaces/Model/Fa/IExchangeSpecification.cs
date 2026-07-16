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

namespace Auriga.Model.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ExchangeSpecification</c> interface.
    /// </summary>
    public partial interface IExchangeSpecification : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Activity.IActivityExchange
    {
        /// <summary>
        /// Gets the containing link.
        /// </summary>
        Auriga.Model.Fa.IExchangeLink ContainingLink { get; }

        /// <summary>
        /// Gets the incoming exchange specification realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IExchangeSpecificationRealization> IncomingExchangeSpecificationRealizations { get; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        Auriga.Model.Fa.IExchangeContainment Link { get; set; }

        /// <summary>
        /// Gets the outgoing exchange specification realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IExchangeSpecificationRealization> OutgoingExchangeSpecificationRealizations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
