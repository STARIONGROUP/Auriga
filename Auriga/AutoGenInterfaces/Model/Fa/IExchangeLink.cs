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

namespace Auriga.Model.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ExchangeLink</c> interface.
    /// </summary>
    public partial interface IExchangeLink : Auriga.Model.Capellacore.INamedRelationship
    {
        /// <summary>
        /// Gets the destinations.
        /// </summary>
        List<Auriga.Model.Fa.IFunctionSpecification> Destinations { get; }

        /// <summary>
        /// Gets the exchange containment links.
        /// </summary>
        List<Auriga.Model.Fa.IExchangeContainment> ExchangeContainmentLinks { get; }

        /// <summary>
        /// Gets the exchanges.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IExchangeSpecification> Exchanges { get; }

        /// <summary>
        /// Gets the owned exchange containments.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IExchangeContainment> OwnedExchangeContainments { get; }

        /// <summary>
        /// Gets the sources.
        /// </summary>
        List<Auriga.Model.Fa.IFunctionSpecification> Sources { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
