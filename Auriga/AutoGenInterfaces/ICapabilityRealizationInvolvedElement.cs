// ------------------------------------------------------------------------------------------------
// <copyright file="ICapabilityRealizationInvolvedElement.cs" company="Starion Group S.A.">
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
    public partial interface ICapabilityRealizationInvolvedElement : global::Auriga.Capellacore.IInvolvedElement
    {
        global::System.Collections.Generic.IEnumerable<global::Auriga.Capellacommon.ICapabilityRealizationInvolvement> CapabilityRealizationInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.La.ICapabilityRealization> InvolvingCapabilityRealizations { get; }

    }
}
