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
    public partial interface IFunctionalChainInvolvementLink : global::Auriga.Fa.IFunctionalChainInvolvement, global::Auriga.Fa.IReferenceHierarchyContext
    {
        global::Auriga.Capellacore.IConstraint ExchangeContext { get; set; }

        global::System.Collections.Generic.List<global::Auriga.Information.IExchangeItem> ExchangedItems { get; }

        global::Auriga.Fa.IFunctionalChainInvolvementFunction Source { get; set; }

        global::Auriga.Fa.IFunctionalChainInvolvementFunction Target { get; set; }

    }
}
