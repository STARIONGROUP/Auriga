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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Capellacommon
{
    public partial interface IStateMachine : global::Auriga.Capellacore.ICapellaElement, global::Auriga.Behavior.IAbstractBehavior
    {
        global::Auriga.IContainerList<global::Auriga.Capellacommon.IRegion> OwnedRegions { get; }

        global::Auriga.IContainerList<global::Auriga.Capellacommon.IPseudostate> OwnedConnectionPoints { get; }

    }
}
