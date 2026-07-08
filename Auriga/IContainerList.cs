// ------------------------------------------------------------------------------------------------
// <copyright file="IContainerList.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga
{
    using System.Collections.Generic;

    /// <summary>
    /// An owner-aware list used for <b>containment</b> references in the generated object model: adding
    /// an element sets its <see cref="IAurigaElement.Container"/> to the <see cref="Owner"/> and removing
    /// it clears that container again (the analogue of an EMF containment <c>EList</c>). Non-containment
    /// (cross-reference) collections use a plain <see cref="List{T}"/> instead.
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
    }
}
