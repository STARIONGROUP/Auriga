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

namespace Auriga.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FunctionalExchange</c> interface.
    /// </summary>
    public partial interface IFunctionalExchange : Auriga.Capellacore.INamedElement, Auriga.Capellacore.IRelationship, Auriga.Capellacore.IInvolvedElement, Auriga.Activity.IObjectFlow, Auriga.Behavior.IAbstractEvent, Auriga.Information.IAbstractEventOperation
    {
        /// <summary>
        /// Gets the allocating component exchanges.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentExchange> AllocatingComponentExchanges { get; }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        IEnumerable<Auriga.Fa.IExchangeCategory> Categories { get; }

        /// <summary>
        /// Gets the exchange specifications.
        /// </summary>
        List<Auriga.Fa.IFunctionalExchangeSpecification> ExchangeSpecifications { get; }

        /// <summary>
        /// Gets the exchanged items.
        /// </summary>
        List<Auriga.Information.IExchangeItem> ExchangedItems { get; }

        /// <summary>
        /// Gets the incoming component exchange functional exchange realizations.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> IncomingComponentExchangeFunctionalExchangeRealizations { get; }

        /// <summary>
        /// Gets the incoming functional exchange realizations.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalExchangeRealization> IncomingFunctionalExchangeRealizations { get; }

        /// <summary>
        /// Gets the involving functional chains.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalChain> InvolvingFunctionalChains { get; }

        /// <summary>
        /// Gets the outgoing functional exchange realizations.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalExchangeRealization> OutgoingFunctionalExchangeRealizations { get; }

        /// <summary>
        /// Gets the owned functional exchange realizations.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IFunctionalExchangeRealization> OwnedFunctionalExchangeRealizations { get; }

        /// <summary>
        /// Gets the realized functional exchanges.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalExchange> RealizedFunctionalExchanges { get; }

        /// <summary>
        /// Gets the realizing functional exchanges.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalExchange> RealizingFunctionalExchanges { get; }

        /// <summary>
        /// Gets the source function output port.
        /// </summary>
        Auriga.Fa.IFunctionOutputPort SourceFunctionOutputPort { get; }

        /// <summary>
        /// Gets the target function input port.
        /// </summary>
        Auriga.Fa.IFunctionInputPort TargetFunctionInputPort { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
