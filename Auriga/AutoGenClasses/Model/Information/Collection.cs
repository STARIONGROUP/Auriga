// ------------------------------------------------------------------------------------------------
// <copyright file="Collection.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Information
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Collection</c> class.
    /// </summary>
    public partial class Collection : Auriga.Core.AurigaElement, Auriga.Model.Information.ICollection
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
        /// Gets or sets the aggregation kind.
        /// </summary>
        public Auriga.Model.Information.AggregationKind? AggregationKind { get; set; }

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
        /// Gets the features.
        /// </summary>
        public List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets or sets the final.
        /// </summary>
        public bool? Final { get; set; }

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the index.
        /// </summary>
        public List<Auriga.Model.Information.Datatype.IDataType> Index { get; } = new List<Auriga.Model.Information.Datatype.IDataType>();

        /// <summary>
        /// Gets or sets the is primitive.
        /// </summary>
        public bool? IsPrimitive { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public Auriga.Model.Information.CollectionKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the max inclusive.
        /// </summary>
        public bool? MaxInclusive { get; set; }

        /// <summary>
        /// Gets or sets the min inclusive.
        /// </summary>
        public bool? MinInclusive { get; set; }

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
        /// Gets or sets the ordered.
        /// </summary>
        public bool? Ordered { get; set; }

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
        /// Gets the owned data values.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Information.Datavalue.IDataValue> OwnedDataValues => this.backingOwnedDataValues ??= new Auriga.Core.ContainerList<Auriga.Model.Information.Datavalue.IDataValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDataValues"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Information.Datavalue.IDataValue> backingOwnedDataValues;

        /// <summary>
        /// Gets or sets the owned default value.
        /// </summary>
        public Auriga.Model.Information.Datavalue.IDataValue OwnedDefaultValue
        {
            get => this.backingOwnedDefaultValue;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedDefaultValue = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedDefaultValue"/>.
        /// </summary>
        private Auriga.Model.Information.Datavalue.IDataValue backingOwnedDefaultValue;

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
        /// Gets the owned generalizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IGeneralization> OwnedGeneralizations => this.backingOwnedGeneralizations ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IGeneralization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedGeneralizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IGeneralization> backingOwnedGeneralizations;

        /// <summary>
        /// Gets or sets the owned max card.
        /// </summary>
        public Auriga.Model.Information.Datavalue.INumericValue OwnedMaxCard
        {
            get => this.backingOwnedMaxCard;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMaxCard = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMaxCard"/>.
        /// </summary>
        private Auriga.Model.Information.Datavalue.INumericValue backingOwnedMaxCard;

        /// <summary>
        /// Gets or sets the owned max length.
        /// </summary>
        public Auriga.Model.Information.Datavalue.INumericValue OwnedMaxLength
        {
            get => this.backingOwnedMaxLength;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMaxLength = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMaxLength"/>.
        /// </summary>
        private Auriga.Model.Information.Datavalue.INumericValue backingOwnedMaxLength;

        /// <summary>
        /// Gets or sets the owned max value.
        /// </summary>
        public Auriga.Model.Information.Datavalue.IDataValue OwnedMaxValue
        {
            get => this.backingOwnedMaxValue;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMaxValue = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMaxValue"/>.
        /// </summary>
        private Auriga.Model.Information.Datavalue.IDataValue backingOwnedMaxValue;

        /// <summary>
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.Core.ContainerList<Auriga.Model.Modellingcore.IModelElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMigratedElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets or sets the owned min card.
        /// </summary>
        public Auriga.Model.Information.Datavalue.INumericValue OwnedMinCard
        {
            get => this.backingOwnedMinCard;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMinCard = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMinCard"/>.
        /// </summary>
        private Auriga.Model.Information.Datavalue.INumericValue backingOwnedMinCard;

        /// <summary>
        /// Gets or sets the owned min length.
        /// </summary>
        public Auriga.Model.Information.Datavalue.INumericValue OwnedMinLength
        {
            get => this.backingOwnedMinLength;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMinLength = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMinLength"/>.
        /// </summary>
        private Auriga.Model.Information.Datavalue.INumericValue backingOwnedMinLength;

        /// <summary>
        /// Gets or sets the owned min value.
        /// </summary>
        public Auriga.Model.Information.Datavalue.IDataValue OwnedMinValue
        {
            get => this.backingOwnedMinValue;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMinValue = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMinValue"/>.
        /// </summary>
        private Auriga.Model.Information.Datavalue.IDataValue backingOwnedMinValue;

        /// <summary>
        /// Gets or sets the owned null value.
        /// </summary>
        public Auriga.Model.Information.Datavalue.IDataValue OwnedNullValue
        {
            get => this.backingOwnedNullValue;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedNullValue = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedNullValue"/>.
        /// </summary>
        private Auriga.Model.Information.Datavalue.IDataValue backingOwnedNullValue;

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
        /// Gets or sets the type.
        /// </summary>
        public Auriga.Model.Capellacore.IType Type { get; set; }

        /// <summary>
        /// Gets the typed elements.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.ITypedElement> TypedElements => Enumerable.Empty<Auriga.Model.Capellacore.ITypedElement>();

        /// <summary>
        /// Gets or sets the unique.
        /// </summary>
        public bool? Unique { get; set; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        public Auriga.Model.Capellacore.VisibilityKind? Visibility { get; set; }

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>Collection</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.NamingRules)
            {
                yield return element;
            }

            foreach (var element in this.OwnedConstraints)
            {
                yield return element;
            }

            foreach (var element in this.OwnedDataValues)
            {
                yield return element;
            }

            if (this.OwnedDefaultValue != null)
            {
                yield return this.OwnedDefaultValue;
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

            foreach (var element in this.OwnedGeneralizations)
            {
                yield return element;
            }

            if (this.OwnedMaxCard != null)
            {
                yield return this.OwnedMaxCard;
            }

            if (this.OwnedMaxLength != null)
            {
                yield return this.OwnedMaxLength;
            }

            if (this.OwnedMaxValue != null)
            {
                yield return this.OwnedMaxValue;
            }

            foreach (var element in this.OwnedMigratedElements)
            {
                yield return element;
            }

            if (this.OwnedMinCard != null)
            {
                yield return this.OwnedMinCard;
            }

            if (this.OwnedMinLength != null)
            {
                yield return this.OwnedMinLength;
            }

            if (this.OwnedMinValue != null)
            {
                yield return this.OwnedMinValue;
            }

            if (this.OwnedNullValue != null)
            {
                yield return this.OwnedNullValue;
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
