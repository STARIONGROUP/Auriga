// ------------------------------------------------------------------------------------------------
// <copyright file="IExchangeItemRealization.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Information
{
    /// <summary>
    /// Definition of the <c>ExchangeItemRealization</c> interface.
    /// </summary>
    public partial interface IExchangeItemRealization : Auriga.Model.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized item.
        /// </summary>
        Auriga.Model.Modellingcore.IAbstractExchangeItem RealizedItem { get; }

        /// <summary>
        /// Gets the realizing operation.
        /// </summary>
        Auriga.Model.Information.IOperation RealizingOperation { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
