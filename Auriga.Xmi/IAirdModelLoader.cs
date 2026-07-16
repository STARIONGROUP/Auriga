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
    /// object graph, transitively loading any <c>.airdfragment</c> files the analysis references. The
    /// diagram counterpart of <see cref="ICapellaModelLoader"/>.
    /// </summary>
    public interface IAirdModelLoader
    {
        /// <summary>
        /// Loads the Sirius diagram model identified by <paramref name="path"/>. The path may be the
        /// <c>.aird</c> file itself or the project directory that contains exactly one such file (its
        /// semantic <c>.capella</c> and metadata <c>.afm</c> siblings are ignored; the semantic hrefs
        /// they are the target of stay unresolved in a diagram-only load).
        /// </summary>
        /// <param name="path">the <c>.aird</c> file path, or the project directory path</param>
        /// <returns>the fully resolved object graph, including any referenced <c>.airdfragment</c>s</returns>
        XmiReaderResult Load(string path);
    }
}
