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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IMission : Auriga.Capellacore.INamedElement, Auriga.Capellacore.IInvolverElement
    {
        Auriga.IContainerList<Auriga.Ctx.IMissionInvolvement> OwnedMissionInvolvements { get; }

        IEnumerable<Auriga.Ctx.ISystemComponent> InvolvedSystemComponents { get; }

        Auriga.IContainerList<Auriga.Ctx.ICapabilityExploitation> OwnedCapabilityExploitations { get; }

        IEnumerable<Auriga.Ctx.ICapability> ExploitedCapabilities { get; }

    }
}
