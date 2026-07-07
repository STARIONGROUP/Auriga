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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IDataType : Auriga.Capellacore.IGeneralizableElement, Auriga.Information.Datavalue.IDataValueContainer, Auriga.Modellingcore.IFinalizableElement
    {
        bool? Discrete { get; set; }

        bool? MinInclusive { get; set; }

        bool? MaxInclusive { get; set; }

        string Pattern { get; set; }

        Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        Auriga.Information.Datavalue.IDataValue DefaultValue { get; }

        Auriga.Information.Datavalue.IDataValue NullValue { get; }

        Auriga.IContainerList<Auriga.Information.IInformationRealization> OwnedInformationRealizations { get; }

        IEnumerable<Auriga.Information.Datatype.IDataType> RealizedDataTypes { get; }

        IEnumerable<Auriga.Information.Datatype.IDataType> RealizingDataTypes { get; }

    }
}
