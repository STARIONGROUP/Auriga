// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractState.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>AbstractState</c> interface.
    /// </summary>
    public partial interface IAbstractState : Auriga.Capellacore.INamedElement, Auriga.Modellingcore.IIState
    {
        /// <summary>
        /// Gets the incoming.
        /// </summary>
        IEnumerable<Auriga.Capellacommon.IStateTransition> Incoming { get; }

        /// <summary>
        /// Gets the involver regions.
        /// </summary>
        IEnumerable<Auriga.Capellacommon.IRegion> InvolverRegions { get; }

        /// <summary>
        /// Gets the outgoing.
        /// </summary>
        IEnumerable<Auriga.Capellacommon.IStateTransition> Outgoing { get; }

        /// <summary>
        /// Gets the owned abstract state realizations.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacommon.IAbstractStateRealization> OwnedAbstractStateRealizations { get; }

        /// <summary>
        /// Gets the realized abstract states.
        /// </summary>
        IEnumerable<Auriga.Capellacommon.IAbstractState> RealizedAbstractStates { get; }

        /// <summary>
        /// Gets the realizing abstract states.
        /// </summary>
        IEnumerable<Auriga.Capellacommon.IAbstractState> RealizingAbstractStates { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
