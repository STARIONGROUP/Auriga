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
    public partial interface IAbstractState : global::Auriga.Capellacore.INamedElement, global::Auriga.Modellingcore.IIState
    {
        global::Auriga.IContainerList<global::Auriga.Capellacommon.IAbstractStateRealization> OwnedAbstractStateRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.IAbstractState> RealizedAbstractStates { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.IAbstractState> RealizingAbstractStates { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.IStateTransition> Outgoing { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.IStateTransition> Incoming { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.IRegion> InvolverRegions { get; }

    }
}
