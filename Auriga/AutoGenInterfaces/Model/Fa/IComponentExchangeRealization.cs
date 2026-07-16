// ------------------------------------------------------------------------------------------------
// <copyright file="IComponentExchangeRealization.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>ComponentExchangeRealization</c> interface.
    /// </summary>
    public partial interface IComponentExchangeRealization : Auriga.Model.Fa.IExchangeSpecificationRealization
    {
        /// <summary>
        /// Gets the allocated component exchange.
        /// </summary>
        Auriga.Model.Fa.IComponentExchange AllocatedComponentExchange { get; }

        /// <summary>
        /// Gets the allocating component exchange.
        /// </summary>
        Auriga.Model.Fa.IComponentExchange AllocatingComponentExchange { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
