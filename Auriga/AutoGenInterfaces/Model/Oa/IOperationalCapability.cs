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

namespace Auriga.Model.Oa
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>OperationalCapability</c> interface.
    /// </summary>
    public partial interface IOperationalCapability : Auriga.Model.Interaction.IAbstractCapability, Auriga.Model.Capellacore.INamespace
    {
        /// <summary>
        /// Gets the compliances.
        /// </summary>
        List<Auriga.Model.Oa.IConceptCompliance> Compliances { get; }

        /// <summary>
        /// Gets the configurations.
        /// </summary>
        List<Auriga.Model.Oa.ICapabilityConfiguration> Configurations { get; }

        /// <summary>
        /// Gets the involved entities.
        /// </summary>
        IEnumerable<Auriga.Model.Oa.IEntity> InvolvedEntities { get; }

        /// <summary>
        /// Gets the owned entity operational capability involvements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Oa.IEntityOperationalCapabilityInvolvement> OwnedEntityOperationalCapabilityInvolvements { get; }

        /// <summary>
        /// Gets the realizing capabilities.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ICapability> RealizingCapabilities { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
