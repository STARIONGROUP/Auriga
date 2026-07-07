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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IFunctionalExchange : Auriga.Capellacore.INamedElement, Auriga.Capellacore.IRelationship, Auriga.Capellacore.IInvolvedElement, Auriga.Activity.IObjectFlow, Auriga.Behavior.IAbstractEvent, Auriga.Information.IAbstractEventOperation
    {
        List<Auriga.Fa.IFunctionalExchangeSpecification> ExchangeSpecifications { get; }

        IEnumerable<Auriga.Fa.IFunctionalChain> InvolvingFunctionalChains { get; }

        List<Auriga.Information.IExchangeItem> ExchangedItems { get; }

        IEnumerable<Auriga.Fa.IComponentExchange> AllocatingComponentExchanges { get; }

        IEnumerable<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> IncomingComponentExchangeFunctionalExchangeRealizations { get; }

        IEnumerable<Auriga.Fa.IFunctionalExchangeRealization> IncomingFunctionalExchangeRealizations { get; }

        IEnumerable<Auriga.Fa.IFunctionalExchangeRealization> OutgoingFunctionalExchangeRealizations { get; }

        IEnumerable<Auriga.Fa.IExchangeCategory> Categories { get; }

        Auriga.IContainerList<Auriga.Fa.IFunctionalExchangeRealization> OwnedFunctionalExchangeRealizations { get; }

        Auriga.Fa.IFunctionOutputPort SourceFunctionOutputPort { get; }

        Auriga.Fa.IFunctionInputPort TargetFunctionInputPort { get; }

        IEnumerable<Auriga.Fa.IFunctionalExchange> RealizedFunctionalExchanges { get; }

        IEnumerable<Auriga.Fa.IFunctionalExchange> RealizingFunctionalExchanges { get; }

    }
}
