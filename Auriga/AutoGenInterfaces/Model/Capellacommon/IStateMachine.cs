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

namespace Auriga.Model.Capellacommon
{
    /// <summary>
    /// Definition of the <c>StateMachine</c> interface.
    /// </summary>
    public partial interface IStateMachine : Auriga.Model.Capellacore.ICapellaElement, Auriga.Model.Behavior.IAbstractBehavior
    {
        /// <summary>
        /// Gets the owned connection points.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IPseudostate> OwnedConnectionPoints { get; }

        /// <summary>
        /// Gets the owned regions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IRegion> OwnedRegions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
