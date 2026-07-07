// ------------------------------------------------------------------------------------------------
// <copyright file="PhysicalNode.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa
{
    using System.Collections.Generic;
    using System.Linq;

    public partial class PhysicalNode : Auriga.AurigaElement, Auriga.Pa.IPhysicalNode
    {
        public IEnumerable<Auriga.Pa.IPhysicalNode> SubPhysicalNodes => Enumerable.Empty<Auriga.Pa.IPhysicalNode>();

        public Auriga.Pa.PhysicalComponentKind? Kind { get; set; }

        public Auriga.Pa.PhysicalComponentNature? Nature { get; set; }

        private Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> backingOwnedDeploymentLinks;

        public Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks => this.backingOwnedDeploymentLinks ??= new Auriga.ContainerList<Auriga.Cs.IAbstractDeploymentLink>(this);

        private Auriga.IContainerList<Auriga.Pa.IPhysicalComponent> backingOwnedPhysicalComponents;

        public Auriga.IContainerList<Auriga.Pa.IPhysicalComponent> OwnedPhysicalComponents => this.backingOwnedPhysicalComponents ??= new Auriga.ContainerList<Auriga.Pa.IPhysicalComponent>(this);

        private Auriga.IContainerList<Auriga.Pa.IPhysicalComponentPkg> backingOwnedPhysicalComponentPkgs;

        public Auriga.IContainerList<Auriga.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs => this.backingOwnedPhysicalComponentPkgs ??= new Auriga.ContainerList<Auriga.Pa.IPhysicalComponentPkg>(this);

        public IEnumerable<Auriga.Pa.ILogicalInterfaceRealization> LogicalInterfaceRealizations => Enumerable.Empty<Auriga.Pa.ILogicalInterfaceRealization>();

        public IEnumerable<Auriga.Pa.IPhysicalComponent> SubPhysicalComponents => Enumerable.Empty<Auriga.Pa.IPhysicalComponent>();

        public IEnumerable<Auriga.La.ILogicalComponent> RealizedLogicalComponents => Enumerable.Empty<Auriga.La.ILogicalComponent>();

        public IEnumerable<Auriga.Pa.IPhysicalFunction> AllocatedPhysicalFunctions => Enumerable.Empty<Auriga.Pa.IPhysicalFunction>();

        public IEnumerable<Auriga.Pa.IPhysicalComponent> DeployedPhysicalComponents => Enumerable.Empty<Auriga.Pa.IPhysicalComponent>();

        public IEnumerable<Auriga.Pa.IPhysicalComponent> DeployingPhysicalComponents => Enumerable.Empty<Auriga.Pa.IPhysicalComponent>();

        public IEnumerable<Auriga.Epbs.IConfigurationItem> AllocatorConfigurationItems => Enumerable.Empty<Auriga.Epbs.IConfigurationItem>();

        public string Summary { get; set; }

        public string Description { get; set; }

        public string Review { get; set; }

        private Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        public Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.ContainerList<Auriga.Capellacore.IAbstractPropertyValue>(this);

        private Auriga.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> backingOwnedEnumerationPropertyTypes;

        public Auriga.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes => this.backingOwnedEnumerationPropertyTypes ??= new Auriga.ContainerList<Auriga.Capellacore.IEnumerationPropertyType>(this);

        public List<Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Capellacore.IAbstractPropertyValue>();

        private Auriga.IContainerList<Auriga.Capellacore.IPropertyValueGroup> backingOwnedPropertyValueGroups;

        public Auriga.IContainerList<Auriga.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups => this.backingOwnedPropertyValueGroups ??= new Auriga.ContainerList<Auriga.Capellacore.IPropertyValueGroup>(this);

        public List<Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Capellacore.IPropertyValueGroup>();

        public Auriga.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        public List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Capellacore.IEnumerationPropertyLiteral>();

        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        public string Sid { get; set; }

        public IEnumerable<Auriga.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Modellingcore.IAbstractConstraint>();

        private Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        public Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        private Auriga.IContainerList<Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        public Auriga.IContainerList<Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.ContainerList<Auriga.Modellingcore.IModelElement>(this);

        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        public bool? VisibleInDoc { get; set; }

        public bool? VisibleInLM { get; set; }

        public bool Actor { get; set; }

        public bool Human { get; set; }

        private Auriga.IContainerList<Auriga.Cs.IInterfaceUse> backingOwnedInterfaceUses;

        public Auriga.IContainerList<Auriga.Cs.IInterfaceUse> OwnedInterfaceUses => this.backingOwnedInterfaceUses ??= new Auriga.ContainerList<Auriga.Cs.IInterfaceUse>(this);

        public IEnumerable<Auriga.Cs.IInterfaceUse> UsedInterfaceLinks => Enumerable.Empty<Auriga.Cs.IInterfaceUse>();

        public IEnumerable<Auriga.Cs.IInterface> UsedInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

        private Auriga.IContainerList<Auriga.Cs.IInterfaceImplementation> backingOwnedInterfaceImplementations;

        public Auriga.IContainerList<Auriga.Cs.IInterfaceImplementation> OwnedInterfaceImplementations => this.backingOwnedInterfaceImplementations ??= new Auriga.ContainerList<Auriga.Cs.IInterfaceImplementation>(this);

        public IEnumerable<Auriga.Cs.IInterfaceImplementation> ImplementedInterfaceLinks => Enumerable.Empty<Auriga.Cs.IInterfaceImplementation>();

        public IEnumerable<Auriga.Cs.IInterface> ImplementedInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

        private Auriga.IContainerList<Auriga.Cs.IComponentRealization> backingOwnedComponentRealizations;

        public Auriga.IContainerList<Auriga.Cs.IComponentRealization> OwnedComponentRealizations => this.backingOwnedComponentRealizations ??= new Auriga.ContainerList<Auriga.Cs.IComponentRealization>(this);

        public IEnumerable<Auriga.Cs.IComponent> RealizedComponents => Enumerable.Empty<Auriga.Cs.IComponent>();

        public IEnumerable<Auriga.Cs.IComponent> RealizingComponents => Enumerable.Empty<Auriga.Cs.IComponent>();

        public IEnumerable<Auriga.Cs.IInterface> ProvidedInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

        public IEnumerable<Auriga.Cs.IInterface> RequiredInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

        public IEnumerable<Auriga.Fa.IComponentPort> ContainedComponentPorts => Enumerable.Empty<Auriga.Fa.IComponentPort>();

        public IEnumerable<Auriga.Cs.IPart> ContainedParts => Enumerable.Empty<Auriga.Cs.IPart>();

        public IEnumerable<Auriga.Cs.IPhysicalPort> ContainedPhysicalPorts => Enumerable.Empty<Auriga.Cs.IPhysicalPort>();

        private Auriga.IContainerList<Auriga.Cs.IPhysicalPath> backingOwnedPhysicalPath;

        public Auriga.IContainerList<Auriga.Cs.IPhysicalPath> OwnedPhysicalPath => this.backingOwnedPhysicalPath ??= new Auriga.ContainerList<Auriga.Cs.IPhysicalPath>(this);

        private Auriga.IContainerList<Auriga.Cs.IPhysicalLink> backingOwnedPhysicalLinks;

        public Auriga.IContainerList<Auriga.Cs.IPhysicalLink> OwnedPhysicalLinks => this.backingOwnedPhysicalLinks ??= new Auriga.ContainerList<Auriga.Cs.IPhysicalLink>(this);

        private Auriga.IContainerList<Auriga.Cs.IPhysicalLinkCategory> backingOwnedPhysicalLinkCategories;

        public Auriga.IContainerList<Auriga.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories => this.backingOwnedPhysicalLinkCategories ??= new Auriga.ContainerList<Auriga.Cs.IPhysicalLinkCategory>(this);

        public IEnumerable<Auriga.Cs.IPart> RepresentingParts => Enumerable.Empty<Auriga.Cs.IPart>();

        public Auriga.Capellacommon.IAbstractCapabilityPkg OwnedAbstractCapabilityPkg { get; set; }

        public Auriga.Cs.IInterfacePkg OwnedInterfacePkg { get; set; }

        public Auriga.Information.IDataPkg OwnedDataPkg { get; set; }

        private Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> backingOwnedStateMachines;

        public Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedStateMachines => this.backingOwnedStateMachines ??= new Auriga.ContainerList<Auriga.Capellacommon.IStateMachine>(this);

        public IEnumerable<Auriga.Capellacore.ITypedElement> TypedElements => Enumerable.Empty<Auriga.Capellacore.ITypedElement>();

        public IEnumerable<Auriga.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Modellingcore.IAbstractTypedElement>();

        public string Name { get; set; }

        private Auriga.IContainerList<Auriga.Capellacore.ITrace> backingOwnedTraces;

        public Auriga.IContainerList<Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.ContainerList<Auriga.Capellacore.ITrace>(this);

        public IEnumerable<Auriga.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Capellacommon.IGenericTrace>();

        private Auriga.IContainerList<Auriga.Capellacore.INamingRule> backingNamingRules;

        public Auriga.IContainerList<Auriga.Capellacore.INamingRule> NamingRules => this.backingNamingRules ??= new Auriga.ContainerList<Auriga.Capellacore.INamingRule>(this);

        private Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> backingOwnedFunctionalAllocation;

        public Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocation => this.backingOwnedFunctionalAllocation ??= new Auriga.ContainerList<Auriga.Fa.IComponentFunctionalAllocation>(this);

        private Auriga.IContainerList<Auriga.Fa.IComponentExchange> backingOwnedComponentExchanges;

        public Auriga.IContainerList<Auriga.Fa.IComponentExchange> OwnedComponentExchanges => this.backingOwnedComponentExchanges ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchange>(this);

        private Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> backingOwnedComponentExchangeCategories;

        public Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories => this.backingOwnedComponentExchangeCategories ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchangeCategory>(this);

        public IEnumerable<Auriga.Fa.IComponentFunctionalAllocation> FunctionalAllocations => Enumerable.Empty<Auriga.Fa.IComponentFunctionalAllocation>();

        public IEnumerable<Auriga.Fa.IAbstractFunction> AllocatedFunctions => Enumerable.Empty<Auriga.Fa.IAbstractFunction>();

        public List<Auriga.Fa.IExchangeLink> InExchangeLinks { get; } = new List<Auriga.Fa.IExchangeLink>();

        public List<Auriga.Fa.IExchangeLink> OutExchangeLinks { get; } = new List<Auriga.Fa.IExchangeLink>();

        private Auriga.IContainerList<Auriga.Capellacore.IFeature> backingOwnedFeatures;

        public Auriga.IContainerList<Auriga.Capellacore.IFeature> OwnedFeatures => this.backingOwnedFeatures ??= new Auriga.ContainerList<Auriga.Capellacore.IFeature>(this);

        public IEnumerable<Auriga.Information.IProperty> ContainedProperties => Enumerable.Empty<Auriga.Information.IProperty>();

        public bool? Abstract { get; set; }

        private Auriga.IContainerList<Auriga.Capellacore.IGeneralization> backingOwnedGeneralizations;

        public Auriga.IContainerList<Auriga.Capellacore.IGeneralization> OwnedGeneralizations => this.backingOwnedGeneralizations ??= new Auriga.ContainerList<Auriga.Capellacore.IGeneralization>(this);

        public IEnumerable<Auriga.Capellacore.IGeneralization> SuperGeneralizations => Enumerable.Empty<Auriga.Capellacore.IGeneralization>();

        public IEnumerable<Auriga.Capellacore.IGeneralization> SubGeneralizations => Enumerable.Empty<Auriga.Capellacore.IGeneralization>();

        public IEnumerable<Auriga.Capellacore.IGeneralizableElement> Super => Enumerable.Empty<Auriga.Capellacore.IGeneralizableElement>();

        public IEnumerable<Auriga.Capellacore.IGeneralizableElement> Sub => Enumerable.Empty<Auriga.Capellacore.IGeneralizableElement>();

        private Auriga.IContainerList<Auriga.Cs.IInterfaceAllocation> backingOwnedInterfaceAllocations;

        public Auriga.IContainerList<Auriga.Cs.IInterfaceAllocation> OwnedInterfaceAllocations => this.backingOwnedInterfaceAllocations ??= new Auriga.ContainerList<Auriga.Cs.IInterfaceAllocation>(this);

        public IEnumerable<Auriga.Cs.IInterfaceAllocation> ProvisionedInterfaceAllocations => Enumerable.Empty<Auriga.Cs.IInterfaceAllocation>();

        public IEnumerable<Auriga.Cs.IInterface> AllocatedInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

        private Auriga.IContainerList<Auriga.Information.Communication.ICommunicationLink> backingOwnedCommunicationLinks;

        public Auriga.IContainerList<Auriga.Information.Communication.ICommunicationLink> OwnedCommunicationLinks => this.backingOwnedCommunicationLinks ??= new Auriga.ContainerList<Auriga.Information.Communication.ICommunicationLink>(this);

        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Produce => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Consume => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Send => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Receive => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Call => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Execute => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Write => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Access => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Acquire => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        public IEnumerable<Auriga.Information.Communication.ICommunicationLink> Transmit => Enumerable.Empty<Auriga.Information.Communication.ICommunicationLink>();

        public IEnumerable<Auriga.Capellacommon.ICapabilityRealizationInvolvement> CapabilityRealizationInvolvements => Enumerable.Empty<Auriga.Capellacommon.ICapabilityRealizationInvolvement>();

        public IEnumerable<Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations => Enumerable.Empty<Auriga.La.ICapabilityRealization>();

        public IEnumerable<Auriga.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Capellacore.IInvolvement>();

        public IEnumerable<Auriga.Cs.IAbstractDeploymentLink> DeployingLinks => Enumerable.Empty<Auriga.Cs.IAbstractDeploymentLink>();

        public IEnumerable<Auriga.Cs.IAbstractDeploymentLink> DeploymentLinks => Enumerable.Empty<Auriga.Cs.IAbstractDeploymentLink>();

    }
}
