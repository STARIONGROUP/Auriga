// ------------------------------------------------------------------------------------------------
// <copyright file="Entity.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Entity</c> class.
    /// </summary>
    public partial class Entity : Auriga.Core.AurigaElement, Auriga.Model.Oa.IEntity
    {
        /// <summary>
        /// Gets or sets the abstract.
        /// </summary>
        public bool? Abstract { get; set; }

        /// <summary>
        /// Gets the abstract typed elements.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTypedElement>();

        /// <summary>
        /// Gets the access.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Access => Enumerable.Empty<Auriga.Model.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the acquire.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Acquire => Enumerable.Empty<Auriga.Model.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets or sets the actor.
        /// </summary>
        public bool Actor { get; set; }

        /// <summary>
        /// Gets or sets the actual location.
        /// </summary>
        public Auriga.Model.Oa.ILocation ActualLocation { get; set; }

        /// <summary>
        /// Gets the allocated functions.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IAbstractFunction> AllocatedFunctions => Enumerable.Empty<Auriga.Model.Fa.IAbstractFunction>();

        /// <summary>
        /// Gets the allocated interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> AllocatedInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets the allocated operational activities.
        /// </summary>
        public IEnumerable<Auriga.Model.Oa.IOperationalActivity> AllocatedOperationalActivities => Enumerable.Empty<Auriga.Model.Oa.IOperationalActivity>();

        /// <summary>
        /// Gets the allocated roles.
        /// </summary>
        public IEnumerable<Auriga.Model.Oa.IRole> AllocatedRoles => Enumerable.Empty<Auriga.Model.Oa.IRole>();

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Model.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Model.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Model.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Model.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the call.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Call => Enumerable.Empty<Auriga.Model.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the composing links.
        /// </summary>
        public List<Auriga.Model.Oa.IItemInConcept> ComposingLinks { get; } = new List<Auriga.Model.Oa.IItemInConcept>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets the consume.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Consume => Enumerable.Empty<Auriga.Model.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the contained component ports.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentPort> ContainedComponentPorts => Enumerable.Empty<Auriga.Model.Fa.IComponentPort>();

        /// <summary>
        /// Gets the contained generic traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Model.Capellacommon.IGenericTrace>();

        /// <summary>
        /// Gets the contained parts.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IPart> ContainedParts => Enumerable.Empty<Auriga.Model.Cs.IPart>();

        /// <summary>
        /// Gets the contained physical ports.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IPhysicalPort> ContainedPhysicalPorts => Enumerable.Empty<Auriga.Model.Cs.IPhysicalPort>();

        /// <summary>
        /// Gets the contained properties.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.IProperty> ContainedProperties => Enumerable.Empty<Auriga.Model.Information.IProperty>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the execute.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Execute => Enumerable.Empty<Auriga.Model.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the functional allocations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentFunctionalAllocation> FunctionalAllocations => Enumerable.Empty<Auriga.Model.Fa.IComponentFunctionalAllocation>();

        /// <summary>
        /// Gets or sets the human.
        /// </summary>
        public bool Human { get; set; }

        /// <summary>
        /// Gets the implemented interface links.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterfaceImplementation> ImplementedInterfaceLinks => Enumerable.Empty<Auriga.Model.Cs.IInterfaceImplementation>();

        /// <summary>
        /// Gets the implemented interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> ImplementedInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets the in exchange links.
        /// </summary>
        public List<Auriga.Model.Fa.IExchangeLink> InExchangeLinks { get; } = new List<Auriga.Model.Fa.IExchangeLink>();

        /// <summary>
        /// Gets the incoming information flows.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractInformationFlow> IncomingInformationFlows => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractInformationFlow>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the information flows.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractInformationFlow> InformationFlows => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractInformationFlow>();

        /// <summary>
        /// Gets the involving involvements.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Model.Capellacore.IInvolvement>();

        /// <summary>
        /// Gets the involving operational capabilities.
        /// </summary>
        public IEnumerable<Auriga.Model.Oa.IOperationalCapability> InvolvingOperationalCapabilities => Enumerable.Empty<Auriga.Model.Oa.IOperationalCapability>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the naming rules.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.INamingRule> NamingRules => this.backingNamingRules ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.INamingRule>(this);

        /// <summary>
        /// Backing field for <see cref="NamingRules"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.INamingRule> backingNamingRules;

        /// <summary>
        /// Gets the organisational unit memberships.
        /// </summary>
        public List<Auriga.Model.Oa.IOrganisationalUnitComposition> OrganisationalUnitMemberships { get; } = new List<Auriga.Model.Oa.IOrganisationalUnitComposition>();

        /// <summary>
        /// Gets the out exchange links.
        /// </summary>
        public List<Auriga.Model.Fa.IExchangeLink> OutExchangeLinks { get; } = new List<Auriga.Model.Fa.IExchangeLink>();

        /// <summary>
        /// Gets the outgoing information flows.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractInformationFlow> OutgoingInformationFlows => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractInformationFlow>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets or sets the owned abstract capability pkg.
        /// </summary>
        public Auriga.Model.Capellacommon.IAbstractCapabilityPkg OwnedAbstractCapabilityPkg
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
        private Auriga.Model.Capellacommon.IAbstractCapabilityPkg backingOwnedAbstractCapabilityPkg;

        /// <summary>
        /// Gets the owned communication links.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Information.Communication.ICommunicationLink> OwnedCommunicationLinks => this.backingOwnedCommunicationLinks ??= new Auriga.Core.ContainerList<Auriga.Model.Information.Communication.ICommunicationLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedCommunicationLinks"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Information.Communication.ICommunicationLink> backingOwnedCommunicationLinks;

        /// <summary>
        /// Gets the owned communication means.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Oa.ICommunicationMean> OwnedCommunicationMeans => this.backingOwnedCommunicationMeans ??= new Auriga.Core.ContainerList<Auriga.Model.Oa.ICommunicationMean>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedCommunicationMeans"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Oa.ICommunicationMean> backingOwnedCommunicationMeans;

        /// <summary>
        /// Gets the owned component exchange categories.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories => this.backingOwnedComponentExchangeCategories ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IComponentExchangeCategory>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeCategories"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeCategory> backingOwnedComponentExchangeCategories;

        /// <summary>
        /// Gets the owned component exchanges.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchange> OwnedComponentExchanges => this.backingOwnedComponentExchanges ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IComponentExchange>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchanges"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchange> backingOwnedComponentExchanges;

        /// <summary>
        /// Gets the owned component realizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Cs.IComponentRealization> OwnedComponentRealizations => this.backingOwnedComponentRealizations ??= new Auriga.Core.ContainerList<Auriga.Model.Cs.IComponentRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentRealizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Cs.IComponentRealization> backingOwnedComponentRealizations;

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.Core.ContainerList<Auriga.Model.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        /// <summary>
        /// Gets or sets the owned data pkg.
        /// </summary>
        public Auriga.Model.Information.IDataPkg OwnedDataPkg
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
        private Auriga.Model.Information.IDataPkg backingOwnedDataPkg;

        /// <summary>
        /// Gets the owned entities.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Oa.IEntity> OwnedEntities => this.backingOwnedEntities ??= new Auriga.Core.ContainerList<Auriga.Model.Oa.IEntity>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedEntities"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Oa.IEntity> backingOwnedEntities;

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
        /// Gets the owned features.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IFeature> OwnedFeatures => this.backingOwnedFeatures ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IFeature>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFeatures"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IFeature> backingOwnedFeatures;

        /// <summary>
        /// Gets the owned functional allocation.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocation => this.backingOwnedFunctionalAllocation ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IComponentFunctionalAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalAllocation"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentFunctionalAllocation> backingOwnedFunctionalAllocation;

        /// <summary>
        /// Gets the owned generalizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IGeneralization> OwnedGeneralizations => this.backingOwnedGeneralizations ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IGeneralization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedGeneralizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IGeneralization> backingOwnedGeneralizations;

        /// <summary>
        /// Gets the owned interface allocations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Cs.IInterfaceAllocation> OwnedInterfaceAllocations => this.backingOwnedInterfaceAllocations ??= new Auriga.Core.ContainerList<Auriga.Model.Cs.IInterfaceAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedInterfaceAllocations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Cs.IInterfaceAllocation> backingOwnedInterfaceAllocations;

        /// <summary>
        /// Gets the owned interface implementations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Cs.IInterfaceImplementation> OwnedInterfaceImplementations => this.backingOwnedInterfaceImplementations ??= new Auriga.Core.ContainerList<Auriga.Model.Cs.IInterfaceImplementation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedInterfaceImplementations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Cs.IInterfaceImplementation> backingOwnedInterfaceImplementations;

        /// <summary>
        /// Gets or sets the owned interface pkg.
        /// </summary>
        public Auriga.Model.Cs.IInterfacePkg OwnedInterfacePkg
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
        private Auriga.Model.Cs.IInterfacePkg backingOwnedInterfacePkg;

        /// <summary>
        /// Gets the owned interface uses.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Cs.IInterfaceUse> OwnedInterfaceUses => this.backingOwnedInterfaceUses ??= new Auriga.Core.ContainerList<Auriga.Model.Cs.IInterfaceUse>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedInterfaceUses"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Cs.IInterfaceUse> backingOwnedInterfaceUses;

        /// <summary>
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.Core.ContainerList<Auriga.Model.Modellingcore.IModelElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMigratedElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets the owned physical link categories.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalLinkCategory> OwnedPhysicalLinkCategories => this.backingOwnedPhysicalLinkCategories ??= new Auriga.Core.ContainerList<Auriga.Model.Cs.IPhysicalLinkCategory>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalLinkCategories"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalLinkCategory> backingOwnedPhysicalLinkCategories;

        /// <summary>
        /// Gets the owned physical links.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalLink> OwnedPhysicalLinks => this.backingOwnedPhysicalLinks ??= new Auriga.Core.ContainerList<Auriga.Model.Cs.IPhysicalLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalLinks"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalLink> backingOwnedPhysicalLinks;

        /// <summary>
        /// Gets the owned physical path.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalPath> OwnedPhysicalPath => this.backingOwnedPhysicalPath ??= new Auriga.Core.ContainerList<Auriga.Model.Cs.IPhysicalPath>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalPath"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Cs.IPhysicalPath> backingOwnedPhysicalPath;

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
        /// Gets the owned role allocations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Oa.IRoleAllocation> OwnedRoleAllocations => this.backingOwnedRoleAllocations ??= new Auriga.Core.ContainerList<Auriga.Model.Oa.IRoleAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRoleAllocations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Oa.IRoleAllocation> backingOwnedRoleAllocations;

        /// <summary>
        /// Gets the owned state machines.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IStateMachine> OwnedStateMachines => this.backingOwnedStateMachines ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacommon.IStateMachine>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedStateMachines"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IStateMachine> backingOwnedStateMachines;

        /// <summary>
        /// Gets the owned traces.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.ITrace>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTraces"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets the produce.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Produce => Enumerable.Empty<Auriga.Model.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the provided interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> ProvidedInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets the provisioned interface allocations.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterfaceAllocation> ProvisionedInterfaceAllocations => Enumerable.Empty<Auriga.Model.Cs.IInterfaceAllocation>();

        /// <summary>
        /// Gets the realized components.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IComponent> RealizedComponents => Enumerable.Empty<Auriga.Model.Cs.IComponent>();

        /// <summary>
        /// Gets the realizing components.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IComponent> RealizingComponents => Enumerable.Empty<Auriga.Model.Cs.IComponent>();

        /// <summary>
        /// Gets the realizing system components.
        /// </summary>
        public IEnumerable<Auriga.Model.Ctx.ISystemComponent> RealizingSystemComponents => Enumerable.Empty<Auriga.Model.Ctx.ISystemComponent>();

        /// <summary>
        /// Gets the receive.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Receive => Enumerable.Empty<Auriga.Model.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the representing parts.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IPart> RepresentingParts => Enumerable.Empty<Auriga.Model.Cs.IPart>();

        /// <summary>
        /// Gets the required interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> RequiredInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Gets the role allocations.
        /// </summary>
        public IEnumerable<Auriga.Model.Oa.IRoleAllocation> RoleAllocations => Enumerable.Empty<Auriga.Model.Oa.IRoleAllocation>();

        /// <summary>
        /// Gets the send.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Send => Enumerable.Empty<Auriga.Model.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public Auriga.Model.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        /// <summary>
        /// Gets the sub.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.IGeneralizableElement> Sub => Enumerable.Empty<Auriga.Model.Capellacore.IGeneralizableElement>();

        /// <summary>
        /// Gets the sub entities.
        /// </summary>
        public IEnumerable<Auriga.Model.Oa.IEntity> SubEntities => Enumerable.Empty<Auriga.Model.Oa.IEntity>();

        /// <summary>
        /// Gets the sub generalizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.IGeneralization> SubGeneralizations => Enumerable.Empty<Auriga.Model.Capellacore.IGeneralization>();

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets the super.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.IGeneralizableElement> Super => Enumerable.Empty<Auriga.Model.Capellacore.IGeneralizableElement>();

        /// <summary>
        /// Gets the super generalizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.IGeneralization> SuperGeneralizations => Enumerable.Empty<Auriga.Model.Capellacore.IGeneralization>();

        /// <summary>
        /// Gets the transmit.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Transmit => Enumerable.Empty<Auriga.Model.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the typed elements.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.ITypedElement> TypedElements => Enumerable.Empty<Auriga.Model.Capellacore.ITypedElement>();

        /// <summary>
        /// Gets the used interface links.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterfaceUse> UsedInterfaceLinks => Enumerable.Empty<Auriga.Model.Cs.IInterfaceUse>();

        /// <summary>
        /// Gets the used interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> UsedInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

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
        public IEnumerable<Auriga.Model.Information.Communication.ICommunicationLink> Write => Enumerable.Empty<Auriga.Model.Information.Communication.ICommunicationLink>();

        /// <summary>
        /// Gets the elements directly contained by this <c>Entity</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
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

            foreach (var element in this.OwnedCommunicationMeans)
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

            foreach (var element in this.OwnedEntities)
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

            foreach (var element in this.OwnedRoleAllocations)
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
