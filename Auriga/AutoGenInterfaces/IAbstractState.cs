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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Capellacommon
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IAbstractState : Auriga.Capellacore.INamedElement, Auriga.Modellingcore.IIState
    {
        Auriga.IContainerList<Auriga.Capellacommon.IAbstractStateRealization> OwnedAbstractStateRealizations { get; }

        IEnumerable<Auriga.Capellacommon.IAbstractState> RealizedAbstractStates { get; }

        IEnumerable<Auriga.Capellacommon.IAbstractState> RealizingAbstractStates { get; }

        IEnumerable<Auriga.Capellacommon.IStateTransition> Outgoing { get; }

        IEnumerable<Auriga.Capellacommon.IStateTransition> Incoming { get; }

        IEnumerable<Auriga.Capellacommon.IRegion> InvolverRegions { get; }

    }
}
