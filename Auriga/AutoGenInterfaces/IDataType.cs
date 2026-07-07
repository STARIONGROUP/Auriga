// ------------------------------------------------------------------------------------------------
// <copyright file="IDataType.cs" company="Starion Group S.A.">
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
    public partial interface IDataType : global::Auriga.Capellacore.IGeneralizableElement, global::Auriga.Information.Datavalue.IDataValueContainer, global::Auriga.Modellingcore.IFinalizableElement
    {
        bool? Discrete { get; set; }

        bool? MinInclusive { get; set; }

        bool? MaxInclusive { get; set; }

        string Pattern { get; set; }

        global::Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        global::Auriga.Information.Datavalue.IDataValue DefaultValue { get; }

        global::Auriga.Information.Datavalue.IDataValue NullValue { get; }

        global::Auriga.IContainerList<global::Auriga.Information.IInformationRealization> OwnedInformationRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Datatype.IDataType> RealizedDataTypes { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.Datatype.IDataType> RealizingDataTypes { get; }

    }
}
