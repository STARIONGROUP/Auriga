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
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IOperationalCapability : Auriga.Interaction.IAbstractCapability, Auriga.Capellacore.INamespace
    {
        List<Auriga.Oa.IConceptCompliance> Compliances { get; }

        List<Auriga.Oa.ICapabilityConfiguration> Configurations { get; }

        Auriga.IContainerList<Auriga.Oa.IEntityOperationalCapabilityInvolvement> OwnedEntityOperationalCapabilityInvolvements { get; }

        IEnumerable<Auriga.Ctx.ICapability> RealizingCapabilities { get; }

        IEnumerable<Auriga.Oa.IEntity> InvolvedEntities { get; }

    }
}
