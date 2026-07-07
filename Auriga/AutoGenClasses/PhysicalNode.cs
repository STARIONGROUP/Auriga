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
    public partial class PhysicalNode : global::Auriga.AurigaElement, global::Auriga.Pa.IPhysicalNode
    {
        public global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalNode> SubPhysicalNodes => global::System.Linq.Enumerable.Empty<global::Auriga.Pa.IPhysicalNode>();

        public global::Auriga.Pa.PhysicalComponentKind? Kind { get; set; }

        public global::Auriga.Pa.PhysicalComponentNature? Nature { get; set; }

        private global::Auriga.IContainerList<global::Auriga.Cs.IAbstractDeploymentLink> backingOwnedDeploymentLinks;

        public global::Auriga.IContainerList<global::Auriga.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks => this.backingOwnedDeploymentLinks ??= new global::Auriga.ContainerList<global::Auriga.Cs.IAbstractDeploymentLink>(this);

        private global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalComponent> backingOwnedPhysicalComponents;

        public global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalComponent> OwnedPhysicalComponents => this.backingOwnedPhysicalComponents ??= new global::Auriga.ContainerList<global::Auriga.Pa.IPhysicalComponent>(this);

        private global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalComponentPkg> backingOwnedPhysicalComponentPkgs;

        public global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalComponentPkg> OwnedPhysicalComponentPkgs => this.backingOwnedPhysicalComponentPkgs ??= new global::Auriga.ContainerList<global::Auriga.Pa.IPhysicalComponentPkg>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.ILogicalInterfaceRealization> LogicalInterfaceRealizations => global::System.Linq.Enumerable.Empty<global::Auriga.Pa.ILogicalInterfaceRealization>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalComponent> SubPhysicalComponents => global::System.Linq.Enumerable.Empty<global::Auriga.Pa.IPhysicalComponent>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalComponent> RealizedLogicalComponents => global::System.Linq.Enumerable.Empty<global::Auriga.La.ILogicalComponent>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalFunction> AllocatedPhysicalFunctions => global::System.Linq.Enumerable.Empty<global::Auriga.Pa.IPhysicalFunction>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalComponent> DeployedPhysicalComponents => global::System.Linq.Enumerable.Empty<global::Auriga.Pa.IPhysicalComponent>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalComponent> DeployingPhysicalComponents => global::System.Linq.Enumerable.Empty<global::Auriga.Pa.IPhysicalComponent>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Epbs.IConfigurationItem> AllocatorConfigurationItems => global::System.Linq.Enumerable.Empty<global::Auriga.Epbs.IConfigurationItem>();

        public string Summary { get; set; }

        public string Description { get; set; }

        public string Review { get; set; }

        private global::Auriga.IContainerList<global::Auriga.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.IAbstractPropertyValue>(this);

        private global::Auriga.IContainerList<global::Auriga.Capellacore.IEnumerationPropertyType> backingOwnedEnumerationPropertyTypes;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes => this.backingOwnedEnumerationPropertyTypes ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.IEnumerationPropertyType>(this);

        public global::System.Collections.Generic.List<global::Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new global::System.Collections.Generic.List<global::Auriga.Capellacore.IAbstractPropertyValue>();

        private global::Auriga.IContainerList<global::Auriga.Capellacore.IPropertyValueGroup> backingOwnedPropertyValueGroups;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups => this.backingOwnedPropertyValueGroups ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.IPropertyValueGroup>(this);

        public global::System.Collections.Generic.List<global::Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new global::System.Collections.Generic.List<global::Auriga.Capellacore.IPropertyValueGroup>();

        public global::Auriga.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        public global::System.Collections.Generic.List<global::Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new global::System.Collections.Generic.List<global::Auriga.Capellacore.IEnumerationPropertyLiteral>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Modellingcore.IAbstractTrace> IncomingTraces => global::System.Linq.Enumerable.Empty<global::Auriga.Modellingcore.IAbstractTrace>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => global::System.Linq.Enumerable.Empty<global::Auriga.Modellingcore.IAbstractTrace>();

        public string Sid { get; set; }

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Modellingcore.IAbstractConstraint> Constraints => global::System.Linq.Enumerable.Empty<global::Auriga.Modellingcore.IAbstractConstraint>();

        private global::Auriga.IContainerList<global::Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        public global::Auriga.IContainerList<global::Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new global::Auriga.ContainerList<global::Auriga.Modellingcore.IAbstractConstraint>(this);

        private global::Auriga.IContainerList<global::Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        public global::Auriga.IContainerList<global::Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new global::Auriga.ContainerList<global::Auriga.Modellingcore.IModelElement>(this);

        private global::Auriga.IContainerList<global::Auriga.Emde.IElementExtension> backingOwnedExtensions;

        public global::Auriga.IContainerList<global::Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new global::Auriga.ContainerList<global::Auriga.Emde.IElementExtension>(this);

        public bool? VisibleInDoc { get; set; }

        public bool? VisibleInLM { get; set; }

        public bool Actor { get; set; }

        public bool Human { get; set; }

        private global::Auriga.IContainerList<global::Auriga.Cs.IInterfaceUse> backingOwnedInterfaceUses;

        public global::Auriga.IContainerList<global::Auriga.Cs.IInterfaceUse> OwnedInterfaceUses => this.backingOwnedInterfaceUses ??= new global::Auriga.ContainerList<global::Auriga.Cs.IInterfaceUse>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterfaceUse> UsedInterfaceLinks => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IInterfaceUse>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> UsedInterfaces => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IInterface>();

        private global::Auriga.IContainerList<global::Auriga.Cs.IInterfaceImplementation> backingOwnedInterfaceImplementations;

        public global::Auriga.IContainerList<global::Auriga.Cs.IInterfaceImplementation> OwnedInterfaceImplementations => this.backingOwnedInterfaceImplementations ??= new global::Auriga.ContainerList<global::Auriga.Cs.IInterfaceImplementation>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterfaceImplementation> ImplementedInterfaceLinks => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IInterfaceImplementation>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> ImplementedInterfaces => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IInterface>();

        private global::Auriga.IContainerList<global::Auriga.Cs.IComponentRealization> backingOwnedComponentRealizations;

        public global::Auriga.IContainerList<global::Auriga.Cs.IComponentRealization> OwnedComponentRealizations => this.backingOwnedComponentRealizations ??= new global::Auriga.ContainerList<global::Auriga.Cs.IComponentRealization>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IComponent> RealizedComponents => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IComponent>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IComponent> RealizingComponents => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IComponent>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> ProvidedInterfaces => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IInterface>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> RequiredInterfaces => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IInterface>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentPort> ContainedComponentPorts => global::System.Linq.Enumerable.Empty<global::Auriga.Fa.IComponentPort>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPart> ContainedParts => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IPart>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPhysicalPort> ContainedPhysicalPorts => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IPhysicalPort>();

        private global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalPath> backingOwnedPhysicalPath;

        public global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalPath> OwnedPhysicalPath => this.backingOwnedPhysicalPath ??= new global::Auriga.ContainerList<global::Auriga.Cs.IPhysicalPath>(this);

        private global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalLink> backingOwnedPhysicalLinks;

        public global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalLink> OwnedPhysicalLinks => this.backingOwnedPhysicalLinks ??= new global::Auriga.ContainerList<global::Auriga.Cs.IPhysicalLink>(this);

        private global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalLinkCategory> backingOwnedPhysicalLinkCategories;

        public global::Auriga.IContainerList<global::Auriga.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories => this.backingOwnedPhysicalLinkCategories ??= new global::Auriga.ContainerList<global::Auriga.Cs.IPhysicalLinkCategory>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPart> RepresentingParts => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IPart>();

        public global::Auriga.Capellacommon.IAbstractCapabilityPkg OwnedAbstractCapabilityPkg { get; set; }

        public global::Auriga.Cs.IInterfacePkg OwnedInterfacePkg { get; set; }

        public global::Auriga.Information.IDataPkg OwnedDataPkg { get; set; }

        private global::Auriga.IContainerList<global::Auriga.Capellacommon.IStateMachine> backingOwnedStateMachines;

        public global::Auriga.IContainerList<global::Auriga.Capellacommon.IStateMachine> OwnedStateMachines => this.backingOwnedStateMachines ??= new global::Auriga.ContainerList<global::Auriga.Capellacommon.IStateMachine>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.ITypedElement> TypedElements => global::System.Linq.Enumerable.Empty<global::Auriga.Capellacore.ITypedElement>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Modellingcore.IAbstractTypedElement> AbstractTypedElements => global::System.Linq.Enumerable.Empty<global::Auriga.Modellingcore.IAbstractTypedElement>();

        public string Name { get; set; }

        private global::Auriga.IContainerList<global::Auriga.Capellacore.ITrace> backingOwnedTraces;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.ITrace>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.IGenericTrace> ContainedGenericTraces => global::System.Linq.Enumerable.Empty<global::Auriga.Capellacommon.IGenericTrace>();

        private global::Auriga.IContainerList<global::Auriga.Capellacore.INamingRule> backingNamingRules;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.INamingRule> NamingRules => this.backingNamingRules ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.INamingRule>(this);

        private global::Auriga.IContainerList<global::Auriga.Fa.IComponentFunctionalAllocation> backingOwnedFunctionalAllocation;

        public global::Auriga.IContainerList<global::Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocation => this.backingOwnedFunctionalAllocation ??= new global::Auriga.ContainerList<global::Auriga.Fa.IComponentFunctionalAllocation>(this);

        private global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchange> backingOwnedComponentExchanges;

        public global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchange> OwnedComponentExchanges => this.backingOwnedComponentExchanges ??= new global::Auriga.ContainerList<global::Auriga.Fa.IComponentExchange>(this);

        private global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchangeCategory> backingOwnedComponentExchangeCategories;

        public global::Auriga.IContainerList<global::Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories => this.backingOwnedComponentExchangeCategories ??= new global::Auriga.ContainerList<global::Auriga.Fa.IComponentExchangeCategory>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentFunctionalAllocation> FunctionalAllocations => global::System.Linq.Enumerable.Empty<global::Auriga.Fa.IComponentFunctionalAllocation>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunction> AllocatedFunctions => global::System.Linq.Enumerable.Empty<global::Auriga.Fa.IAbstractFunction>();

        public global::System.Collections.Generic.List<global::Auriga.Fa.IExchangeLink> InExchangeLinks { get; } = new global::System.Collections.Generic.List<global::Auriga.Fa.IExchangeLink>();

        public global::System.Collections.Generic.List<global::Auriga.Fa.IExchangeLink> OutExchangeLinks { get; } = new global::System.Collections.Generic.List<global::Auriga.Fa.IExchangeLink>();

        private global::Auriga.IContainerList<global::Auriga.Capellacore.IFeature> backingOwnedFeatures;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.IFeature> OwnedFeatures => this.backingOwnedFeatures ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.IFeature>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IProperty> ContainedProperties => global::System.Linq.Enumerable.Empty<global::Auriga.Information.IProperty>();

        public bool? Abstract { get; set; }

        private global::Auriga.IContainerList<global::Auriga.Capellacore.IGeneralization> backingOwnedGeneralizations;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.IGeneralization> OwnedGeneralizations => this.backingOwnedGeneralizations ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.IGeneralization>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.IGeneralization> SuperGeneralizations => global::System.Linq.Enumerable.Empty<global::Auriga.Capellacore.IGeneralization>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.IGeneralization> SubGeneralizations => global::System.Linq.Enumerable.Empty<global::Auriga.Capellacore.IGeneralization>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.IGeneralizableElement> Super => global::System.Linq.Enumerable.Empty<global::Auriga.Capellacore.IGeneralizableElement>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.IGeneralizableElement> Sub => global::System.Linq.Enumerable.Empty<global::Auriga.Capellacore.IGeneralizableElement>();

        private global::Auriga.IContainerList<global::Auriga.Cs.IInterfaceAllocation> backingOwnedInterfaceAllocations;

        public global::Auriga.IContainerList<global::Auriga.Cs.IInterfaceAllocation> OwnedInterfaceAllocations => this.backingOwnedInterfaceAllocations ??= new global::Auriga.ContainerList<global::Auriga.Cs.IInterfaceAllocation>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterfaceAllocation> ProvisionedInterfaceAllocations => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IInterfaceAllocation>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IInterface> AllocatedInterfaces => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IInterface>();

        private global::Auriga.IContainerList<global::Auriga.Information.Communication.ICommunicationLink> backingOwnedCommunicationLinks;

        public global::Auriga.IContainerList<global::Auriga.Information.Communication.ICommunicationLink> OwnedCommunicationLinks => this.backingOwnedCommunicationLinks ??= new global::Auriga.ContainerList<global::Auriga.Information.Communication.ICommunicationLink>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Produce => global::System.Linq.Enumerable.Empty<global::Auriga.Information.Communication.ICommunicationLink>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Consume => global::System.Linq.Enumerable.Empty<global::Auriga.Information.Communication.ICommunicationLink>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Send => global::System.Linq.Enumerable.Empty<global::Auriga.Information.Communication.ICommunicationLink>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Receive => global::System.Linq.Enumerable.Empty<global::Auriga.Information.Communication.ICommunicationLink>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Call => global::System.Linq.Enumerable.Empty<global::Auriga.Information.Communication.ICommunicationLink>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Execute => global::System.Linq.Enumerable.Empty<global::Auriga.Information.Communication.ICommunicationLink>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Write => global::System.Linq.Enumerable.Empty<global::Auriga.Information.Communication.ICommunicationLink>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Access => global::System.Linq.Enumerable.Empty<global::Auriga.Information.Communication.ICommunicationLink>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Acquire => global::System.Linq.Enumerable.Empty<global::Auriga.Information.Communication.ICommunicationLink>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Communication.ICommunicationLink> Transmit => global::System.Linq.Enumerable.Empty<global::Auriga.Information.Communication.ICommunicationLink>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.ICapabilityRealizationInvolvement> CapabilityRealizationInvolvements => global::System.Linq.Enumerable.Empty<global::Auriga.Capellacommon.ICapabilityRealizationInvolvement>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations => global::System.Linq.Enumerable.Empty<global::Auriga.La.ICapabilityRealization>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.IInvolvement> InvolvingInvolvements => global::System.Linq.Enumerable.Empty<global::Auriga.Capellacore.IInvolvement>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IAbstractDeploymentLink> DeployingLinks => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IAbstractDeploymentLink>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IAbstractDeploymentLink> DeploymentLinks => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IAbstractDeploymentLink>();

    }
}
