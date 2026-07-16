// ------------------------------------------------------------------------------------------------
// <copyright file="IStringType.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Information.Datatype
{
    /// <summary>
    /// Definition of the <c>StringType</c> interface.
    /// </summary>
    public partial interface IStringType : Auriga.Model.Information.Datatype.IDataType
    {
        /// <summary>
        /// Gets or sets the owned default value.
        /// </summary>
        Auriga.Model.Information.Datavalue.IAbstractStringValue OwnedDefaultValue { get; set; }

        /// <summary>
        /// Gets or sets the owned max length.
        /// </summary>
        Auriga.Model.Information.Datavalue.INumericValue OwnedMaxLength { get; set; }

        /// <summary>
        /// Gets or sets the owned min length.
        /// </summary>
        Auriga.Model.Information.Datavalue.INumericValue OwnedMinLength { get; set; }

        /// <summary>
        /// Gets or sets the owned null value.
        /// </summary>
        Auriga.Model.Information.Datavalue.IAbstractStringValue OwnedNullValue { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
