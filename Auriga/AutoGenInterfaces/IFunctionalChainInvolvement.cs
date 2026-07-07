// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionalChainInvolvement.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>FunctionalChainInvolvement</c> interface.
    /// </summary>
    public partial interface IFunctionalChainInvolvement : Auriga.Capellacore.IInvolvement
    {
        /// <summary>
        /// Gets the involved element.
        /// </summary>
        Auriga.Capellacore.IInvolvedElement InvolvedElement { get; }

        /// <summary>
        /// Gets the next functional chain involvements.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalChainInvolvement> NextFunctionalChainInvolvements { get; }

        /// <summary>
        /// Gets the previous functional chain involvements.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalChainInvolvement> PreviousFunctionalChainInvolvements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
