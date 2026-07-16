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

namespace Auriga.Model.Pa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PhysicalFunction</c> class.
    /// </summary>
    public partial class PhysicalFunction : Auriga.Core.AurigaElement, Auriga.Model.Pa.IPhysicalFunction
    {
        /// <summary>
        /// Gets or sets the abstract type.
        /// </summary>
        public Auriga.Model.Modellingcore.IAbstractType AbstractType { get; set; }

        /// <summary>
        /// Gets the abstract typed elements.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTypedElement> AbstractTypedElements => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTypedElement>();

        /// <summary>
        /// Gets or sets the aggregation kind.
        /// </summary>
        public Auriga.Model.Information.AggregationKind? AggregationKind { get; set; }

        /// <summary>
        /// Gets the allocating physical components.
        /// </summary>
        public IEnumerable<Auriga.Model.Pa.IPhysicalComponent> AllocatingPhysicalComponents => Enumerable.Empty<Auriga.Model.Pa.IPhysicalComponent>();

        /// <summary>
        /// Gets the allocation blocks.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IAbstractFunctionalBlock> AllocationBlocks => Enumerable.Empty<Auriga.Model.Fa.IAbstractFunctionalBlock>();

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Model.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Model.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Model.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Model.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Activity.IInputPin> Arguments => this.backingArguments ??= new Auriga.Core.ContainerList<Auriga.Model.Activity.IInputPin>(this);

        /// <summary>
        /// Backing field for <see cref="Arguments"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Activity.IInputPin> backingArguments;

        /// <summary>
        /// Gets the association.
        /// </summary>
        public Auriga.Model.Information.IAssociation Association => default;

        /// <summary>
        /// Gets the available in states.
        /// </summary>
        public List<Auriga.Model.Capellacommon.IState> AvailableInStates { get; } = new List<Auriga.Model.Capellacommon.IState>();

        /// <summary>
        /// Gets or sets the behavior.
        /// </summary>
        public Auriga.Model.Behavior.IAbstractBehavior Behavior { get; set; }

        /// <summary>
        /// Gets the children physical functions.
        /// </summary>
        public IEnumerable<Auriga.Model.Pa.IPhysicalFunction> ChildrenPhysicalFunctions => Enumerable.Empty<Auriga.Model.Pa.IPhysicalFunction>();

        /// <summary>
        /// Gets the component functional allocations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IComponentFunctionalAllocation> ComponentFunctionalAllocations => Enumerable.Empty<Auriga.Model.Fa.IComponentFunctionalAllocation>();

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets the contained generic traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacommon.IGenericTrace> ContainedGenericTraces => Enumerable.Empty<Auriga.Model.Capellacommon.IGenericTrace>();

        /// <summary>
        /// Gets the contained physical functions.
        /// </summary>
        public IEnumerable<Auriga.Model.Pa.IPhysicalFunction> ContainedPhysicalFunctions => Enumerable.Empty<Auriga.Model.Pa.IPhysicalFunction>();

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        public Auriga.Model.Modellingcore.IAbstractType Context { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the features.
        /// </summary>
        public List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral> Features { get; } = new List<Auriga.Model.Capellacore.IEnumerationPropertyLiteral>();

        /// <summary>
        /// Gets or sets the final.
        /// </summary>
        public bool? Final { get; set; }

        /// <summary>
        /// Gets the in activity partition.
        /// </summary>
        public Auriga.Model.Activity.IActivityPartition InActivityPartition => default;

        /// <summary>
        /// Gets the in function realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionRealization> InFunctionRealizations => Enumerable.Empty<Auriga.Model.Fa.IFunctionRealization>();

        /// <summary>
        /// Gets the in interruptible region.
        /// </summary>
        public Auriga.Model.Activity.IInterruptibleActivityRegion InInterruptibleRegion => default;

        /// <summary>
        /// Gets the in structured node.
        /// </summary>
        public Auriga.Model.Activity.IInterruptibleActivityRegion InStructuredNode => default;

        /// <summary>
        /// Gets the incoming.
        /// </summary>
        public IEnumerable<Auriga.Model.Activity.IActivityEdge> Incoming => Enumerable.Empty<Auriga.Model.Activity.IActivityEdge>();

        /// <summary>
        /// Gets the incoming traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> IncomingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the inputs.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Activity.IInputPin> Inputs => this.backingInputs ??= new Auriga.Core.ContainerList<Auriga.Model.Activity.IInputPin>(this);

        /// <summary>
        /// Backing field for <see cref="Inputs"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Activity.IInputPin> backingInputs;

        /// <summary>
        /// Gets the involving capabilities.
        /// </summary>
        public IEnumerable<Auriga.Model.Ctx.ICapability> InvolvingCapabilities => Enumerable.Empty<Auriga.Model.Ctx.ICapability>();

        /// <summary>
        /// Gets the involving capability realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.La.ICapabilityRealization> InvolvingCapabilityRealizations => Enumerable.Empty<Auriga.Model.La.ICapabilityRealization>();

        /// <summary>
        /// Gets the involving functional chains.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionalChain> InvolvingFunctionalChains => Enumerable.Empty<Auriga.Model.Fa.IFunctionalChain>();

        /// <summary>
        /// Gets the involving involvements.
        /// </summary>
        public IEnumerable<Auriga.Model.Capellacore.IInvolvement> InvolvingInvolvements => Enumerable.Empty<Auriga.Model.Capellacore.IInvolvement>();

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
        public Auriga.Model.Fa.FunctionKind? Kind { get; set; }

        /// <summary>
        /// Gets the linked function specification.
        /// </summary>
        public Auriga.Model.Fa.IFunctionSpecification LinkedFunctionSpecification => default;

        /// <summary>
        /// Gets the linked state machine.
        /// </summary>
        public Auriga.Model.Capellacommon.IStateMachine LinkedStateMachine => default;

        /// <summary>
        /// Gets or sets the local postcondition.
        /// </summary>
        public Auriga.Model.Modellingcore.IAbstractConstraint LocalPostcondition
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
        private Auriga.Model.Modellingcore.IAbstractConstraint backingLocalPostcondition;

        /// <summary>
        /// Gets or sets the local precondition.
        /// </summary>
        public Auriga.Model.Modellingcore.IAbstractConstraint LocalPrecondition
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
        private Auriga.Model.Modellingcore.IAbstractConstraint backingLocalPrecondition;

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
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.INamingRule> NamingRules => this.backingNamingRules ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.INamingRule>(this);

        /// <summary>
        /// Backing field for <see cref="NamingRules"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.INamingRule> backingNamingRules;

        /// <summary>
        /// Gets or sets the ordered.
        /// </summary>
        public bool? Ordered { get; set; }

        /// <summary>
        /// Gets the out function realizations.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IFunctionRealization> OutFunctionRealizations => Enumerable.Empty<Auriga.Model.Fa.IFunctionRealization>();

        /// <summary>
        /// Gets the outgoing.
        /// </summary>
        public IEnumerable<Auriga.Model.Activity.IActivityEdge> Outgoing => Enumerable.Empty<Auriga.Model.Activity.IActivityEdge>();

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Model.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Model.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the outputs.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Activity.IOutputPin> Outputs => this.backingOutputs ??= new Auriga.Core.ContainerList<Auriga.Model.Activity.IOutputPin>(this);

        /// <summary>
        /// Backing field for <see cref="Outputs"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Activity.IOutputPin> backingOutputs;

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.Core.ContainerList<Auriga.Model.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

        /// <summary>
        /// Gets or sets the owned default value.
        /// </summary>
        public Auriga.Model.Information.Datavalue.IDataValue OwnedDefaultValue
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
        private Auriga.Model.Information.Datavalue.IDataValue backingOwnedDefaultValue;

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
        /// Gets the owned function realizations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionRealization> OwnedFunctionRealizations => this.backingOwnedFunctionRealizations ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IFunctionRealization>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionRealizations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionRealization> backingOwnedFunctionRealizations;

        /// <summary>
        /// Gets the owned functional chains.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalChain> OwnedFunctionalChains => this.backingOwnedFunctionalChains ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IFunctionalChain>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalChains"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalChain> backingOwnedFunctionalChains;

        /// <summary>
        /// Gets the owned functional exchanges.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalExchange> OwnedFunctionalExchanges => this.backingOwnedFunctionalExchanges ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IFunctionalExchange>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctionalExchanges"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IFunctionalExchange> backingOwnedFunctionalExchanges;

        /// <summary>
        /// Gets the owned functions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Fa.IAbstractFunction> OwnedFunctions => this.backingOwnedFunctions ??= new Auriga.Core.ContainerList<Auriga.Model.Fa.IAbstractFunction>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedFunctions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Fa.IAbstractFunction> backingOwnedFunctions;

        /// <summary>
        /// Gets the owned handlers.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Activity.IExceptionHandler> OwnedHandlers => this.backingOwnedHandlers ??= new Auriga.Core.ContainerList<Auriga.Model.Activity.IExceptionHandler>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedHandlers"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Activity.IExceptionHandler> backingOwnedHandlers;

        /// <summary>
        /// Gets or sets the owned max card.
        /// </summary>
        public Auriga.Model.Information.Datavalue.INumericValue OwnedMaxCard
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
        private Auriga.Model.Information.Datavalue.INumericValue backingOwnedMaxCard;

        /// <summary>
        /// Gets or sets the owned max length.
        /// </summary>
        public Auriga.Model.Information.Datavalue.INumericValue OwnedMaxLength
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
        private Auriga.Model.Information.Datavalue.INumericValue backingOwnedMaxLength;

        /// <summary>
        /// Gets or sets the owned max value.
        /// </summary>
        public Auriga.Model.Information.Datavalue.IDataValue OwnedMaxValue
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
        private Auriga.Model.Information.Datavalue.IDataValue backingOwnedMaxValue;

        /// <summary>
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.Core.ContainerList<Auriga.Model.Modellingcore.IModelElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMigratedElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets or sets the owned min card.
        /// </summary>
        public Auriga.Model.Information.Datavalue.INumericValue OwnedMinCard
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
        private Auriga.Model.Information.Datavalue.INumericValue backingOwnedMinCard;

        /// <summary>
        /// Gets or sets the owned min length.
        /// </summary>
        public Auriga.Model.Information.Datavalue.INumericValue OwnedMinLength
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
        private Auriga.Model.Information.Datavalue.INumericValue backingOwnedMinLength;

        /// <summary>
        /// Gets or sets the owned min value.
        /// </summary>
        public Auriga.Model.Information.Datavalue.IDataValue OwnedMinValue
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
        private Auriga.Model.Information.Datavalue.IDataValue backingOwnedMinValue;

        /// <summary>
        /// Gets or sets the owned null value.
        /// </summary>
        public Auriga.Model.Information.Datavalue.IDataValue OwnedNullValue
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
        private Auriga.Model.Information.Datavalue.IDataValue backingOwnedNullValue;

        /// <summary>
        /// Gets the owned physical function pkgs.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Pa.IPhysicalFunctionPkg> OwnedPhysicalFunctionPkgs => this.backingOwnedPhysicalFunctionPkgs ??= new Auriga.Core.ContainerList<Auriga.Model.Pa.IPhysicalFunctionPkg>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedPhysicalFunctionPkgs"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Pa.IPhysicalFunctionPkg> backingOwnedPhysicalFunctionPkgs;

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
        /// Gets the owned traces.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Capellacore.ITrace> OwnedTraces => this.backingOwnedTraces ??= new Auriga.Core.ContainerList<Auriga.Model.Capellacore.ITrace>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTraces"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Capellacore.ITrace> backingOwnedTraces;

        /// <summary>
        /// Gets the realized logical functions.
        /// </summary>
        public IEnumerable<Auriga.Model.La.ILogicalFunction> RealizedLogicalFunctions => Enumerable.Empty<Auriga.Model.La.ILogicalFunction>();

        /// <summary>
        /// Gets the representing instance roles.
        /// </summary>
        public IEnumerable<Auriga.Model.Interaction.IInstanceRole> RepresentingInstanceRoles => Enumerable.Empty<Auriga.Model.Interaction.IInstanceRole>();

        /// <summary>
        /// Gets the results.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Activity.IOutputPin> Results => this.backingResults ??= new Auriga.Core.ContainerList<Auriga.Model.Activity.IOutputPin>(this);

        /// <summary>
        /// Backing field for <see cref="Results"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Activity.IOutputPin> backingResults;

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
        /// Gets the sub functions.
        /// </summary>
        public IEnumerable<Auriga.Model.Fa.IAbstractFunction> SubFunctions => Enumerable.Empty<Auriga.Model.Fa.IAbstractFunction>();

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public Auriga.Model.Capellacore.IType Type => default;

        /// <summary>
        /// Gets or sets the unique.
        /// </summary>
        public bool? Unique { get; set; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        public Auriga.Model.Capellacore.VisibilityKind? Visibility { get; set; }

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>PhysicalFunction</c>.
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

            foreach (var element in this.OwnedPhysicalFunctionPkgs)
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
