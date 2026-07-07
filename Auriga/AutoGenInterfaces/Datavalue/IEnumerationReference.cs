// ------------------------------------------------------------------------------------------------
// <copyright file="IEnumerationReference.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>EnumerationReference</c> interface.
    /// </summary>
    public partial interface IEnumerationReference : Auriga.Information.Datavalue.IAbstractEnumerationValue
    {
        /// <summary>
        /// Gets or sets the referenced property.
        /// </summary>
        Auriga.Information.IProperty ReferencedProperty { get; set; }

        /// <summary>
        /// Gets or sets the referenced value.
        /// </summary>
        Auriga.Information.Datavalue.IAbstractEnumerationValue ReferencedValue { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
