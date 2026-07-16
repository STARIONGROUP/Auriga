// ------------------------------------------------------------------------------------------------
// <copyright file="SystemEngineering.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Capellamodeller
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>SystemEngineering</c> class.
    /// </summary>
    public partial class SystemEngineering : Auriga.Core.AurigaElement, Auriga.Model.Capellamodeller.ISystemEngineering
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
        /// Gets the contained e p b s architectures.
        /// </summary>
        public IEnumerable<Auriga.Model.Epbs.IEPBSArchitecture> ContainedEPBSArchitectures => Enumerable.Empty<Auriga.Model.Epbs.IEPBSArchitecture>();

        /// <summary>
        /// Gets the contained generic traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Model.Capellacommon.IGenericTrace>();

        /// <summary>
        /// Gets the contained logical architectures.
        /// </summary>
        public IEnumerable<Auriga.Model.La.ILogicalArchitecture> ContainedLogicalArchitectures => Enumerable.Empty<Auriga.Model.La.ILogicalArchitecture>();

        /// <summary>
        /// Gets the contained operational analysis.
        /// </summary>
        public IEnumerable<Auriga.Model.Oa.IOperationalAnalysis> ContainedOperationalAnalysis => Enumerable.Empty<Auriga.Model.Oa.IOperationalAnalysis>();

        /// <summary>
        /// Gets the contained physical architectures.
        /// </summary>
        public IEnumerable<Auriga.Model.Pa.IPhysicalArchitecture> ContainedPhysicalArchitectures => Enumerable.Empty<Auriga.Model.Pa.IPhysicalArchitecture>();

        /// <summary>
        /// Gets the contained shared pkgs.
        /// </summary>
        public IEnumerable<Auriga.Model.Sharedmodel.ISharedPkg> ContainedSharedPkgs => Enumerable.Empty<Auriga.Model.Sharedmodel.ISharedPkg>();

        /// <summary>
        /// Gets the contained system analysis.
        /// </summary>
        public IEnumerable<Auriga.Model.Ctx.ISystemAnalysis> ContainedSystemAnalysis => Enumerable.Empty<Auriga.Model.Ctx.ISystemAnalysis>();

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
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the owned architecture pkgs.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IModellingArchitecturePkg> OwnedArchitecturePkgs => this.backingOwnedArchitecturePkgs ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IModellingArchitecturePkg>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedArchitecturePkgs"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IModellingArchitecturePkg> backingOwnedArchitecturePkgs;

        /// <summary>
        /// Gets the owned architectures.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IModellingArchitecture> OwnedArchitectures => this.backingOwnedArchitectures ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IModellingArchitecture>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedArchitectures"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IModellingArchitecture> backingOwnedArchitectures;

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
        /// Gets the owned property value pkgs.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IPropertyValuePkg> OwnedPropertyValuePkgs => this.backingOwnedPropertyValuePkgs ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IPropertyValuePkg>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValuePkgs"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IPropertyValuePkg> backingOwnedPropertyValuePkgs;

        /// <summary>
        /// Gets the owned property values.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValues"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        /// <summary>
        /// Gets the owned reuse links.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.IReuseLink> OwnedReuseLinks => this.backingOwnedReuseLinks ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.IReuseLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedReuseLinks"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.IReuseLink> backingOwnedReuseLinks;

        /// <summary>
        /// Gets the owned traces.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.ITrace>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTraces"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets the reuse links.
        /// </summary>
        public List<Auriga.Model.Capellacore.IReuseLink> ReuseLinks { get; } = new List<Auriga.Model.Capellacore.IReuseLink>();

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
        /// Gets the elements directly contained by this <c>SystemEngineering</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.NamingRules)
            {
                yield return element;
            }

            foreach (var element in this.OwnedArchitecturePkgs)
            {
                yield return element;
            }

            foreach (var element in this.OwnedArchitectures)
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

            foreach (var element in this.OwnedPropertyValuePkgs)
            {
                yield return element;
            }

            foreach (var element in this.OwnedPropertyValues)
            {
                yield return element;
            }

            foreach (var element in this.OwnedReuseLinks)
            {
                yield return element;
            }

            foreach (var element in this.OwnedTraces)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
