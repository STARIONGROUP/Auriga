// ------------------------------------------------------------------------------------------------
// <copyright file="IMission.cs" company="Starion Group S.A.">
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

namespace Auriga.Ctx
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Mission</c> interface.
    /// </summary>
    public partial interface IMission : Auriga.Capellacore.INamedElement, Auriga.Capellacore.IInvolverElement
    {
        /// <summary>
        /// Gets the exploited capabilities.
        /// </summary>
        IEnumerable<Auriga.Ctx.ICapability> ExploitedCapabilities { get; }

        /// <summary>
        /// Gets the involved system components.
        /// </summary>
        IEnumerable<Auriga.Ctx.ISystemComponent> InvolvedSystemComponents { get; }

        /// <summary>
        /// Gets the owned capability exploitations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Ctx.ICapabilityExploitation> OwnedCapabilityExploitations { get; }

        /// <summary>
        /// Gets the owned mission involvements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Ctx.IMissionInvolvement> OwnedMissionInvolvements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
