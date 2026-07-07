// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionalChainInvolvementFunction.cs" company="Starion Group S.A.">
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

    public partial interface IFunctionalChainInvolvementFunction : Auriga.Fa.IFunctionalChainInvolvement, Auriga.Fa.ISequenceLinkEnd
    {
        IEnumerable<Auriga.Fa.IFunctionalChainInvolvementLink> OutgoingInvolvementLinks { get; }

        IEnumerable<Auriga.Fa.IFunctionalChainInvolvementLink> IncomingInvolvementLinks { get; }

    }
}
