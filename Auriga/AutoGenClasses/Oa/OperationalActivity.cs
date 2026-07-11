// ------------------------------------------------------------------------------------------------
// <copyright file="OperationalActivity.cs" company="Starion Group S.A.">
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

namespace Auriga.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>OperationalActivity</c> class.
    /// </summary>
    public partial class OperationalActivity : Auriga.Core.AurigaElement, Auriga.Oa.IOperationalActivity
    {
        /// <summary>
        /// Gets or sets the abstract type.
        /// </summary>
        public Auriga.Modellingcore.IAbstractType AbstractType { get; set; }

        /// <summary>
        /// Gets the abstract typed elements.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Modellingcore.IAbstractTypedElement>();

        /// <summary>
        /// Gets the activity allocations.
        /// </summary>
        public IEnumerable<Auriga.Oa.IActivityAllocation> ActivityAllocations => Enumerable.Empty<Auriga.Oa.IActivityAllocation>();

        /// <summary>
        /// Gets or sets the aggregation kind.
        /// </summary>
        public Auriga.Information.AggregationKind? AggregationKind { get; set; }

        /// <summary>
        /// Gets the allocating roles.
        /// </summary>
        public IEnumerable<Auriga.Oa.IRole> AllocatingRoles => Enumerable.Empty<Auriga.Oa.IRole>();

        /// <summary>
        /// Gets the allocation blocks.
        /// </summary>
        public IEnumerable<Auriga.Fa.IAbstractFunctionalBlock> AllocationBlocks => Enumerable.Empty<Auriga.Fa.IAbstractFunctionalBlock>();

        /// <summary>
        /// Gets the allocator entities.
        /// </summary>
        public IEnumerable<Auriga.Oa.IEntity> AllocatorEntities => Enumerable.Empty<Auriga.Oa.IEntity>();

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Activity.IInputPin> Arguments => this.backingArguments ??= new Auriga.Core.ContainerList<Auriga.Activity.IInputPin>(this);

        /// <summary>
        /// Backing field for <see cref="Arguments"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Activity.IInputPin> backingArguments;

        /// <summary>
        /// Gets the association.
        /// </summary>
        public Auriga.Information.IAssociation Association => default;

        /// <summary>
        /// Gets the available in states.
        /// </summary>
        public List<Auriga.Capellacommon.IState> AvailableInStates { get; } = new List<Auriga.Capellacommon.IState>();

        /// <summary>
        /// Gets or sets the behavior.
        /// </summary>
        public Auriga.Behavior.IAbstractBehavior Behavior { get; set; }

        /// <summary>
        /// Gets the children operational activities.
        /// </summary>
        public IEnumerable<Auriga.Oa.IOperationalActivity> ChildrenOperationalActivities => Enumerable.Empty<Auriga.Oa.IOperationalActivity>();

        /// <summary>
        /// Gets the component functional allocations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IComponentFunctionalAllocation> ComponentFunctionalAllocations => Enumerable.Empty<Auriga.Fa.IComponentFunctionalAllocation>();

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets the contained generic traces.
        /// </summary>
        public IEnumerable<Auriga.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Capellacommon.IGenericTrace>();

        /// <summary>
        /// Gets the contained operational activities.
        /// </summary>
        public IEnumerable<Auriga.Oa.IOperationalActivity> ContainedOperationalActivities => Enumerable.Empty<Auriga.Oa.IOperationalActivity>();

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        public Auriga.Modellingcore.IAbstractType Context { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets or sets the final.
        /// </summary>
        public bool? Final { get; set; }

        /// <summary>
        /// Gets the in activity partition.
        /// </summary>
        public Auriga.Activity.IActivityPartition InActivityPartition => default;

        /// <summary>
        /// Gets the in function realizations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionRealization> InFunctionRealizations => Enumerable.Empty<Auriga.Fa.IFunctionRealization>();

        /// <summary>
        /// Gets the in interruptible region.
        /// </summary>
        public Auriga.Activity.IInterruptibleActivityRegion InInterruptibleRegion => default;

        /// <summary>
        /// Gets the in structured node.
        /// </summary>
        public Auriga.Activity.IInterruptibleActivityRegion InStructuredNode => default;

        /// <summary>
        /// Gets the incoming.
        /// </summary>
        public IEnumerable<Auriga.Activity.IActivityEdge> Incoming => Enumerable.Empty<Auriga.Activity.IActivityEdge>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the inputs.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Activity.IInputPin> Inputs => this.backingInputs ??= new Auriga.Core.ContainerList<Auriga.Activity.IInputPin>(this);

        /// <summary>
        /// Backing field for <see cref="Inputs"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Activity.IInputPin> backingInputs;

        /// <summary>
        /// Gets the involving capabilities.
        /// </summary>
        public IEnumerable<Auriga.Ctx.ICapability> InvolvingCapabilities => Enumerable.Empty<Auriga.Ctx.ICapability>();

        /// <summary>
        /// Gets the involving capability realizations.
        /// </summary>
        public IEnumerable<Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations => Enumerable.Empty<Auriga.La.ICapabilityRealization>();

        /// <summary>
        /// Gets the involving functional chains.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionalChain> InvolvingFunctionalChains => Enumerable.Empty<Auriga.Fa.IFunctionalChain>();

        /// <summary>
        /// Gets the involving involvements.
        /// </summary>
        public IEnumerable<Auriga.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Capellacore.IInvolvement>();

        /// <summary>
        /// Gets or sets the is abstract.
        /// </summary>
        public bool? IsAbstract { get; set; }

        /// <summary>
        /// Gets or sets the is derived.
        /// </summary>
        public bool? IsDerived { get; set; }

        /// <summary>
        /// Gets or sets the is part of key.
        /// </summary>
        public bool? IsPartOfKey { get; set; }

        /// <summary>
        /// Gets or sets the is read only.
        /// </summary>
        public bool? IsReadOnly { get; set; }

        /// <summary>
        /// Gets or sets the is static.
        /// </summary>
        public bool? IsStatic { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public Auriga.Fa.FunctionKind? Kind { get; set; }

        /// <summary>
        /// Gets the linked function specification.
        /// </summary>
        public Auriga.Fa.IFunctionSpecification LinkedFunctionSpecification => default;

        /// <summary>
        /// Gets the linked state machine.
        /// </summary>
        public Auriga.Capellacommon.IStateMachine LinkedStateMachine => default;

        /// <summary>
        /// Gets or sets the local postcondition.
        /// </summary>
        public Auriga.Modellingcore.IAbstractConstraint LocalPostcondition
        {
            get => this.backingLocalPostcondition;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingLocalPostcondition = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="LocalPostcondition"/>.
        /// </summary>
        private Auriga.Modellingcore.IAbstractConstraint backingLocalPostcondition;

        /// <summary>
        /// Gets or sets the local precondition.
        /// </summary>
        public Auriga.Modellingcore.IAbstractConstraint LocalPrecondition
        {
            get => this.backingLocalPrecondition;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingLocalPrecondition = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="LocalPrecondition"/>.
        /// </summary>
        private Auriga.Modellingcore.IAbstractConstraint backingLocalPrecondition;

        /// <summary>
        /// Gets or sets the max inclusive.
        /// </summary>
        public bool? MaxInclusive { get; set; }

        /// <summary>
        /// Gets or sets the min inclusive.
        /// </summary>
        public bool? MinInclusive { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the naming rules.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Capellacore.INamingRule> NamingRules => this.backingNamingRules ??= new Auriga.Core.ContainerList<Auriga.Capellacore.INamingRule>(this);

        /// <summary>
        /// Backing field for <see cref="NamingRules"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Capellacore.INamingRule> backingNamingRules;

        /// <summary>
        /// Gets or sets the ordered.
        /// </summary>
        public bool? Ordered { get; set; }

        /// <summary>
        /// Gets the out function realizations.
        /// </summary>
        public IEnumerable<Auriga.Fa.IFunctionRealization> OutFunctionRealizations => Enumerable.Empty<Auriga.Fa.IFunctionRealization>();

        /// <summary>
        /// Gets the outgoing.
        /// </summary>
        public IEnumerable<Auriga.Activity.IActivityEdge> Outgoing => Enumerable.Empty<Auriga.Activity.IActivityEdge>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the outputs.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Activity.IOutputPin> Outputs => this.backingOutputs ??= new Auriga.Core.ContainerList<Auriga.Activity.IOutputPin>(this);

        /// <summary>
        /// Backing field for <see cref="Outputs"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Activity.IOutputPin> backingOutputs;

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.Core.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        /// <summary>
        /// Gets or sets the owned default value.
        /// </summary>
        public Auriga.Information.Datavalue.IDataValue OwnedDefaultValue
        {
            get => this.backingOwnedDefaultValue;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedDefaultValue = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedDefaultValue"/>.
        /// </summary>
        private Auriga.Information.Datavalue.IDataValue backingOwnedDefaultValue;

        /// <summary>
        /// Gets the owned enumeration property types.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> OwnedEnumerationPropertyTypes => this.backingOwnedEnumerationPropertyTypes ??= new Auriga.Core.ContainerList<Auriga.Capellacore.IEnumerationPropertyType>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedEnumerationPropertyTypes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Capellacore.IEnumerationPropertyType> backingOwnedEnumerationPropertyTypes;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned function realizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Fa.IFunctionRealization> OwnedFunctionRealizations => this.backingOwnedFunctionRealizations ??= new Auriga.Core.ContainerList<Auriga.Fa.IFunctionRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionRealizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Fa.IFunctionRealization> backingOwnedFunctionRealizations;

        /// <summary>
        /// Gets the owned functional chains.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Fa.IFunctionalChain> OwnedFunctionalChains => this.backingOwnedFunctionalChains ??= new Auriga.Core.ContainerList<Auriga.Fa.IFunctionalChain>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalChains"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Fa.IFunctionalChain> backingOwnedFunctionalChains;

        /// <summary>
        /// Gets the owned functional exchanges.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Fa.IFunctionalExchange> OwnedFunctionalExchanges => this.backingOwnedFunctionalExchanges ??= new Auriga.Core.ContainerList<Auriga.Fa.IFunctionalExchange>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalExchanges"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Fa.IFunctionalExchange> backingOwnedFunctionalExchanges;

        /// <summary>
        /// Gets the owned functions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Fa.IAbstractFunction> OwnedFunctions => this.backingOwnedFunctions ??= new Auriga.Core.ContainerList<Auriga.Fa.IAbstractFunction>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Fa.IAbstractFunction> backingOwnedFunctions;

        /// <summary>
        /// Gets the owned handlers.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Activity.IExceptionHandler> OwnedHandlers => this.backingOwnedHandlers ??= new Auriga.Core.ContainerList<Auriga.Activity.IExceptionHandler>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedHandlers"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Activity.IExceptionHandler> backingOwnedHandlers;

        /// <summary>
        /// Gets or sets the owned max card.
        /// </summary>
        public Auriga.Information.Datavalue.INumericValue OwnedMaxCard
        {
            get => this.backingOwnedMaxCard;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMaxCard = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMaxCard"/>.
        /// </summary>
        private Auriga.Information.Datavalue.INumericValue backingOwnedMaxCard;

        /// <summary>
        /// Gets or sets the owned max length.
        /// </summary>
        public Auriga.Information.Datavalue.INumericValue OwnedMaxLength
        {
            get => this.backingOwnedMaxLength;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMaxLength = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMaxLength"/>.
        /// </summary>
        private Auriga.Information.Datavalue.INumericValue backingOwnedMaxLength;

        /// <summary>
        /// Gets or sets the owned max value.
        /// </summary>
        public Auriga.Information.Datavalue.IDataValue OwnedMaxValue
        {
            get => this.backingOwnedMaxValue;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMaxValue = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMaxValue"/>.
        /// </summary>
        private Auriga.Information.Datavalue.IDataValue backingOwnedMaxValue;

        /// <summary>
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.Core.ContainerList<Auriga.Modellingcore.IModelElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMigratedElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets or sets the owned min card.
        /// </summary>
        public Auriga.Information.Datavalue.INumericValue OwnedMinCard
        {
            get => this.backingOwnedMinCard;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMinCard = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMinCard"/>.
        /// </summary>
        private Auriga.Information.Datavalue.INumericValue backingOwnedMinCard;

        /// <summary>
        /// Gets or sets the owned min length.
        /// </summary>
        public Auriga.Information.Datavalue.INumericValue OwnedMinLength
        {
            get => this.backingOwnedMinLength;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMinLength = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMinLength"/>.
        /// </summary>
        private Auriga.Information.Datavalue.INumericValue backingOwnedMinLength;

        /// <summary>
        /// Gets or sets the owned min value.
        /// </summary>
        public Auriga.Information.Datavalue.IDataValue OwnedMinValue
        {
            get => this.backingOwnedMinValue;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedMinValue = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedMinValue"/>.
        /// </summary>
        private Auriga.Information.Datavalue.IDataValue backingOwnedMinValue;

        /// <summary>
        /// Gets or sets the owned null value.
        /// </summary>
        public Auriga.Information.Datavalue.IDataValue OwnedNullValue
        {
            get => this.backingOwnedNullValue;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedNullValue = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedNullValue"/>.
        /// </summary>
        private Auriga.Information.Datavalue.IDataValue backingOwnedNullValue;

        /// <summary>
        /// Gets the owned operational activity pkgs.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Oa.IOperationalActivityPkg> OwnedOperationalActivityPkgs => this.backingOwnedOperationalActivityPkgs ??= new Auriga.Core.ContainerList<Auriga.Oa.IOperationalActivityPkg>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedOperationalActivityPkgs"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Oa.IOperationalActivityPkg> backingOwnedOperationalActivityPkgs;

        /// <summary>
        /// Gets the owned process.
        /// </summary>
        public IEnumerable<Auriga.Oa.IOperationalProcess> OwnedProcess => Enumerable.Empty<Auriga.Oa.IOperationalProcess>();

        /// <summary>
        /// Gets the owned property value groups.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Capellacore.IPropertyValueGroup> OwnedPropertyValueGroups => this.backingOwnedPropertyValueGroups ??= new Auriga.Core.ContainerList<Auriga.Capellacore.IPropertyValueGroup>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValueGroups"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Capellacore.IPropertyValueGroup> backingOwnedPropertyValueGroups;

        /// <summary>
        /// Gets the owned property values.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> OwnedPropertyValues => this.backingOwnedPropertyValues ??= new Auriga.Core.ContainerList<Auriga.Capellacore.IAbstractPropertyValue>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPropertyValues"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Capellacore.IAbstractPropertyValue> backingOwnedPropertyValues;

        /// <summary>
        /// Gets the owned swimlanes.
        /// </summary>
        public IEnumerable<Auriga.Oa.ISwimlane> OwnedSwimlanes => Enumerable.Empty<Auriga.Oa.ISwimlane>();

        /// <summary>
        /// Gets the owned traces.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.Core.ContainerList<Auriga.Capellacore.ITrace>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTraces"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets the realizing system functions.
        /// </summary>
        public IEnumerable<Auriga.Ctx.ISystemFunction> RealizingSystemFunctions => Enumerable.Empty<Auriga.Ctx.ISystemFunction>();

        /// <summary>
        /// Gets the representing instance roles.
        /// </summary>
        public IEnumerable<Auriga.Interaction.IInstanceRole> RepresentingInstanceRoles => Enumerable.Empty<Auriga.Interaction.IInstanceRole>();

        /// <summary>
        /// Gets the results.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Activity.IOutputPin> Results => this.backingResults ??= new Auriga.Core.ContainerList<Auriga.Activity.IOutputPin>(this);

        /// <summary>
        /// Backing field for <see cref="Results"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Activity.IOutputPin> backingResults;

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
        /// Gets the sub functions.
        /// </summary>
        public IEnumerable<Auriga.Fa.IAbstractFunction> SubFunctions => Enumerable.Empty<Auriga.Fa.IAbstractFunction>();

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public Auriga.Capellacore.IType Type => default;

        /// <summary>
        /// Gets or sets the unique.
        /// </summary>
        public bool? Unique { get; set; }

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

        /// <summary>
        /// Gets the elements directly contained by this <c>OperationalActivity</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Arguments)
            {
                yield return element;
            }

            foreach (var element in this.Inputs)
            {
                yield return element;
            }

            if (this.LocalPostcondition != null)
            {
                yield return this.LocalPostcondition;
            }

            if (this.LocalPrecondition != null)
            {
                yield return this.LocalPrecondition;
            }

            foreach (var element in this.NamingRules)
            {
                yield return element;
            }

            foreach (var element in this.Outputs)
            {
                yield return element;
            }

            foreach (var element in this.OwnedConstraints)
            {
                yield return element;
            }

            if (this.OwnedDefaultValue != null)
            {
                yield return this.OwnedDefaultValue;
            }

            foreach (var element in this.OwnedEnumerationPropertyTypes)
            {
                yield return element;
            }

            foreach (var element in this.OwnedExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedFunctionRealizations)
            {
                yield return element;
            }

            foreach (var element in this.OwnedFunctionalChains)
            {
                yield return element;
            }

            foreach (var element in this.OwnedFunctionalExchanges)
            {
                yield return element;
            }

            foreach (var element in this.OwnedFunctions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedHandlers)
            {
                yield return element;
            }

            if (this.OwnedMaxCard != null)
            {
                yield return this.OwnedMaxCard;
            }

            if (this.OwnedMaxLength != null)
            {
                yield return this.OwnedMaxLength;
            }

            if (this.OwnedMaxValue != null)
            {
                yield return this.OwnedMaxValue;
            }

            foreach (var element in this.OwnedMigratedElements)
            {
                yield return element;
            }

            if (this.OwnedMinCard != null)
            {
                yield return this.OwnedMinCard;
            }

            if (this.OwnedMinLength != null)
            {
                yield return this.OwnedMinLength;
            }

            if (this.OwnedMinValue != null)
            {
                yield return this.OwnedMinValue;
            }

            if (this.OwnedNullValue != null)
            {
                yield return this.OwnedNullValue;
            }

            foreach (var element in this.OwnedOperationalActivityPkgs)
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

            foreach (var element in this.OwnedTraces)
            {
                yield return element;
            }

            foreach (var element in this.Results)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
