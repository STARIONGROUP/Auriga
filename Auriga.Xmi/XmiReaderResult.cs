// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderResult.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using System.Collections.Generic;

    /// <summary>
    /// The outcome of reading an XMI document: the typed root element and every element that was read,
    /// with a by-identifier lookup.
    /// </summary>
    public sealed class XmiReaderResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReaderResult"/> class.
        /// </summary>
        /// <param name="root">the typed root element of the document</param>
        /// <param name="elements">every element read from the document, keyed by <c>xmi:id</c></param>
        public XmiReaderResult(IAurigaElement root, IReadOnlyDictionary<string, IAurigaElement> elements)
        {
            this.Root = root;
            this.Elements = elements;
        }

        /// <summary>
        /// Gets the typed root element of the document (a <c>capellamodeller::Project</c>).
        /// </summary>
        public IAurigaElement Root { get; }

        /// <summary>
        /// Gets every element read from the document, keyed by its <c>xmi:id</c>.
        /// </summary>
        public IReadOnlyDictionary<string, IAurigaElement> Elements { get; }
    }
}
