// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiElementCache.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Cache
{
    using System.Collections.Generic;

    /// <summary>
    /// The cache in which every <see cref="IAurigaElement"/> read from an XMI document is registered,
    /// keyed by its <c>xmi:id</c>. The reader populates it on the first (instantiation) pass; the
    /// reference resolver reads it on the second pass to turn the collected <c>#id</c> references into
    /// object references. This mirrors the <c>IXmiElementCache</c> of uml4net.
    /// </summary>
    public interface IXmiElementCache
    {
        /// <summary>
        /// Gets the number of elements in the cache.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets every cached <see cref="IAurigaElement"/>.
        /// </summary>
        IEnumerable<IAurigaElement> Values { get; }

        /// <summary>
        /// Registers the supplied <paramref name="element"/> under its <see cref="IAurigaElement.Id"/>.
        /// </summary>
        /// <param name="element">the element to cache</param>
        /// <returns>
        /// true when the element was added; false when its identifier is null/empty or already present
        /// </returns>
        bool TryAdd(IAurigaElement element);

        /// <summary>
        /// Looks up the element registered under the supplied identifier.
        /// </summary>
        /// <param name="id">the <c>xmi:id</c> of the element (without a leading <c>#</c>)</param>
        /// <param name="element">the resolved element, or <c>null</c> when not found</param>
        /// <returns>true when an element with the identifier is present</returns>
        bool TryGetValue(string id, out IAurigaElement? element);

        /// <summary>
        /// Removes every element from the cache.
        /// </summary>
        void Clear();
    }
}
