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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IFunctionInputPort : Auriga.Fa.IFunctionPort, Auriga.Activity.IInputPin
    {
        List<Auriga.Information.IExchangeItem> IncomingExchangeItems { get; }

        IEnumerable<Auriga.Fa.IFunctionalExchange> IncomingFunctionalExchanges { get; }

    }
}
