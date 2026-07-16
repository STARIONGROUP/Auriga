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

namespace Auriga.Model.Activity
{
    /// <summary>
    /// Definition of the <c>ActivityEdge</c> interface.
    /// </summary>
    public partial interface IActivityEdge : Auriga.Model.Modellingcore.IAbstractRelationship
    {
        /// <summary>
        /// Gets or sets the guard.
        /// </summary>
        Auriga.Model.Modellingcore.IValueSpecification Guard { get; set; }

        /// <summary>
        /// Gets the in activity partition.
        /// </summary>
        Auriga.Model.Activity.IActivityPartition InActivityPartition { get; }

        /// <summary>
        /// Gets the in interruptible region.
        /// </summary>
        Auriga.Model.Activity.IInterruptibleActivityRegion InInterruptibleRegion { get; }

        /// <summary>
        /// Gets the in structured node.
        /// </summary>
        Auriga.Model.Activity.IStructuredActivityNode InStructuredNode { get; }

        /// <summary>
        /// Gets or sets the interrupts.
        /// </summary>
        Auriga.Model.Activity.IInterruptibleActivityRegion Interrupts { get; set; }

        /// <summary>
        /// Gets or sets the kind of rate.
        /// </summary>
        Auriga.Model.Modellingcore.RateKind? KindOfRate { get; set; }

        /// <summary>
        /// Gets or sets the probability.
        /// </summary>
        Auriga.Model.Modellingcore.IValueSpecification Probability { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        Auriga.Model.Modellingcore.IValueSpecification Rate { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Model.Activity.IActivityNode Source { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Model.Activity.IActivityNode Target { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        Auriga.Model.Modellingcore.IValueSpecification Weight { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
