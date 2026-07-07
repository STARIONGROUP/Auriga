// ------------------------------------------------------------------------------------------------
// <copyright file="IFunctionalExchange.cs" company="Starion Group S.A.">
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
    public partial interface IFunctionalExchange : global::Auriga.Capellacore.INamedElement, global::Auriga.Capellacore.IRelationship, global::Auriga.Capellacore.IInvolvedElement, global::Auriga.Activity.IObjectFlow, global::Auriga.Behavior.IAbstractEvent, global::Auriga.Information.IAbstractEventOperation
    {
        global::System.Collections.Generic.List<global::Auriga.Fa.IFunctionalExchangeSpecification> ExchangeSpecifications { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalChain> InvolvingFunctionalChains { get; }

        global::System.Collections.Generic.List<global::Auriga.Information.IExchangeItem> ExchangedItems { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentExchange> AllocatingComponentExchanges { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> IncomingComponentExchangeFunctionalExchangeRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalExchangeRealization> IncomingFunctionalExchangeRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalExchangeRealization> OutgoingFunctionalExchangeRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IExchangeCategory> Categories { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IFunctionalExchangeRealization> OwnedFunctionalExchangeRealizations { get; }

        global::Auriga.Fa.IFunctionOutputPort SourceFunctionOutputPort { get; }

        global::Auriga.Fa.IFunctionInputPort TargetFunctionInputPort { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalExchange> RealizedFunctionalExchanges { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalExchange> RealizingFunctionalExchanges { get; }

    }
}
