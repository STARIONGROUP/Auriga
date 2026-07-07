// ------------------------------------------------------------------------------------------------
// <copyright file="FunctionInputPort.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>FunctionInputPort</c> class.
    /// </summary>
    public partial class FunctionInputPort : Auriga.AurigaElement, Auriga.Fa.IFunctionInputPort
    {
        /// <summary>
        /// Gets or sets the abstract type.
        /// </summary>
        public Auriga.Modellingcore.IAbstractType AbstractType { get; set; }

        /// <summary>
        /// Gets the abstract typed elements.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Modellingcore.IAbstractTypedElement>();

        /// <summary>
        /// Gets the allocator component ports.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentPort> AllocatorComponentPorts => Enumerable.Empty<Auriga.Fa.IComponentPort>();

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the in activity partition.
        /// </summary>
        public Auriga.Activity.IActivityPartition InActivityPartition => default;

        /// <summary>
        /// Gets the in interruptible region.
        /// </summary>
        public Auriga.Activity.IInterruptibleActivityRegion InInterruptibleRegion => default;

        /// <summary>
        /// Gets the in state.
        /// </summary>
        public List<Auriga.Modellingcore.IIState> InState { get; } = new List<Auriga.Modellingcore.IIState>();

        /// <summary>
        /// Gets the in structured node.
        /// </summary>
        public Auriga.Activity.IInterruptibleActivityRegion InStructuredNode => default;

        /// <summary>
        /// Gets the incoming.
        /// </summary>
        public IEnumerable<Auriga.Activity.IActivityEdge> Incoming => Enumerable.Empty<Auriga.Activity.IActivityEdge>();

        /// <summary>
        /// Gets the incoming exchange items.
        /// </summary>
        public List<Auriga.Information.IExchangeItem> IncomingExchangeItems { get; } = new List<Auriga.Information.IExchangeItem>();

        /// <summary>
        /// Gets the incoming functional exchanges.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalExchange> IncomingFunctionalExchanges => Enumerable.Empty<Auriga.Fa.IFunctionalExchange>();

        /// <summary>
        /// Gets the incoming port allocations.
        /// </summary>
        public IEnumerable<Auriga.Information.IPortAllocation> IncomingPortAllocations => Enumerable.Empty<Auriga.Information.IPortAllocation>();

        /// <summary>
        /// Gets the incoming port realizations.
        /// </summary>
        public IEnumerable<Auriga.Information.IPortRealization> IncomingPortRealizations => Enumerable.Empty<Auriga.Information.IPortRealization>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets or sets the input evaluation action.
        /// </summary>
        public Auriga.Activity.IAbstractAction InputEvaluationAction { get; set; }

        /// <summary>
        /// Gets or sets the is control.
        /// </summary>
        public bool? IsControl { get; set; }

        /// <summary>
        /// Gets or sets the is control type.
        /// </summary>
        public bool? IsControlType { get; set; }

        /// <summary>
        /// Gets or sets the kind of node.
        /// </summary>
        public Auriga.Activity.ObjectNodeKind? KindOfNode { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ordering.
        /// </summary>
        public Auriga.Activity.ObjectNodeOrderingKind? Ordering { get; set; }

        /// <summary>
        /// Gets the outgoing.
        /// </summary>
        public IEnumerable<Auriga.Activity.IActivityEdge> Outgoing => Enumerable.Empty<Auriga.Activity.IActivityEdge>();

        /// <summary>
        /// Gets the outgoing port allocations.
        /// </summary>
        public IEnumerable<Auriga.Information.IPortAllocation> OutgoingPortAllocations => Enumerable.Empty<Auriga.Information.IPortAllocation>();

        /// <summary>
        /// Gets the outgoing port realizations.
        /// </summary>
        public IEnumerable<Auriga.Information.IPortRealization> OutgoingPortRealizations => Enumerable.Empty<Auriga.Information.IPortRealization>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        /// <summary>
        /// Gets the owned enumeration property types.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes => this.backingOwnedEnumerationPropertyTypes ??= new Auriga.ContainerList<Auriga.Capellacore.IEnumerationPropertyType>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedEnumerationPropertyTypes"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> backingOwnedEnumerationPropertyTypes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.IContainerList<Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.ContainerList<Auriga.Modellingcore.IModelElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMigratedElements"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets the owned port allocations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IPortAllocation> OwnedPortAllocations => this.backingOwnedPortAllocations ??= new Auriga.ContainerList<Auriga.Information.IPortAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPortAllocations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.IPortAllocation> backingOwnedPortAllocations;

        /// <summary>
        /// Gets the owned port realizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IPortRealization> OwnedPortRealizations => this.backingOwnedPortRealizations ??= new Auriga.ContainerList<Auriga.Information.IPortRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPortRealizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.IPortRealization> backingOwnedPortRealizations;

        /// <summary>
        /// Gets the owned property value groups.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups => this.backingOwnedPropertyValueGroups ??= new Auriga.ContainerList<Auriga.Capellacore.IPropertyValueGroup>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValueGroups"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IPropertyValueGroup> backingOwnedPropertyValueGroups;

        /// <summary>
        /// Gets the owned property values.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.ContainerList<Auriga.Capellacore.IAbstractPropertyValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValues"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        /// <summary>
        /// Gets the owned protocols.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedProtocols => this.backingOwnedProtocols ??= new Auriga.ContainerList<Auriga.Capellacommon.IStateMachine>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedProtocols"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> backingOwnedProtocols;

        /// <summary>
        /// Gets the provided interfaces.
        /// </summary>
        public List<Auriga.Cs.IInterface> ProvidedInterfaces { get; } = new List<Auriga.Cs.IInterface>();

        /// <summary>
        /// Gets the realized function ports.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionPort> RealizedFunctionPorts => Enumerable.Empty<Auriga.Fa.IFunctionPort>();

        /// <summary>
        /// Gets the realizing function ports.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionPort> RealizingFunctionPorts => Enumerable.Empty<Auriga.Fa.IFunctionPort>();

        /// <summary>
        /// @deprecated : 'representedComponentPort' shall not be used anymore
        /// </summary>
        public Auriga.Fa.IComponentPort RepresentedComponentPort { get; set; }

        /// <summary>
        /// Gets the required interfaces.
        /// </summary>
        public List<Auriga.Cs.IInterface> RequiredInterfaces { get; } = new List<Auriga.Cs.IInterface>();

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Gets or sets the selection.
        /// </summary>
        public Auriga.Behavior.IAbstractBehavior Selection { get; set; }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public Auriga.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public Auriga.Capellacore.IType Type => default;

        /// <summary>
        /// Gets or sets the upper bound.
        /// </summary>
        public Auriga.Modellingcore.IValueSpecification UpperBound { get; set; }

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
