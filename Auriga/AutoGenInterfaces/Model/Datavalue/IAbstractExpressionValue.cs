// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractExpressionValue.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Information.Datavalue
{
    /// <summary>
    /// Definition of the <c>AbstractExpressionValue</c> interface.
    /// </summary>
    public partial interface IAbstractExpressionValue : Auriga.Model.Information.Datavalue.IAbstractBooleanValue, Auriga.Model.Information.Datavalue.IAbstractComplexValue, Auriga.Model.Information.Datavalue.IAbstractEnumerationValue, Auriga.Model.Information.Datavalue.INumericValue, Auriga.Model.Information.Datavalue.IAbstractStringValue
    {
        /// <summary>
        /// Gets the expression.
        /// </summary>
        string Expression { get; }

        /// <summary>
        /// Gets the expression type.
        /// </summary>
        Auriga.Model.Information.Datatype.IDataType ExpressionType { get; }

        /// <summary>
        /// Gets or sets the unparsed expression.
        /// </summary>
        string UnparsedExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
