// ------------------------------------------------------------------------------------------------
// <copyright file="FunctionOutputPort.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>FunctionOutputPort</c> class.
    /// </summary>
    public partial class FunctionOutputPort : Auriga.Core.AurigaElement, Auriga.Model.Fa.IFunctionOutputPort
    {
        /// <summary>
        /// Gets or sets the abstract type.
        /// </summary>
        public Auriga.Model.Modellingcore.IAbstractType AbstractType { get; set; }

        /// <summary>
        /// Gets the abstract typed elements.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTypedElement>();

        /// <summary>
        /// Gets the allocator component ports.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentPort> AllocatorComponentPorts => Enumerable.Empty<Auriga.Model.Fa.IComponentPort>();

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Model.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Model.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Model.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Model.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the in activity partition.
        /// </summary>
        public Auriga.Model.Activity.IActivityPartition InActivityPartition => default;

        /// <summary>
        /// Gets the in interruptible region.
        /// </summary>
        public Auriga.Model.Activity.IInterruptibleActivityRegion InInterruptibleRegion => default;

        /// <summary>
        /// Gets the in state.
        /// </summary>
        public List<Auriga.Model.Modellingcore.IIState> InState { get; } = new List<Auriga.Model.Modellingcore.IIState>();

        /// <summary>
        /// Gets the in structured node.
        /// </summary>
        public Auriga.Model.Activity.IInterruptibleActivityRegion InStructuredNode => default;

        /// <summary>
        /// Gets the incoming.
        /// </summary>
        public IEnumerable<Auriga.Model.Activity.IActivityEdge> Incoming => Enumerable.Empty<Auriga.Model.Activity.IActivityEdge>();

        /// <summary>
        /// Gets the incoming port allocations.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.IPortAllocation> IncomingPortAllocations => Enumerable.Empty<Auriga.Model.Information.IPortAllocation>();

        /// <summary>
        /// Gets the incoming port realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.IPortRealization> IncomingPortRealizations => Enumerable.Empty<Auriga.Model.Information.IPortRealization>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

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
        public Auriga.Model.Activity.ObjectNodeKind? KindOfNode { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ordering.
        /// </summary>
        public Auriga.Model.Activity.ObjectNodeOrderingKind? Ordering { get; set; }

        /// <summary>
        /// Gets the outgoing.
        /// </summary>
        public IEnumerable<Auriga.Model.Activity.IActivityEdge> Outgoing => Enumerable.Empty<Auriga.Model.Activity.IActivityEdge>();

        /// <summary>
        /// Gets the outgoing exchange items.
        /// </summary>
        public List<Auriga.Model.Information.IExchangeItem> OutgoingExchangeItems { get; } = new List<Auriga.Model.Information.IExchangeItem>();

        /// <summary>
        /// Gets the outgoing functional exchanges.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalExchange> OutgoingFunctionalExchanges => Enumerable.Empty<Auriga.Model.Fa.IFunctionalExchange>();

        /// <summary>
        /// Gets the outgoing port allocations.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.IPortAllocation> OutgoingPortAllocations => Enumerable.Empty<Auriga.Model.Information.IPortAllocation>();

        /// <summary>
        /// Gets the outgoing port realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.IPortRealization> OutgoingPortRealizations => Enumerable.Empty<Auriga.Model.Information.IPortRealization>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.Core.ContainerList<Auriga.Model.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        /// <summary>
        /// Gets the owned enumeration property types.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes => this.backingOwnedEnumerationPropertyTypes ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IEnumerationPropertyType>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedEnumerationPropertyTypes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IEnumerationPropertyType> backingOwnedEnumerationPropertyTypes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Model.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.Core.ContainerList<Auriga.Model.Modellingcore.IModelElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMigratedElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets the owned port allocations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Information.IPortAllocation> OwnedPortAllocations => this.backingOwnedPortAllocations ??= new Auriga.Core.ContainerList<Auriga.Model.Information.IPortAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPortAllocations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Information.IPortAllocation> backingOwnedPortAllocations;

        /// <summary>
        /// Gets the owned port realizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Information.IPortRealization> OwnedPortRealizations => this.backingOwnedPortRealizations ??= new Auriga.Core.ContainerList<Auriga.Model.Information.IPortRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPortRealizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Information.IPortRealization> backingOwnedPortRealizations;

        /// <summary>
        /// Gets the owned property value groups.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups => this.backingOwnedPropertyValueGroups ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IPropertyValueGroup>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValueGroups"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IPropertyValueGroup> backingOwnedPropertyValueGroups;

        /// <summary>
        /// Gets the owned property values.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValues"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        /// <summary>
        /// Gets the owned protocols.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IStateMachine> OwnedProtocols => this.backingOwnedProtocols ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacommon.IStateMachine>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedProtocols"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IStateMachine> backingOwnedProtocols;

        /// <summary>
        /// Gets the provided interfaces.
        /// </summary>
        public List<Auriga.Model.Cs.IInterface> ProvidedInterfaces { get; } = new List<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets the realized function ports.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionPort> RealizedFunctionPorts => Enumerable.Empty<Auriga.Model.Fa.IFunctionPort>();

        /// <summary>
        /// Gets the realizing function ports.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionPort> RealizingFunctionPorts => Enumerable.Empty<Auriga.Model.Fa.IFunctionPort>();

        /// <summary>
        /// @deprecated : 'representedComponentPort' shall not be used anymore
        /// </summary>
        public Auriga.Model.Fa.IComponentPort RepresentedComponentPort { get; set; }

        /// <summary>
        /// Gets the required interfaces.
        /// </summary>
        public List<Auriga.Model.Cs.IInterface> RequiredInterfaces { get; } = new List<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Gets or sets the selection.
        /// </summary>
        public Auriga.Model.Behavior.IAbstractBehavior Selection { get; set; }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public Auriga.Model.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public Auriga.Model.Capellacore.IType Type => default;

        /// <summary>
        /// Gets or sets the upper bound.
        /// </summary>
        public Auriga.Model.Modellingcore.IValueSpecification UpperBound
        {
            get => this.backingUpperBound;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingUpperBound = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="UpperBound"/>.
        /// </summary>
        private Auriga.Model.Modellingcore.IValueSpecification backingUpperBound;

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>FunctionOutputPort</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedConstraints)
            {
                yield return element;
            }

            foreach (var element in this.OwnedEnumerationPropertyTypes)
            {
                yield return element;
            }

            foreach (var element in this.OwnedExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedMigratedElements)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPortAllocations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPortRealizations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPropertyValueGroups)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPropertyValues)
            {
                yield return element;
            }

            foreach (var element in this.OwnedProtocols)
            {
                yield return element;
            }

            if (this.UpperBound != null)
            {
                yield return this.UpperBound;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
