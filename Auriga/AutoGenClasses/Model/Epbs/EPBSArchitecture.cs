// ------------------------------------------------------------------------------------------------
// <copyright file="EPBSArchitecture.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Epbs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>EPBSArchitecture</c> class.
    /// </summary>
    public partial class EPBSArchitecture : Auriga.Core.AurigaElement, Auriga.Model.Epbs.IEPBSArchitecture
    {
        /// <summary>
        /// Gets the allocated architectures.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IBlockArchitecture> AllocatedArchitectures => Enumerable.Empty<Auriga.Model.Cs.IBlockArchitecture>();

        /// <summary>
        /// Gets the allocated physical architecture realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Epbs.IPhysicalArchitectureRealization> AllocatedPhysicalArchitectureRealizations => Enumerable.Empty<Auriga.Model.Epbs.IPhysicalArchitectureRealization>();

        /// <summary>
        /// Gets the allocated physical architectures.
        /// </summary>
        public IEnumerable<Auriga.Model.Pa.IPhysicalArchitecture> AllocatedPhysicalArchitectures => Enumerable.Empty<Auriga.Model.Pa.IPhysicalArchitecture>();

        /// <summary>
        /// Gets the allocating architectures.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IBlockArchitecture> AllocatingArchitectures => Enumerable.Empty<Auriga.Model.Cs.IBlockArchitecture>();

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Model.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Model.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Model.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Model.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets the contained capability realization pkg.
        /// </summary>
        public Auriga.Model.La.ICapabilityRealizationPkg ContainedCapabilityRealizationPkg => default;

        /// <summary>
        /// Gets the contained generic traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Model.Capellacommon.IGenericTrace>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

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
        /// Gets the owned component exchange categories.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeCategory> OwnedComponentExchangeCategories => this.backingOwnedComponentExchangeCategories ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IComponentExchangeCategory>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeCategories"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeCategory> backingOwnedComponentExchangeCategories;

        /// <summary>
        /// Gets the owned component exchange realizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeRealization> OwnedComponentExchangeRealizations => this.backingOwnedComponentExchangeRealizations ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IComponentExchangeRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchangeRealizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchangeRealization> backingOwnedComponentExchangeRealizations;

        /// <summary>
        /// Gets the owned component exchanges.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchange> OwnedComponentExchanges => this.backingOwnedComponentExchanges ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IComponentExchange>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedComponentExchanges"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentExchange> backingOwnedComponentExchanges;

        /// <summary>
        /// Gets or sets the owned configuration item pkg.
        /// </summary>
        public Auriga.Model.Epbs.IConfigurationItemPkg OwnedConfigurationItemPkg
        {
            get => this.backingOwnedConfigurationItemPkg;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedConfigurationItemPkg = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedConfigurationItemPkg"/>.
        /// </summary>
        private Auriga.Model.Epbs.IConfigurationItemPkg backingOwnedConfigurationItemPkg;

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
        /// Gets or sets the owned function pkg.
        /// </summary>
        public Auriga.Model.Fa.IFunctionPkg OwnedFunctionPkg
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
        private Auriga.Model.Fa.IFunctionPkg backingOwnedFunctionPkg;

        /// <summary>
        /// Gets the owned functional allocations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentFunctionalAllocation> OwnedFunctionalAllocations => this.backingOwnedFunctionalAllocations ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IComponentFunctionalAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalAllocations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IComponentFunctionalAllocation> backingOwnedFunctionalAllocations;

        /// <summary>
        /// Gets the owned functional links.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IExchangeLink> OwnedFunctionalLinks => this.backingOwnedFunctionalLinks ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IExchangeLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalLinks"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IExchangeLink> backingOwnedFunctionalLinks;

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
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.Core.ContainerList<Auriga.Model.Modellingcore.IModelElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMigratedElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets the owned physical architecture realizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Epbs.IPhysicalArchitectureRealization> OwnedPhysicalArchitectureRealizations => this.backingOwnedPhysicalArchitectureRealizations ??= new Auriga.Core.ContainerList<Auriga.Model.Epbs.IPhysicalArchitectureRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalArchitectureRealizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Epbs.IPhysicalArchitectureRealization> backingOwnedPhysicalArchitectureRealizations;

        /// <summary>
        /// Gets the owned property value groups.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups => this.backingOwnedPropertyValueGroups ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IPropertyValueGroup>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValueGroups"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IPropertyValueGroup> backingOwnedPropertyValueGroups;

        /// <summary>
        /// Gets the owned property value pkgs.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IPropertyValuePkg> OwnedPropertyValuePkgs => this.backingOwnedPropertyValuePkgs ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IPropertyValuePkg>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValuePkgs"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IPropertyValuePkg> backingOwnedPropertyValuePkgs;

        /// <summary>
        /// Gets the owned property values.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValues"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        /// <summary>
        /// Gets the owned traces.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.ITrace>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTraces"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets the provisioned architecture allocations.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IArchitectureAllocation> ProvisionedArchitectureAllocations => Enumerable.Empty<Auriga.Model.Cs.IArchitectureAllocation>();

        /// <summary>
        /// Gets the provisioning architecture allocations.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IArchitectureAllocation> ProvisioningArchitectureAllocations => Enumerable.Empty<Auriga.Model.Cs.IArchitectureAllocation>();

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
        public Auriga.Model.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets the system.
        /// </summary>
        public Auriga.Model.Cs.IComponent System => default;

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>EPBSArchitecture</c>.
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

            if (this.OwnedConfigurationItemPkg != null)
            {
                yield return this.OwnedConfigurationItemPkg;
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

            foreach (var element in this.OwnedMigratedElements)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPhysicalArchitectureRealizations)
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
