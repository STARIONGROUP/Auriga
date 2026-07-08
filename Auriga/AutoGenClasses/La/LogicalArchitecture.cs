// ------------------------------------------------------------------------------------------------
// <copyright file="LogicalArchitecture.cs" company="Starion Group S.A.">
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

namespace Auriga.La
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>LogicalArchitecture</c> class.
    /// </summary>
    public partial class LogicalArchitecture : Auriga.AurigaElement, Auriga.La.ILogicalArchitecture
    {
        /// <summary>
        /// Gets the allocated architectures.
        /// </summary>
        public IEnumerable<Auriga.Cs.IBlockArchitecture> AllocatedArchitectures => Enumerable.Empty<Auriga.Cs.IBlockArchitecture>();

        /// <summary>
        /// Gets the allocated system analyses.
        /// </summary>
        public IEnumerable<Auriga.Ctx.ISystemAnalysis> AllocatedSystemAnalyses => Enumerable.Empty<Auriga.Ctx.ISystemAnalysis>();

        /// <summary>
        /// Gets the allocated system analysis realizations.
        /// </summary>
        public IEnumerable<Auriga.La.ISystemAnalysisRealization> AllocatedSystemAnalysisRealizations => Enumerable.Empty<Auriga.La.ISystemAnalysisRealization>();

        /// <summary>
        /// Gets the allocating architectures.
        /// </summary>
        public IEnumerable<Auriga.Cs.IBlockArchitecture> AllocatingArchitectures => Enumerable.Empty<Auriga.Cs.IBlockArchitecture>();

        /// <summary>
        /// Gets the allocating physical architectures.
        /// </summary>
        public IEnumerable<Auriga.Pa.IPhysicalArchitecture> AllocatingPhysicalArchitectures => Enumerable.Empty<Auriga.Pa.IPhysicalArchitecture>();

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
        /// Gets the contained capability realization pkg.
        /// </summary>
        public Auriga.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg => default;

        /// <summary>
        /// Gets the contained generic traces.
        /// </summary>
        public IEnumerable<Auriga.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Capellacommon.IGenericTrace>();

        /// <summary>
        /// Gets the contained logical function pkg.
        /// </summary>
        public Auriga.La.ILogicalFunctionPkg ContainedLogicalFunctionPkg => default;

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

        /// <summary>
        /// Backing field for <see cref="NamingRules"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.INamingRule> backingNamingRules;

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
        /// Gets the owned component exchange categories.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories => this.backingOwnedComponentExchangeCategories ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchangeCategory>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeCategories"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IComponentExchangeCategory> backingOwnedComponentExchangeCategories;

        /// <summary>
        /// Gets the owned component exchange realizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations => this.backingOwnedComponentExchangeRealizations ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchangeRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeRealizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IComponentExchangeRealization> backingOwnedComponentExchangeRealizations;

        /// <summary>
        /// Gets the owned component exchanges.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentExchange> OwnedComponentExchanges => this.backingOwnedComponentExchanges ??= new Auriga.ContainerList<Auriga.Fa.IComponentExchange>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchanges"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IComponentExchange> backingOwnedComponentExchanges;

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
        /// Gets or sets the owned function pkg.
        /// </summary>
        public Auriga.Fa.IFunctionPkg OwnedFunctionPkg
        {
            get => this.backingOwnedFunctionPkg;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedFunctionPkg = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionPkg"/>.
        /// </summary>
        private Auriga.Fa.IFunctionPkg backingOwnedFunctionPkg;

        /// <summary>
        /// Gets the owned functional allocations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocations => this.backingOwnedFunctionalAllocations ??= new Auriga.ContainerList<Auriga.Fa.IComponentFunctionalAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalAllocations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IComponentFunctionalAllocation> backingOwnedFunctionalAllocations;

        /// <summary>
        /// Gets the owned functional links.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IExchangeLink> OwnedFunctionalLinks => this.backingOwnedFunctionalLinks ??= new Auriga.ContainerList<Auriga.Fa.IExchangeLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalLinks"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IExchangeLink> backingOwnedFunctionalLinks;

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
        /// Gets or sets the owned logical component pkg.
        /// </summary>
        public Auriga.La.ILogicalComponentPkg OwnedLogicalComponentPkg
        {
            get => this.backingOwnedLogicalComponentPkg;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedLogicalComponentPkg = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedLogicalComponentPkg"/>.
        /// </summary>
        private Auriga.La.ILogicalComponentPkg backingOwnedLogicalComponentPkg;

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
        /// Gets the owned property value pkgs.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IPropertyValuePkg> OwnedPropertyValuePkgs => this.backingOwnedPropertyValuePkgs ??= new Auriga.ContainerList<Auriga.Capellacore.IPropertyValuePkg>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValuePkgs"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IPropertyValuePkg> backingOwnedPropertyValuePkgs;

        /// <summary>
        /// Gets the owned property values.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.ContainerList<Auriga.Capellacore.IAbstractPropertyValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValues"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        /// <summary>
        /// Gets the owned system analysis realizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.La.ISystemAnalysisRealization> OwnedSystemAnalysisRealizations => this.backingOwnedSystemAnalysisRealizations ??= new Auriga.ContainerList<Auriga.La.ISystemAnalysisRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedSystemAnalysisRealizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.La.ISystemAnalysisRealization> backingOwnedSystemAnalysisRealizations;

        /// <summary>
        /// Gets the owned traces.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.ContainerList<Auriga.Capellacore.ITrace>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTraces"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets the provisioned architecture allocations.
        /// </summary>
        public IEnumerable<Auriga.Cs.IArchitectureAllocation> ProvisionedArchitectureAllocations => Enumerable.Empty<Auriga.Cs.IArchitectureAllocation>();

        /// <summary>
        /// Gets the provisioning architecture allocations.
        /// </summary>
        public IEnumerable<Auriga.Cs.IArchitectureAllocation> ProvisioningArchitectureAllocations => Enumerable.Empty<Auriga.Cs.IArchitectureAllocation>();

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
        /// Gets the system.
        /// </summary>
        public Auriga.Cs.IComponent System => default;

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>LogicalArchitecture</c>.
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

            foreach (var element in this.OwnedComponentExchangeCategories)
            {
                yield return element;
            }

            foreach (var element in this.OwnedComponentExchangeRealizations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedComponentExchanges)
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

            foreach (var element in this.OwnedEnumerationPropertyTypes)
            {
                yield return element;
            }

            foreach (var element in this.OwnedExtensions)
            {
                yield return element;
            }

            if (this.OwnedFunctionPkg != null)
            {
                yield return this.OwnedFunctionPkg;
            }

            foreach (var element in this.OwnedFunctionalAllocations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedFunctionalLinks)
            {
                yield return element;
            }

            if (this.OwnedInterfacePkg != null)
            {
                yield return this.OwnedInterfacePkg;
            }

            if (this.OwnedLogicalComponentPkg != null)
            {
                yield return this.OwnedLogicalComponentPkg;
            }

            foreach (var element in this.OwnedMigratedElements)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPropertyValueGroups)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPropertyValuePkgs)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPropertyValues)
            {
                yield return element;
            }

            foreach (var element in this.OwnedSystemAnalysisRealizations)
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
