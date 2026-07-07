// ------------------------------------------------------------------------------------------------
// <copyright file="IExchangeContainment.cs" company="Starion Group S.A.">
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

namespace Auriga.Fa
{
    /// <summary>
    /// Definition of the <c>ExchangeContainment</c> interface.
    /// </summary>
    public partial interface IExchangeContainment : Auriga.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets or sets the exchange.
        /// </summary>
        Auriga.Fa.IExchangeSpecification Exchange { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        Auriga.Fa.IExchangeLink Link { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
