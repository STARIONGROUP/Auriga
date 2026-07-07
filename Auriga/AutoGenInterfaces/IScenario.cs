// ------------------------------------------------------------------------------------------------
// <copyright file="IScenario.cs" company="Starion Group S.A.">
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

namespace Auriga.Interaction
{
    public partial interface IScenario : global::Auriga.Capellacore.INamespace, global::Auriga.Behavior.IAbstractBehavior
    {
        global::Auriga.Interaction.ScenarioKind? Kind { get; set; }

        bool? Merged { get; set; }

        global::Auriga.Capellacore.IConstraint PreCondition { get; set; }

        global::Auriga.Capellacore.IConstraint PostCondition { get; set; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IInstanceRole> OwnedInstanceRoles { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.ISequenceMessage> OwnedMessages { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IInteractionFragment> OwnedInteractionFragments { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.ITimeLapse> OwnedTimeLapses { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IEvent> OwnedEvents { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IGate> OwnedFormalGates { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IScenarioRealization> OwnedScenarioRealization { get; }

        global::Auriga.IContainerList<global::Auriga.Interaction.IConstraintDuration> OwnedConstraintDurations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Fa.IAbstractFunction> ContainedFunctions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Cs.IPart> ContainedParts { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IScenario> ReferencedScenarios { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IScenario> RealizedScenarios { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Interaction.IScenario> RealizingScenarios { get; }

    }
}
