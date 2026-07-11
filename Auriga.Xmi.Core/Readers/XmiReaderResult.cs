// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderResult.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Readers
{
    using System.Collections.Generic;

    using Auriga.Xmi.ReferenceResolver;

    /// <summary>
    /// The outcome of reading an XMI document: the typed root element and every element that was read,
    /// with a by-identifier lookup, together with any references that could not be resolved.
    /// </summary>
    public sealed class XmiReaderResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReaderResult"/> class.
        /// </summary>
        /// <param name="root">the typed root element of the document</param>
        /// <param name="elements">every element read from the document, keyed by <c>xmi:id</c></param>
        /// <param name="unresolvedReferences">the references that could not be resolved (dangling references)</param>
        public XmiReaderResult(IAurigaElement root, IReadOnlyDictionary<string, IAurigaElement> elements, IReadOnlyList<UnresolvedReference> unresolvedReferences)
        {
            this.Root = root;
            this.Elements = elements;
            this.UnresolvedReferences = unresolvedReferences;
        }

        /// <summary>
        /// Gets the typed root element of the document (a <c>capellamodeller::Project</c>).
        /// </summary>
        public IAurigaElement Root { get; }

        /// <summary>
        /// Gets every element read from the document, keyed by its <c>xmi:id</c>.
        /// </summary>
        public IReadOnlyDictionary<string, IAurigaElement> Elements { get; }

        /// <summary>
        /// Gets the references that could not be resolved because the referenced <c>xmi:id</c> was not
        /// found in the document (dangling references). Empty when every reference resolved.
        /// </summary>
        public IReadOnlyList<UnresolvedReference> UnresolvedReferences { get; }
    }
}
