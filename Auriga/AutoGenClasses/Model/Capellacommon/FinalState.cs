// ------------------------------------------------------------------------------------------------
// <copyright file="FinalState.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Capellacommon
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>FinalState</c> class.
    /// </summary>
    public partial class FinalState : Auriga.Core.AurigaElement, Auriga.Model.Capellacommon.IFinalState
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
        /// Gets the available abstract capabilities.
        /// </summary>
        public IEnumerable<Auriga.Model.Interaction.IAbstractCapability> AvailableAbstractCapabilities => Enumerable.Empty<Auriga.Model.Interaction.IAbstractCapability>();

        /// <summary>
        /// Gets the available abstract functions.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IAbstractFunction> AvailableAbstractFunctions => Enumerable.Empty<Auriga.Model.Fa.IAbstractFunction>();

        /// <summary>
        /// Gets the available functional chains.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalChain> AvailableFunctionalChains => Enumerable.Empty<Auriga.Model.Fa.IFunctionalChain>();

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the do activity.
        /// </summary>
        public List<Auriga.Model.Behavior.IAbstractEvent> DoActivity { get; } = new List<Auriga.Model.Behavior.IAbstractEvent>();

        /// <summary>
        /// Gets the entry.
        /// </summary>
        public List<Auriga.Model.Behavior.IAbstractEvent> Entry { get; } = new List<Auriga.Model.Behavior.IAbstractEvent>();

        /// <summary>
        /// Gets the exit.
        /// </summary>
        public List<Auriga.Model.Behavior.IAbstractEvent> Exit { get; } = new List<Auriga.Model.Behavior.IAbstractEvent>();

        /// <summary>
        /// Gets the exploited states.
        /// </summary>
        public List<Auriga.Model.Modellingcore.IIState> ExploitedStates { get; } = new List<Auriga.Model.Modellingcore.IIState>();

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the incoming.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacommon.IStateTransition> Incoming => Enumerable.Empty<Auriga.Model.Capellacommon.IStateTransition>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the involver regions.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacommon.IRegion> InvolverRegions => Enumerable.Empty<Auriga.Model.Capellacommon.IRegion>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the outgoing.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacommon.IStateTransition> Outgoing => Enumerable.Empty<Auriga.Model.Capellacommon.IStateTransition>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the owned abstract state realizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IAbstractStateRealization> OwnedAbstractStateRealizations => this.backingOwnedAbstractStateRealizations ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacommon.IAbstractStateRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAbstractStateRealizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IAbstractStateRealization> backingOwnedAbstractStateRealizations;

        /// <summary>
        /// Gets the owned connection points.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IPseudostate> OwnedConnectionPoints => this.backingOwnedConnectionPoints ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacommon.IPseudostate>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConnectionPoints"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IPseudostate> backingOwnedConnectionPoints;

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
        /// Gets the owned regions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IRegion> OwnedRegions => this.backingOwnedRegions ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacommon.IRegion>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRegions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IRegion> backingOwnedRegions;

        /// <summary>
        /// Gets the realized abstract states.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacommon.IAbstractState> RealizedAbstractStates => Enumerable.Empty<Auriga.Model.Capellacommon.IAbstractState>();

        /// <summary>
        /// Gets the realizing abstract states.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacommon.IAbstractState> RealizingAbstractStates => Enumerable.Empty<Auriga.Model.Capellacommon.IAbstractState>();

        /// <summary>
        /// Gets the referenced states.
        /// </summary>
        public List<Auriga.Model.Modellingcore.IIState> ReferencedStates { get; } = new List<Auriga.Model.Modellingcore.IIState>();

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Gets or sets the state invariant.
        /// </summary>
        public Auriga.Model.Modellingcore.IAbstractConstraint StateInvariant
        {
            get => this.backingStateInvariant;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingStateInvariant = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="StateInvariant"/>.
        /// </summary>
        private Auriga.Model.Modellingcore.IAbstractConstraint backingStateInvariant;

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
        public bool? VisibleInDoc { get; set; } = true;

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; } = true;

        /// <summary>
        /// Gets the elements directly contained by this <c>FinalState</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedAbstractStateRealizations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedConnectionPoints)
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

            foreach (var element in this.OwnedExtensions)
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

            foreach (var element in this.OwnedRegions)
            {
                yield return element;
            }

            if (this.StateInvariant != null)
            {
                yield return this.StateInvariant;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
