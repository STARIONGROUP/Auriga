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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ICapability : Auriga.Interaction.IAbstractCapability
    {
        Auriga.IContainerList<Auriga.Ctx.ICapabilityInvolvement> OwnedCapabilityInvolvements { get; }

        IEnumerable<Auriga.Ctx.ISystemComponent> InvolvedSystemComponents { get; }

        IEnumerable<Auriga.Ctx.ICapabilityExploitation> Purposes { get; }

        IEnumerable<Auriga.Ctx.IMission> PurposeMissions { get; }

        IEnumerable<Auriga.Oa.IOperationalCapability> RealizedOperationalCapabilities { get; }

        IEnumerable<Auriga.La.ICapabilityRealization> RealizingCapabilityRealizations { get; }

    }
}
