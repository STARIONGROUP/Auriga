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
    public partial interface ICommunicationItem : global::Auriga.Capellacore.IClassifier, global::Auriga.Information.Datavalue.IDataValueContainer
    {
        global::Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        global::Auriga.IContainerList<global::Auriga.Capellacommon.IStateMachine> OwnedStateMachines { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Information.IProperty> Properties { get; }

    }
}
