// ------------------------------------------------------------------------------------------------
// <copyright file="IActivityEdge.cs" company="Starion Group S.A.">
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
    public partial interface IActivityEdge : global::Auriga.Modellingcore.IAbstractRelationship
    {
        global::Auriga.Modellingcore.RateKind? KindOfRate { get; set; }

        global::Auriga.Activity.IActivityPartition InActivityPartition { get; }

        global::Auriga.Activity.IInterruptibleActivityRegion InInterruptibleRegion { get; }

        global::Auriga.Activity.IStructuredActivityNode InStructuredNode { get; }

        global::Auriga.Modellingcore.IValueSpecification Rate { get; set; }

        global::Auriga.Modellingcore.IValueSpecification Probability { get; set; }

        global::Auriga.Activity.IActivityNode Target { get; set; }

        global::Auriga.Activity.IActivityNode Source { get; set; }

        global::Auriga.Modellingcore.IValueSpecification Guard { get; set; }

        global::Auriga.Modellingcore.IValueSpecification Weight { get; set; }

        global::Auriga.Activity.IInterruptibleActivityRegion Interrupts { get; set; }

    }
}
