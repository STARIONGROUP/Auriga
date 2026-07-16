// ------------------------------------------------------------------------------------------------
// <copyright file="IConstraintDuration.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>ConstraintDuration</c> interface.
    /// </summary>
    public partial interface IConstraintDuration : Auriga.Model.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        string Duration { get; set; }

        /// <summary>
        /// Gets or sets the finish.
        /// </summary>
        Auriga.Model.Interaction.IInteractionFragment Finish { get; set; }

        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        Auriga.Model.Interaction.IInteractionFragment Start { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
