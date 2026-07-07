// ------------------------------------------------------------------------------------------------
// <copyright file="PhysicalComponentPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalComponentPkg</c> class.
    /// </summary>
    public partial class PhysicalComponentPkg : Auriga.AurigaElement, Auriga.Pa.IPhysicalComponentPkg
    {
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
        /// Gets the contained generic traces.
        /// </summary>
        public IEnumerable<Auriga.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Capellacommon.IGenericTrace>();

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
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the naming rules.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.INamingRule> NamingRules => this.backingNamingRules ??= new Auriga.ContainerList<Auriga.Capellacore.INamingRule>(this);

        private Auriga.IContainerList<Auriga.Capellacore.INamingRule> backingNamingRules;

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the owned associations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IAssociation> OwnedAssociations => this.backingOwnedAssociations ??= new Auriga.ContainerList<Auriga.Information.IAssociation>(this);

        private Auriga.IContainerList<Auriga.Information.IAssociation> backingOwnedAssociations;

        /// <summary>
        /// Gets the owned component exchange categories.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories => this.backingOwnedComponentExchangeCategories ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchangeCategory>(this);

        private Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> backingOwnedComponentExchangeCategories;

        /// <summary>
        /// Gets the owned component exchange realizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations => this.backingOwnedComponentExchangeRealizations ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchangeRealization>(this);

        private Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> backingOwnedComponentExchangeRealizations;

        /// <summary>
        /// Gets the owned component exchanges.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentExchange> OwnedComponentExchanges => this.backingOwnedComponentExchanges ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchange>(this);

        private Auriga.IContainerList<Auriga.Fa.IComponentExchange> backingOwnedComponentExchanges;

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        private Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        /// <summary>
        /// Gets the owned deployments.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeployments => this.backingOwnedDeployments ??= new Auriga.ContainerList<Auriga.Cs.IAbstractDeploymentLink>(this);

        private Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> backingOwnedDeployments;

        /// <summary>
        /// Gets the owned enumeration property types.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes => this.backingOwnedEnumerationPropertyTypes ??= new Auriga.ContainerList<Auriga.Capellacore.IEnumerationPropertyType>(this);

        private Auriga.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> backingOwnedEnumerationPropertyTypes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned functional allocations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocations => this.backingOwnedFunctionalAllocations ??= new Auriga.ContainerList<Auriga.Fa.IComponentFunctionalAllocation>(this);

        private Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> backingOwnedFunctionalAllocations;

        /// <summary>
        /// Gets the owned functional links.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IExchangeLink> OwnedFunctionalLinks => this.backingOwnedFunctionalLinks ??= new Auriga.ContainerList<Auriga.Fa.IExchangeLink>(this);

        private Auriga.IContainerList<Auriga.Fa.IExchangeLink> backingOwnedFunctionalLinks;

        /// <summary>
        /// Gets the owned key parts.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IKeyPart> OwnedKeyParts => this.backingOwnedKeyParts ??= new Auriga.ContainerList<Auriga.Information.IKeyPart>(this);

        private Auriga.IContainerList<Auriga.Information.IKeyPart> backingOwnedKeyParts;

        /// <summary>
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.IContainerList<Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.ContainerList<Auriga.Modellingcore.IModelElement>(this);

        private Auriga.IContainerList<Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets the owned parts.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IPart> OwnedParts => this.backingOwnedParts ??= new Auriga.ContainerList<Auriga.Cs.IPart>(this);

        private Auriga.IContainerList<Auriga.Cs.IPart> backingOwnedParts;

        /// <summary>
        /// Gets the owned physical component pkgs.
        /// </summary>
        public Auriga.IContainerList<Auriga.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs => this.backingOwnedPhysicalComponentPkgs ??= new Auriga.ContainerList<Auriga.Pa.IPhysicalComponentPkg>(this);

        private Auriga.IContainerList<Auriga.Pa.IPhysicalComponentPkg> backingOwnedPhysicalComponentPkgs;

        /// <summary>
        /// Gets the owned physical components.
        /// </summary>
        public Auriga.IContainerList<Auriga.Pa.IPhysicalComponent> OwnedPhysicalComponents => this.backingOwnedPhysicalComponents ??= new Auriga.ContainerList<Auriga.Pa.IPhysicalComponent>(this);

        private Auriga.IContainerList<Auriga.Pa.IPhysicalComponent> backingOwnedPhysicalComponents;

        /// <summary>
        /// Gets the owned physical link categories.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories => this.backingOwnedPhysicalLinkCategories ??= new Auriga.ContainerList<Auriga.Cs.IPhysicalLinkCategory>(this);

        private Auriga.IContainerList<Auriga.Cs.IPhysicalLinkCategory> backingOwnedPhysicalLinkCategories;

        /// <summary>
        /// Gets the owned physical links.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IPhysicalLink> OwnedPhysicalLinks => this.backingOwnedPhysicalLinks ??= new Auriga.ContainerList<Auriga.Cs.IPhysicalLink>(this);

        private Auriga.IContainerList<Auriga.Cs.IPhysicalLink> backingOwnedPhysicalLinks;

        /// <summary>
        /// Gets the owned property value groups.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups => this.backingOwnedPropertyValueGroups ??= new Auriga.ContainerList<Auriga.Capellacore.IPropertyValueGroup>(this);

        private Auriga.IContainerList<Auriga.Capellacore.IPropertyValueGroup> backingOwnedPropertyValueGroups;

        /// <summary>
        /// Gets the owned property value pkgs.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IPropertyValuePkg> OwnedPropertyValuePkgs => this.backingOwnedPropertyValuePkgs ??= new Auriga.ContainerList<Auriga.Capellacore.IPropertyValuePkg>(this);

        private Auriga.IContainerList<Auriga.Capellacore.IPropertyValuePkg> backingOwnedPropertyValuePkgs;

        /// <summary>
        /// Gets the owned property values.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.ContainerList<Auriga.Capellacore.IAbstractPropertyValue>(this);

        private Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        /// <summary>
        /// Gets the owned state machines.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedStateMachines => this.backingOwnedStateMachines ??= new Auriga.ContainerList<Auriga.Capellacommon.IStateMachine>(this);

        private Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> backingOwnedStateMachines;

        /// <summary>
        /// Gets the owned traces.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.ContainerList<Auriga.Capellacore.ITrace>(this);

        private Auriga.IContainerList<Auriga.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        public string Review { get; set; }

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
        /// Gets or sets the visibility.
        /// </summary>
        public Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

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
