// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionInputPort.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FunctionInputPort</c> interface.
    /// </summary>
    public partial interface IFunctionInputPort : Auriga.Fa.IFunctionPort, Auriga.Activity.IInputPin
    {
        /// <summary>
        /// Gets the incoming exchange items.
        /// </summary>
        List<Auriga.Information.IExchangeItem> IncomingExchangeItems { get; }

        /// <summary>
        /// Gets the incoming functional exchanges.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalExchange> IncomingFunctionalExchanges { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
