// ------------------------------------------------------------------------------------------------
// <copyright file="ISvgExporter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;
    using System.IO;

    /// <summary>
    /// The service that serializes intermediate <see cref="Diagram"/> models to SVG — the
    /// injectable exporter of the rendering pipeline. The default implementation,
    /// <see cref="SvgExporter"/>, writes plain SVG with no external dependency; register it in the
    /// application's container, or construct it directly. The exporter is representation-kind
    /// agnostic: it consumes only intermediate-model data, every kind difference having been
    /// expressed by the builders.
    /// </summary>
    public interface ISvgExporter
    {
        /// <summary>
        /// Exports the diagram to an SVG document string.
        /// </summary>
        /// <param name="diagram">the diagram to export</param>
        /// <returns>the SVG document text</returns>
        /// <exception cref="ArgumentNullException">the diagram is null</exception>
        string Export(Diagram diagram);

        /// <summary>
        /// Exports the diagram as an SVG document to the supplied stream.
        /// </summary>
        /// <param name="diagram">the diagram to export</param>
        /// <param name="stream">the stream the SVG document is written to</param>
        /// <exception cref="ArgumentNullException">the diagram or the stream is null</exception>
        void Export(Diagram diagram, Stream stream);

        /// <summary>
        /// Exports the diagram as an SVG file.
        /// </summary>
        /// <param name="diagram">the diagram to export</param>
        /// <param name="path">the file path the SVG document is written to</param>
        /// <exception cref="ArgumentNullException">the diagram is null</exception>
        /// <exception cref="ArgumentException">the path is null or empty</exception>
        void ExportToFile(Diagram diagram, string path);
    }
}
