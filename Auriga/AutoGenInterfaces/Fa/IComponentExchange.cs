// ------------------------------------------------------------------------------------------------
// <copyright file="IComponentExchange.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ComponentExchange</c> interface.
    /// </summary>
    public partial interface IComponentExchange : Auriga.Behavior.IAbstractEvent, Auriga.Information.IAbstractEventOperation, Auriga.Capellacore.INamedElement, Auriga.Fa.IExchangeSpecification
    {
        /// <summary>
        /// Gets the allocated functional exchanges.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalExchange> AllocatedFunctionalExchanges { get; }

        /// <summary>
        /// Gets the allocator physical links.
        /// </summary>
        IEnumerable<Auriga.Cs.IPhysicalLink> AllocatorPhysicalLinks { get; }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentExchangeCategory> Categories { get; }

        /// <summary>
        /// Gets the incoming component exchange realizations.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentExchangeRealization> IncomingComponentExchangeRealizations { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Fa.ComponentExchangeKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the oriented.
        /// </summary>
        bool? Oriented { get; set; }

        /// <summary>
        /// Gets the outgoing component exchange functional exchange allocations.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OutgoingComponentExchangeFunctionalExchangeAllocations { get; }

        /// <summary>
        /// Gets the outgoing component exchange realizations.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentExchangeRealization> OutgoingComponentExchangeRealizations { get; }

        /// <summary>
        /// Gets the owned component exchange ends.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentExchangeEnd> OwnedComponentExchangeEnds { get; }

        /// <summary>
        /// Gets the owned component exchange functional exchange allocations.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OwnedComponentExchangeFunctionalExchangeAllocations { get; }

        /// <summary>
        /// Gets the owned component exchange realizations.
        /// </summary>
        Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations { get; }

        /// <summary>
        /// Gets the realized component exchanges.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentExchange> RealizedComponentExchanges { get; }

        /// <summary>
        /// Gets the realizing component exchanges.
        /// </summary>
        IEnumerable<Auriga.Fa.IComponentExchange> RealizingComponentExchanges { get; }

        /// <summary>
        /// Gets the source part.
        /// </summary>
        Auriga.Cs.IPart SourcePart { get; }

        /// <summary>
        /// Gets the source port.
        /// </summary>
        Auriga.Information.IPort SourcePort { get; }

        /// <summary>
        /// Gets the target part.
        /// </summary>
        Auriga.Cs.IPart TargetPart { get; }

        /// <summary>
        /// Gets the target port.
        /// </summary>
        Auriga.Information.IPort TargetPort { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
