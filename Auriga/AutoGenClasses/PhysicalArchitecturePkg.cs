// ------------------------------------------------------------------------------------------------
// <copyright file="PhysicalArchitecturePkg.cs" company="Starion Group S.A.">
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Pa
{
    public partial class PhysicalArchitecturePkg : global::Auriga.AurigaElement, global::Auriga.Pa.IPhysicalArchitecturePkg
    {
        private global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalArchitecturePkg> backingOwnedPhysicalArchitecturePkgs;

        public global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalArchitecturePkg> OwnedPhysicalArchitecturePkgs => this.backingOwnedPhysicalArchitecturePkgs ??= new global::Auriga.ContainerList<global::Auriga.Pa.IPhysicalArchitecturePkg>(this);

        private global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalArchitecture> backingOwnedPhysicalArchitectures;

        public global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalArchitecture> OwnedPhysicalArchitectures => this.backingOwnedPhysicalArchitectures ??= new global::Auriga.ContainerList<global::Auriga.Pa.IPhysicalArchitecture>(this);

        private global::Auriga.IContainerList<global::Auriga.Capellacore.IPropertyValuePkg> backingOwnedPropertyValuePkgs;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.IPropertyValuePkg> OwnedPropertyValuePkgs => this.backingOwnedPropertyValuePkgs ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.IPropertyValuePkg>(this);

        private global::Auriga.IContainerList<global::Auriga.Capellacore.ITrace> backingOwnedTraces;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.ITrace>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.IGenericTrace> ContainedGenericTraces => global::System.Linq.Enumerable.Empty<global::Auriga.Capellacommon.IGenericTrace>();

        private global::Auriga.IContainerList<global::Auriga.Capellacore.INamingRule> backingNamingRules;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.INamingRule> NamingRules => this.backingNamingRules ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.INamingRule>(this);

        public string Name { get; set; }

        public string Sid { get; set; }

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Modellingcore.IAbstractConstraint> Constraints => global::System.Linq.Enumerable.Empty<global::Auriga.Modellingcore.IAbstractConstraint>();

        private global::Auriga.IContainerList<global::Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        public global::Auriga.IContainerList<global::Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new global::Auriga.ContainerList<global::Auriga.Modellingcore.IAbstractConstraint>(this);

        private global::Auriga.IContainerList<global::Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        public global::Auriga.IContainerList<global::Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new global::Auriga.ContainerList<global::Auriga.Modellingcore.IModelElement>(this);

        private global::Auriga.IContainerList<global::Auriga.Emde.IElementExtension> backingOwnedExtensions;

        public global::Auriga.IContainerList<global::Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new global::Auriga.ContainerList<global::Auriga.Emde.IElementExtension>(this);

        public string Summary { get; set; }

        public string Description { get; set; }

        public string Review { get; set; }

        private global::Auriga.IContainerList<global::Auriga.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.IAbstractPropertyValue>(this);

        private global::Auriga.IContainerList<global::Auriga.Capellacore.IEnumerationPropertyType> backingOwnedEnumerationPropertyTypes;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes => this.backingOwnedEnumerationPropertyTypes ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.IEnumerationPropertyType>(this);

        public global::System.Collections.Generic.List<global::Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new global::System.Collections.Generic.List<global::Auriga.Capellacore.IAbstractPropertyValue>();

        private global::Auriga.IContainerList<global::Auriga.Capellacore.IPropertyValueGroup> backingOwnedPropertyValueGroups;

        public global::Auriga.IContainerList<global::Auriga.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups => this.backingOwnedPropertyValueGroups ??= new global::Auriga.ContainerList<global::Auriga.Capellacore.IPropertyValueGroup>(this);

        public global::System.Collections.Generic.List<global::Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new global::System.Collections.Generic.List<global::Auriga.Capellacore.IPropertyValueGroup>();

        public global::Auriga.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        public global::System.Collections.Generic.List<global::Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new global::System.Collections.Generic.List<global::Auriga.Capellacore.IEnumerationPropertyLiteral>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Modellingcore.IAbstractTrace> IncomingTraces => global::System.Linq.Enumerable.Empty<global::Auriga.Modellingcore.IAbstractTrace>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => global::System.Linq.Enumerable.Empty<global::Auriga.Modellingcore.IAbstractTrace>();

        public bool? VisibleInDoc { get; set; }

        public bool? VisibleInLM { get; set; }

    }
}
