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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IScenario : Auriga.Capellacore.INamespace, Auriga.Behavior.IAbstractBehavior
    {
        Auriga.Interaction.ScenarioKind? Kind { get; set; }

        bool? Merged { get; set; }

        Auriga.Capellacore.IConstraint PreCondition { get; set; }

        Auriga.Capellacore.IConstraint PostCondition { get; set; }

        Auriga.IContainerList<Auriga.Interaction.IInstanceRole> OwnedInstanceRoles { get; }

        Auriga.IContainerList<Auriga.Interaction.ISequenceMessage> OwnedMessages { get; }

        Auriga.IContainerList<Auriga.Interaction.IInteractionFragment> OwnedInteractionFragments { get; }

        Auriga.IContainerList<Auriga.Interaction.ITimeLapse> OwnedTimeLapses { get; }

        Auriga.IContainerList<Auriga.Interaction.IEvent> OwnedEvents { get; }

        Auriga.IContainerList<Auriga.Interaction.IGate> OwnedFormalGates { get; }

        Auriga.IContainerList<Auriga.Interaction.IScenarioRealization> OwnedScenarioRealization { get; }

        Auriga.IContainerList<Auriga.Interaction.IConstraintDuration> OwnedConstraintDurations { get; }

        IEnumerable<Auriga.Fa.IAbstractFunction> ContainedFunctions { get; }

        IEnumerable<Auriga.Cs.IPart> ContainedParts { get; }

        IEnumerable<Auriga.Interaction.IScenario> ReferencedScenarios { get; }

        IEnumerable<Auriga.Interaction.IScenario> RealizedScenarios { get; }

        IEnumerable<Auriga.Interaction.IScenario> RealizingScenarios { get; }

    }
}
