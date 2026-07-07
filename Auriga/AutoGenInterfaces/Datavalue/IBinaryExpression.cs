// ------------------------------------------------------------------------------------------------
// <copyright file="IBinaryExpression.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>BinaryExpression</c> interface.
    /// </summary>
    public partial interface IBinaryExpression : Auriga.Information.Datavalue.IAbstractExpressionValue
    {
        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        Auriga.Information.Datavalue.BinaryOperator? Operator { get; set; }

        /// <summary>
        /// Gets or sets the owned left operand.
        /// </summary>
        Auriga.Information.Datavalue.IDataValue OwnedLeftOperand { get; set; }

        /// <summary>
        /// Gets or sets the owned right operand.
        /// </summary>
        Auriga.Information.Datavalue.IDataValue OwnedRightOperand { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
