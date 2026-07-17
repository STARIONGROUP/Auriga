// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiReader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Readers
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Reads an XMI document — a Capella <c>.melodymodeller</c> / <c>.capella</c> semantic model or a
    /// Sirius <c>.aird</c> diagram model — into a fully-typed and reference-resolved Auriga object graph.
    /// </summary>
    public interface IXmiReader
    {
        /// <summary>
        /// Reads the XMI document at the supplied path, transitively loading the fragment documents of
        /// the main document's family (<c>.capellafragment</c> / <c>.airdfragment</c>) it references.
        /// </summary>
        /// <param name="path">the path of the <c>.melodymodeller</c> / <c>.capella</c> / <c>.aird</c> file</param>
        /// <returns>the read result</returns>
        XmiReaderResult Read(string path);

        /// <summary>
        /// Reads the XMI document at the supplied path, transitively loading every referenced document
        /// that carries one of the supplied extensions into the same session before the single
        /// reference-resolution pass. Passing the union of both metamodel families (e.g.
        /// <c>.airdfragment</c> + <c>.capella</c> / <c>.capellafragment</c> for an <c>.aird</c> main
        /// document) co-loads the semantic model the diagrams point into, so their cross-metamodel
        /// <c>target</c> / <c>semanticElements</c> hrefs resolve to the co-loaded elements.
        /// </summary>
        /// <param name="path">the path of the main document</param>
        /// <param name="referencedDocumentExtensions">
        /// the file extensions of the referenced documents to load transitively into the session
        /// </param>
        /// <returns>the read result</returns>
        XmiReaderResult Read(string path, IReadOnlyCollection<string> referencedDocumentExtensions);

        /// <summary>
        /// Reads the XMI document from the supplied stream.
        /// </summary>
        /// <param name="stream">the stream to read</param>
        /// <param name="documentName">the name of the document (used for diagnostics)</param>
        /// <returns>the read result</returns>
        XmiReaderResult Read(Stream stream, string documentName);
    }
}
