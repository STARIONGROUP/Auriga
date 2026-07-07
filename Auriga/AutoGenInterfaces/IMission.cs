// ------------------------------------------------------------------------------------------------
// <copyright file="IMission.cs" company="Starion Group S.A.">
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

namespace Auriga.Ctx
{
    public partial interface IMission : global::Auriga.Capellacore.INamedElement, global::Auriga.Capellacore.IInvolverElement
    {
        global::Auriga.IContainerList<global::Auriga.Ctx.IMissionInvolvement> OwnedMissionInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemComponent> InvolvedSystemComponents { get; }

        global::Auriga.IContainerList<global::Auriga.Ctx.ICapabilityExploitation> OwnedCapabilityExploitations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ICapability> ExploitedCapabilities { get; }

    }
}
