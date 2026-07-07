// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionOutputPort.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>FunctionOutputPort</c> interface.
    /// </summary>
    public partial interface IFunctionOutputPort : Auriga.Fa.IFunctionPort, Auriga.Activity.IOutputPin
    {
        /// <summary>
        /// Gets the outgoing exchange items.
        /// </summary>
        List<Auriga.Information.IExchangeItem> OutgoingExchangeItems { get; }

        /// <summary>
        /// Gets the outgoing functional exchanges.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalExchange> OutgoingFunctionalExchanges { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
