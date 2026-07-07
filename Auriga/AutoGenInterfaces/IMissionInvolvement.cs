// ------------------------------------------------------------------------------------------------
// <copyright file="IMissionInvolvement.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>MissionInvolvement</c> interface.
    /// </summary>
    public partial interface IMissionInvolvement : Auriga.Capellacore.IInvolvement
    {
        /// <summary>
        /// Gets the mission.
        /// </summary>
        Auriga.Ctx.IMission Mission { get; }

        /// <summary>
        /// Gets the system component.
        /// </summary>
        Auriga.Ctx.ISystemComponent SystemComponent { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
