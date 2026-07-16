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

namespace Auriga.Model.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FunctionalExchange</c> interface.
    /// </summary>
    public partial interface IFunctionalExchange : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Capellacore.IRelationship, Auriga.Model.Capellacore.IInvolvedElement, Auriga.Model.Activity.IObjectFlow, Auriga.Model.Behavior.IAbstractEvent, Auriga.Model.Information.IAbstractEventOperation
    {
        /// <summary>
        /// Gets the allocating component exchanges.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentExchange> AllocatingComponentExchanges { get; }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IExchangeCategory> Categories { get; }

        /// <summary>
        /// Gets the exchange specifications.
        /// </summary>
        List<Auriga.Model.Fa.IFunctionalExchangeSpecification> ExchangeSpecifications { get; }

        /// <summary>
        /// Gets the exchanged items.
        /// </summary>
        List<Auriga.Model.Information.IExchangeItem> ExchangedItems { get; }

        /// <summary>
        /// Gets the incoming component exchange functional exchange realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentExchangeFunctionalExchangeAllocation> IncomingComponentExchangeFunctionalExchangeRealizations { get; }

        /// <summary>
        /// Gets the incoming functional exchange realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalExchangeRealization> IncomingFunctionalExchangeRealizations { get; }

        /// <summary>
        /// Gets the involving functional chains.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalChain> InvolvingFunctionalChains { get; }

        /// <summary>
        /// Gets the outgoing functional exchange realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalExchangeRealization> OutgoingFunctionalExchangeRealizations { get; }

        /// <summary>
        /// Gets the owned functional exchange realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalExchangeRealization> OwnedFunctionalExchangeRealizations { get; }

        /// <summary>
        /// Gets the realized functional exchanges.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalExchange> RealizedFunctionalExchanges { get; }

        /// <summary>
        /// Gets the realizing functional exchanges.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalExchange> RealizingFunctionalExchanges { get; }

        /// <summary>
        /// Gets the source function output port.
        /// </summary>
        Auriga.Model.Fa.IFunctionOutputPort SourceFunctionOutputPort { get; }

        /// <summary>
        /// Gets the target function input port.
        /// </summary>
        Auriga.Model.Fa.IFunctionInputPort TargetFunctionInputPort { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
