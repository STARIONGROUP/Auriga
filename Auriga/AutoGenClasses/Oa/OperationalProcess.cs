// ------------------------------------------------------------------------------------------------
// <copyright file="OperationalProcess.cs" company="Starion Group S.A.">
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

namespace Auriga.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>OperationalProcess</c> class.
    /// </summary>
    public partial class OperationalProcess : Auriga.AurigaElement, Auriga.Oa.IOperationalProcess
    {
        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the available in states.
        /// </summary>
        public List<Auriga.Capellacommon.IState> AvailableInStates { get; } = new List<Auriga.Capellacommon.IState>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the enacted functional blocks.
        /// </summary>
        public IEnumerable<Auriga.Fa.IAbstractFunctionalBlock> EnactedFunctionalBlocks => Enumerable.Empty<Auriga.Fa.IAbstractFunctionalBlock>();

        /// <summary>
        /// Gets the enacted functions.
        /// </summary>
        public IEnumerable<Auriga.Fa.IAbstractFunction> EnactedFunctions => Enumerable.Empty<Auriga.Fa.IAbstractFunction>();

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the first functional chain involvements.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalChainInvolvement> FirstFunctionalChainInvolvements => Enumerable.Empty<Auriga.Fa.IFunctionalChainInvolvement>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the involved elements.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IInvolvedElement> InvolvedElements => Enumerable.Empty<Auriga.Capellacore.IInvolvedElement>();

        /// <summary>
        /// Gets the involved functional chain involvements.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalChainInvolvement> InvolvedFunctionalChainInvolvements => Enumerable.Empty<Auriga.Fa.IFunctionalChainInvolvement>();

        /// <summary>
        /// Gets the involved functional exchanges.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalExchange> InvolvedFunctionalExchanges => Enumerable.Empty<Auriga.Fa.IFunctionalExchange>();

        /// <summary>
        /// Gets the involved functions.
        /// </summary>
        public IEnumerable<Auriga.Fa.IAbstractFunction> InvolvedFunctions => Enumerable.Empty<Auriga.Fa.IAbstractFunction>();

        /// <summary>
        /// Gets the involved involvements.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IInvolvement> InvolvedInvolvements => Enumerable.Empty<Auriga.Capellacore.IInvolvement>();

        /// <summary>
        /// Gets the involving capabilities.
        /// </summary>
        public IEnumerable<Auriga.Ctx.ICapability> InvolvingCapabilities => Enumerable.Empty<Auriga.Ctx.ICapability>();

        /// <summary>
        /// Gets the involving capability realizations.
        /// </summary>
        public IEnumerable<Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations => Enumerable.Empty<Auriga.La.ICapabilityRealization>();

        /// <summary>
        /// Gets the involving involvements.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Capellacore.IInvolvement>();

        /// <summary>
        /// Gets the involving operational capabilities.
        /// </summary>
        public IEnumerable<Auriga.Oa.IOperationalCapability> InvolvingOperationalCapabilities => Enumerable.Empty<Auriga.Oa.IOperationalCapability>();

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public Auriga.Fa.FunctionalChainKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

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
        /// Gets the owned functional chain involvements.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IFunctionalChainInvolvement> OwnedFunctionalChainInvolvements => this.backingOwnedFunctionalChainInvolvements ??= new Auriga.ContainerList<Auriga.Fa.IFunctionalChainInvolvement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalChainInvolvements"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IFunctionalChainInvolvement> backingOwnedFunctionalChainInvolvements;

        /// <summary>
        /// Gets the owned functional chain realizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IFunctionalChainRealization> OwnedFunctionalChainRealizations => this.backingOwnedFunctionalChainRealizations ??= new Auriga.ContainerList<Auriga.Fa.IFunctionalChainRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalChainRealizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IFunctionalChainRealization> backingOwnedFunctionalChainRealizations;

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
        /// Gets the owned sequence links.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.ISequenceLink> OwnedSequenceLinks => this.backingOwnedSequenceLinks ??= new Auriga.ContainerList<Auriga.Fa.ISequenceLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedSequenceLinks"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.ISequenceLink> backingOwnedSequenceLinks;

        /// <summary>
        /// Gets the owned sequence nodes.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IControlNode> OwnedSequenceNodes => this.backingOwnedSequenceNodes ??= new Auriga.ContainerList<Auriga.Fa.IControlNode>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedSequenceNodes"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IControlNode> backingOwnedSequenceNodes;

        /// <summary>
        /// Gets or sets the post condition.
        /// </summary>
        public Auriga.Capellacore.IConstraint PostCondition { get; set; }

        /// <summary>
        /// Gets or sets the pre condition.
        /// </summary>
        public Auriga.Capellacore.IConstraint PreCondition { get; set; }

        /// <summary>
        /// Gets the realized functional chains.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalChain> RealizedFunctionalChains => Enumerable.Empty<Auriga.Fa.IFunctionalChain>();

        /// <summary>
        /// Gets the realizing functional chains.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalChain> RealizingFunctionalChains => Enumerable.Empty<Auriga.Fa.IFunctionalChain>();

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
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
