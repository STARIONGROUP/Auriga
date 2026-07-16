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

namespace Auriga.Model.Capellacommon
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>AbstractState</c> interface.
    /// </summary>
    public partial interface IAbstractState : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Modellingcore.IIState
    {
        /// <summary>
        /// Gets the incoming.
        /// </summary>
        IEnumerable<Auriga.Model.Capellacommon.IStateTransition> Incoming { get; }

        /// <summary>
        /// Gets the involver regions.
        /// </summary>
        IEnumerable<Auriga.Model.Capellacommon.IRegion> InvolverRegions { get; }

        /// <summary>
        /// Gets the outgoing.
        /// </summary>
        IEnumerable<Auriga.Model.Capellacommon.IStateTransition> Outgoing { get; }

        /// <summary>
        /// Gets the owned abstract state realizations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacommon.IAbstractStateRealization> OwnedAbstractStateRealizations { get; }

        /// <summary>
        /// Gets the realized abstract states.
        /// </summary>
        IEnumerable<Auriga.Model.Capellacommon.IAbstractState> RealizedAbstractStates { get; }

        /// <summary>
        /// Gets the realizing abstract states.
        /// </summary>
        IEnumerable<Auriga.Model.Capellacommon.IAbstractState> RealizingAbstractStates { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
