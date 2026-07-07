// ------------------------------------------------------------------------------------------------
// <copyright file="IStateTransitionRealization.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>StateTransitionRealization</c> interface.
    /// </summary>
    public partial interface IStateTransitionRealization : Auriga.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized state transition.
        /// </summary>
        Auriga.Capellacommon.IStateTransition RealizedStateTransition { get; }

        /// <summary>
        /// Gets the realizing state transition.
        /// </summary>
        Auriga.Capellacommon.IStateTransition RealizingStateTransition { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
