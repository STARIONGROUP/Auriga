// ------------------------------------------------------------------------------------------------
// <copyright file="IBooleanReference.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>BooleanReference</c> interface.
    /// </summary>
    public partial interface IBooleanReference : Auriga.Information.Datavalue.IAbstractBooleanValue
    {
        /// <summary>
        /// Gets or sets the referenced property.
        /// </summary>
        Auriga.Information.IProperty ReferencedProperty { get; set; }

        /// <summary>
        /// Gets or sets the referenced value.
        /// </summary>
        Auriga.Information.Datavalue.IAbstractBooleanValue ReferencedValue { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
