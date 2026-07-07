// ------------------------------------------------------------------------------------------------
// <copyright file="INumericValue.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>NumericValue</c> interface.
    /// </summary>
    public partial interface INumericValue : Auriga.Information.Datavalue.IDataValue
    {
        /// <summary>
        /// Gets the numeric type.
        /// </summary>
        Auriga.Information.Datatype.INumericType NumericType { get; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        Auriga.Information.IUnit Unit { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
