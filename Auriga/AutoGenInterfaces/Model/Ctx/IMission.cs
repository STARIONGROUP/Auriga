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

namespace Auriga.Model.Ctx
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Mission</c> interface.
    /// </summary>
    public partial interface IMission : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Capellacore.IInvolverElement
    {
        /// <summary>
        /// Gets the exploited capabilities.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ICapability> ExploitedCapabilities { get; }

        /// <summary>
        /// Gets the involved system components.
        /// </summary>
        IEnumerable<Auriga.Model.Ctx.ISystemComponent> InvolvedSystemComponents { get; }

        /// <summary>
        /// Gets the owned capability exploitations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Ctx.ICapabilityExploitation> OwnedCapabilityExploitations { get; }

        /// <summary>
        /// Gets the owned mission involvements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Ctx.IMissionInvolvement> OwnedMissionInvolvements { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
