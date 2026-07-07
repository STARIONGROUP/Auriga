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
    /// An owner-aware list used for <b>containment</b> references in the generated object model:
    /// adding an element sets its <see cref="IAurigaElement.Container"/> to the owner (the analogue of
    /// an EMF containment <c>EList</c>). Non-containment (cross-reference) collections use a plain
    /// <see cref="List{T}"/> instead.
    /// </summary>
    /// <typeparam name="T">the element type, an <see cref="IAurigaElement"/></typeparam>
    public interface IContainerList<T> : IList<T> where T : notnull, IAurigaElement
    {
        /// <summary>
        /// Gets the element that owns this containment list.
        /// </summary>
        IAurigaElement Owner { get; }
    }
}
