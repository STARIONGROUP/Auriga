// ------------------------------------------------------------------------------------------------
// <copyright file="IAirdModelLoader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    using Auriga.Xmi.Core.Readers;

    /// <summary>
    /// The project-level entry point that loads an on-disk Sirius diagram model — given the <c>.aird</c>
    /// file or the project directory that contains it — into a single, fully reference-resolved Auriga
    /// object graph, transitively loading any <c>.airdfragment</c> files the analysis references and
    /// co-loading the Capella semantic documents the diagrams point into, so the cross-metamodel
    /// <c>target</c> / <c>semanticElements</c> links resolve. The diagram counterpart of
    /// <see cref="ICapellaModelLoader"/>.
    /// </summary>
    public interface IAirdModelLoader
    {
        /// <summary>
        /// Loads the Sirius diagram model identified by <paramref name="path"/>, co-loading the Capella
        /// semantic documents its diagrams reference. The path may be the <c>.aird</c> file itself or the
        /// project directory that contains exactly one such file (the metadata <c>.afm</c> sibling is
        /// ignored; tooling references such as <c>platform:/plugin</c> <c>.odesign</c> links are reported
        /// as unresolved).
        /// </summary>
        /// <param name="path">the <c>.aird</c> file path, or the project directory path</param>
        /// <returns>
        /// the fully resolved object graph, including any referenced <c>.airdfragment</c>s and the
        /// co-loaded Capella semantic documents
        /// </returns>
        XmiReaderResult Load(string path);
    }
}
