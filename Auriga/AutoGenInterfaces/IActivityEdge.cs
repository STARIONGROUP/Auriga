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
    public partial interface IActivityEdge : Auriga.Modellingcore.IAbstractRelationship
    {
        Auriga.Modellingcore.RateKind? KindOfRate { get; set; }

        Auriga.Activity.IActivityPartition InActivityPartition { get; }

        Auriga.Activity.IInterruptibleActivityRegion InInterruptibleRegion { get; }

        Auriga.Activity.IStructuredActivityNode InStructuredNode { get; }

        Auriga.Modellingcore.IValueSpecification Rate { get; set; }

        Auriga.Modellingcore.IValueSpecification Probability { get; set; }

        Auriga.Activity.IActivityNode Target { get; set; }

        Auriga.Activity.IActivityNode Source { get; set; }

        Auriga.Modellingcore.IValueSpecification Guard { get; set; }

        Auriga.Modellingcore.IValueSpecification Weight { get; set; }

        Auriga.Activity.IInterruptibleActivityRegion Interrupts { get; set; }

    }
}
