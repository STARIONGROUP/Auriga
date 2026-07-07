// ------------------------------------------------------------------------------------------------
// <copyright file="DataPkg.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DataPkg</c> class.
    /// </summary>
    public partial class DataPkg : Auriga.AurigaElement, Auriga.Information.IDataPkg
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
        /// Gets the features.
        /// </summary>
        public List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

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
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the owned associations.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IAssociation> OwnedAssociations => this.backingOwnedAssociations ??= new Auriga.ContainerList<Auriga.Information.IAssociation>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedAssociations"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.IAssociation> backingOwnedAssociations;

        /// <summary>
        /// Gets the owned classes.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IClass> OwnedClasses => this.backingOwnedClasses ??= new Auriga.ContainerList<Auriga.Information.IClass>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedClasses"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.IClass> backingOwnedClasses;

        /// <summary>
        /// Gets the owned collections.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.ICollection> OwnedCollections => this.backingOwnedCollections ??= new Auriga.ContainerList<Auriga.Information.ICollection>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedCollections"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.ICollection> backingOwnedCollections;

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        /// <summary>
        /// Gets the owned data pkgs.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IDataPkg> OwnedDataPkgs => this.backingOwnedDataPkgs ??= new Auriga.ContainerList<Auriga.Information.IDataPkg>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDataPkgs"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.IDataPkg> backingOwnedDataPkgs;

        /// <summary>
        /// Gets the owned data types.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.Datatype.IDataType> OwnedDataTypes => this.backingOwnedDataTypes ??= new Auriga.ContainerList<Auriga.Information.Datatype.IDataType>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedDataTypes"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.Datatype.IDataType> backingOwnedDataTypes;

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
        /// Gets the owned exceptions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.Communication.IException> OwnedExceptions => this.backingOwnedExceptions ??= new Auriga.ContainerList<Auriga.Information.Communication.IException>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExceptions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.Communication.IException> backingOwnedExceptions;

        /// <summary>
        /// Gets the owned exchange items.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IExchangeItem> OwnedExchangeItems => this.backingOwnedExchangeItems ??= new Auriga.ContainerList<Auriga.Information.IExchangeItem>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExchangeItems"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.IExchangeItem> backingOwnedExchangeItems;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned key parts.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IKeyPart> OwnedKeyParts => this.backingOwnedKeyParts ??= new Auriga.ContainerList<Auriga.Information.IKeyPart>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedKeyParts"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.IKeyPart> backingOwnedKeyParts;

        /// <summary>
        /// Gets the owned message references.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.Communication.IMessageReference> OwnedMessageReferences => this.backingOwnedMessageReferences ??= new Auriga.ContainerList<Auriga.Information.Communication.IMessageReference>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMessageReferences"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.Communication.IMessageReference> backingOwnedMessageReferences;

        /// <summary>
        /// Gets the owned messages.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.Communication.IMessage> OwnedMessages => this.backingOwnedMessages ??= new Auriga.ContainerList<Auriga.Information.Communication.IMessage>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMessages"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.Communication.IMessage> backingOwnedMessages;

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
        /// Gets the owned signals.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.Communication.ISignal> OwnedSignals => this.backingOwnedSignals ??= new Auriga.ContainerList<Auriga.Information.Communication.ISignal>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedSignals"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.Communication.ISignal> backingOwnedSignals;

        /// <summary>
        /// Gets the owned state events.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacommon.IStateEvent> OwnedStateEvents => this.backingOwnedStateEvents ??= new Auriga.ContainerList<Auriga.Capellacommon.IStateEvent>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedStateEvents"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacommon.IStateEvent> backingOwnedStateEvents;

        /// <summary>
        /// Gets the owned traces.
        /// </summary>
        public Auriga.IContainerList<Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.ContainerList<Auriga.Capellacore.ITrace>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTraces"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets the owned units.
        /// </summary>
        public Auriga.IContainerList<Auriga.Information.IUnit> OwnedUnits => this.backingOwnedUnits ??= new Auriga.ContainerList<Auriga.Information.IUnit>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedUnits"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Information.IUnit> backingOwnedUnits;

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

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
