// ------------------------------------------------------------------------------------------------
// <copyright file="PhysicalLink.cs" company="Starion Group S.A.">
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

namespace Auriga.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalLink</c> class.
    /// </summary>
    public partial class PhysicalLink : Auriga.Core.AurigaElement, Auriga.Cs.IPhysicalLink
    {
        /// <summary>
        /// Gets the allocated component exchanges.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentExchange> AllocatedComponentExchanges => Enumerable.Empty<Auriga.Fa.IComponentExchange>();

        /// <summary>
        /// Gets the allocator configuration items.
        /// </summary>
        public IEnumerable<Auriga.Epbs.IConfigurationItem> AllocatorConfigurationItems => Enumerable.Empty<Auriga.Epbs.IConfigurationItem>();

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
        public IEnumerable<Auriga.Cs.IPhysicalLinkCategory> Categories => Enumerable.Empty<Auriga.Cs.IPhysicalLinkCategory>();

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
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the involving involvements.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Capellacore.IInvolvement>();

        /// <summary>
        /// Gets the link ends.
        /// </summary>
        public List<Auriga.Cs.IAbstractPhysicalLinkEnd> LinkEnds { get; } = new List<Auriga.Cs.IAbstractPhysicalLinkEnd>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the owned component exchange allocations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Fa.IComponentExchangeAllocation> OwnedComponentExchangeAllocations => this.backingOwnedComponentExchangeAllocations ??= new Auriga.Core.ContainerList<Auriga.Fa.IComponentExchangeAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeAllocations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Fa.IComponentExchangeAllocation> backingOwnedComponentExchangeAllocations;

        /// <summary>
        /// Gets the owned component exchange functional exchange allocations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> OwnedComponentExchangeFunctionalExchangeAllocations => this.backingOwnedComponentExchangeFunctionalExchangeAllocations ??= new Auriga.Core.ContainerList<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeFunctionalExchangeAllocations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> backingOwnedComponentExchangeFunctionalExchangeAllocations;

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.Core.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        /// <summary>
        /// Gets the owned enumeration property types.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes => this.backingOwnedEnumerationPropertyTypes ??= new Auriga.Core.ContainerList<Auriga.Capellacore.IEnumerationPropertyType>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedEnumerationPropertyTypes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> backingOwnedEnumerationPropertyTypes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.Core.ContainerList<Auriga.Modellingcore.IModelElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMigratedElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets the owned physical link ends.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Cs.IPhysicalLinkEnd> OwnedPhysicalLinkEnds => this.backingOwnedPhysicalLinkEnds ??= new Auriga.Core.ContainerList<Auriga.Cs.IPhysicalLinkEnd>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalLinkEnds"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Cs.IPhysicalLinkEnd> backingOwnedPhysicalLinkEnds;

        /// <summary>
        /// Gets the owned physical link realizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Cs.IPhysicalLinkRealization> OwnedPhysicalLinkRealizations => this.backingOwnedPhysicalLinkRealizations ??= new Auriga.Core.ContainerList<Auriga.Cs.IPhysicalLinkRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalLinkRealizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Cs.IPhysicalLinkRealization> backingOwnedPhysicalLinkRealizations;

        /// <summary>
        /// Gets the owned property value groups.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups => this.backingOwnedPropertyValueGroups ??= new Auriga.Core.ContainerList<Auriga.Capellacore.IPropertyValueGroup>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValueGroups"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Capellacore.IPropertyValueGroup> backingOwnedPropertyValueGroups;

        /// <summary>
        /// Gets the owned property values.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.Core.ContainerList<Auriga.Capellacore.IAbstractPropertyValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValues"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        /// <summary>
        /// Gets the realized physical links.
        /// </summary>
        public IEnumerable<Auriga.Cs.IPhysicalLink> RealizedPhysicalLinks => Enumerable.Empty<Auriga.Cs.IPhysicalLink>();

        /// <summary>
        /// Gets the realizing physical links.
        /// </summary>
        public IEnumerable<Auriga.Cs.IPhysicalLink> RealizingPhysicalLinks => Enumerable.Empty<Auriga.Cs.IPhysicalLink>();

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Gets the source physical port.
        /// </summary>
        public Auriga.Cs.IPhysicalPort SourcePhysicalPort => default;

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public Auriga.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets the target physical port.
        /// </summary>
        public Auriga.Cs.IPhysicalPort TargetPhysicalPort => default;

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>PhysicalLink</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedComponentExchangeAllocations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedComponentExchangeFunctionalExchangeAllocations)
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

            foreach (var element in this.OwnedPhysicalLinkEnds)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPhysicalLinkRealizations)
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
