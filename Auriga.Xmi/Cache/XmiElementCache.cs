// ------------------------------------------------------------------------------------------------
// <copyright file="XmiElementCache.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Cache
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The default <see cref="IXmiElementCache"/>, backed by a dictionary keyed by <c>xmi:id</c>.
    /// </summary>
    public sealed class XmiElementCache : IXmiElementCache
    {
        private readonly Dictionary<string, IAurigaElement> elements = new Dictionary<string, IAurigaElement>(StringComparer.Ordinal);

        /// <summary>
        /// Gets the number of elements in the cache.
        /// </summary>
        public int Count => this.elements.Count;

        /// <summary>
        /// Gets every cached <see cref="IAurigaElement"/>.
        /// </summary>
        public IEnumerable<IAurigaElement> Values => this.elements.Values;

        /// <summary>
        /// Registers the supplied <paramref name="element"/> under its <see cref="IAurigaElement.Id"/>.
        /// </summary>
        /// <param name="element">the element to cache</param>
        /// <returns>
        /// true when the element was added; false when its identifier is null/empty or already present
        /// </returns>
        public bool TryAdd(IAurigaElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (string.IsNullOrEmpty(element.Id))
            {
                return false;
            }

            return this.elements.TryAdd(element.Id!, element);
        }

        /// <summary>
        /// Looks up the element registered under the supplied identifier.
        /// </summary>
        /// <param name="id">the <c>xmi:id</c> of the element (without a leading <c>#</c>)</param>
        /// <param name="element">the resolved element, or <c>null</c> when not found</param>
        /// <returns>true when an element with the identifier is present</returns>
        public bool TryGetValue(string id, out IAurigaElement? element)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.elements.TryGetValue(id, out element);
        }

        /// <summary>
        /// Removes every element from the cache.
        /// </summary>
        public void Clear()
        {
            this.elements.Clear();
        }
    }
}
