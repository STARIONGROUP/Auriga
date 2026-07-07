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
    public partial interface ICapabilityRealization : global::Auriga.Interaction.IAbstractCapability
    {
        global::Auriga.IContainerList<global::Auriga.Capellacommon.ICapabilityRealizationInvolvement> OwnedCapabilityRealizationInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.ICapabilityRealizationInvolvedElement> InvolvedComponents { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ICapability> RealizedCapabilities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ICapabilityRealization> RealizedCapabilityRealizations { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ICapabilityRealization> RealizingCapabilityRealizations { get; }

    }
}
