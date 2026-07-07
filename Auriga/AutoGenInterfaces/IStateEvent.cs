// ------------------------------------------------------------------------------------------------
// <copyright file="IStateEvent.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacommon
{
    public partial interface IStateEvent : global::Auriga.Capellacore.INamedElement, global::Auriga.Behavior.IAbstractEvent
    {
        global::Auriga.Capellacore.IConstraint Expression { get; set; }

        global::Auriga.IContainerList<global::Auriga.Capellacommon.IStateEventRealization> OwnedStateEventRealizations { get; }

    }
}
