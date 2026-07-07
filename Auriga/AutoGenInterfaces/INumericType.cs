// ------------------------------------------------------------------------------------------------
// <copyright file="INumericType.cs" company="Starion Group S.A.">
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

namespace Auriga.Information.Datatype
{
    public partial interface INumericType : Auriga.Information.Datatype.IDataType
    {
        Auriga.Information.Datatype.NumericTypeKind? Kind { get; set; }

        Auriga.Information.Datavalue.INumericValue OwnedDefaultValue { get; set; }

        Auriga.Information.Datavalue.INumericValue OwnedNullValue { get; set; }

        Auriga.Information.Datavalue.INumericValue OwnedMinValue { get; set; }

        Auriga.Information.Datavalue.INumericValue OwnedMaxValue { get; set; }

    }
}
