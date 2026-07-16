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

namespace Auriga.Model.Capellacommon
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>StateTransition</c> interface.
    /// </summary>
    public partial interface IStateTransition : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets the effect.
        /// </summary>
        List<Auriga.Model.Behavior.IAbstractEvent> Effect { get; }

        /// <summary>
        /// Gets or sets the guard.
        /// </summary>
        Auriga.Model.Capellacore.IConstraint Guard { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Model.Capellacommon.TransitionKind? Kind { get; set; }

        /// <summary>
        /// Gets the owned state transition realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IStateTransitionRealization> OwnedStateTransitionRealizations { get; }

        /// <summary>
        /// Gets the realized state transitions.
        /// </summary>
        IEnumerable<Auriga.Model.Capellacommon.IStateTransition> RealizedStateTransitions { get; }

        /// <summary>
        /// Gets the realizing state transitions.
        /// </summary>
        IEnumerable<Auriga.Model.Capellacommon.IStateTransition> RealizingStateTransitions { get; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Model.Capellacommon.IAbstractState Source { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Model.Capellacommon.IAbstractState Target { get; set; }

        /// <summary>
        /// Gets or sets the trigger description.
        /// </summary>
        string TriggerDescription { get; set; }

        /// <summary>
        /// Gets the triggers.
        /// </summary>
        List<Auriga.Model.Behavior.IAbstractEvent> Triggers { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
