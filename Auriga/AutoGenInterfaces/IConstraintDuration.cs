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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Interaction
{
    public partial interface IConstraintDuration : Auriga.Capellacore.INamedElement
    {
        string Duration { get; set; }

        Auriga.Interaction.IInteractionFragment Start { get; set; }

        Auriga.Interaction.IInteractionFragment Finish { get; set; }

    }
}
