// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Writers
{
    using System.IO;

    /// <summary>
    /// Serializes a Capella object graph back to XMI. The inverse of <c>IXmiReader</c>.
    /// </summary>
    public interface IXmiWriter
    {
        /// <summary>
        /// Writes the object graph rooted at <paramref name="root"/> to <paramref name="mainFilePath"/>,
        /// preserving the fragment layout: elements are partitioned by their
        /// <see cref="IAurigaElement.SourceDocument"/>, the main document is written to
        /// <paramref name="mainFilePath"/> and every <c>.capellafragment</c> to a sibling path relative to
        /// it, with cross-document references serialized as relative <c>href</c>s.
        /// </summary>
        /// <param name="root">the root of the object graph (the <c>capellamodeller:Project</c>)</param>
        /// <param name="mainFilePath">the path of the main semantic file to write</param>
        void Write(IAurigaElement root, string mainFilePath);

        /// <summary>
        /// Writes a single document — the subtree rooted at <paramref name="documentRoot"/> that belongs to
        /// <paramref name="documentName"/> — to a stream. References to elements in other documents are
        /// serialized relative to <paramref name="documentName"/>.
        /// </summary>
        /// <param name="documentRoot">the root element of the document</param>
        /// <param name="stream">the stream to write to</param>
        /// <param name="documentName">the document's canonical name, relative to the main file</param>
        void WriteDocument(IAurigaElement documentRoot, Stream stream, string documentName);
    }
}
