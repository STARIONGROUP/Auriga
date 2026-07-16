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

namespace Auriga.Model.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>OperationalProcess</c> class.
    /// </summary>
    public partial class OperationalProcess : Auriga.Core.AurigaElement, Auriga.Model.Oa.IOperationalProcess
    {
        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Model.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Model.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Model.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Model.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the available in states.
        /// </summary>
        public List<Auriga.Model.Capellacommon.IState> AvailableInStates { get; } = new List<Auriga.Model.Capellacommon.IState>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the enacted functional blocks.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IAbstractFunctionalBlock> EnactedFunctionalBlocks => Enumerable.Empty<Auriga.Model.Fa.IAbstractFunctionalBlock>();

        /// <summary>
        /// Gets the enacted functions.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IAbstractFunction> EnactedFunctions => Enumerable.Empty<Auriga.Model.Fa.IAbstractFunction>();

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the first functional chain involvements.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalChainInvolvement> FirstFunctionalChainInvolvements => Enumerable.Empty<Auriga.Model.Fa.IFunctionalChainInvolvement>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the involved elements.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.IInvolvedElement> InvolvedElements => Enumerable.Empty<Auriga.Model.Capellacore.IInvolvedElement>();

        /// <summary>
        /// Gets the involved functional chain involvements.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalChainInvolvement> InvolvedFunctionalChainInvolvements => Enumerable.Empty<Auriga.Model.Fa.IFunctionalChainInvolvement>();

        /// <summary>
        /// Gets the involved functional exchanges.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalExchange> InvolvedFunctionalExchanges => Enumerable.Empty<Auriga.Model.Fa.IFunctionalExchange>();

        /// <summary>
        /// Gets the involved functions.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IAbstractFunction> InvolvedFunctions => Enumerable.Empty<Auriga.Model.Fa.IAbstractFunction>();

        /// <summary>
        /// Gets the involved involvements.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.IInvolvement> InvolvedInvolvements => Enumerable.Empty<Auriga.Model.Capellacore.IInvolvement>();

        /// <summary>
        /// Gets the involving capabilities.
        /// </summary>
        public IEnumerable<Auriga.Model.Ctx.ICapability> InvolvingCapabilities => Enumerable.Empty<Auriga.Model.Ctx.ICapability>();

        /// <summary>
        /// Gets the involving capability realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.La.ICapabilityRealization> InvolvingCapabilityRealizations => Enumerable.Empty<Auriga.Model.La.ICapabilityRealization>();

        /// <summary>
        /// Gets the involving involvements.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Model.Capellacore.IInvolvement>();

        /// <summary>
        /// Gets the involving operational capabilities.
        /// </summary>
        public IEnumerable<Auriga.Model.Oa.IOperationalCapability> InvolvingOperationalCapabilities => Enumerable.Empty<Auriga.Model.Oa.IOperationalCapability>();

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public Auriga.Model.Fa.FunctionalChainKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

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
        /// Gets the owned functional chain involvements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalChainInvolvement> OwnedFunctionalChainInvolvements => this.backingOwnedFunctionalChainInvolvements ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IFunctionalChainInvolvement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalChainInvolvements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalChainInvolvement> backingOwnedFunctionalChainInvolvements;

        /// <summary>
        /// Gets the owned functional chain realizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalChainRealization> OwnedFunctionalChainRealizations => this.backingOwnedFunctionalChainRealizations ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IFunctionalChainRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalChainRealizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalChainRealization> backingOwnedFunctionalChainRealizations;

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
        /// Gets the owned sequence links.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.ISequenceLink> OwnedSequenceLinks => this.backingOwnedSequenceLinks ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.ISequenceLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedSequenceLinks"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.ISequenceLink> backingOwnedSequenceLinks;

        /// <summary>
        /// Gets the owned sequence nodes.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IControlNode> OwnedSequenceNodes => this.backingOwnedSequenceNodes ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IControlNode>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedSequenceNodes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IControlNode> backingOwnedSequenceNodes;

        /// <summary>
        /// Gets or sets the post condition.
        /// </summary>
        public Auriga.Model.Capellacore.IConstraint PostCondition { get; set; }

        /// <summary>
        /// Gets or sets the pre condition.
        /// </summary>
        public Auriga.Model.Capellacore.IConstraint PreCondition { get; set; }

        /// <summary>
        /// Gets the realized functional chains.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalChain> RealizedFunctionalChains => Enumerable.Empty<Auriga.Model.Fa.IFunctionalChain>();

        /// <summary>
        /// Gets the realizing functional chains.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalChain> RealizingFunctionalChains => Enumerable.Empty<Auriga.Model.Fa.IFunctionalChain>();

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
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>OperationalProcess</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
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

            foreach (var element in this.OwnedFunctionalChainInvolvements)
            {
                yield return element;
            }

            foreach (var element in this.OwnedFunctionalChainRealizations)
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

            foreach (var element in this.OwnedSequenceLinks)
            {
                yield return element;
            }

            foreach (var element in this.OwnedSequenceNodes)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
