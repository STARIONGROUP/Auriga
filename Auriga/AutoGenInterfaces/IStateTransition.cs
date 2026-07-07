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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IStateTransition : Auriga.Capellacore.INamedElement, Auriga.Capellacore.IRelationship
    {
        Auriga.Capellacommon.TransitionKind? Kind { get; set; }

        string TriggerDescription { get; set; }

        Auriga.Capellacore.IConstraint Guard { get; set; }

        Auriga.Capellacommon.IAbstractState Source { get; set; }

        Auriga.Capellacommon.IAbstractState Target { get; set; }

        List<Auriga.Behavior.IAbstractEvent> Effect { get; }

        List<Auriga.Behavior.IAbstractEvent> Triggers { get; }

        Auriga.IContainerList<Auriga.Capellacommon.IStateTransitionRealization> OwnedStateTransitionRealizations { get; }

        IEnumerable<Auriga.Capellacommon.IStateTransition> RealizedStateTransitions { get; }

        IEnumerable<Auriga.Capellacommon.IStateTransition> RealizingStateTransitions { get; }

    }
}
