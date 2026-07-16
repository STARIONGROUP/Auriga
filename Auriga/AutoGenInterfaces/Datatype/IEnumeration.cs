// ------------------------------------------------------------------------------------------------
// <copyright file="IEnumeration.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Enumeration</c> interface.
    /// </summary>
    public partial interface IEnumeration : Auriga.Information.Datatype.IDataType
    {
        /// <summary>
        /// Gets or sets the domain type.
        /// </summary>
        Auriga.Information.Datatype.IDataType DomainType { get; set; }

        /// <summary>
        /// Gets or sets the owned default value.
        /// </summary>
        Auriga.Information.Datavalue.IAbstractEnumerationValue OwnedDefaultValue { get; set; }

        /// <summary>
        /// Gets the owned literals.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Information.Datavalue.IEnumerationLiteral> OwnedLiterals { get; }

        /// <summary>
        /// Gets or sets the owned max value.
        /// </summary>
        Auriga.Information.Datavalue.IAbstractEnumerationValue OwnedMaxValue { get; set; }

        /// <summary>
        /// Gets or sets the owned min value.
        /// </summary>
        Auriga.Information.Datavalue.IAbstractEnumerationValue OwnedMinValue { get; set; }

        /// <summary>
        /// Gets or sets the owned null value.
        /// </summary>
        Auriga.Information.Datavalue.IAbstractEnumerationValue OwnedNullValue { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
