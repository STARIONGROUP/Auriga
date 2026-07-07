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
    public partial interface IActivityNode : global::Auriga.Modellingcore.IAbstractNamedElement
    {
        global::Auriga.Activity.IActivityPartition InActivityPartition { get; }

        global::Auriga.Activity.IInterruptibleActivityRegion InInterruptibleRegion { get; }

        global::Auriga.Activity.IInterruptibleActivityRegion InStructuredNode { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Activity.IActivityEdge> Outgoing { get; }

        global::System.Collections.Generic.IEnumerable<global::Auriga.Activity.IActivityEdge> Incoming { get; }

    }
}
