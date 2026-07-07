// ------------------------------------------------------------------------------------------------
// <copyright file="IStateTransition.cs" company="Starion Group S.A.">
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
    public partial interface IStateTransition : global::Auriga.Capellacore.INamedElement, global::Auriga.Capellacore.IRelationship
    {
        global::Auriga.Capellacommon.TransitionKind? Kind { get; set; }

        string TriggerDescription { get; set; }

        global::Auriga.Capellacore.IConstraint Guard { get; set; }

        global::Auriga.Capellacommon.IAbstractState Source { get; set; }

        global::Auriga.Capellacommon.IAbstractState Target { get; set; }

        global::System.Collections.Generic.List<global::Auriga.Behavior.IAbstractEvent> Effect { get; }

        global::System.Collections.Generic.List<global::Auriga.Behavior.IAbstractEvent> Triggers { get; }

        global::Auriga.IContainerList<global::Auriga.Capellacommon.IStateTransitionRealization> OwnedStateTransitionRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.IStateTransition> RealizedStateTransitions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.IStateTransition> RealizingStateTransitions { get; }

    }
}
