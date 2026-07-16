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

namespace Auriga.Model.Ctx
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Capability</c> interface.
    /// </summary>
    public partial interface ICapability : Auriga.Model.Interaction.IAbstractCapability
    {
        /// <summary>
        /// Gets the involved system components.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ISystemComponent> InvolvedSystemComponents { get; }

        /// <summary>
        /// Gets the owned capability involvements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Ctx.ICapabilityInvolvement> OwnedCapabilityInvolvements { get; }

        /// <summary>
        /// Gets the purpose missions.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.IMission> PurposeMissions { get; }

        /// <summary>
        /// Gets the purposes.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ICapabilityExploitation> Purposes { get; }

        /// <summary>
        /// Gets the realized operational capabilities.
        /// </summary>
        IEnumerable<Auriga.Model.Oa.IOperationalCapability> RealizedOperationalCapabilities { get; }

        /// <summary>
        /// Gets the realizing capability realizations.
        /// </summary>
        IEnumerable<Auriga.Model.La.ICapabilityRealization> RealizingCapabilityRealizations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
