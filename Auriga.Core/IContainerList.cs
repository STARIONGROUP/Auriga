// ------------------------------------------------------------------------------------------------
// <copyright file="IContainerList.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// An owner-aware list used for <b>containment</b> references in the generated object model: adding
    /// an element sets its <see cref="IAurigaElement.Container"/> to the <see cref="Owner"/> and removing
    /// it clears that container again (the analogue of an EMF containment <c>EList</c>). Non-containment
    /// (cross-reference) collections use a plain <see cref="List{T}"/> instead.
    ///
    /// <para>Containment is <b>exclusive</b>: an element already held by another container is rejected
    /// (not silently stolen), so it belongs to exactly one owner. Move it by removing it from its current
    /// container first. See <c>docs/containment-list.md</c>.</para>
    /// </summary>
    /// <typeparam name="T">the element type, an <see cref="IAurigaElement"/></typeparam>
    public interface IContainerList<T> : IList<T> where T : class, IAurigaElement
    {
        /// <summary>
        /// Gets the element that owns this containment list.
        /// </summary>
        IAurigaElement Owner { get; }

        /// <summary>
        /// Adds a range of elements to the list, setting each element's <see cref="IAurigaElement.Container"/>
        /// to the <see cref="Owner"/>.
        /// </summary>
        /// <param name="elements">the elements to add</param>
        void AddRange(IEnumerable<T> elements);

        /// <summary>
        /// Moves the element at <paramref name="oldIndex"/> to <paramref name="newIndex"/> within this list.
        /// The element stays in the same list, so its <see cref="IAurigaElement.Container"/> is unchanged —
        /// this is the supported way to reorder a containment feature (the indexer set replaces, it does not
        /// move).
        /// </summary>
        /// <param name="oldIndex">the current zero-based index of the element</param>
        /// <param name="newIndex">the zero-based index to move it to</param>
        void Move(int oldIndex, int newIndex);
    }
}
