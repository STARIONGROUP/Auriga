// ------------------------------------------------------------------------------------------------
// <copyright file="EventEndsOrdering.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence.Ordering
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>EventEndsOrdering</c> class.
    /// </summary>
    public partial class EventEndsOrdering : Auriga.Core.AurigaElement, Auriga.Sirius.Sequence.Ordering.IEventEndsOrdering
    {
        /// <summary>
        /// Gets the event ends.
        /// </summary>
        public List<Auriga.Sirius.Sequence.Ordering.IEventEnd> EventEnds { get; } = new List<Auriga.Sirius.Sequence.Ordering.IEventEnd>();

        /// <summary>
        /// Gets the sequence diagram.
        /// </summary>
        public Auriga.Sirius.Sequence.ISequenceDDiagram SequenceDiagram => default;

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
