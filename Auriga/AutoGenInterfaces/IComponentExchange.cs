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
    public partial interface IComponentExchange : global::Auriga.Behavior.IAbstractEvent, global::Auriga.Information.IAbstractEventOperation, global::Auriga.Capellacore.INamedElement, global::Auriga.Fa.IExchangeSpecification
    {
        global::Auriga.Fa.ComponentExchangeKind? Kind { get; set; }

        bool? Oriented { get; set; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalExchange> AllocatedFunctionalExchanges { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentExchangeRealization> IncomingComponentExchangeRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentExchangeRealization> OutgoingComponentExchangeRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OutgoingComponentExchangeFunctionalExchangeAllocations { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OwnedComponentExchangeFunctionalExchangeAllocations { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations { get; }

        global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchangeEnd> OwnedComponentExchangeEnds { get; }

        global::Auriga.Information.IPort SourcePort { get; }

        global::Auriga.Cs.IPart SourcePart { get; }

        global::Auriga.Information.IPort TargetPort { get; }

        global::Auriga.Cs.IPart TargetPart { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentExchangeCategory> Categories { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalLink> AllocatorPhysicalLinks { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentExchange> RealizedComponentExchanges { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentExchange> RealizingComponentExchanges { get; }

    }
}
