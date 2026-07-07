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
    using System.Collections.Generic;
    using System.Linq;

    public partial class PhysicalFunction : Auriga.AurigaElement, Auriga.Pa.IPhysicalFunction
    {
        private Auriga.IContainerList<Auriga.Pa.IPhysicalFunctionPkg> backingOwnedPhysicalFunctionPkgs;

        public Auriga.IContainerList<Auriga.Pa.IPhysicalFunctionPkg> OwnedPhysicalFunctionPkgs => this.backingOwnedPhysicalFunctionPkgs ??= new Auriga.ContainerList<Auriga.Pa.IPhysicalFunctionPkg>(this);

        public IEnumerable<Auriga.Pa.IPhysicalComponent> AllocatingPhysicalComponents => Enumerable.Empty<Auriga.Pa.IPhysicalComponent>();

        public IEnumerable<Auriga.La.ILogicalFunction> RealizedLogicalFunctions => Enumerable.Empty<Auriga.La.ILogicalFunction>();

        public IEnumerable<Auriga.Pa.IPhysicalFunction> ContainedPhysicalFunctions => Enumerable.Empty<Auriga.Pa.IPhysicalFunction>();

        public IEnumerable<Auriga.Pa.IPhysicalFunction> ChildrenPhysicalFunctions => Enumerable.Empty<Auriga.Pa.IPhysicalFunction>();

        public Auriga.Fa.FunctionKind? Kind { get; set; }

        public string Condition { get; set; }

        private Auriga.IContainerList<Auriga.Fa.IAbstractFunction> backingOwnedFunctions;

        public Auriga.IContainerList<Auriga.Fa.IAbstractFunction> OwnedFunctions => this.backingOwnedFunctions ??= new Auriga.ContainerList<Auriga.Fa.IAbstractFunction>(this);

        private Auriga.IContainerList<Auriga.Fa.IFunctionRealization> backingOwnedFunctionRealizations;

        public Auriga.IContainerList<Auriga.Fa.IFunctionRealization> OwnedFunctionRealizations => this.backingOwnedFunctionRealizations ??= new Auriga.ContainerList<Auriga.Fa.IFunctionRealization>(this);

        private Auriga.IContainerList<Auriga.Fa.IFunctionalExchange> backingOwnedFunctionalExchanges;

        public Auriga.IContainerList<Auriga.Fa.IFunctionalExchange> OwnedFunctionalExchanges => this.backingOwnedFunctionalExchanges ??= new Auriga.ContainerList<Auriga.Fa.IFunctionalExchange>(this);

        public IEnumerable<Auriga.Fa.IAbstractFunction> SubFunctions => Enumerable.Empty<Auriga.Fa.IAbstractFunction>();

        public IEnumerable<Auriga.Fa.IFunctionRealization> OutFunctionRealizations => Enumerable.Empty<Auriga.Fa.IFunctionRealization>();

        public IEnumerable<Auriga.Fa.IFunctionRealization> InFunctionRealizations => Enumerable.Empty<Auriga.Fa.IFunctionRealization>();

        public IEnumerable<Auriga.Fa.IComponentFunctionalAllocation> ComponentFunctionalAllocations => Enumerable.Empty<Auriga.Fa.IComponentFunctionalAllocation>();

        public IEnumerable<Auriga.Fa.IAbstractFunctionalBlock> AllocationBlocks => Enumerable.Empty<Auriga.Fa.IAbstractFunctionalBlock>();

        public List<Auriga.Capellacommon.IState> AvailableInStates { get; } = new List<Auriga.Capellacommon.IState>();

        public IEnumerable<Auriga.Ctx.ICapability> InvolvingCapabilities => Enumerable.Empty<Auriga.Ctx.ICapability>();

        public IEnumerable<Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations => Enumerable.Empty<Auriga.La.ICapabilityRealization>();

        public IEnumerable<Auriga.Fa.IFunctionalChain> InvolvingFunctionalChains => Enumerable.Empty<Auriga.Fa.IFunctionalChain>();

        public Auriga.Capellacommon.IStateMachine LinkedStateMachine => default;

        public Auriga.Fa.IFunctionSpecification LinkedFunctionSpecification => default;

        private Auriga.IContainerList<Auriga.Capellacore.ITrace> backingOwnedTraces;

        public Auriga.IContainerList<Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.ContainerList<Auriga.Capellacore.ITrace>(this);

        public IEnumerable<Auriga.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Capellacommon.IGenericTrace>();

        private Auriga.IContainerList<Auriga.Capellacore.INamingRule> backingNamingRules;

        public Auriga.IContainerList<Auriga.Capellacore.INamingRule> NamingRules => this.backingNamingRules ??= new Auriga.ContainerList<Auriga.Capellacore.INamingRule>(this);

        public string Name { get; set; }

        public string Sid { get; set; }

        public IEnumerable<Auriga.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Modellingcore.IAbstractConstraint>();

        private Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        public Auriga.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        private Auriga.IContainerList<Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        public Auriga.IContainerList<Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.ContainerList<Auriga.Modellingcore.IModelElement>(this);

        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        public string Summary { get; set; }

        public string Description { get; set; }

        public string Review { get; set; }

        private Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        public Auriga.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.ContainerList<Auriga.Capellacore.IAbstractPropertyValue>(this);

        private Auriga.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> backingOwnedEnumerationPropertyTypes;

        public Auriga.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes => this.backingOwnedEnumerationPropertyTypes ??= new Auriga.ContainerList<Auriga.Capellacore.IEnumerationPropertyType>(this);

        public List<Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Capellacore.IAbstractPropertyValue>();

        private Auriga.IContainerList<Auriga.Capellacore.IPropertyValueGroup> backingOwnedPropertyValueGroups;

        public Auriga.IContainerList<Auriga.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups => this.backingOwnedPropertyValueGroups ??= new Auriga.ContainerList<Auriga.Capellacore.IPropertyValueGroup>(this);

        public List<Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Capellacore.IPropertyValueGroup>();

        public Auriga.Capellacore.IEnumerationPropertyLiteral Status { get; set; }

        public List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Capellacore.IEnumerationPropertyLiteral>();

        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        public bool? VisibleInDoc { get; set; }

        public bool? VisibleInLM { get; set; }

        public IEnumerable<Auriga.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Capellacore.IInvolvement>();

        public IEnumerable<Auriga.Interaction.IInstanceRole> RepresentingInstanceRoles => Enumerable.Empty<Auriga.Interaction.IInstanceRole>();

        public Auriga.Information.AggregationKind? AggregationKind { get; set; }

        public bool? IsDerived { get; set; }

        public bool? IsReadOnly { get; set; }

        public bool? IsPartOfKey { get; set; }

        public Auriga.Information.IAssociation Association => default;

        public bool? IsAbstract { get; set; }

        public bool? IsStatic { get; set; }

        public Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        public Auriga.Capellacore.IType Type => default;

        public Auriga.Modellingcore.IAbstractType AbstractType { get; set; }

        public bool? Ordered { get; set; }

        public bool? Unique { get; set; }

        public bool? MinInclusive { get; set; }

        public bool? MaxInclusive { get; set; }

        public Auriga.Information.Datavalue.IDataValue OwnedDefaultValue { get; set; }

        public Auriga.Information.Datavalue.IDataValue OwnedMinValue { get; set; }

        public Auriga.Information.Datavalue.IDataValue OwnedMaxValue { get; set; }

        public Auriga.Information.Datavalue.IDataValue OwnedNullValue { get; set; }

        public Auriga.Information.Datavalue.INumericValue OwnedMinCard { get; set; }

        public Auriga.Information.Datavalue.INumericValue OwnedMinLength { get; set; }

        public Auriga.Information.Datavalue.INumericValue OwnedMaxCard { get; set; }

        public Auriga.Information.Datavalue.INumericValue OwnedMaxLength { get; set; }

        public bool? Final { get; set; }

        private Auriga.IContainerList<Auriga.Fa.IFunctionalChain> backingOwnedFunctionalChains;

        public Auriga.IContainerList<Auriga.Fa.IFunctionalChain> OwnedFunctionalChains => this.backingOwnedFunctionalChains ??= new Auriga.ContainerList<Auriga.Fa.IFunctionalChain>(this);

        public Auriga.Behavior.IAbstractBehavior Behavior { get; set; }

        private Auriga.IContainerList<Auriga.Activity.IOutputPin> backingResults;

        public Auriga.IContainerList<Auriga.Activity.IOutputPin> Results => this.backingResults ??= new Auriga.ContainerList<Auriga.Activity.IOutputPin>(this);

        private Auriga.IContainerList<Auriga.Activity.IInputPin> backingArguments;

        public Auriga.IContainerList<Auriga.Activity.IInputPin> Arguments => this.backingArguments ??= new Auriga.ContainerList<Auriga.Activity.IInputPin>(this);

        public Auriga.Modellingcore.IAbstractConstraint LocalPrecondition { get; set; }

        public Auriga.Modellingcore.IAbstractConstraint LocalPostcondition { get; set; }

        public Auriga.Modellingcore.IAbstractType Context { get; set; }

        private Auriga.IContainerList<Auriga.Activity.IInputPin> backingInputs;

        public Auriga.IContainerList<Auriga.Activity.IInputPin> Inputs => this.backingInputs ??= new Auriga.ContainerList<Auriga.Activity.IInputPin>(this);

        private Auriga.IContainerList<Auriga.Activity.IOutputPin> backingOutputs;

        public Auriga.IContainerList<Auriga.Activity.IOutputPin> Outputs => this.backingOutputs ??= new Auriga.ContainerList<Auriga.Activity.IOutputPin>(this);

        private Auriga.IContainerList<Auriga.Activity.IExceptionHandler> backingOwnedHandlers;

        public Auriga.IContainerList<Auriga.Activity.IExceptionHandler> OwnedHandlers => this.backingOwnedHandlers ??= new Auriga.ContainerList<Auriga.Activity.IExceptionHandler>(this);

        public Auriga.Activity.IActivityPartition InActivityPartition => default;

        public Auriga.Activity.IInterruptibleActivityRegion InInterruptibleRegion => default;

        public Auriga.Activity.IInterruptibleActivityRegion InStructuredNode => default;

        public IEnumerable<Auriga.Activity.IActivityEdge> Outgoing => Enumerable.Empty<Auriga.Activity.IActivityEdge>();

        public IEnumerable<Auriga.Activity.IActivityEdge> Incoming => Enumerable.Empty<Auriga.Activity.IActivityEdge>();

        public IEnumerable<Auriga.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Modellingcore.IAbstractTypedElement>();

    }
}
