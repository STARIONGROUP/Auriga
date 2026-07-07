// ------------------------------------------------------------------------------------------------
// <copyright file="CapabilityRealization.cs" company="Starion Group S.A.">
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

namespace Auriga.La
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>CapabilityRealization</c> class.
    /// </summary>
    public partial class CapabilityRealization : Auriga.AurigaElement, Auriga.La.ICapabilityRealization
    {
        /// <summary>
        /// Gets the abstract capability extension points.
        /// </summary>
        public Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityExtensionPoint> AbstractCapabilityExtensionPoints => this.backingAbstractCapabilityExtensionPoints ??= new Auriga.ContainerList<Auriga.Interaction.IAbstractCapabilityExtensionPoint>(this);

        /// <summary>
        /// Backing field for <see cref="AbstractCapabilityExtensionPoints"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityExtensionPoint> backingAbstractCapabilityExtensionPoints;

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
        /// Gets the contained generic traces.
        /// </summary>
        public IEnumerable<Auriga.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Capellacommon.IGenericTrace>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the extended abstract capabilities.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IAbstractCapability> ExtendedAbstractCapabilities => Enumerable.Empty<Auriga.Interaction.IAbstractCapability>();

        /// <summary>
        /// Gets the extending.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IAbstractCapabilityExtend> Extending => Enumerable.Empty<Auriga.Interaction.IAbstractCapabilityExtend>();

        /// <summary>
        /// Gets the extending abstract capabilities.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IAbstractCapability> ExtendingAbstractCapabilities => Enumerable.Empty<Auriga.Interaction.IAbstractCapability>();

        /// <summary>
        /// Gets the extends.
        /// </summary>
        public Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityExtend> Extends => this.backingExtends ??= new Auriga.ContainerList<Auriga.Interaction.IAbstractCapabilityExtend>(this);

        /// <summary>
        /// Backing field for <see cref="Extends"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityExtend> backingExtends;

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the included abstract capabilities.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IAbstractCapability> IncludedAbstractCapabilities => Enumerable.Empty<Auriga.Interaction.IAbstractCapability>();

        /// <summary>
        /// Gets the includes.
        /// </summary>
        public Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityInclude> Includes => this.backingIncludes ??= new Auriga.ContainerList<Auriga.Interaction.IAbstractCapabilityInclude>(this);

        /// <summary>
        /// Backing field for <see cref="Includes"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityInclude> backingIncludes;

        /// <summary>
        /// Gets the including.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IAbstractCapabilityInclude> Including => Enumerable.Empty<Auriga.Interaction.IAbstractCapabilityInclude>();

        /// <summary>
        /// Gets the including abstract capabilities.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IAbstractCapability> IncludingAbstractCapabilities => Enumerable.Empty<Auriga.Interaction.IAbstractCapability>();

        /// <summary>
        /// Gets the incoming capability allocation.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IAbstractCapabilityRealization> IncomingCapabilityAllocation => Enumerable.Empty<Auriga.Interaction.IAbstractCapabilityRealization>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the involved abstract functions.
        /// </summary>
        public IEnumerable<Auriga.Fa.IAbstractFunction> InvolvedAbstractFunctions => Enumerable.Empty<Auriga.Fa.IAbstractFunction>();

        /// <summary>
        /// Gets the involved components.
        /// </summary>
        public IEnumerable<Auriga.Capellacommon.ICapabilityRealizationInvolvedElement> InvolvedComponents => Enumerable.Empty<Auriga.Capellacommon.ICapabilityRealizationInvolvedElement>();

        /// <summary>
        /// Gets the involved functional chains.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalChain> InvolvedFunctionalChains => Enumerable.Empty<Auriga.Fa.IFunctionalChain>();

        /// <summary>
        /// Gets the involved involvements.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IInvolvement> InvolvedInvolvements => Enumerable.Empty<Auriga.Capellacore.IInvolvement>();

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
        /// Gets the outgoing capability allocation.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IAbstractCapabilityRealization> OutgoingCapabilityAllocation => Enumerable.Empty<Auriga.Interaction.IAbstractCapabilityRealization>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the owned abstract capability realizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityRealization> OwnedAbstractCapabilityRealizations => this.backingOwnedAbstractCapabilityRealizations ??= new Auriga.ContainerList<Auriga.Interaction.IAbstractCapabilityRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAbstractCapabilityRealizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityRealization> backingOwnedAbstractCapabilityRealizations;

        /// <summary>
        /// Gets the owned abstract function abstract capability involvements.
        /// </summary>
        public Auriga.IContainerList<Auriga.Interaction.IAbstractFunctionAbstractCapabilityInvolvement> OwnedAbstractFunctionAbstractCapabilityInvolvements => this.backingOwnedAbstractFunctionAbstractCapabilityInvolvements ??= new Auriga.ContainerList<Auriga.Interaction.IAbstractFunctionAbstractCapabilityInvolvement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAbstractFunctionAbstractCapabilityInvolvements"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Interaction.IAbstractFunctionAbstractCapabilityInvolvement> backingOwnedAbstractFunctionAbstractCapabilityInvolvements;

        /// <summary>
        /// Gets the owned capability realization involvements.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacommon.ICapabilityRealizationInvolvement> OwnedCapabilityRealizationInvolvements => this.backingOwnedCapabilityRealizationInvolvements ??= new Auriga.ContainerList<Auriga.Capellacommon.ICapabilityRealizationInvolvement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedCapabilityRealizationInvolvements"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacommon.ICapabilityRealizationInvolvement> backingOwnedCapabilityRealizationInvolvements;

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
        /// Gets the owned functional chain abstract capability involvements.
        /// </summary>
        public Auriga.IContainerList<Auriga.Interaction.IFunctionalChainAbstractCapabilityInvolvement> OwnedFunctionalChainAbstractCapabilityInvolvements => this.backingOwnedFunctionalChainAbstractCapabilityInvolvements ??= new Auriga.ContainerList<Auriga.Interaction.IFunctionalChainAbstractCapabilityInvolvement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalChainAbstractCapabilityInvolvements"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Interaction.IFunctionalChainAbstractCapabilityInvolvement> backingOwnedFunctionalChainAbstractCapabilityInvolvements;

        /// <summary>
        /// Gets the owned functional chains.
        /// </summary>
        public Auriga.IContainerList<Auriga.Fa.IFunctionalChain> OwnedFunctionalChains => this.backingOwnedFunctionalChains ??= new Auriga.ContainerList<Auriga.Fa.IFunctionalChain>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalChains"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Fa.IFunctionalChain> backingOwnedFunctionalChains;

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
        /// Gets the owned property value pkgs.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IPropertyValuePkg> OwnedPropertyValuePkgs => this.backingOwnedPropertyValuePkgs ??= new Auriga.ContainerList<Auriga.Capellacore.IPropertyValuePkg>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValuePkgs"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IPropertyValuePkg> backingOwnedPropertyValuePkgs;

        /// <summary>
        /// Gets the owned property values.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.ContainerList<Auriga.Capellacore.IAbstractPropertyValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValues"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        /// <summary>
        /// Gets the owned scenarios.
        /// </summary>
        public Auriga.IContainerList<Auriga.Interaction.IScenario> OwnedScenarios => this.backingOwnedScenarios ??= new Auriga.ContainerList<Auriga.Interaction.IScenario>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedScenarios"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Interaction.IScenario> backingOwnedScenarios;

        /// <summary>
        /// Gets the owned traces.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.ContainerList<Auriga.Capellacore.ITrace>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTraces"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets or sets the post condition.
        /// </summary>
        public Auriga.Capellacore.IConstraint PostCondition { get; set; }

        /// <summary>
        /// Gets or sets the pre condition.
        /// </summary>
        public Auriga.Capellacore.IConstraint PreCondition { get; set; }

        /// <summary>
        /// Gets the realized capabilities.
        /// </summary>
        public IEnumerable<Auriga.Ctx.ICapability> RealizedCapabilities => Enumerable.Empty<Auriga.Ctx.ICapability>();

        /// <summary>
        /// Gets the realized capability realizations.
        /// </summary>
        public IEnumerable<Auriga.La.ICapabilityRealization> RealizedCapabilityRealizations => Enumerable.Empty<Auriga.La.ICapabilityRealization>();

        /// <summary>
        /// Gets the realizing capability realizations.
        /// </summary>
        public IEnumerable<Auriga.La.ICapabilityRealization> RealizingCapabilityRealizations => Enumerable.Empty<Auriga.La.ICapabilityRealization>();

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
        public IEnumerable<Auriga.Interaction.IAbstractCapability> Sub => Enumerable.Empty<Auriga.Interaction.IAbstractCapability>();

        /// <summary>
        /// Gets the sub generalizations.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IAbstractCapabilityGeneralization> SubGeneralizations => Enumerable.Empty<Auriga.Interaction.IAbstractCapabilityGeneralization>();

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets the super.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IAbstractCapability> Super => Enumerable.Empty<Auriga.Interaction.IAbstractCapability>();

        /// <summary>
        /// Gets the super generalizations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityGeneralization> SuperGeneralizations => this.backingSuperGeneralizations ??= new Auriga.ContainerList<Auriga.Interaction.IAbstractCapabilityGeneralization>(this);

        /// <summary>
        /// Backing field for <see cref="SuperGeneralizations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Interaction.IAbstractCapabilityGeneralization> backingSuperGeneralizations;

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
