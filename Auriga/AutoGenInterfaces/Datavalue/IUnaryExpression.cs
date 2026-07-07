// ------------------------------------------------------------------------------------------------
// <copyright file="IUnaryExpression.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>UnaryExpression</c> interface.
    /// </summary>
    public partial interface IUnaryExpression : Auriga.Information.Datavalue.IAbstractExpressionValue
    {
        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        Auriga.Information.Datavalue.UnaryOperator? Operator { get; set; }

        /// <summary>
        /// Gets or sets the owned operand.
        /// </summary>
        Auriga.Information.Datavalue.IDataValue OwnedOperand { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
