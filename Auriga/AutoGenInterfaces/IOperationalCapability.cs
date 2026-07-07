// ------------------------------------------------------------------------------------------------
// <copyright file="IOperationalCapability.cs" company="Starion Group S.A.">
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

namespace Auriga.Oa
{
    public partial interface IOperationalCapability : global::Auriga.Interaction.IAbstractCapability, global::Auriga.Capellacore.INamespace
    {
        global::System.Collections.Generic.List<global::Auriga.Oa.IConceptCompliance> Compliances { get; }

        global::System.Collections.Generic.List<global::Auriga.Oa.ICapabilityConfiguration> Configurations { get; }

        global::Auriga.IContainerList<global::Auriga.Oa.IEntityOperationalCapabilityInvolvement> OwnedEntityOperationalCapabilityInvolvements { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Ctx.ICapability> RealizingCapabilities { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Oa.IEntity> InvolvedEntities { get; }

    }
}
