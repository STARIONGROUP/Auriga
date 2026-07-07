// ------------------------------------------------------------------------------------------------
// <copyright file="ICapabilityRealization.cs" company="Starion Group S.A.">
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

namespace Auriga.La
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface ICapabilityRealization : Auriga.Interaction.IAbstractCapability
    {
        Auriga.IContainerList<Auriga.Capellacommon.ICapabilityRealizationInvolvement> OwnedCapabilityRealizationInvolvements { get; }

        IEnumerable<Auriga.Capellacommon.ICapabilityRealizationInvolvedElement> InvolvedComponents { get; }

        IEnumerable<Auriga.Ctx.ICapability> RealizedCapabilities { get; }

        IEnumerable<Auriga.La.ICapabilityRealization> RealizedCapabilityRealizations { get; }

        IEnumerable<Auriga.La.ICapabilityRealization> RealizingCapabilityRealizations { get; }

    }
}
