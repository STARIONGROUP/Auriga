// ------------------------------------------------------------------------------------------------
// <copyright file="IInteractionUse.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>InteractionUse</c> interface.
    /// </summary>
    public partial interface IInteractionUse : Auriga.Model.Interaction.IAbstractFragment
    {
        /// <summary>
        /// Gets the actual gates.
        /// </summary>
        IEnumerable<Auriga.Model.Interaction.IGate> ActualGates { get; }

        /// <summary>
        /// Gets or sets the referenced scenario.
        /// </summary>
        Auriga.Model.Interaction.IScenario ReferencedScenario { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
