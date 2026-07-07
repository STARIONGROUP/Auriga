// ------------------------------------------------------------------------------------------------
// <copyright file="PhysicalArchitecture.cs" company="Starion Group S.A.">
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

    public partial class PhysicalArchitecture : Auriga.AurigaElement, Auriga.Pa.IPhysicalArchitecture
    {
        public Auriga.Pa.IPhysicalComponentPkg OwnedPhysicalComponentPkg { get; set; }

        public Auriga.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg => default;

        public Auriga.Pa.IPhysicalFunctionPkg ContainedPhysicalFunctionPkg => default;

        private Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> backingOwnedDeployments;

        public Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeployments => this.backingOwnedDeployments ??= new Auriga.ContainerList<Auriga.Cs.IAbstractDeploymentLink>(this);

        private Auriga.IContainerList<Auriga.Pa.ILogicalArchitectureRealization> backingOwnedLogicalArchitectureRealizations;

        public Auriga.IContainerList<Auriga.Pa.ILogicalArchitectureRealization> OwnedLogicalArchitectureRealizations => this.backingOwnedLogicalArchitectureRealizations ??= new Auriga.ContainerList<Auriga.Pa.ILogicalArchitectureRealization>(this);

        public IEnumerable<Auriga.Pa.ILogicalArchitectureRealization> AllocatedLogicalArchitectureRealizations => Enumerable.Empty<Auriga.Pa.ILogicalArchitectureRealization>();

        public IEnumerable<Auriga.La.ILogicalArchitecture> AllocatedLogicalArchitectures => Enumerable.Empty<Auriga.La.ILogicalArchitecture>();

        public IEnumerable<Auriga.Epbs.IEPBSArchitecture> AllocatingEpbsArchitectures => Enumerable.Empty<Auriga.Epbs.IEPBSArchitecture>();

        public Auriga.Capellacommon.IAbstractCapabilityPkg OwnedAbstractCapabilityPkg { get; set; }

        public Auriga.Cs.IInterfacePkg OwnedInterfacePkg { get; set; }

        public Auriga.Information.IDataPkg OwnedDataPkg { get; set; }

        public IEnumerable<Auriga.Cs.IArchitectureAllocation> ProvisionedArchitectureAllocations => Enumerable.Empty<Auriga.Cs.IArchitectureAllocation>();

        public IEnumerable<Auriga.Cs.IArchitectureAllocation> ProvisioningArchitectureAllocations => Enumerable.Empty<Auriga.Cs.IArchitectureAllocation>();

        public IEnumerable<Auriga.Cs.IBlockArchitecture> AllocatedArchitectures => Enumerable.Empty<Auriga.Cs.IBlockArchitecture>();

        public IEnumerable<Auriga.Cs.IBlockArchitecture> AllocatingArchitectures => Enumerable.Empty<Auriga.Cs.IBlockArchitecture>();

        public Auriga.Cs.IComponent System => default;

        public Auriga.Fa.IFunctionPkg OwnedFunctionPkg { get; set; }

        private Auriga.IContainerList<Auriga.Fa.IComponentExchange> backingOwnedComponentExchanges;

        public Auriga.IContainerList<Auriga.Fa.IComponentExchange> OwnedComponentExchanges => this.backingOwnedComponentExchanges ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchange>(this);

        private Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> backingOwnedComponentExchangeCategories;

        public Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories => this.backingOwnedComponentExchangeCategories ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchangeCategory>(this);

        private Auriga.IContainerList<Auriga.Fa.IExchangeLink> backingOwnedFunctionalLinks;

        public Auriga.IContainerList<Auriga.Fa.IExchangeLink> OwnedFunctionalLinks => this.backingOwnedFunctionalLinks ??= new Auriga.ContainerList<Auriga.Fa.IExchangeLink>(this);

        private Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> backingOwnedFunctionalAllocations;

        public Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocations => this.backingOwnedFunctionalAllocations ??= new Auriga.ContainerList<Auriga.Fa.IComponentFunctionalAllocation>(this);

        private Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> backingOwnedComponentExchangeRealizations;

        public Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations => this.backingOwnedComponentExchangeRealizations ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchangeRealization>(this);

        private Auriga.IContainerList<Auriga.Capellacore.IPropertyValuePkg> backingOwnedPropertyValuePkgs;

        public Auriga.IContainerList<Auriga.Capellacore.IPropertyValuePkg> OwnedPropertyValuePkgs => this.backingOwnedPropertyValuePkgs ??= new Auriga.ContainerList<Auriga.Capellacore.IPropertyValuePkg>(this);

        private Auriga.IContainerList<Auriga.Capellacore.ITrace> backingOwnedTraces;

        public Auriga.IContainerList<Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.ContainerList<Auriga.Capellacore.ITrace>(this);

        public IEnumerable<Auriga.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Capellacommon.IGenericTrace>();

        private Auriga.IContainerList<Auriga.Capellacore.INamingRule> backingNamingRules;

        public Auriga.IContainerList<Auriga.Capellacore.INamingRule> NamingRules => this.backingNamingRules ??= new Auriga.ContainerList<Auriga.Capellacore.INamingRule>(this);

        public string Name { get; set; }

        public string Sid { get; set; }

        public IEnumerable<Auriga.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Modellingcore.IAbstractConstraint>();

        private Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        public Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        private Auriga.IContainerList<Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        public Auriga.IContainerList<Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.ContainerList<Auriga.Modellingcore.IModelElement>(this);

        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

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

        public bool? VisibleInDoc { get; set; }

        public bool? VisibleInLM { get; set; }

    }
}
