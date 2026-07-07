// ------------------------------------------------------------------------------------------------
// <copyright file="IActivityNode.cs" company="Starion Group S.A.">
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

namespace Auriga.Activity
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>ActivityNode</c> interface.
    /// </summary>
    public partial interface IActivityNode : Auriga.Modellingcore.IAbstractNamedElement
    {
        /// <summary>
        /// Gets the in activity partition.
        /// </summary>
        Auriga.Activity.IActivityPartition InActivityPartition { get; }

        /// <summary>
        /// Gets the in interruptible region.
        /// </summary>
        Auriga.Activity.IInterruptibleActivityRegion InInterruptibleRegion { get; }

        /// <summary>
        /// Gets the in structured node.
        /// </summary>
        Auriga.Activity.IInterruptibleActivityRegion InStructuredNode { get; }

        /// <summary>
        /// Gets the incoming.
        /// </summary>
        IEnumerable<Auriga.Activity.IActivityEdge> Incoming { get; }

        /// <summary>
        /// Gets the outgoing.
        /// </summary>
        IEnumerable<Auriga.Activity.IActivityEdge> Outgoing { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
