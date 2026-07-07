// ------------------------------------------------------------------------------------------------
// <copyright file="IRegion.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacommon
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>Region</c> interface.
    /// </summary>
    public partial interface IRegion : Auriga.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the involved states.
        /// </summary>
        List<Auriga.Capellacommon.IAbstractState> InvolvedStates { get; }

        /// <summary>
        /// Gets the owned states.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacommon.IAbstractState> OwnedStates { get; }

        /// <summary>
        /// Gets the owned transitions.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacommon.IStateTransition> OwnedTransitions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
