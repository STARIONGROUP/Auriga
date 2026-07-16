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

namespace Auriga.Model.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ComponentExchange</c> interface.
    /// </summary>
    public partial interface IComponentExchange : Auriga.Model.Behavior.IAbstractEvent, Auriga.Model.Information.IAbstractEventOperation, Auriga.Model.Capellacore.INamedElement, Auriga.Model.Fa.IExchangeSpecification
    {
        /// <summary>
        /// Gets the allocated functional exchanges.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IFunctionalExchange> AllocatedFunctionalExchanges { get; }

        /// <summary>
        /// Gets the allocator physical links.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IPhysicalLink> AllocatorPhysicalLinks { get; }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentExchangeCategory> Categories { get; }

        /// <summary>
        /// Gets the incoming component exchange realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentExchangeRealization> IncomingComponentExchangeRealizations { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Model.Fa.ComponentExchangeKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the oriented.
        /// </summary>
        bool? Oriented { get; set; }

        /// <summary>
        /// Gets the outgoing component exchange functional exchange allocations.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentExchangeFunctionalExchangeAllocation> OutgoingComponentExchangeFunctionalExchangeAllocations { get; }

        /// <summary>
        /// Gets the outgoing component exchange realizations.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentExchangeRealization> OutgoingComponentExchangeRealizations { get; }

        /// <summary>
        /// Gets the owned component exchange ends.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeEnd> OwnedComponentExchangeEnds { get; }

        /// <summary>
        /// Gets the owned component exchange functional exchange allocations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeFunctionalExchangeAllocation> OwnedComponentExchangeFunctionalExchangeAllocations { get; }

        /// <summary>
        /// Gets the owned component exchange realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations { get; }

        /// <summary>
        /// Gets the realized component exchanges.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentExchange> RealizedComponentExchanges { get; }

        /// <summary>
        /// Gets the realizing component exchanges.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IComponentExchange> RealizingComponentExchanges { get; }

        /// <summary>
        /// Gets the source part.
        /// </summary>
        Auriga.Model.Cs.IPart SourcePart { get; }

        /// <summary>
        /// Gets the source port.
        /// </summary>
        Auriga.Model.Information.IPort SourcePort { get; }

        /// <summary>
        /// Gets the target part.
        /// </summary>
        Auriga.Model.Cs.IPart TargetPart { get; }

        /// <summary>
        /// Gets the target port.
        /// </summary>
        Auriga.Model.Information.IPort TargetPort { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
