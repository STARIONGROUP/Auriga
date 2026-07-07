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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Capellacommon
{
    public partial interface IStateTransitionRealization : global::Auriga.Capellacore.IAllocation
    {
        global::Auriga.Capellacommon.IStateTransition RealizedStateTransition { get; }

        global::Auriga.Capellacommon.IStateTransition RealizingStateTransition { get; }

    }
}
