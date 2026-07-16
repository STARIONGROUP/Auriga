// ------------------------------------------------------------------------------------------------
// <copyright file="IValuePart.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ValuePart</c> interface.
    /// </summary>
    public partial interface IValuePart : Auriga.Model.Capellacore.ICapellaElement
    {
        /// <summary>
        /// Gets or sets the owned value.
        /// </summary>
        Auriga.Model.Information.Datavalue.IDataValue OwnedValue { get; set; }

        /// <summary>
        /// Gets or sets the referenced property.
        /// </summary>
        Auriga.Model.Information.IProperty ReferencedProperty { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
