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

namespace Auriga.Model.Cs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Part</c> class.
    /// </summary>
    public partial class Part : Auriga.Core.AurigaElement, Auriga.Model.Cs.IPart
    {
        /// <summary>
        /// Gets or sets the abstract type.
        /// </summary>
        public Auriga.Model.Modellingcore.IAbstractType AbstractType { get; set; }

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
        /// Gets the association.
        /// </summary>
        public Auriga.Model.Information.IAssociation Association => default;

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets the deployed parts.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IPart> DeployedParts => Enumerable.Empty<Auriga.Model.Cs.IPart>();

        /// <summary>
        /// Gets the deploying links.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IAbstractDeploymentLink> DeployingLinks => Enumerable.Empty<Auriga.Model.Cs.IAbstractDeploymentLink>();

        /// <summary>
        /// Gets the deploying parts.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IPart> DeployingParts => Enumerable.Empty<Auriga.Model.Cs.IPart>();

        /// <summary>
        /// Gets the deployment links.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IAbstractDeploymentLink> DeploymentLinks => Enumerable.Empty<Auriga.Model.Cs.IAbstractDeploymentLink>();

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
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractInformationFlow> OutgoingInformationFlows => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractInformationFlow>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets or sets the owned abstract type.
        /// </summary>
        public Auriga.Model.Modellingcore.IAbstractType OwnedAbstractType
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
        private Auriga.Model.Modellingcore.IAbstractType backingOwnedAbstractType;

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.Core.ContainerList<Auriga.Model.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

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
        /// Gets the owned deployment links.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Cs.IAbstractDeploymentLink> OwnedDeploymentLinks => this.backingOwnedDeploymentLinks ??= new Auriga.Core.ContainerList<Auriga.Model.Cs.IAbstractDeploymentLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDeploymentLinks"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Cs.IAbstractDeploymentLink> backingOwnedDeploymentLinks;

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
        /// Gets the owned property values.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValues"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        /// <summary>
        /// Gets the provided interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> ProvidedInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

        /// <summary>
        /// Gets the representing instance roles.
        /// </summary>
        public IEnumerable<Auriga.Model.Interaction.IInstanceRole> RepresentingInstanceRoles => Enumerable.Empty<Auriga.Model.Interaction.IInstanceRole>();

        /// <summary>
        /// Gets the required interfaces.
        /// </summary>
        public IEnumerable<Auriga.Model.Cs.IInterface> RequiredInterfaces => Enumerable.Empty<Auriga.Model.Cs.IInterface>();

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
        /// Gets the type.
        /// </summary>
        public Auriga.Model.Capellacore.IType Type => default;

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
        /// Gets the elements directly contained by this <c>Part</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
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
