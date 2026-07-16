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

namespace Auriga.Model.Interaction
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Scenario</c> interface.
    /// </summary>
    public partial interface IScenario : Auriga.Model.Capellacore.INamespace, Auriga.Model.Behavior.IAbstractBehavior
    {
        /// <summary>
        /// Gets the contained functions.
        /// </summary>
        IEnumerable<Auriga.Model.Fa.IAbstractFunction> ContainedFunctions { get; }

        /// <summary>
        /// Gets the contained parts.
        /// </summary>
        IEnumerable<Auriga.Model.Cs.IPart> ContainedParts { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Model.Interaction.ScenarioKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the merged.
        /// </summary>
        bool? Merged { get; set; }

        /// <summary>
        /// Gets the owned constraint durations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IConstraintDuration> OwnedConstraintDurations { get; }

        /// <summary>
        /// Gets the owned events.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IEvent> OwnedEvents { get; }

        /// <summary>
        /// Gets the owned formal gates.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IGate> OwnedFormalGates { get; }

        /// <summary>
        /// Gets the owned instance roles.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IInstanceRole> OwnedInstanceRoles { get; }

        /// <summary>
        /// Gets the owned interaction fragments.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IInteractionFragment> OwnedInteractionFragments { get; }

        /// <summary>
        /// Gets the owned messages.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.ISequenceMessage> OwnedMessages { get; }

        /// <summary>
        /// Gets the owned scenario realization.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.IScenarioRealization> OwnedScenarioRealization { get; }

        /// <summary>
        /// Gets the owned time lapses.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Interaction.ITimeLapse> OwnedTimeLapses { get; }

        /// <summary>
        /// Gets or sets the post condition.
        /// </summary>
        Auriga.Model.Capellacore.IConstraint PostCondition { get; set; }

        /// <summary>
        /// Gets or sets the pre condition.
        /// </summary>
        Auriga.Model.Capellacore.IConstraint PreCondition { get; set; }

        /// <summary>
        /// Gets the realized scenarios.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IScenario> RealizedScenarios { get; }

        /// <summary>
        /// Gets the realizing scenarios.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IScenario> RealizingScenarios { get; }

        /// <summary>
        /// Gets the referenced scenarios.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IScenario> ReferencedScenarios { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
