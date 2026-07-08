// ------------------------------------------------------------------------------------------------
// <copyright file="Class.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Class</c> class.
    /// </summary>
    public partial class Class : Auriga.AurigaElement, Auriga.Information.IClass
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
        /// Gets the contained operations.
        /// </summary>
        public IEnumerable<Auriga.Information.IOperation> ContainedOperations => Enumerable.Empty<Auriga.Information.IOperation>();

        /// <summary>
        /// Gets the contained properties.
        /// </summary>
        public IEnumerable<Auriga.Information.IProperty> ContainedProperties => Enumerable.Empty<Auriga.Information.IProperty>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

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
        /// Gets or sets the is primitive.
        /// </summary>
        public bool? IsPrimitive { get; set; }

        /// <summary>
        /// Gets the key parts.
        /// </summary>
        public List<Auriga.Information.IKeyPart> KeyParts { get; } = new List<Auriga.Information.IKeyPart>();

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
        /// Gets the nested general classes.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IGeneralClass> NestedGeneralClasses => this.backingNestedGeneralClasses ??= new Auriga.ContainerList<Auriga.Capellacore.IGeneralClass>(this);

        /// <summary>
        /// Backing field for <see cref="NestedGeneralClasses"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IGeneralClass> backingNestedGeneralClasses;

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
        /// Gets the owned data values.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.Datavalue.IDataValue> OwnedDataValues => this.backingOwnedDataValues ??= new Auriga.ContainerList<Auriga.Information.Datavalue.IDataValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDataValues"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.Datavalue.IDataValue> backingOwnedDataValues;

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
        /// Gets the realized classes.
        /// </summary>
        public IEnumerable<Auriga.Information.IClass> RealizedClasses => Enumerable.Empty<Auriga.Information.IClass>();

        /// <summary>
        /// Gets the realizing classes.
        /// </summary>
        public IEnumerable<Auriga.Information.IClass> RealizingClasses => Enumerable.Empty<Auriga.Information.IClass>();

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
        /// Gets or sets the visibility.
        /// </summary>
        public Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>Class</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
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

            foreach (var element in this.OwnedDataValues)
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
