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

namespace Auriga.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FunctionalChainInvolvementFunction</c> interface.
    /// </summary>
    public partial interface IFunctionalChainInvolvementFunction : Auriga.Fa.IFunctionalChainInvolvement, Auriga.Fa.ISequenceLinkEnd
    {
        /// <summary>
        /// Gets the incoming involvement links.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalChainInvolvementLink> IncomingInvolvementLinks { get; }

        /// <summary>
        /// Gets the outgoing involvement links.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalChainInvolvementLink> OutgoingInvolvementLinks { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
