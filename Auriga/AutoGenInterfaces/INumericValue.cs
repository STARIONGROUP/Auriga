// ------------------------------------------------------------------------------------------------
// <copyright file="INumericValue.cs" company="Starion Group S.A.">
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

namespace Auriga.Information.Datavalue
{
    public partial interface INumericValue : global::Auriga.Information.Datavalue.IDataValue
    {
        global::Auriga.Information.IUnit Unit { get; set; }

        global::Auriga.Information.Datatype.INumericType NumericType { get; }

    }
}
