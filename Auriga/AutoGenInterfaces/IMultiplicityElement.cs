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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Information
{
    public partial interface IMultiplicityElement : Auriga.Capellacore.ICapellaElement
    {
        bool? Ordered { get; set; }

        bool? Unique { get; set; }

        bool? MinInclusive { get; set; }

        bool? MaxInclusive { get; set; }

        Auriga.Information.Datavalue.IDataValue OwnedDefaultValue { get; set; }

        Auriga.Information.Datavalue.IDataValue OwnedMinValue { get; set; }

        Auriga.Information.Datavalue.IDataValue OwnedMaxValue { get; set; }

        Auriga.Information.Datavalue.IDataValue OwnedNullValue { get; set; }

        Auriga.Information.Datavalue.INumericValue OwnedMinCard { get; set; }

        Auriga.Information.Datavalue.INumericValue OwnedMinLength { get; set; }

        Auriga.Information.Datavalue.INumericValue OwnedMaxCard { get; set; }

        Auriga.Information.Datavalue.INumericValue OwnedMaxLength { get; set; }

    }
}
