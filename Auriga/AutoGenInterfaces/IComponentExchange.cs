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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IComponentExchange : Auriga.Behavior.IAbstractEvent, Auriga.Information.IAbstractEventOperation, Auriga.Capellacore.INamedElement, Auriga.Fa.IExchangeSpecification
    {
        Auriga.Fa.ComponentExchangeKind? Kind { get; set; }

        bool? Oriented { get; set; }

        IEnumerable<Auriga.Fa.IFunctionalExchange> AllocatedFunctionalExchanges { get; }

        IEnumerable<Auriga.Fa.IComponentExchangeRealization> IncomingComponentExchangeRealizations { get; }

        IEnumerable<Auriga.Fa.IComponentExchangeRealization> OutgoingComponentExchangeRealizations { get; }

        IEnumerable<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OutgoingComponentExchangeFunctionalExchangeAllocations { get; }

        Auriga.IContainerList<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OwnedComponentExchangeFunctionalExchangeAllocations { get; }

        Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations { get; }

        Auriga.IContainerList<Auriga.Fa.IComponentExchangeEnd> OwnedComponentExchangeEnds { get; }

        Auriga.Information.IPort SourcePort { get; }

        Auriga.Cs.IPart SourcePart { get; }

        Auriga.Information.IPort TargetPort { get; }

        Auriga.Cs.IPart TargetPart { get; }

        IEnumerable<Auriga.Fa.IComponentExchangeCategory> Categories { get; }

        IEnumerable<Auriga.Cs.IPhysicalLink> AllocatorPhysicalLinks { get; }

        IEnumerable<Auriga.Fa.IComponentExchange> RealizedComponentExchanges { get; }

        IEnumerable<Auriga.Fa.IComponentExchange> RealizingComponentExchanges { get; }

    }
}
