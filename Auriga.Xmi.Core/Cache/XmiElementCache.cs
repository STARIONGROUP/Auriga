// ------------------------------------------------------------------------------------------------
// <copyright file="XmiElementCache.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Cache
{
    using Auriga.Core;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The default <see cref="IXmiElementCache"/>, backed by a dictionary keyed by <c>xmi:id</c>.
    /// </summary>
    public sealed class XmiElementCache : IXmiElementCache
    {
        /// <summary>
        /// The backing store of cached elements, keyed by <c>xmi:id</c> with ordinal comparison.
        /// </summary>
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
        /// Registers the supplied <paramref name="element"/> under its document-scoped key
        /// (<see cref="IAurigaElement.SourceDocument"/><c>#</c><see cref="IAurigaElement.Id"/>).
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

            return this.elements.TryAdd(Key(element.SourceDocument, element.Id!), element);
        }

        /// <summary>
        /// Looks up the element registered under the supplied document-scoped key.
        /// </summary>
        /// <param name="key">the document-scoped key (<c>documentName#id</c>), built with <see cref="Key"/></param>
        /// <param name="element">the resolved element, or <c>null</c> when not found</param>
        /// <returns>true when an element with the key is present</returns>
        public bool TryGetValue(string key, out IAurigaElement? element)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return this.elements.TryGetValue(key, out element);
        }

        /// <summary>
        /// Builds the document-scoped cache key (<c>documentName#id</c>) — the analogue of uml4net's
        /// <c>FullyQualifiedIdentifier</c>. Every element is cached under this key so an <c>href</c> that
        /// names another document resolves against the element that document contributed.
        /// </summary>
        /// <param name="documentName">the document the element belongs to (relative to the main file)</param>
        /// <param name="id">the bare <c>xmi:id</c> of the element</param>
        /// <returns>the document-scoped key</returns>
        public static string Key(string? documentName, string id)
        {
            return string.Concat(documentName, "#", id);
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
