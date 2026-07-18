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

namespace Auriga.Model.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ComponentExchange</c> class.
    /// </summary>
    public partial class ComponentExchange : Auriga.Core.AurigaElement, Auriga.Model.Fa.IComponentExchange
    {
        /// <summary>
        /// Gets the abstract typed elements.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTypedElement>();

        /// <summary>
        /// Gets the allocated functional exchanges.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalExchange> AllocatedFunctionalExchanges => Enumerable.Empty<Auriga.Model.Fa.IFunctionalExchange>();

        /// <summary>
        /// Gets the allocator physical links.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IPhysicalLink> AllocatorPhysicalLinks => Enumerable.Empty<Auriga.Model.Cs.IPhysicalLink>();

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Model.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Model.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Model.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Model.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the categories.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentExchangeCategory> Categories => Enumerable.Empty<Auriga.Model.Fa.IComponentExchangeCategory>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets the containing link.
        /// </summary>
        public Auriga.Model.Fa.IExchangeLink ContainingLink => default;

        /// <summary>
        /// Gets the convoyed informations.
        /// </summary>
        public List<Auriga.Model.Modellingcore.IAbstractExchangeItem> ConvoyedInformations { get; } = new List<Auriga.Model.Modellingcore.IAbstractExchangeItem>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the incoming component exchange realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentExchangeRealization> IncomingComponentExchangeRealizations => Enumerable.Empty<Auriga.Model.Fa.IComponentExchangeRealization>();

        /// <summary>
        /// Gets the incoming exchange specification realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IExchangeSpecificationRealization> IncomingExchangeSpecificationRealizations => Enumerable.Empty<Auriga.Model.Fa.IExchangeSpecificationRealization>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the invoking sequence messages.
        /// </summary>
        public IEnumerable<Auriga.Model.Interaction.ISequenceMessage> InvokingSequenceMessages => Enumerable.Empty<Auriga.Model.Interaction.ISequenceMessage>();

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public Auriga.Model.Fa.ComponentExchangeKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        public Auriga.Model.Fa.IExchangeContainment Link { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the oriented.
        /// </summary>
        public bool? Oriented { get; set; } = false;

        /// <summary>
        /// Gets the outgoing component exchange functional exchange allocations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentExchangeFunctionalExchangeAllocation> OutgoingComponentExchangeFunctionalExchangeAllocations => Enumerable.Empty<Auriga.Model.Fa.IComponentExchangeFunctionalExchangeAllocation>();

        /// <summary>
        /// Gets the outgoing component exchange realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentExchangeRealization> OutgoingComponentExchangeRealizations => Enumerable.Empty<Auriga.Model.Fa.IComponentExchangeRealization>();

        /// <summary>
        /// Gets the outgoing exchange specification realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IExchangeSpecificationRealization> OutgoingExchangeSpecificationRealizations => Enumerable.Empty<Auriga.Model.Fa.IExchangeSpecificationRealization>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the owned component exchange ends.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeEnd> OwnedComponentExchangeEnds => this.backingOwnedComponentExchangeEnds ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IComponentExchangeEnd>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeEnds"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeEnd> backingOwnedComponentExchangeEnds;

        /// <summary>
        /// Gets the owned component exchange functional exchange allocations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeFunctionalExchangeAllocation> OwnedComponentExchangeFunctionalExchangeAllocations => this.backingOwnedComponentExchangeFunctionalExchangeAllocations ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IComponentExchangeFunctionalExchangeAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeFunctionalExchangeAllocations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeFunctionalExchangeAllocation> backingOwnedComponentExchangeFunctionalExchangeAllocations;

        /// <summary>
        /// Gets the owned component exchange realizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations => this.backingOwnedComponentExchangeRealizations ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IComponentExchangeRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeRealizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeRealization> backingOwnedComponentExchangeRealizations;

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
        /// Gets the realizations.
        /// </summary>
        public List<Auriga.Model.Modellingcore.IAbstractRelationship> Realizations { get; } = new List<Auriga.Model.Modellingcore.IAbstractRelationship>();

        /// <summary>
        /// Gets the realized component exchanges.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentExchange> RealizedComponentExchanges => Enumerable.Empty<Auriga.Model.Fa.IComponentExchange>();

        /// <summary>
        /// Gets or sets the realized flow.
        /// </summary>
        public Auriga.Model.Modellingcore.IAbstractInformationFlow RealizedFlow { get; set; }

        /// <summary>
        /// Gets the realizing activity flows.
        /// </summary>
        public IEnumerable<Auriga.Model.Activity.IActivityEdge> RealizingActivityFlows => Enumerable.Empty<Auriga.Model.Activity.IActivityEdge>();

        /// <summary>
        /// Gets the realizing component exchanges.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentExchange> RealizingComponentExchanges => Enumerable.Empty<Auriga.Model.Fa.IComponentExchange>();

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
        public Auriga.Model.Modellingcore.IInformationsExchanger Source { get; set; }

        /// <summary>
        /// Gets the source part.
        /// </summary>
        public Auriga.Model.Cs.IPart SourcePart => default;

        /// <summary>
        /// Gets the source port.
        /// </summary>
        public Auriga.Model.Information.IPort SourcePort => default;

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public Auriga.Model.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public Auriga.Model.Modellingcore.IInformationsExchanger Target { get; set; }

        /// <summary>
        /// Gets the target part.
        /// </summary>
        public Auriga.Model.Cs.IPart TargetPart => default;

        /// <summary>
        /// Gets the target port.
        /// </summary>
        public Auriga.Model.Information.IPort TargetPort => default;

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; } = true;

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; } = true;

        /// <summary>
        /// Gets the elements directly contained by this <c>ComponentExchange</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
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
