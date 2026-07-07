// ------------------------------------------------------------------------------------------------
// <copyright file="ICapability.cs" company="Starion Group S.A.">
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
    public partial interface ICapability : global::Auriga.Interaction.IAbstractCapability
    {
        global::Auriga.IContainerList<global::Auriga.Ctx.ICapabilityInvolvement> OwnedCapabilityInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ISystemComponent> InvolvedSystemComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ICapabilityExploitation> Purposes { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.IMission> PurposeMissions { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IOperationalCapability> RealizedOperationalCapabilities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ICapabilityRealization> RealizingCapabilityRealizations { get; }

    }
}
