// ------------------------------------------------------------------------------------------------
// <copyright file="IState.cs" company="Starion Group S.A.">
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
    using System.Linq;

    /// <summary>
    /// Definition of the <c>State</c> interface.
    /// </summary>
    public partial interface IState : Auriga.Capellacommon.IAbstractState
    {
        /// <summary>
        /// Gets the available abstract capabilities.
        /// </summary>
        IEnumerable<Auriga.Interaction.IAbstractCapability> AvailableAbstractCapabilities { get; }

        /// <summary>
        /// Gets the available abstract functions.
        /// </summary>
        IEnumerable<Auriga.Fa.IAbstractFunction> AvailableAbstractFunctions { get; }

        /// <summary>
        /// Gets the available functional chains.
        /// </summary>
        IEnumerable<Auriga.Fa.IFunctionalChain> AvailableFunctionalChains { get; }

        /// <summary>
        /// Gets the do activity.
        /// </summary>
        List<Auriga.Behavior.IAbstractEvent> DoActivity { get; }

        /// <summary>
        /// Gets the entry.
        /// </summary>
        List<Auriga.Behavior.IAbstractEvent> Entry { get; }

        /// <summary>
        /// Gets the exit.
        /// </summary>
        List<Auriga.Behavior.IAbstractEvent> Exit { get; }

        /// <summary>
        /// Gets the owned connection points.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacommon.IPseudostate> OwnedConnectionPoints { get; }

        /// <summary>
        /// Gets the owned regions.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacommon.IRegion> OwnedRegions { get; }

        /// <summary>
        /// Gets or sets the state invariant.
        /// </summary>
        Auriga.Modellingcore.IAbstractConstraint StateInvariant { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
