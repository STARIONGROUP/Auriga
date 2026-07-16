// ------------------------------------------------------------------------------------------------
// <copyright file="IEventEndsOrdering.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Sequence.Ordering
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>EventEndsOrdering</c> interface.
    /// </summary>
    public partial interface IEventEndsOrdering : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets the event ends.
        /// </summary>
        List<Auriga.Diagram.Sequence.Ordering.IEventEnd> EventEnds { get; }

        /// <summary>
        /// Gets the sequence diagram.
        /// </summary>
        Auriga.Diagram.Sequence.ISequenceDDiagram SequenceDiagram { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
