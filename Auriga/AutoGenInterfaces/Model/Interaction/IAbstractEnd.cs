// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractEnd.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>AbstractEnd</c> interface.
    /// </summary>
    public partial interface IAbstractEnd : Auriga.Model.Interaction.IInteractionFragment
    {
        /// <summary>
        /// Gets the covered.
        /// </summary>
        Auriga.Model.Interaction.IInstanceRole Covered { get; }

        /// <summary>
        /// Gets or sets the event.
        /// </summary>
        Auriga.Model.Interaction.IEvent Event { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
