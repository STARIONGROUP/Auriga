// ------------------------------------------------------------------------------------------------
// <copyright file="IInteractionOperand.cs" company="Starion Group S.A.">
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

namespace Auriga.Interaction
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>InteractionOperand</c> interface.
    /// </summary>
    public partial interface IInteractionOperand : Auriga.Interaction.IInteractionFragment
    {
        /// <summary>
        /// Gets or sets the guard.
        /// </summary>
        Auriga.Capellacore.IConstraint Guard { get; set; }

        /// <summary>
        /// Gets the referenced interaction fragments.
        /// </summary>
        List<Auriga.Interaction.IInteractionFragment> ReferencedInteractionFragments { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
