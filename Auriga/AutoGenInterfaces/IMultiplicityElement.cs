// ------------------------------------------------------------------------------------------------
// <copyright file="IMultiplicityElement.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>MultiplicityElement</c> interface.
    /// </summary>
    public partial interface IMultiplicityElement : Auriga.Capellacore.ICapellaElement
    {
        /// <summary>
        /// Gets or sets the max inclusive.
        /// </summary>
        bool? MaxInclusive { get; set; }

        /// <summary>
        /// Gets or sets the min inclusive.
        /// </summary>
        bool? MinInclusive { get; set; }

        /// <summary>
        /// Gets or sets the ordered.
        /// </summary>
        bool? Ordered { get; set; }

        /// <summary>
        /// Gets or sets the owned default value.
        /// </summary>
        Auriga.Information.Datavalue.IDataValue OwnedDefaultValue { get; set; }

        /// <summary>
        /// Gets or sets the owned max card.
        /// </summary>
        Auriga.Information.Datavalue.INumericValue OwnedMaxCard { get; set; }

        /// <summary>
        /// Gets or sets the owned max length.
        /// </summary>
        Auriga.Information.Datavalue.INumericValue OwnedMaxLength { get; set; }

        /// <summary>
        /// Gets or sets the owned max value.
        /// </summary>
        Auriga.Information.Datavalue.IDataValue OwnedMaxValue { get; set; }

        /// <summary>
        /// Gets or sets the owned min card.
        /// </summary>
        Auriga.Information.Datavalue.INumericValue OwnedMinCard { get; set; }

        /// <summary>
        /// Gets or sets the owned min length.
        /// </summary>
        Auriga.Information.Datavalue.INumericValue OwnedMinLength { get; set; }

        /// <summary>
        /// Gets or sets the owned min value.
        /// </summary>
        Auriga.Information.Datavalue.IDataValue OwnedMinValue { get; set; }

        /// <summary>
        /// Gets or sets the owned null value.
        /// </summary>
        Auriga.Information.Datavalue.IDataValue OwnedNullValue { get; set; }

        /// <summary>
        /// Gets or sets the unique.
        /// </summary>
        bool? Unique { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
