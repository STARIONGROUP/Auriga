// ------------------------------------------------------------------------------------------------
// <copyright file="IStateEventRealization.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellacommon
{
    /// <summary>
    /// Definition of the <c>StateEventRealization</c> interface.
    /// </summary>
    public partial interface IStateEventRealization : Auriga.Capellacore.IAllocation
    {
        /// <summary>
        /// Gets the realized event.
        /// </summary>
        Auriga.Capellacommon.IStateEvent RealizedEvent { get; }

        /// <summary>
        /// Gets the realizing event.
        /// </summary>
        Auriga.Capellacommon.IStateEvent RealizingEvent { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
