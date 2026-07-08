// ------------------------------------------------------------------------------------------------
// <copyright file="Part.cs" company="Starion Group S.A.">
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

namespace Auriga.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Part</c> class.
    /// </summary>
    public partial class Part : Auriga.AurigaElement, Auriga.Cs.IPart
    {
        /// <summary>
        /// Gets or sets the abstract type.
        /// </summary>
        public Auriga.Modellingcore.IAbstractType AbstractType { get; set; }

        /// <summary>
        /// Gets or sets the aggregation kind.
        /// </summary>
        public Auriga.Information.AggregationKind? AggregationKind { get; set; }

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the association.
        /// </summary>
        public Auriga.Information.IAssociation Association => default;

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets the deployed parts.
        /// </summary>
        public IEnumerable<Auriga.Cs.IPart> DeployedParts => Enumerable.Empty<Auriga.Cs.IPart>();

        /// <summary>
        /// Gets the deploying links.
        /// </summary>
        public IEnumerable<Auriga.Cs.IAbstractDeploymentLink> DeployingLinks => Enumerable.Empty<Auriga.Cs.IAbstractDeploymentLink>();

        /// <summary>
        /// Gets the deploying parts.
        /// </summary>
        public IEnumerable<Auriga.Cs.IPart> DeployingParts => Enumerable.Empty<Auriga.Cs.IPart>();

        /// <summary>
        /// Gets the deployment links.
        /// </summary>
        public IEnumerable<Auriga.Cs.IAbstractDeploymentLink> DeploymentLinks => Enumerable.Empty<Auriga.Cs.IAbstractDeploymentLink>();

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
        /// Gets the incoming information flows.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractInformationFlow> IncomingInformationFlows => Enumerable.Empty<Auriga.Modellingcore.IAbstractInformationFlow>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the information flows.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractInformationFlow> InformationFlows => Enumerable.Empty<Auriga.Modellingcore.IAbstractInformationFlow>();

        /// <summary>
        /// Gets the involving involvements.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Capellacore.IInvolvement>();

        /// <summary>
        /// Gets or sets the is abstract.
        /// </summary>
        public bool? IsAbstract { get; set; }

        /// <summary>
        /// Gets or sets the is derived.
        /// </summary>
        public bool? IsDerived { get; set; }

        /// <summary>
        /// Gets or sets the is part of key.
        /// </summary>
        public bool? IsPartOfKey { get; set; }

        /// <summary>
        /// Gets or sets the is read only.
        /// </summary>
        public bool? IsReadOnly { get; set; }

        /// <summary>
        /// Gets or sets the is static.
        /// </summary>
        public bool? IsStatic { get; set; }

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
        /// Gets or sets the ordered.
        /// </summary>
        public bool? Ordered { get; set; }

        /// <summary>
        /// Gets the outgoing information flows.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractInformationFlow> OutgoingInformationFlows => Enumerable.Empty<Auriga.Modellingcore.IAbstractInformationFlow>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets or sets the owned abstract type.
        /// </summary>
        public Auriga.Modellingcore.IAbstractType OwnedAbstractType
        {
            get => this.backingOwnedAbstractType;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedAbstractType = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedAbstractType"/>.
        /// </summary>
        private Auriga.Modellingcore.IAbstractType backingOwnedAbstractType;

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        /// <summary>
        /// Gets or sets the owned default value.
        /// </summary>
        public Auriga.Information.Datavalue.IDataValue OwnedDefaultValue
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
        private Auriga.Information.Datavalue.IDataValue backingOwnedDefaultValue;

        /// <summary>
        /// Gets the owned deployment links.
        /// </summary>
        public Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks => this.backingOwnedDeploymentLinks ??= new Auriga.ContainerList<Auriga.Cs.IAbstractDeploymentLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDeploymentLinks"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Cs.IAbstractDeploymentLink> backingOwnedDeploymentLinks;

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
        /// Gets or sets the owned max card.
        /// </summary>
        public Auriga.Information.Datavalue.INumericValue OwnedMaxCard
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
        private Auriga.Information.Datavalue.INumericValue backingOwnedMaxCard;

        /// <summary>
        /// Gets or sets the owned max length.
        /// </summary>
        public Auriga.Information.Datavalue.INumericValue OwnedMaxLength
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
        private Auriga.Information.Datavalue.INumericValue backingOwnedMaxLength;

        /// <summary>
        /// Gets or sets the owned max value.
        /// </summary>
        public Auriga.Information.Datavalue.IDataValue OwnedMaxValue
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
        private Auriga.Information.Datavalue.IDataValue backingOwnedMaxValue;

        /// <summary>
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.IContainerList<Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.ContainerList<Auriga.Modellingcore.IModelElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMigratedElements"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets or sets the owned min card.
        /// </summary>
        public Auriga.Information.Datavalue.INumericValue OwnedMinCard
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
        private Auriga.Information.Datavalue.INumericValue backingOwnedMinCard;

        /// <summary>
        /// Gets or sets the owned min length.
        /// </summary>
        public Auriga.Information.Datavalue.INumericValue OwnedMinLength
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
        private Auriga.Information.Datavalue.INumericValue backingOwnedMinLength;

        /// <summary>
        /// Gets or sets the owned min value.
        /// </summary>
        public Auriga.Information.Datavalue.IDataValue OwnedMinValue
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
        private Auriga.Information.Datavalue.IDataValue backingOwnedMinValue;

        /// <summary>
        /// Gets or sets the owned null value.
        /// </summary>
        public Auriga.Information.Datavalue.IDataValue OwnedNullValue
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
        private Auriga.Information.Datavalue.IDataValue backingOwnedNullValue;

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
        /// Gets the provided interfaces.
        /// </summary>
        public IEnumerable<Auriga.Cs.IInterface> ProvidedInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

        /// <summary>
        /// Gets the representing instance roles.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IInstanceRole> RepresentingInstanceRoles => Enumerable.Empty<Auriga.Interaction.IInstanceRole>();

        /// <summary>
        /// Gets the required interfaces.
        /// </summary>
        public IEnumerable<Auriga.Cs.IInterface> RequiredInterfaces => Enumerable.Empty<Auriga.Cs.IInterface>();

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
        /// Gets the type.
        /// </summary>
        public Auriga.Capellacore.IType Type => default;

        /// <summary>
        /// Gets or sets the unique.
        /// </summary>
        public bool? Unique { get; set; }

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
        /// Gets the elements directly contained by this <c>Part</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            if (this.OwnedAbstractType != null)
            {
                yield return this.OwnedAbstractType;
            }

            foreach (var element in this.OwnedConstraints)
            {
                yield return element;
            }

            if (this.OwnedDefaultValue != null)
            {
                yield return this.OwnedDefaultValue;
            }

            foreach (var element in this.OwnedDeploymentLinks)
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

            foreach (var element in this.OwnedPropertyValues)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
