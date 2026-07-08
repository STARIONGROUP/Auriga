// ------------------------------------------------------------------------------------------------
// <copyright file="FunctionalExchange.cs" company="Starion Group S.A.">
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

namespace Auriga.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FunctionalExchange</c> class.
    /// </summary>
    public partial class FunctionalExchange : Auriga.AurigaElement, Auriga.Fa.IFunctionalExchange
    {
        /// <summary>
        /// Gets the abstract typed elements.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Modellingcore.IAbstractTypedElement>();

        /// <summary>
        /// Gets the allocating component exchanges.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentExchange> AllocatingComponentExchanges => Enumerable.Empty<Auriga.Fa.IComponentExchange>();

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the categories.
        /// </summary>
        public IEnumerable<Auriga.Fa.IExchangeCategory> Categories => Enumerable.Empty<Auriga.Fa.IExchangeCategory>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the exchange specifications.
        /// </summary>
        public List<Auriga.Fa.IFunctionalExchangeSpecification> ExchangeSpecifications { get; } = new List<Auriga.Fa.IFunctionalExchangeSpecification>();

        /// <summary>
        /// Gets the exchanged items.
        /// </summary>
        public List<Auriga.Information.IExchangeItem> ExchangedItems { get; } = new List<Auriga.Information.IExchangeItem>();

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets or sets the guard.
        /// </summary>
        public Auriga.Modellingcore.IValueSpecification Guard
        {
            get => this.backingGuard;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingGuard = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Guard"/>.
        /// </summary>
        private Auriga.Modellingcore.IValueSpecification backingGuard;

        /// <summary>
        /// Gets the in activity partition.
        /// </summary>
        public Auriga.Activity.IActivityPartition InActivityPartition => default;

        /// <summary>
        /// Gets the in interruptible region.
        /// </summary>
        public Auriga.Activity.IInterruptibleActivityRegion InInterruptibleRegion => default;

        /// <summary>
        /// Gets the in structured node.
        /// </summary>
        public Auriga.Activity.IStructuredActivityNode InStructuredNode => default;

        /// <summary>
        /// Gets the incoming component exchange functional exchange realizations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation> IncomingComponentExchangeFunctionalExchangeRealizations => Enumerable.Empty<Auriga.Fa.IComponentExchangeFunctionalExchangeAllocation>();

        /// <summary>
        /// Gets the incoming functional exchange realizations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalExchangeRealization> IncomingFunctionalExchangeRealizations => Enumerable.Empty<Auriga.Fa.IFunctionalExchangeRealization>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets or sets the interrupts.
        /// </summary>
        public Auriga.Activity.IInterruptibleActivityRegion Interrupts { get; set; }

        /// <summary>
        /// Gets the invoking sequence messages.
        /// </summary>
        public IEnumerable<Auriga.Interaction.ISequenceMessage> InvokingSequenceMessages => Enumerable.Empty<Auriga.Interaction.ISequenceMessage>();

        /// <summary>
        /// Gets the involving functional chains.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalChain> InvolvingFunctionalChains => Enumerable.Empty<Auriga.Fa.IFunctionalChain>();

        /// <summary>
        /// Gets the involving involvements.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Capellacore.IInvolvement>();

        /// <summary>
        /// Gets or sets the is multicast.
        /// </summary>
        public bool? IsMulticast { get; set; }

        /// <summary>
        /// Gets or sets the is multireceive.
        /// </summary>
        public bool? IsMultireceive { get; set; }

        /// <summary>
        /// Gets or sets the kind of rate.
        /// </summary>
        public Auriga.Modellingcore.RateKind? KindOfRate { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the outgoing functional exchange realizations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalExchangeRealization> OutgoingFunctionalExchangeRealizations => Enumerable.Empty<Auriga.Fa.IFunctionalExchangeRealization>();

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
        /// Gets the owned functional exchange realizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IFunctionalExchangeRealization> OwnedFunctionalExchangeRealizations => this.backingOwnedFunctionalExchangeRealizations ??= new Auriga.ContainerList<Auriga.Fa.IFunctionalExchangeRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalExchangeRealizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IFunctionalExchangeRealization> backingOwnedFunctionalExchangeRealizations;

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
        /// Gets or sets the probability.
        /// </summary>
        public Auriga.Modellingcore.IValueSpecification Probability
        {
            get => this.backingProbability;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingProbability = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Probability"/>.
        /// </summary>
        private Auriga.Modellingcore.IValueSpecification backingProbability;

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        public Auriga.Modellingcore.IValueSpecification Rate
        {
            get => this.backingRate;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingRate = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Rate"/>.
        /// </summary>
        private Auriga.Modellingcore.IValueSpecification backingRate;

        /// <summary>
        /// Gets or sets the realized flow.
        /// </summary>
        public Auriga.Modellingcore.IAbstractInformationFlow RealizedFlow { get; set; }

        /// <summary>
        /// Gets the realized functional exchanges.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalExchange> RealizedFunctionalExchanges => Enumerable.Empty<Auriga.Fa.IFunctionalExchange>();

        /// <summary>
        /// Gets the realizing functional exchanges.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalExchange> RealizingFunctionalExchanges => Enumerable.Empty<Auriga.Fa.IFunctionalExchange>();

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Gets or sets the selection.
        /// </summary>
        public Auriga.Behavior.IAbstractBehavior Selection { get; set; }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public Auriga.Activity.IActivityNode Source { get; set; }

        /// <summary>
        /// Gets the source function output port.
        /// </summary>
        public Auriga.Fa.IFunctionOutputPort SourceFunctionOutputPort => default;

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public Auriga.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public Auriga.Activity.IActivityNode Target { get; set; }

        /// <summary>
        /// Gets the target function input port.
        /// </summary>
        public Auriga.Fa.IFunctionInputPort TargetFunctionInputPort => default;

        /// <summary>
        /// Gets or sets the transformation.
        /// </summary>
        public Auriga.Behavior.IAbstractBehavior Transformation { get; set; }

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public Auriga.Modellingcore.IValueSpecification Weight
        {
            get => this.backingWeight;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingWeight = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Weight"/>.
        /// </summary>
        private Auriga.Modellingcore.IValueSpecification backingWeight;

        /// <summary>
        /// Gets the elements directly contained by this <c>FunctionalExchange</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            if (this.Guard != null)
            {
                yield return this.Guard;
            }

            foreach (var element in this.OwnedConstraints)
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

            foreach (var element in this.OwnedFunctionalExchangeRealizations)
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

            if (this.Probability != null)
            {
                yield return this.Probability;
            }

            if (this.Rate != null)
            {
                yield return this.Rate;
            }

            if (this.Weight != null)
            {
                yield return this.Weight;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
