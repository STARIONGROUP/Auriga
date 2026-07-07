// ------------------------------------------------------------------------------------------------
// <copyright file="IExchangeSpecificationRealization.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ExchangeSpecificationRealization</c> interface.
    /// </summary>
    public partial interface IExchangeSpecificationRealization : Auriga.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized exchange specification.
        /// </summary>
        Auriga.Fa.IExchangeSpecification RealizedExchangeSpecification { get; }

        /// <summary>
        /// Gets the realizing exchange specification.
        /// </summary>
        Auriga.Fa.IExchangeSpecification RealizingExchangeSpecification { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
