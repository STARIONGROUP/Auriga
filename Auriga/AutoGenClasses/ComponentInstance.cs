// ------------------------------------------------------------------------------------------------
// <copyright file="ComponentInstance.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa.Deployment
{
    public partial class ComponentInstance : global::Auriga.AurigaElement, global::Auriga.Pa.Deployment.IComponentInstance
    {
        public global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.Deployment.IPortInstance> PortInstances => global::System.Linq.Enumerable.Empty<global::Auriga.Pa.Deployment.IPortInstance>();

        private global::Auriga.IContainerList<global::Auriga.Pa.Deployment.IAbstractPhysicalInstance> backingOwnedAbstractPhysicalInstances;

        public global::Auriga.IContainerList<global::Auriga.Pa.Deployment.IAbstractPhysicalInstance> OwnedAbstractPhysicalInstances => this.backingOwnedAbstractPhysicalInstances ??= new global::Auriga.ContainerList<global::Auriga.Pa.Deployment.IAbstractPhysicalInstance>(this);

        private global::Auriga.IContainerList<global::Auriga.Pa.Deployment.IInstanceDeploymentLink> backingOwnedInstanceDeploymentLinks;

        public global::Auriga.IContainerList<global::Auriga.Pa.Deployment.IInstanceDeploymentLink> OwnedInstanceDeploymentLinks => this.backingOwnedInstanceDeploymentLinks ??= new global::Auriga.ContainerList<global::Auriga.Pa.Deployment.IInstanceDeploymentLink>(this);

        public global::Auriga.Pa.IPhysicalComponent Type { get; set; }

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

        public string Sid { get; set; }

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Modellingcore.IAbstractConstraint> Constraints => global::System.Linq.Enumerable.Empty<global::Auriga.Modellingcore.IAbstractConstraint>();

        private global::Auriga.IContainerList<global::Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        public global::Auriga.IContainerList<global::Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new global::Auriga.ContainerList<global::Auriga.Modellingcore.IAbstractConstraint>(this);

        private global::Auriga.IContainerList<global::Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        public global::Auriga.IContainerList<global::Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new global::Auriga.ContainerList<global::Auriga.Modellingcore.IModelElement>(this);

        private global::Auriga.IContainerList<global::Auriga.Emde.IElementExtension> backingOwnedExtensions;

        public global::Auriga.IContainerList<global::Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new global::Auriga.ContainerList<global::Auriga.Emde.IElementExtension>(this);

        public bool? VisibleInDoc { get; set; }

        public bool? VisibleInLM { get; set; }

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IAbstractDeploymentLink> DeployingLinks => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IAbstractDeploymentLink>();

        public string Name { get; set; }

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IAbstractDeploymentLink> DeploymentLinks => global::System.Linq.Enumerable.Empty<global::Auriga.Cs.IAbstractDeploymentLink>();

    }
}
