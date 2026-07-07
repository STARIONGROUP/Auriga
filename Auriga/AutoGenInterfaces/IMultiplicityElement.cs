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
    public partial interface IMultiplicityElement : global::Auriga.Capellacore.ICapellaElement
    {
        bool? Ordered { get; set; }

        bool? Unique { get; set; }

        bool? MinInclusive { get; set; }

        bool? MaxInclusive { get; set; }

        global::Auriga.Information.Datavalue.IDataValue OwnedDefaultValue { get; set; }

        global::Auriga.Information.Datavalue.IDataValue OwnedMinValue { get; set; }

        global::Auriga.Information.Datavalue.IDataValue OwnedMaxValue { get; set; }

        global::Auriga.Information.Datavalue.IDataValue OwnedNullValue { get; set; }

        global::Auriga.Information.Datavalue.INumericValue OwnedMinCard { get; set; }

        global::Auriga.Information.Datavalue.INumericValue OwnedMinLength { get; set; }

        global::Auriga.Information.Datavalue.INumericValue OwnedMaxCard { get; set; }

        global::Auriga.Information.Datavalue.INumericValue OwnedMaxLength { get; set; }

    }
}
