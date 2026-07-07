// ------------------------------------------------------------------------------------------------
// <copyright file="INumericType.cs" company="Starion Group S.A.">
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

namespace Auriga.Information.Datatype
{
    /// <summary>
    /// Definition of the <c>NumericType</c> interface.
    /// </summary>
    public partial interface INumericType : Auriga.Information.Datatype.IDataType
    {
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Information.Datatype.NumericTypeKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the owned default value.
        /// </summary>
        Auriga.Information.Datavalue.INumericValue OwnedDefaultValue { get; set; }

        /// <summary>
        /// Gets or sets the owned max value.
        /// </summary>
        Auriga.Information.Datavalue.INumericValue OwnedMaxValue { get; set; }

        /// <summary>
        /// Gets or sets the owned min value.
        /// </summary>
        Auriga.Information.Datavalue.INumericValue OwnedMinValue { get; set; }

        /// <summary>
        /// Gets or sets the owned null value.
        /// </summary>
        Auriga.Information.Datavalue.INumericValue OwnedNullValue { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
