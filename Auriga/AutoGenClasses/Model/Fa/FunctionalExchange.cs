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

namespace Auriga.Model.Fa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FunctionalExchange</c> class.
    /// </summary>
    public partial class FunctionalExchange : Auriga.Core.AurigaElement, Auriga.Model.Fa.IFunctionalExchange
    {
        /// <summary>
        /// Gets the abstract typed elements.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTypedElement>();

        /// <summary>
        /// Gets the allocating component exchanges.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentExchange> AllocatingComponentExchanges => Enumerable.Empty<Auriga.Model.Fa.IComponentExchange>();

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Model.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Model.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Model.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Model.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the categories.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IExchangeCategory> Categories => Enumerable.Empty<Auriga.Model.Fa.IExchangeCategory>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the exchange specifications.
        /// </summary>
        public List<Auriga.Model.Fa.IFunctionalExchangeSpecification> ExchangeSpecifications { get; } = new List<Auriga.Model.Fa.IFunctionalExchangeSpecification>();

        /// <summary>
        /// Gets the exchanged items.
        /// </summary>
        public List<Auriga.Model.Information.IExchangeItem> ExchangedItems { get; } = new List<Auriga.Model.Information.IExchangeItem>();

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets or sets the guard.
        /// </summary>
        public Auriga.Model.Modellingcore.IValueSpecification Guard
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
        private Auriga.Model.Modellingcore.IValueSpecification backingGuard;

        /// <summary>
        /// Gets the in activity partition.
        /// </summary>
        public Auriga.Model.Activity.IActivityPartition InActivityPartition => default;

        /// <summary>
        /// Gets the in interruptible region.
        /// </summary>
        public Auriga.Model.Activity.IInterruptibleActivityRegion InInterruptibleRegion => default;

        /// <summary>
        /// Gets the in structured node.
        /// </summary>
        public Auriga.Model.Activity.IStructuredActivityNode InStructuredNode => default;

        /// <summary>
        /// Gets the incoming component exchange functional exchange realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentExchangeFunctionalExchangeAllocation> IncomingComponentExchangeFunctionalExchangeRealizations => Enumerable.Empty<Auriga.Model.Fa.IComponentExchangeFunctionalExchangeAllocation>();

        /// <summary>
        /// Gets the incoming functional exchange realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalExchangeRealization> IncomingFunctionalExchangeRealizations => Enumerable.Empty<Auriga.Model.Fa.IFunctionalExchangeRealization>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets or sets the interrupts.
        /// </summary>
        public Auriga.Model.Activity.IInterruptibleActivityRegion Interrupts { get; set; }

        /// <summary>
        /// Gets the invoking sequence messages.
        /// </summary>
        public IEnumerable<Auriga.Model.Interaction.ISequenceMessage> InvokingSequenceMessages => Enumerable.Empty<Auriga.Model.Interaction.ISequenceMessage>();

        /// <summary>
        /// Gets the involving functional chains.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalChain> InvolvingFunctionalChains => Enumerable.Empty<Auriga.Model.Fa.IFunctionalChain>();

        /// <summary>
        /// Gets the involving involvements.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Model.Capellacore.IInvolvement>();

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
        public Auriga.Model.Modellingcore.RateKind? KindOfRate { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the outgoing functional exchange realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalExchangeRealization> OutgoingFunctionalExchangeRealizations => Enumerable.Empty<Auriga.Model.Fa.IFunctionalExchangeRealization>();

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
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Model.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned functional exchange realizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalExchangeRealization> OwnedFunctionalExchangeRealizations => this.backingOwnedFunctionalExchangeRealizations ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IFunctionalExchangeRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalExchangeRealizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalExchangeRealization> backingOwnedFunctionalExchangeRealizations;

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
        /// Gets or sets the probability.
        /// </summary>
        public Auriga.Model.Modellingcore.IValueSpecification Probability
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
        private Auriga.Model.Modellingcore.IValueSpecification backingProbability;

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        public Auriga.Model.Modellingcore.IValueSpecification Rate
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
        private Auriga.Model.Modellingcore.IValueSpecification backingRate;

        /// <summary>
        /// Gets or sets the realized flow.
        /// </summary>
        public Auriga.Model.Modellingcore.IAbstractInformationFlow RealizedFlow { get; set; }

        /// <summary>
        /// Gets the realized functional exchanges.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalExchange> RealizedFunctionalExchanges => Enumerable.Empty<Auriga.Model.Fa.IFunctionalExchange>();

        /// <summary>
        /// Gets the realizing functional exchanges.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalExchange> RealizingFunctionalExchanges => Enumerable.Empty<Auriga.Model.Fa.IFunctionalExchange>();

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Gets or sets the selection.
        /// </summary>
        public Auriga.Model.Behavior.IAbstractBehavior Selection { get; set; }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public Auriga.Model.Activity.IActivityNode Source { get; set; }

        /// <summary>
        /// Gets the source function output port.
        /// </summary>
        public Auriga.Model.Fa.IFunctionOutputPort SourceFunctionOutputPort => default;

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public Auriga.Model.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public Auriga.Model.Activity.IActivityNode Target { get; set; }

        /// <summary>
        /// Gets the target function input port.
        /// </summary>
        public Auriga.Model.Fa.IFunctionInputPort TargetFunctionInputPort => default;

        /// <summary>
        /// Gets or sets the transformation.
        /// </summary>
        public Auriga.Model.Behavior.IAbstractBehavior Transformation { get; set; }

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; } = true;

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; } = true;

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public Auriga.Model.Modellingcore.IValueSpecification Weight
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
        private Auriga.Model.Modellingcore.IValueSpecification backingWeight;

        /// <summary>
        /// Gets the elements directly contained by this <c>FunctionalExchange</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
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
