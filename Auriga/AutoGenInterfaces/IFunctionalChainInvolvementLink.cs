// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionalChainInvolvementLink.cs" company="Starion Group S.A.">
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

    public partial interface IFunctionalChainInvolvementLink : Auriga.Fa.IFunctionalChainInvolvement, Auriga.Fa.IReferenceHierarchyContext
    {
        Auriga.Capellacore.IConstraint ExchangeContext { get; set; }

        List<Auriga.Information.IExchangeItem> ExchangedItems { get; }

        Auriga.Fa.IFunctionalChainInvolvementFunction Source { get; set; }

        Auriga.Fa.IFunctionalChainInvolvementFunction Target { get; set; }

    }
}
