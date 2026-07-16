// ------------------------------------------------------------------------------------------------
// <copyright file="IStateMachine.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>StateMachine</c> interface.
    /// </summary>
    public partial interface IStateMachine : Auriga.Capellacore.ICapellaElement, Auriga.Behavior.IAbstractBehavior
    {
        /// <summary>
        /// Gets the owned connection points.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Capellacommon.IPseudostate> OwnedConnectionPoints { get; }

        /// <summary>
        /// Gets the owned regions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Capellacommon.IRegion> OwnedRegions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
