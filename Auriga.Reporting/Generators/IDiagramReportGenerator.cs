// ------------------------------------------------------------------------------------------------
// <copyright file="IDiagramReportGenerator.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Generators
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Auriga.Reporting.Builders;
    using Auriga.Reporting.Model;

    /// <summary>
    /// Turns a Capella project into the pictures of its diagrams, in one call: it loads the
    /// <c>.aird</c> and the semantic documents it references, builds every representation into a
    /// <see cref="Diagram"/>, and writes the requested artifacts. The entry point for a caller who
    /// wants the output rather than the object model — the command-line tool binds its options
    /// straight to it.
    /// </summary>
    /// <remarks>
    /// A caller who wants to substitute a service — a palette, a style resolver, a tooltip
    /// resolver, an icon registry — should compose the pipeline with
    /// <see cref="ReportingBuilder"/> and drive <see cref="IDiagramBuilder"/> and the exporters
    /// directly. This generator deliberately owns its composition, because the directory a model's
    /// own artwork resolves against is only known once the path is in hand, and a container cannot
    /// be reconfigured after it is built.
    /// </remarks>
    public interface IDiagramReportGenerator
    {
        /// <summary>
        /// Loads the model, builds its representations and writes the requested artifacts.
        /// </summary>
        /// <param name="aird">the Sirius <c>.aird</c> file, or the project directory holding exactly one</param>
        /// <param name="output">the directory the artifacts are written to; created when absent</param>
        /// <param name="options">what to write and how, or <c>null</c> for an SVG and a PNG of every representation</param>
        /// <returns>the files written, in the order they were produced</returns>
        /// <exception cref="ArgumentNullException">the model path or the output directory is null</exception>
        /// <exception cref="ArgumentException">no format was asked for</exception>
        /// <exception cref="FileNotFoundException">the path names no readable Sirius model</exception>
        IReadOnlyList<FileInfo> Generate(FileInfo aird, DirectoryInfo output, DiagramReportOptions? options = null);

        /// <summary>
        /// The representations the model holds, without writing anything — what a caller shows
        /// before choosing what to export.
        /// </summary>
        /// <param name="aird">the Sirius <c>.aird</c> file, or the project directory holding exactly one</param>
        /// <param name="options">the options whose <see cref="DiagramReportOptions.NameFilter"/> narrows the list, or <c>null</c> for all of them</param>
        /// <returns>the representations, in the order the model holds them</returns>
        /// <exception cref="ArgumentNullException">the model path is null</exception>
        /// <exception cref="FileNotFoundException">the path names no readable Sirius model</exception>
        IReadOnlyList<Diagram> Query(FileInfo aird, DiagramReportOptions? options = null);
    }
}
