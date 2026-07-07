// ------------------------------------------------------------------------------------------------
// <copyright file="ICommunicationItem.cs" company="Starion Group S.A.">
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

namespace Auriga.Information.Communication
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ICommunicationItem : Auriga.Capellacore.IClassifier, Auriga.Information.Datavalue.IDataValueContainer
    {
        Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        Auriga.IContainerList<Auriga.Capellacommon.IStateMachine> OwnedStateMachines { get; }

        IEnumerable<Auriga.Information.IProperty> Properties { get; }

    }
}
