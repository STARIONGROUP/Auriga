// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionalExchangeRealization.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>FunctionalExchangeRealization</c> interface.
    /// </summary>
    public partial interface IFunctionalExchangeRealization : Auriga.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized functional exchange.
        /// </summary>
        Auriga.Fa.IFunctionalExchange RealizedFunctionalExchange { get; }

        /// <summary>
        /// Gets the realizing functional exchange.
        /// </summary>
        Auriga.Fa.IFunctionalExchange RealizingFunctionalExchange { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
