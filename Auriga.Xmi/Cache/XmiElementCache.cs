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

        /// <inheritdoc/>
        public int Count => this.elements.Count;

        /// <inheritdoc/>
        public IEnumerable<IAurigaElement> Values => this.elements.Values;

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public bool TryGetValue(string id, out IAurigaElement? element)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.elements.TryGetValue(id, out element);
        }

        /// <inheritdoc/>
        public void Clear()
        {
            this.elements.Clear();
        }
    }
}
