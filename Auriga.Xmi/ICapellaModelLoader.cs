// ------------------------------------------------------------------------------------------------
// <copyright file="ICapellaModelLoader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi
{
    /// <summary>
    /// The project-level entry point that loads an on-disk Capella project — given the semantic model
    /// file (a <c>.capella</c> or legacy <c>.melodymodeller</c>) or the directory that contains it — into
    /// a single, fully reference-resolved Auriga object graph, transitively loading any
    /// <c>.capellafragment</c> files the model references.
    /// </summary>
    public interface ICapellaModelLoader
    {
        /// <summary>
        /// Loads the Capella project identified by <paramref name="path"/>. The path may be the semantic
        /// model file itself (<c>.capella</c> / <c>.melodymodeller</c>) or the project directory that
        /// contains exactly one such file (its diagram <c>.aird</c> and metadata <c>.afm</c> siblings are
        /// ignored).
        /// </summary>
        /// <param name="path">the semantic model file path, or the project directory path</param>
        /// <returns>the fully resolved object graph, including any referenced fragments</returns>
        XmiReaderResult Load(string path);
    }
}
