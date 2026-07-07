// ------------------------------------------------------------------------------------------------
// <copyright file="ICollectionValueReference.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    /// <summary>
    /// Definition of the <c>CollectionValueReference</c> interface.
    /// </summary>
    public partial interface ICollectionValueReference : Auriga.Information.IAbstractCollectionValue
    {
        /// <summary>
        /// Gets or sets the referenced property.
        /// </summary>
        Auriga.Information.IProperty ReferencedProperty { get; set; }

        /// <summary>
        /// Gets or sets the referenced value.
        /// </summary>
        Auriga.Information.IAbstractCollectionValue ReferencedValue { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
