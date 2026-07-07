// ------------------------------------------------------------------------------------------------
// <copyright file="PhysicalFunction.cs" company="Starion Group S.A.">
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
    public partial class PhysicalFunction : global::Auriga.AurigaElement, global::Auriga.Pa.IPhysicalFunction
    {
        private global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalFunctionPkg> backingOwnedPhysicalFunctionPkgs;

        public global::Auriga.IContainerList<global::Auriga.Pa.IPhysicalFunctionPkg> OwnedPhysicalFunctionPkgs => this.backingOwnedPhysicalFunctionPkgs ??= new global::Auriga.ContainerList<global::Auriga.Pa.IPhysicalFunctionPkg>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalComponent> AllocatingPhysicalComponents => global::System.Linq.Enumerable.Empty<global::Auriga.Pa.IPhysicalComponent>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.La.ILogicalFunction> RealizedLogicalFunctions => global::System.Linq.Enumerable.Empty<global::Auriga.La.ILogicalFunction>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalFunction> ContainedPhysicalFunctions => global::System.Linq.Enumerable.Empty<global::Auriga.Pa.IPhysicalFunction>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Pa.IPhysicalFunction> ChildrenPhysicalFunctions => global::System.Linq.Enumerable.Empty<global::Auriga.Pa.IPhysicalFunction>();

        public global::Auriga.Fa.FunctionKind? Kind { get; set; }

        public string Condition { get; set; }

        private global::Auriga.IContainerList<global::Auriga.Fa.IAbstractFunction> backingOwnedFunctions;

        public global::Auriga.IContainerList<global::Auriga.Fa.IAbstractFunction> OwnedFunctions => this.backingOwnedFunctions ??= new global::Auriga.ContainerList<global::Auriga.Fa.IAbstractFunction>(this);

        private global::Auriga.IContainerList<global::Auriga.Fa.IFunctionRealization> backingOwnedFunctionRealizations;

        public global::Auriga.IContainerList<global::Auriga.Fa.IFunctionRealization> OwnedFunctionRealizations => this.backingOwnedFunctionRealizations ??= new global::Auriga.ContainerList<global::Auriga.Fa.IFunctionRealization>(this);

        private global::Auriga.IContainerList<global::Auriga.Fa.IFunctionalExchange> backingOwnedFunctionalExchanges;

        public global::Auriga.IContainerList<global::Auriga.Fa.IFunctionalExchange> OwnedFunctionalExchanges => this.backingOwnedFunctionalExchanges ??= new global::Auriga.ContainerList<global::Auriga.Fa.IFunctionalExchange>(this);

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunction> SubFunctions => global::System.Linq.Enumerable.Empty<global::Auriga.Fa.IAbstractFunction>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionRealization> OutFunctionRealizations => global::System.Linq.Enumerable.Empty<global::Auriga.Fa.IFunctionRealization>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionRealization> InFunctionRealizations => global::System.Linq.Enumerable.Empty<global::Auriga.Fa.IFunctionRealization>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IComponentFunctionalAllocation> ComponentFunctionalAllocations => global::System.Linq.Enumerable.Empty<global::Auriga.Fa.IComponentFunctionalAllocation>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunctionalBlock> AllocationBlocks => global::System.Linq.Enumerable.Empty<global::Auriga.Fa.IAbstractFunctionalBlock>();

        public global::System.Collections.Generic.List<global::Auriga.Capellacommon.IState> AvailableInStates { get; } = new global::System.Collections.Generic.List<global::Auriga.Capellacommon.IState>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ICapability> InvolvingCapabilities => global::System.Linq.Enumerable.Empty<global::Auriga.Ctx.ICapability>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations => global::System.Linq.Enumerable.Empty<global::Auriga.La.ICapabilityRealization>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IFunctionalChain> InvolvingFunctionalChains => global::System.Linq.Enumerable.Empty<global::Auriga.Fa.IFunctionalChain>();

        public global::Auriga.Capellacommon.IStateMachine LinkedStateMachine => default;

        public global::Auriga.Fa.IFunctionSpecification LinkedFunctionSpecification => default;

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

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacore.IInvolvement> InvolvingInvolvements => global::System.Linq.Enumerable.Empty<global::Auriga.Capellacore.IInvolvement>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IInstanceRole> RepresentingInstanceRoles => global::System.Linq.Enumerable.Empty<global::Auriga.Interaction.IInstanceRole>();

        public global::Auriga.Information.AggregationKind? AggregationKind { get; set; }

        public bool? IsDerived { get; set; }

        public bool? IsReadOnly { get; set; }

        public bool? IsPartOfKey { get; set; }

        public global::Auriga.Information.IAssociation Association => default;

        public bool? IsAbstract { get; set; }

        public bool? IsStatic { get; set; }

        public global::Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        public global::Auriga.Capellacore.IType Type => default;

        public global::Auriga.Modellingcore.IAbstractType AbstractType { get; set; }

        public bool? Ordered { get; set; }

        public bool? Unique { get; set; }

        public bool? MinInclusive { get; set; }

        public bool? MaxInclusive { get; set; }

        public global::Auriga.Information.Datavalue.IDataValue OwnedDefaultValue { get; set; }

        public global::Auriga.Information.Datavalue.IDataValue OwnedMinValue { get; set; }

        public global::Auriga.Information.Datavalue.IDataValue OwnedMaxValue { get; set; }

        public global::Auriga.Information.Datavalue.IDataValue OwnedNullValue { get; set; }

        public global::Auriga.Information.Datavalue.INumericValue OwnedMinCard { get; set; }

        public global::Auriga.Information.Datavalue.INumericValue OwnedMinLength { get; set; }

        public global::Auriga.Information.Datavalue.INumericValue OwnedMaxCard { get; set; }

        public global::Auriga.Information.Datavalue.INumericValue OwnedMaxLength { get; set; }

        public bool? Final { get; set; }

        private global::Auriga.IContainerList<global::Auriga.Fa.IFunctionalChain> backingOwnedFunctionalChains;

        public global::Auriga.IContainerList<global::Auriga.Fa.IFunctionalChain> OwnedFunctionalChains => this.backingOwnedFunctionalChains ??= new global::Auriga.ContainerList<global::Auriga.Fa.IFunctionalChain>(this);

        public global::Auriga.Behavior.IAbstractBehavior Behavior { get; set; }

        private global::Auriga.IContainerList<global::Auriga.Activity.IOutputPin> backingResults;

        public global::Auriga.IContainerList<global::Auriga.Activity.IOutputPin> Results => this.backingResults ??= new global::Auriga.ContainerList<global::Auriga.Activity.IOutputPin>(this);

        private global::Auriga.IContainerList<global::Auriga.Activity.IInputPin> backingArguments;

        public global::Auriga.IContainerList<global::Auriga.Activity.IInputPin> Arguments => this.backingArguments ??= new global::Auriga.ContainerList<global::Auriga.Activity.IInputPin>(this);

        public global::Auriga.Modellingcore.IAbstractConstraint LocalPrecondition { get; set; }

        public global::Auriga.Modellingcore.IAbstractConstraint LocalPostcondition { get; set; }

        public global::Auriga.Modellingcore.IAbstractType Context { get; set; }

        private global::Auriga.IContainerList<global::Auriga.Activity.IInputPin> backingInputs;

        public global::Auriga.IContainerList<global::Auriga.Activity.IInputPin> Inputs => this.backingInputs ??= new global::Auriga.ContainerList<global::Auriga.Activity.IInputPin>(this);

        private global::Auriga.IContainerList<global::Auriga.Activity.IOutputPin> backingOutputs;

        public global::Auriga.IContainerList<global::Auriga.Activity.IOutputPin> Outputs => this.backingOutputs ??= new global::Auriga.ContainerList<global::Auriga.Activity.IOutputPin>(this);

        private global::Auriga.IContainerList<global::Auriga.Activity.IExceptionHandler> backingOwnedHandlers;

        public global::Auriga.IContainerList<global::Auriga.Activity.IExceptionHandler> OwnedHandlers => this.backingOwnedHandlers ??= new global::Auriga.ContainerList<global::Auriga.Activity.IExceptionHandler>(this);

        public global::Auriga.Activity.IActivityPartition InActivityPartition => default;

        public global::Auriga.Activity.IInterruptibleActivityRegion InInterruptibleRegion => default;

        public global::Auriga.Activity.IInterruptibleActivityRegion InStructuredNode => default;

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Activity.IActivityEdge> Outgoing => global::System.Linq.Enumerable.Empty<global::Auriga.Activity.IActivityEdge>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Activity.IActivityEdge> Incoming => global::System.Linq.Enumerable.Empty<global::Auriga.Activity.IActivityEdge>();

        public global::System.Collections.Generic.IEnumerable<global::Auriga.Modellingcore.IAbstractTypedElement> AbstractTypedElements => global::System.Linq.Enumerable.Empty<global::Auriga.Modellingcore.IAbstractTypedElement>();

    }
}
