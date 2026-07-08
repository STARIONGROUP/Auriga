// ------------------------------------------------------------------------------------------------
// <copyright file="ComponentExchange.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ComponentExchange</c> class.
    /// </summary>
    public partial class ComponentExchange : Auriga.AurigaElement, Auriga.Fa.IComponentExchange
    {
        /// <summary>
        /// Gets the abstract typed elements.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Modellingcore.IAbstractTypedElement>();

        /// <summary>
        /// Gets the allocated functional exchanges.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalExchange> AllocatedFunctionalExchanges => Enumerable.Empty<Auriga.Fa.IFunctionalExchange>();

        /// <summary>
        /// Gets the allocator physical links.
        /// </summary>
        public IEnumerable<Auriga.Cs.IPhysicalLink> AllocatorPhysicalLinks => Enumerable.Empty<Auriga.Cs.IPhysicalLink>();

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the categories.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentExchangeCategory> Categories => Enumerable.Empty<Auriga.Fa.IComponentExchangeCategory>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets the containing link.
        /// </summary>
        public Auriga.Fa.IExchangeLink ContainingLink => default;

        /// <summary>
        /// Gets the convoyed informations.
        /// </summary>
        public List<Auriga.Modellingcore.IAbstractExchangeItem> ConvoyedInformations { get; } = new List<Auriga.Modellingcore.IAbstractExchangeItem>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the incoming component exchange realizations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentExchangeRealization> IncomingComponentExchangeRealizations => Enumerable.Empty<Auriga.Fa.IComponentExchangeRealization>();

        /// <summary>
        /// Gets the incoming exchange specification realizations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IExchangeSpecificationRealization> IncomingExchangeSpecificationRealizations => Enumerable.Empty<Auriga.Fa.IExchangeSpecificationRealization>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the invoking sequence messages.
        /// </summary>
        public IEnumerable<Auriga.Interaction.ISequenceMessage> InvokingSequenceMessages => Enumerable.Empty<Auriga.Interaction.ISequenceMessage>();

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public Auriga.Fa.ComponentExchangeKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        public Auriga.Fa.IExchangeContainment Link { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the oriented.
        /// </summary>
        public bool? Oriented { get; set; }

        /// <summary>
        /// Gets the outgoing component exchange functional exchange allocations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OutgoingComponentExchangeFunctionalExchangeAllocations => Enumerable.Empty<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation>();

        /// <summary>
        /// Gets the outgoing component exchange realizations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentExchangeRealization> OutgoingComponentExchangeRealizations => Enumerable.Empty<Auriga.Fa.IComponentExchangeRealization>();

        /// <summary>
        /// Gets the outgoing exchange specification realizations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IExchangeSpecificationRealization> OutgoingExchangeSpecificationRealizations => Enumerable.Empty<Auriga.Fa.IExchangeSpecificationRealization>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the owned component exchange ends.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentExchangeEnd> OwnedComponentExchangeEnds => this.backingOwnedComponentExchangeEnds ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchangeEnd>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeEnds"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IComponentExchangeEnd> backingOwnedComponentExchangeEnds;

        /// <summary>
        /// Gets the owned component exchange functional exchange allocations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OwnedComponentExchangeFunctionalExchangeAllocations => this.backingOwnedComponentExchangeFunctionalExchangeAllocations ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeFunctionalExchangeAllocations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> backingOwnedComponentExchangeFunctionalExchangeAllocations;

        /// <summary>
        /// Gets the owned component exchange realizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations => this.backingOwnedComponentExchangeRealizations ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchangeRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeRealizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> backingOwnedComponentExchangeRealizations;

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
        /// Gets the realizations.
        /// </summary>
        public List<Auriga.Modellingcore.IAbstractRelationship> Realizations { get; } = new List<Auriga.Modellingcore.IAbstractRelationship>();

        /// <summary>
        /// Gets the realized component exchanges.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentExchange> RealizedComponentExchanges => Enumerable.Empty<Auriga.Fa.IComponentExchange>();

        /// <summary>
        /// Gets or sets the realized flow.
        /// </summary>
        public Auriga.Modellingcore.IAbstractInformationFlow RealizedFlow { get; set; }

        /// <summary>
        /// Gets the realizing activity flows.
        /// </summary>
        public IEnumerable<Auriga.Activity.IActivityEdge> RealizingActivityFlows => Enumerable.Empty<Auriga.Activity.IActivityEdge>();

        /// <summary>
        /// Gets the realizing component exchanges.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentExchange> RealizingComponentExchanges => Enumerable.Empty<Auriga.Fa.IComponentExchange>();

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public Auriga.Modellingcore.IInformationsExchanger Source { get; set; }

        /// <summary>
        /// Gets the source part.
        /// </summary>
        public Auriga.Cs.IPart SourcePart => default;

        /// <summary>
        /// Gets the source port.
        /// </summary>
        public Auriga.Information.IPort SourcePort => default;

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public Auriga.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public Auriga.Modellingcore.IInformationsExchanger Target { get; set; }

        /// <summary>
        /// Gets the target part.
        /// </summary>
        public Auriga.Cs.IPart TargetPart => default;

        /// <summary>
        /// Gets the target port.
        /// </summary>
        public Auriga.Information.IPort TargetPort => default;

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>ComponentExchange</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedComponentExchangeEnds)
            {
                yield return element;
            }

            foreach (var element in this.OwnedComponentExchangeFunctionalExchangeAllocations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedComponentExchangeRealizations)
            {
                yield return element;
            }

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

            foreach (var element in this.OwnedPropertyValueGroups)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPropertyValues)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
