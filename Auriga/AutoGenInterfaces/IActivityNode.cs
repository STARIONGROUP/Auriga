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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Activity
{
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IActivityNode : Auriga.Modellingcore.IAbstractNamedElement
    {
        Auriga.Activity.IActivityPartition InActivityPartition { get; }

        Auriga.Activity.IInterruptibleActivityRegion InInterruptibleRegion { get; }

        Auriga.Activity.IInterruptibleActivityRegion InStructuredNode { get; }

        IEnumerable<Auriga.Activity.IActivityEdge> Outgoing { get; }

        IEnumerable<Auriga.Activity.IActivityEdge> Incoming { get; }

    }
}
