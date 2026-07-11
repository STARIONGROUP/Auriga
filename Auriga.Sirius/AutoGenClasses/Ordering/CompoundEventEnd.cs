// ------------------------------------------------------------------------------------------------
// <copyright file="CompoundEventEnd.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>CompoundEventEnd</c> class.
    /// </summary>
    public partial class CompoundEventEnd : Auriga.AurigaElement, Auriga.Sirius.Sequence.Ordering.ICompoundEventEnd
    {
        /// <summary>
        /// Gets the event ends.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Sequence.Ordering.ISingleEventEnd> EventEnds => this.backingEventEnds ??= new Auriga.ContainerList<Auriga.Sirius.Sequence.Ordering.ISingleEventEnd>(this);

        /// <summary>
        /// Backing field for <see cref="EventEnds"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Sequence.Ordering.ISingleEventEnd> backingEventEnds;

        /// <summary>
        /// Gets or sets the semantic end.
        /// </summary>
        public object SemanticEnd { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>CompoundEventEnd</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.EventEnds)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
