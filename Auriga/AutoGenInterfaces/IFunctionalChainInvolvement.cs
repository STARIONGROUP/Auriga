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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Fa
{
    public partial interface IFunctionalChainInvolvement : global::Auriga.Capellacore.IInvolvement
    {
        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalChainInvolvement> NextFunctionalChainInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalChainInvolvement> PreviousFunctionalChainInvolvements { get; }

        global::Auriga.Capellacore.IInvolvedElement InvolvedElement { get; }

    }
}
