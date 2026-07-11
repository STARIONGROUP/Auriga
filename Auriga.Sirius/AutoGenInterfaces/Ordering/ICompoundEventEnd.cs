// ------------------------------------------------------------------------------------------------
// <copyright file="ICompoundEventEnd.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>CompoundEventEnd</c> interface.
    /// </summary>
    public partial interface ICompoundEventEnd : Auriga.Sirius.Sequence.Ordering.IEventEnd
    {
        /// <summary>
        /// Gets the event ends.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Sequence.Ordering.ISingleEventEnd> EventEnds { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
