// ------------------------------------------------------------------------------------------------
// <copyright file="IInteractionState.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>InteractionState</c> interface.
    /// </summary>
    public partial interface IInteractionState : Auriga.Interaction.IInteractionFragment
    {
        /// <summary>
        /// Gets the covered.
        /// </summary>
        Auriga.Interaction.IInstanceRole Covered { get; }

        /// <summary>
        /// @deprecated : relatedAbstractFunction shall not be used anymore
        /// </summary>
        Auriga.Fa.IAbstractFunction RelatedAbstractFunction { get; set; }

        /// <summary>
        /// @deprecated : relatedAbstractState shall not be used anymore
        /// </summary>
        Auriga.Capellacommon.IAbstractState RelatedAbstractState { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
