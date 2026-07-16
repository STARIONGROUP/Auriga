// ------------------------------------------------------------------------------------------------
// <copyright file="IInterruptibleActivityRegion.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Activity
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>InterruptibleActivityRegion</c> interface.
    /// </summary>
    public partial interface IInterruptibleActivityRegion : Auriga.Model.Activity.IActivityGroup
    {
        /// <summary>
        /// Gets the interrupting edges.
        /// </summary>
        List<Auriga.Model.Activity.IActivityEdge> InterruptingEdges { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
