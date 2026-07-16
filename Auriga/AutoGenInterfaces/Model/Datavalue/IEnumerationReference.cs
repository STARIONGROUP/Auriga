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

namespace Auriga.Model.Information.Datavalue
{
    /// <summary>
    /// Definition of the <c>EnumerationReference</c> interface.
    /// </summary>
    public partial interface IEnumerationReference : Auriga.Model.Information.Datavalue.IAbstractEnumerationValue
    {
        /// <summary>
        /// Gets or sets the referenced property.
        /// </summary>
        Auriga.Model.Information.IProperty ReferencedProperty { get; set; }

        /// <summary>
        /// Gets or sets the referenced value.
        /// </summary>
        Auriga.Model.Information.Datavalue.IAbstractEnumerationValue ReferencedValue { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
