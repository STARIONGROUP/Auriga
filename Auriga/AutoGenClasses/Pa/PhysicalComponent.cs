// ------------------------------------------------------------------------------------------------
// <copyright file="PhysicalComponent.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>PhysicalComponent</c> class.
    /// </summary>
    public partial class PhysicalComponent : Auriga.AurigaElement, Auriga.Pa.IPhysicalComponent
    {
        /// <summary>
        /// Gets or sets the abstract.
        /// </summary>
        public bool? Abstract { get; set; }

        /// <summary>
        /// Gets the abstract typed elements.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Modellingcore.IAbstractTypedElement>();

        /// <summary>
        /// Gets the access.
        /// </summary>
        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Access => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the acquire.
        /// </summary>
        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Acquire => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets or sets the actor.
        /// </summary>
        public bool Actor { get; set; }

        /// <summary>
        /// Gets the allocated functions.
        /// </summary>
        public IEnumerable<Auriga.Fa.IAbstractFunction> AllocatedFunctions => Enumerable.Empty<Auriga.Fa.IAbstractFunction>();

        /// <summary>
        /// Gets the allocated interfaces.
        /// </summary>
        public IEnumerable<Auriga.Cs.IInterface> AllocatedInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

        /// <summary>
        /// Gets the allocated physical functions.
        /// </summary>
        public IEnumerable<Auriga.Pa.IPhysicalFunction> AllocatedPhysicalFunctions => Enumerable.Empty<Auriga.Pa.IPhysicalFunction>();

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
        /// Gets the call.
        /// </summary>
        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Call => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the capability realization involvements.
        /// </summary>
        public IEnumerable<Auriga.Capellacommon.ICapabilityRealizationInvolvement> CapabilityRealizationInvolvements => Enumerable.Empty<Auriga.Capellacommon.ICapabilityRealizationInvolvement>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets the consume.
        /// </summary>
        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Consume => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the contained component ports.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentPort> ContainedComponentPorts => Enumerable.Empty<Auriga.Fa.IComponentPort>();

        /// <summary>
        /// Gets the contained generic traces.
        /// </summary>
        public IEnumerable<Auriga.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Capellacommon.IGenericTrace>();

        /// <summary>
        /// Gets the contained parts.
        /// </summary>
        public IEnumerable<Auriga.Cs.IPart> ContainedParts => Enumerable.Empty<Auriga.Cs.IPart>();

        /// <summary>
        /// Gets the contained physical ports.
        /// </summary>
        public IEnumerable<Auriga.Cs.IPhysicalPort> ContainedPhysicalPorts => Enumerable.Empty<Auriga.Cs.IPhysicalPort>();

        /// <summary>
        /// Gets the contained properties.
        /// </summary>
        public IEnumerable<Auriga.Information.IProperty> ContainedProperties => Enumerable.Empty<Auriga.Information.IProperty>();

        /// <summary>
        /// Gets the deployed physical components.
        /// </summary>
        public IEnumerable<Auriga.Pa.IPhysicalComponent> DeployedPhysicalComponents => Enumerable.Empty<Auriga.Pa.IPhysicalComponent>();

        /// <summary>
        /// Gets the deploying links.
        /// </summary>
        public IEnumerable<Auriga.Cs.IAbstractDeploymentLink> DeployingLinks => Enumerable.Empty<Auriga.Cs.IAbstractDeploymentLink>();

        /// <summary>
        /// Gets the deploying physical components.
        /// </summary>
        public IEnumerable<Auriga.Pa.IPhysicalComponent> DeployingPhysicalComponents => Enumerable.Empty<Auriga.Pa.IPhysicalComponent>();

        /// <summary>
        /// Gets the deployment links.
        /// </summary>
        public IEnumerable<Auriga.Cs.IAbstractDeploymentLink> DeploymentLinks => Enumerable.Empty<Auriga.Cs.IAbstractDeploymentLink>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the execute.
        /// </summary>
        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Execute => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the functional allocations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentFunctionalAllocation> FunctionalAllocations => Enumerable.Empty<Auriga.Fa.IComponentFunctionalAllocation>();

        /// <summary>
        /// Gets or sets the human.
        /// </summary>
        public bool Human { get; set; }

        /// <summary>
        /// Gets the implemented interface links.
        /// </summary>
        public IEnumerable<Auriga.Cs.IInterfaceImplementation> ImplementedInterfaceLinks => Enumerable.Empty<Auriga.Cs.IInterfaceImplementation>();

        /// <summary>
        /// Gets the implemented interfaces.
        /// </summary>
        public IEnumerable<Auriga.Cs.IInterface> ImplementedInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

        /// <summary>
        /// Gets the in exchange links.
        /// </summary>
        public List<Auriga.Fa.IExchangeLink> InExchangeLinks { get; } = new List<Auriga.Fa.IExchangeLink>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the involving capability realizations.
        /// </summary>
        public IEnumerable<Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations => Enumerable.Empty<Auriga.La.ICapabilityRealization>();

        /// <summary>
        /// Gets the involving involvements.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Capellacore.IInvolvement>();

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public Auriga.Pa.PhysicalComponentKind? Kind { get; set; }

        /// <summary>
        /// Gets the logical interface realizations.
        /// </summary>
        public IEnumerable<Auriga.Pa.ILogicalInterfaceRealization> LogicalInterfaceRealizations => Enumerable.Empty<Auriga.Pa.ILogicalInterfaceRealization>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the naming rules.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.INamingRule> NamingRules => this.backingNamingRules ??= new Auriga.ContainerList<Auriga.Capellacore.INamingRule>(this);

        /// <summary>
        /// Backing field for <see cref="NamingRules"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.INamingRule> backingNamingRules;

        /// <summary>
        /// Gets or sets the nature.
        /// </summary>
        public Auriga.Pa.PhysicalComponentNature? Nature { get; set; }

        /// <summary>
        /// Gets the out exchange links.
        /// </summary>
        public List<Auriga.Fa.IExchangeLink> OutExchangeLinks { get; } = new List<Auriga.Fa.IExchangeLink>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets or sets the owned abstract capability pkg.
        /// </summary>
        public Auriga.Capellacommon.IAbstractCapabilityPkg OwnedAbstractCapabilityPkg
        {
            get => this.backingOwnedAbstractCapabilityPkg;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedAbstractCapabilityPkg = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedAbstractCapabilityPkg"/>.
        /// </summary>
        private Auriga.Capellacommon.IAbstractCapabilityPkg backingOwnedAbstractCapabilityPkg;

        /// <summary>
        /// Gets the owned communication links.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.Communication.ICommunicationLink> OwnedCommunicationLinks => this.backingOwnedCommunicationLinks ??= new Auriga.ContainerList<Auriga.Information.Communication.ICommunicationLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedCommunicationLinks"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.Communication.ICommunicationLink> backingOwnedCommunicationLinks;

        /// <summary>
        /// Gets the owned component exchange categories.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories => this.backingOwnedComponentExchangeCategories ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchangeCategory>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeCategories"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> backingOwnedComponentExchangeCategories;

        /// <summary>
        /// Gets the owned component exchanges.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentExchange> OwnedComponentExchanges => this.backingOwnedComponentExchanges ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchange>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchanges"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IComponentExchange> backingOwnedComponentExchanges;

        /// <summary>
        /// Gets the owned component realizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IComponentRealization> OwnedComponentRealizations => this.backingOwnedComponentRealizations ??= new Auriga.ContainerList<Auriga.Cs.IComponentRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentRealizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Cs.IComponentRealization> backingOwnedComponentRealizations;

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        /// <summary>
        /// Gets or sets the owned data pkg.
        /// </summary>
        public Auriga.Information.IDataPkg OwnedDataPkg
        {
            get => this.backingOwnedDataPkg;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedDataPkg = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedDataPkg"/>.
        /// </summary>
        private Auriga.Information.IDataPkg backingOwnedDataPkg;

        /// <summary>
        /// Gets the owned deployment links.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks => this.backingOwnedDeploymentLinks ??= new Auriga.ContainerList<Auriga.Cs.IAbstractDeploymentLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDeploymentLinks"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> backingOwnedDeploymentLinks;

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
        /// Gets the owned features.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IFeature> OwnedFeatures => this.backingOwnedFeatures ??= new Auriga.ContainerList<Auriga.Capellacore.IFeature>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFeatures"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IFeature> backingOwnedFeatures;

        /// <summary>
        /// Gets the owned functional allocation.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocation => this.backingOwnedFunctionalAllocation ??= new Auriga.ContainerList<Auriga.Fa.IComponentFunctionalAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalAllocation"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> backingOwnedFunctionalAllocation;

        /// <summary>
        /// Gets the owned generalizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IGeneralization> OwnedGeneralizations => this.backingOwnedGeneralizations ??= new Auriga.ContainerList<Auriga.Capellacore.IGeneralization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedGeneralizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IGeneralization> backingOwnedGeneralizations;

        /// <summary>
        /// Gets the owned interface allocations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IInterfaceAllocation> OwnedInterfaceAllocations => this.backingOwnedInterfaceAllocations ??= new Auriga.ContainerList<Auriga.Cs.IInterfaceAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedInterfaceAllocations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Cs.IInterfaceAllocation> backingOwnedInterfaceAllocations;

        /// <summary>
        /// Gets the owned interface implementations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IInterfaceImplementation> OwnedInterfaceImplementations => this.backingOwnedInterfaceImplementations ??= new Auriga.ContainerList<Auriga.Cs.IInterfaceImplementation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedInterfaceImplementations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Cs.IInterfaceImplementation> backingOwnedInterfaceImplementations;

        /// <summary>
        /// Gets or sets the owned interface pkg.
        /// </summary>
        public Auriga.Cs.IInterfacePkg OwnedInterfacePkg
        {
            get => this.backingOwnedInterfacePkg;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedInterfacePkg = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedInterfacePkg"/>.
        /// </summary>
        private Auriga.Cs.IInterfacePkg backingOwnedInterfacePkg;

        /// <summary>
        /// Gets the owned interface uses.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IInterfaceUse> OwnedInterfaceUses => this.backingOwnedInterfaceUses ??= new Auriga.ContainerList<Auriga.Cs.IInterfaceUse>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedInterfaceUses"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Cs.IInterfaceUse> backingOwnedInterfaceUses;

        /// <summary>
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.IContainerList<Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.ContainerList<Auriga.Modellingcore.IModelElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMigratedElements"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets the owned physical component pkgs.
        /// </summary>
        public Auriga.IContainerList<Auriga.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs => this.backingOwnedPhysicalComponentPkgs ??= new Auriga.ContainerList<Auriga.Pa.IPhysicalComponentPkg>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalComponentPkgs"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Pa.IPhysicalComponentPkg> backingOwnedPhysicalComponentPkgs;

        /// <summary>
        /// Gets the owned physical components.
        /// </summary>
        public Auriga.IContainerList<Auriga.Pa.IPhysicalComponent> OwnedPhysicalComponents => this.backingOwnedPhysicalComponents ??= new Auriga.ContainerList<Auriga.Pa.IPhysicalComponent>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalComponents"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Pa.IPhysicalComponent> backingOwnedPhysicalComponents;

        /// <summary>
        /// Gets the owned physical link categories.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories => this.backingOwnedPhysicalLinkCategories ??= new Auriga.ContainerList<Auriga.Cs.IPhysicalLinkCategory>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalLinkCategories"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Cs.IPhysicalLinkCategory> backingOwnedPhysicalLinkCategories;

        /// <summary>
        /// Gets the owned physical links.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IPhysicalLink> OwnedPhysicalLinks => this.backingOwnedPhysicalLinks ??= new Auriga.ContainerList<Auriga.Cs.IPhysicalLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalLinks"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Cs.IPhysicalLink> backingOwnedPhysicalLinks;

        /// <summary>
        /// Gets the owned physical path.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IPhysicalPath> OwnedPhysicalPath => this.backingOwnedPhysicalPath ??= new Auriga.ContainerList<Auriga.Cs.IPhysicalPath>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalPath"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Cs.IPhysicalPath> backingOwnedPhysicalPath;

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
        /// Gets the owned state machines.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedStateMachines => this.backingOwnedStateMachines ??= new Auriga.ContainerList<Auriga.Capellacommon.IStateMachine>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedStateMachines"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> backingOwnedStateMachines;

        /// <summary>
        /// Gets the owned traces.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.ContainerList<Auriga.Capellacore.ITrace>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTraces"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets the produce.
        /// </summary>
        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Produce => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the provided interfaces.
        /// </summary>
        public IEnumerable<Auriga.Cs.IInterface> ProvidedInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

        /// <summary>
        /// Gets the provisioned interface allocations.
        /// </summary>
        public IEnumerable<Auriga.Cs.IInterfaceAllocation> ProvisionedInterfaceAllocations => Enumerable.Empty<Auriga.Cs.IInterfaceAllocation>();

        /// <summary>
        /// Gets the realized components.
        /// </summary>
        public IEnumerable<Auriga.Cs.IComponent> RealizedComponents => Enumerable.Empty<Auriga.Cs.IComponent>();

        /// <summary>
        /// Gets the realized logical components.
        /// </summary>
        public IEnumerable<Auriga.La.ILogicalComponent> RealizedLogicalComponents => Enumerable.Empty<Auriga.La.ILogicalComponent>();

        /// <summary>
        /// Gets the realizing components.
        /// </summary>
        public IEnumerable<Auriga.Cs.IComponent> RealizingComponents => Enumerable.Empty<Auriga.Cs.IComponent>();

        /// <summary>
        /// Gets the receive.
        /// </summary>
        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Receive => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the representing parts.
        /// </summary>
        public IEnumerable<Auriga.Cs.IPart> RepresentingParts => Enumerable.Empty<Auriga.Cs.IPart>();

        /// <summary>
        /// Gets the required interfaces.
        /// </summary>
        public IEnumerable<Auriga.Cs.IInterface> RequiredInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Gets the send.
        /// </summary>
        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Send => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public Auriga.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        /// <summary>
        /// Gets the sub.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IGeneralizableElement> Sub => Enumerable.Empty<Auriga.Capellacore.IGeneralizableElement>();

        /// <summary>
        /// Gets the sub generalizations.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IGeneralization> SubGeneralizations => Enumerable.Empty<Auriga.Capellacore.IGeneralization>();

        /// <summary>
        /// Gets the sub physical components.
        /// </summary>
        public IEnumerable<Auriga.Pa.IPhysicalComponent> SubPhysicalComponents => Enumerable.Empty<Auriga.Pa.IPhysicalComponent>();

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets the super.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IGeneralizableElement> Super => Enumerable.Empty<Auriga.Capellacore.IGeneralizableElement>();

        /// <summary>
        /// Gets the super generalizations.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IGeneralization> SuperGeneralizations => Enumerable.Empty<Auriga.Capellacore.IGeneralization>();

        /// <summary>
        /// Gets the transmit.
        /// </summary>
        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Transmit => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the typed elements.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.ITypedElement> TypedElements => Enumerable.Empty<Auriga.Capellacore.ITypedElement>();

        /// <summary>
        /// Gets the used interface links.
        /// </summary>
        public IEnumerable<Auriga.Cs.IInterfaceUse> UsedInterfaceLinks => Enumerable.Empty<Auriga.Cs.IInterfaceUse>();

        /// <summary>
        /// Gets the used interfaces.
        /// </summary>
        public IEnumerable<Auriga.Cs.IInterface> UsedInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the write.
        /// </summary>
        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Write => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the elements directly contained by this <c>PhysicalComponent</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.NamingRules)
            {
                yield return element;
            }

            if (this.OwnedAbstractCapabilityPkg != null)
            {
                yield return this.OwnedAbstractCapabilityPkg;
            }

            foreach (var element in this.OwnedCommunicationLinks)
            {
                yield return element;
            }

            foreach (var element in this.OwnedComponentExchangeCategories)
            {
                yield return element;
            }

            foreach (var element in this.OwnedComponentExchanges)
            {
                yield return element;
            }

            foreach (var element in this.OwnedComponentRealizations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedConstraints)
            {
                yield return element;
            }

            if (this.OwnedDataPkg != null)
            {
                yield return this.OwnedDataPkg;
            }

            foreach (var element in this.OwnedDeploymentLinks)
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

            foreach (var element in this.OwnedFeatures)
            {
                yield return element;
            }

            foreach (var element in this.OwnedFunctionalAllocation)
            {
                yield return element;
            }

            foreach (var element in this.OwnedGeneralizations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedInterfaceAllocations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedInterfaceImplementations)
            {
                yield return element;
            }

            if (this.OwnedInterfacePkg != null)
            {
                yield return this.OwnedInterfacePkg;
            }

            foreach (var element in this.OwnedInterfaceUses)
            {
                yield return element;
            }

            foreach (var element in this.OwnedMigratedElements)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPhysicalComponentPkgs)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPhysicalComponents)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPhysicalLinkCategories)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPhysicalLinks)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPhysicalPath)
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

            foreach (var element in this.OwnedStateMachines)
            {
                yield return element;
            }

            foreach (var element in this.OwnedTraces)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
