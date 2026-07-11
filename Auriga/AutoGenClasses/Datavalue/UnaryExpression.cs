// ------------------------------------------------------------------------------------------------
// <copyright file="UnaryExpression.cs" company="Starion Group S.A.">
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

namespace Auriga.Information.Datavalue
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>UnaryExpression</c> class.
    /// </summary>
    public partial class UnaryExpression : Auriga.Core.AurigaElement, Auriga.Information.Datavalue.IUnaryExpression
    {
        /// <summary>
        /// Gets or sets the abstract.
        /// </summary>
        public bool? Abstract { get; set; }

        /// <summary>
        /// Gets or sets the abstract type.
        /// </summary>
        public Auriga.Modellingcore.IAbstractType AbstractType { get; set; }

        /// <summary>
        /// Gets the applied property value groups.
        /// </summary>
        public List<Auriga.Capellacore.IPropertyValueGroup> AppliedPropertyValueGroups { get; } = new List<Auriga.Capellacore.IPropertyValueGroup>();

        /// <summary>
        /// Gets the applied property values.
        /// </summary>
        public List<Auriga.Capellacore.IAbstractPropertyValue> AppliedPropertyValues { get; } = new List<Auriga.Capellacore.IAbstractPropertyValue>();

        /// <summary>
        /// Gets the boolean type.
        /// </summary>
        public Auriga.Information.Datatype.IBooleanType BooleanType => default;

        /// <summary>
        /// Gets the complex type.
        /// </summary>
        public Auriga.Capellacore.IClassifier ComplexType => default;

        /// <summary>
        /// Gets the constraints.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractConstraint> Constraints => Enumerable.Empty<Auriga.Modellingcore.IAbstractConstraint>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the enumeration type.
        /// </summary>
        public Auriga.Information.Datatype.IEnumeration EnumerationType => default;

        /// <summary>
        /// Gets the expression.
        /// </summary>
        public string Expression => default;

        /// <summary>
        /// Gets the expression type.
        /// </summary>
        public Auriga.Information.Datatype.IDataType ExpressionType => default;

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
        /// Gets the numeric type.
        /// </summary>
        public Auriga.Information.Datatype.INumericType NumericType => default;

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        public Auriga.Information.Datavalue.UnaryOperator? Operator { get; set; }

        /// <summary>
        /// Gets the outgoing traces.
        /// </summary>
        public IEnumerable<Auriga.Modellingcore.IAbstractTrace> OutgoingTraces => Enumerable.Empty<Auriga.Modellingcore.IAbstractTrace>();

        /// <summary>
        /// Gets the owned constraints.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Modellingcore.IAbstractConstraint> OwnedConstraints => this.backingOwnedConstraints ??= new Auriga.Core.ContainerList<Auriga.Modellingcore.IAbstractConstraint>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedConstraints"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Modellingcore.IAbstractConstraint> backingOwnedConstraints;

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
        /// Gets the owned migrated elements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Modellingcore.IModelElement> OwnedMigratedElements => this.backingOwnedMigratedElements ??= new Auriga.Core.ContainerList<Auriga.Modellingcore.IModelElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedMigratedElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Modellingcore.IModelElement> backingOwnedMigratedElements;

        /// <summary>
        /// Gets or sets the owned operand.
        /// </summary>
        public Auriga.Information.Datavalue.IDataValue OwnedOperand
        {
            get => this.backingOwnedOperand;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedOperand = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedOperand"/>.
        /// </summary>
        private Auriga.Information.Datavalue.IDataValue backingOwnedOperand;

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
        /// Gets the string type.
        /// </summary>
        public Auriga.Information.Datatype.IStringType StringType => default;

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public Auriga.Capellacore.IType Type => default;

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        public Auriga.Information.IUnit Unit { get; set; }

        /// <summary>
        /// Gets or sets the unparsed expression.
        /// </summary>
        public string UnparsedExpression { get; set; }

        /// <summary>
        /// Gets or sets the visible in doc.
        /// </summary>
        public bool? VisibleInDoc { get; set; }

        /// <summary>
        /// Gets or sets the visible in l m.
        /// </summary>
        public bool? VisibleInLM { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>UnaryExpression</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
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

            if (this.OwnedOperand != null)
            {
                yield return this.OwnedOperand;
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
