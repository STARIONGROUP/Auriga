// ------------------------------------------------------------------------------------------------
// <copyright file="ExchangeItem.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ExchangeItem</c> class.
    /// </summary>
    public partial class ExchangeItem : Auriga.AurigaElement, Auriga.Information.IExchangeItem
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
        /// Gets the allocator interfaces.
        /// </summary>
        public IEnumerable<Auriga.Cs.IInterface> AllocatorInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

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
        /// Gets or sets the exchange mechanism.
        /// </summary>
        public Auriga.Information.ExchangeMechanism ExchangeMechanism { get; set; }

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets or sets the final.
        /// </summary>
        public bool? Final { get; set; }

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
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        /// <summary>
        /// Gets the owned elements.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IExchangeItemElement> OwnedElements => this.backingOwnedElements ??= new Auriga.ContainerList<Auriga.Information.IExchangeItemElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedElements"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.IExchangeItemElement> backingOwnedElements;

        /// <summary>
        /// Gets the owned enumeration property types.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes => this.backingOwnedEnumerationPropertyTypes ??= new Auriga.ContainerList<Auriga.Capellacore.IEnumerationPropertyType>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedEnumerationPropertyTypes"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> backingOwnedEnumerationPropertyTypes;

        /// <summary>
        /// Gets the owned exchange item instances.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IExchangeItemInstance> OwnedExchangeItemInstances => this.backingOwnedExchangeItemInstances ??= new Auriga.ContainerList<Auriga.Information.IExchangeItemInstance>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExchangeItemInstances"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.IExchangeItemInstance> backingOwnedExchangeItemInstances;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned generalizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IGeneralization> OwnedGeneralizations => this.backingOwnedGeneralizations ??= new Auriga.ContainerList<Auriga.Capellacore.IGeneralization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedGeneralizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IGeneralization> backingOwnedGeneralizations;

        /// <summary>
        /// Gets the owned information realizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IInformationRealization> OwnedInformationRealizations => this.backingOwnedInformationRealizations ??= new Auriga.ContainerList<Auriga.Information.IInformationRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedInformationRealizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.IInformationRealization> backingOwnedInformationRealizations;

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
        /// Gets the owned property values.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.ContainerList<Auriga.Capellacore.IAbstractPropertyValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValues"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        /// <summary>
        /// Gets the owned traces.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.ContainerList<Auriga.Capellacore.ITrace>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTraces"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets the realized exchange items.
        /// </summary>
        public IEnumerable<Auriga.Information.IExchangeItem> RealizedExchangeItems => Enumerable.Empty<Auriga.Information.IExchangeItem>();

        /// <summary>
        /// Gets the realizing exchange items.
        /// </summary>
        public IEnumerable<Auriga.Information.IExchangeItem> RealizingExchangeItems => Enumerable.Empty<Auriga.Information.IExchangeItem>();

        /// <summary>
        /// Gets the realizing operations.
        /// </summary>
        public IEnumerable<Auriga.Information.IOperation> RealizingOperations => Enumerable.Empty<Auriga.Information.IOperation>();

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
        /// Gets the sub.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IGeneralizableElement> Sub => Enumerable.Empty<Auriga.Capellacore.IGeneralizableElement>();

        /// <summary>
        /// Gets the sub generalizations.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IGeneralization> SubGeneralizations => Enumerable.Empty<Auriga.Capellacore.IGeneralization>();

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
        /// Gets the typed elements.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.ITypedElement> TypedElements => Enumerable.Empty<Auriga.Capellacore.ITypedElement>();

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>ExchangeItem</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.NamingRules)
            {
                yield return element;
            }

            foreach (var element in this.OwnedConstraints)
            {
                yield return element;
            }

            foreach (var element in this.OwnedElements)
            {
                yield return element;
            }

            foreach (var element in this.OwnedEnumerationPropertyTypes)
            {
                yield return element;
            }

            foreach (var element in this.OwnedExchangeItemInstances)
            {
                yield return element;
            }

            foreach (var element in this.OwnedExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedGeneralizations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedInformationRealizations)
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
