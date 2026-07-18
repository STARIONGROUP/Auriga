// ------------------------------------------------------------------------------------------------
// <copyright file="Interface.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Interface</c> class.
    /// </summary>
    public partial class Interface : Auriga.Core.AurigaElement, Auriga.Model.Cs.IInterface
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
        /// Gets the allocated interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> AllocatedInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets the allocating components.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IComponent> AllocatingComponents => Enumerable.Empty<Auriga.Model.Cs.IComponent>();

        /// <summary>
        /// Gets the allocating interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> AllocatingInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

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
        /// Gets the contained generic traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Model.Capellacommon.IGenericTrace>();

        /// <summary>
        /// Gets the contained operations.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.IOperation> ContainedOperations => Enumerable.Empty<Auriga.Model.Information.IOperation>();

        /// <summary>
        /// Gets the contained properties.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.IProperty> ContainedProperties => Enumerable.Empty<Auriga.Model.Information.IProperty>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the exchange items.
        /// </summary>
        public IEnumerable<Auriga.Model.Information.IExchangeItem> ExchangeItems => Enumerable.Empty<Auriga.Model.Information.IExchangeItem>();

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets or sets the final.
        /// </summary>
        public bool? Final { get; set; }

        /// <summary>
        /// Gets the implementor components.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IComponent> ImplementorComponents => Enumerable.Empty<Auriga.Model.Cs.IComponent>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the interface implementations.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterfaceImplementation> InterfaceImplementations => Enumerable.Empty<Auriga.Model.Cs.IInterfaceImplementation>();

        /// <summary>
        /// Gets the interface uses.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterfaceUse> InterfaceUses => Enumerable.Empty<Auriga.Model.Cs.IInterfaceUse>();

        /// <summary>
        /// Gets or sets the mechanism.
        /// </summary>
        public string Mechanism { get; set; }

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
        /// Gets the nested general classes.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IGeneralClass> NestedGeneralClasses => this.backingNestedGeneralClasses ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IGeneralClass>(this);

        /// <summary>
        /// Backing field for <see cref="NestedGeneralClasses"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IGeneralClass> backingNestedGeneralClasses;

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

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
        /// Gets the owned exchange item allocations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Cs.IExchangeItemAllocation> OwnedExchangeItemAllocations => this.backingOwnedExchangeItemAllocations ??= new Auriga.Core.ContainerList<Auriga.Model.Cs.IExchangeItemAllocation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExchangeItemAllocations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Cs.IExchangeItemAllocation> backingOwnedExchangeItemAllocations;

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
        /// Gets the owned traces.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.ITrace>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTraces"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets the providing component ports.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentPort> ProvidingComponentPorts => Enumerable.Empty<Auriga.Model.Fa.IComponentPort>();

        /// <summary>
        /// Gets the providing components.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IComponent> ProvidingComponents => Enumerable.Empty<Auriga.Model.Cs.IComponent>();

        /// <summary>
        /// Gets the provisioned interface allocations.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterfaceAllocation> ProvisionedInterfaceAllocations => Enumerable.Empty<Auriga.Model.Cs.IInterfaceAllocation>();

        /// <summary>
        /// Gets the provisioning interface allocations.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterfaceAllocation> ProvisioningInterfaceAllocations => Enumerable.Empty<Auriga.Model.Cs.IInterfaceAllocation>();

        /// <summary>
        /// Gets the realized context interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> RealizedContextInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets the realized logical interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> RealizedLogicalInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets the realizing logical interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> RealizingLogicalInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets the realizing physical interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> RealizingPhysicalInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets the requiring component ports.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentPort> RequiringComponentPorts => Enumerable.Empty<Auriga.Model.Fa.IComponentPort>();

        /// <summary>
        /// Gets the requiring components.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IComponent> RequiringComponents => Enumerable.Empty<Auriga.Model.Cs.IComponent>();

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
        /// Gets or sets the structural.
        /// </summary>
        public bool? Structural { get; set; } = true;

        /// <summary>
        /// Gets the sub.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.IGeneralizableElement> Sub => Enumerable.Empty<Auriga.Model.Capellacore.IGeneralizableElement>();

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
        /// Gets the typed elements.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.ITypedElement> TypedElements => Enumerable.Empty<Auriga.Model.Capellacore.ITypedElement>();

        /// <summary>
        /// Gets the user components.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IComponent> UserComponents => Enumerable.Empty<Auriga.Model.Cs.IComponent>();

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        public Auriga.Model.Capellacore.VisibilityKind? Visibility { get; set; }

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; } = true;

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; } = true;

        /// <summary>
        /// Gets the elements directly contained by this <c>Interface</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.NamingRules)
            {
                yield return element;
            }

            foreach (var element in this.NestedGeneralClasses)
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

            foreach (var element in this.OwnedExchangeItemAllocations)
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

            foreach (var element in this.OwnedGeneralizations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedInterfaceAllocations)
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
