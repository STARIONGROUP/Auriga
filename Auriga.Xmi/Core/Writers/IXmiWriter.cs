// ------------------------------------------------------------------------------------------------
// <copyright file="IXmiWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Writers
{
    using Auriga.Core;
    using System.IO;

    /// <summary>
    /// Serializes a Capella or Sirius object graph back to XMI. The inverse of <c>IXmiReader</c>.
    /// </summary>
    public interface IXmiWriter
    {
        /// <summary>
        /// Writes the object graph rooted at <paramref name="root"/> to <paramref name="mainFilePath"/>,
        /// preserving the fragment layout: elements are partitioned by their
        /// <see cref="IAurigaElement.SourceDocument"/>, the main document is written to
        /// <paramref name="mainFilePath"/> and every fragment to a sibling path relative to it, with
        /// cross-document references serialized as relative <c>href</c>s.
        /// </summary>
        /// <param name="root">the root of the object graph (e.g. the <c>capellamodeller:Project</c>)</param>
        /// <param name="mainFilePath">the path of the main semantic file to write</param>
        void Write(IAurigaElement root, string mainFilePath);

        /// <summary>
        /// Writes a multi-root object graph to <paramref name="mainFilePath"/>, preserving the fragment
        /// layout as <see cref="Write(IAurigaElement, string)"/> does. A Sirius <c>.aird</c> is a
        /// multi-root <c>xmi:XMI</c> document — one <c>viewpoint:DAnalysis</c> plus N parallel
        /// representation roots that are not contained under it — so its roots (the analysis and the
        /// elements read as top-level roots, i.e. those whose <see cref="IAurigaElement.Container"/> is
        /// <c>null</c>) are supplied together and re-emitted inside the <c>xmi:XMI</c> wrapper.
        /// </summary>
        /// <param name="roots">the roots of the object graph; the first is treated as the primary root</param>
        /// <param name="mainFilePath">the path of the main file to write</param>
        void Write(System.Collections.Generic.IReadOnlyCollection<IAurigaElement> roots, string mainFilePath);

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
