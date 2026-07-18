// ------------------------------------------------------------------------------------------------
// <copyright file="Association.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Information
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Association</c> class.
    /// </summary>
    public partial class Association : Auriga.Core.AurigaElement, Auriga.Model.Information.IAssociation
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
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the naming rules.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.INamingRule> NamingRules => this.backingNamingRules ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.INamingRule>(this);

        /// <summary>
        /// Backing field for <see cref="NamingRules"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.INamingRule> backingNamingRules;

        /// <summary>
        /// Gets the navigable members.
        /// </summary>
        public List<Auriga.Model.Information.IProperty> NavigableMembers { get; } = new List<Auriga.Model.Information.IProperty>();

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
        /// Gets the owned members.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Information.IProperty> OwnedMembers => this.backingOwnedMembers ??= new Auriga.Core.ContainerList<Auriga.Model.Information.IProperty>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMembers"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Information.IProperty> backingOwnedMembers;

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
        /// Gets or sets the realized flow.
        /// </summary>
        public Auriga.Model.Modellingcore.IAbstractInformationFlow RealizedFlow { get; set; }

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
        public bool? VisibleInDoc { get; set; } = true;

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; } = true;

        /// <summary>
        /// Gets the elements directly contained by this <c>Association</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.NamingRules)
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

            foreach (var element in this.OwnedMembers)
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
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
