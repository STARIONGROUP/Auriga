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

namespace Auriga.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>OperationalCapability</c> interface.
    /// </summary>
    public partial interface IOperationalCapability : Auriga.Interaction.IAbstractCapability, Auriga.Capellacore.INamespace
    {
        /// <summary>
        /// Gets the compliances.
        /// </summary>
        List<Auriga.Oa.IConceptCompliance> Compliances { get; }

        /// <summary>
        /// Gets the configurations.
        /// </summary>
        List<Auriga.Oa.ICapabilityConfiguration> Configurations { get; }

        /// <summary>
        /// Gets the involved entities.
        /// </summary>
        IEnumerable<Auriga.Oa.IEntity> InvolvedEntities { get; }

        /// <summary>
        /// Gets the owned entity operational capability involvements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Oa.IEntityOperationalCapabilityInvolvement> OwnedEntityOperationalCapabilityInvolvements { get; }

        /// <summary>
        /// Gets the realizing capabilities.
        /// </summary>
        IEnumerable<Auriga.Ctx.ICapability> RealizingCapabilities { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
