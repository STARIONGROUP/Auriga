// ------------------------------------------------------------------------------------------------
// <copyright file="IComponentExchangeFunctionalExchangeAllocation.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ComponentExchangeFunctionalExchangeAllocation</c> interface.
    /// </summary>
    public partial interface IComponentExchangeFunctionalExchangeAllocation : Auriga.Model.Fa.IAbstractFunctionAllocation
    {
        /// <summary>
        /// Gets the allocated functional exchange.
        /// </summary>
        Auriga.Model.Fa.IFunctionalExchange AllocatedFunctionalExchange { get; }

        /// <summary>
        /// Gets the allocating component exchange.
        /// </summary>
        Auriga.Model.Fa.IComponentExchange AllocatingComponentExchange { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
