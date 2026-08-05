// ------------------------------------------------------------------------------------------------
// <copyright file="IRasterExporter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Drawing
{
    using System;
    using System.IO;

    using Auriga.Reporting.Model;

    /// <summary>
    /// The service that rasterizes a diagram to PNG or JPEG — the bitmap counterpart of
    /// <see cref="ISvgExporter"/>, for the consumers that cannot take a vector document: a
    /// thumbnail, a Word or PowerPoint report, an issue-tracker attachment. It exports a
    /// <see cref="Diagram"/> by serializing it to SVG first, and exports SVG text directly for a
    /// caller that already holds one.
    /// </summary>
    /// <remarks>
    /// The image measures the document's viewport — for a diagram, the padded bounding box of its
    /// persisted geometry — rounded to whole pixels and multiplied by
    /// <see cref="RasterOptions.Scale"/>. The default implementation,
    /// <see cref="SkiaRasterExporter"/>, draws with SkiaSharp and Svg.Skia; it is the reason this
    /// package carries a native dependency, and this interface is what keeps that dependency
    /// substitutable. Rasterization is exact rather than best-effort: unlike the builders, which
    /// degrade so that an imperfect diagram still renders, an export that cannot produce an image
    /// throws — a zero-byte file is not a partial result.
    /// </remarks>
    public interface IRasterExporter
    {
        /// <summary>
        /// Rasterizes the diagram and returns the encoded image.
        /// </summary>
        /// <param name="diagram">the diagram to rasterize</param>
        /// <param name="format">the image format to encode</param>
        /// <param name="options">how the diagram is rasterized, or <c>null</c> for the defaults</param>
        /// <returns>the encoded image bytes</returns>
        /// <exception cref="ArgumentNullException">the diagram is null</exception>
        /// <exception cref="InvalidOperationException">the diagram did not rasterize</exception>
        byte[] Export(Diagram diagram, RasterFormat format, RasterOptions? options = null);

        /// <summary>
        /// Rasterizes the diagram and writes the encoded image to the supplied stream.
        /// </summary>
        /// <param name="diagram">the diagram to rasterize</param>
        /// <param name="stream">the stream the encoded image is written to</param>
        /// <param name="format">the image format to encode</param>
        /// <param name="options">how the diagram is rasterized, or <c>null</c> for the defaults</param>
        /// <exception cref="ArgumentNullException">the diagram or the stream is null</exception>
        /// <exception cref="InvalidOperationException">the diagram did not rasterize</exception>
        void Export(Diagram diagram, Stream stream, RasterFormat format, RasterOptions? options = null);

        /// <summary>
        /// Rasterizes an SVG document and returns the encoded image.
        /// </summary>
        /// <param name="svg">the SVG document text</param>
        /// <param name="format">the image format to encode</param>
        /// <param name="options">how the document is rasterized, or <c>null</c> for the defaults</param>
        /// <returns>the encoded image bytes</returns>
        /// <exception cref="ArgumentException">the SVG text is null or empty</exception>
        /// <exception cref="InvalidOperationException">the document did not rasterize</exception>
        byte[] Export(string svg, RasterFormat format, RasterOptions? options = null);

        /// <summary>
        /// Rasterizes an SVG document and writes the encoded image to the supplied stream.
        /// </summary>
        /// <param name="svg">the SVG document text</param>
        /// <param name="stream">the stream the encoded image is written to</param>
        /// <param name="format">the image format to encode</param>
        /// <param name="options">how the document is rasterized, or <c>null</c> for the defaults</param>
        /// <exception cref="ArgumentNullException">the stream is null</exception>
        /// <exception cref="ArgumentException">the SVG text is null or empty</exception>
        /// <exception cref="InvalidOperationException">the document did not rasterize</exception>
        void Export(string svg, Stream stream, RasterFormat format, RasterOptions? options = null);

        /// <summary>
        /// Rasterizes the diagram to an image file, taking the format from the file extension.
        /// </summary>
        /// <param name="diagram">the diagram to rasterize</param>
        /// <param name="path">the file path the encoded image is written to, ending in <c>.png</c>, <c>.jpg</c> or <c>.jpeg</c></param>
        /// <param name="options">how the diagram is rasterized, or <c>null</c> for the defaults</param>
        /// <exception cref="ArgumentNullException">the diagram is null</exception>
        /// <exception cref="ArgumentException">the path is null or empty, or names no supported format</exception>
        /// <exception cref="InvalidOperationException">the diagram did not rasterize</exception>
        void ExportToFile(Diagram diagram, string path, RasterOptions? options = null);

        /// <summary>
        /// Rasterizes an SVG document to an image file, taking the format from the file extension.
        /// </summary>
        /// <param name="svg">the SVG document text</param>
        /// <param name="path">the file path the encoded image is written to, ending in <c>.png</c>, <c>.jpg</c> or <c>.jpeg</c></param>
        /// <param name="options">how the document is rasterized, or <c>null</c> for the defaults</param>
        /// <exception cref="ArgumentException">the SVG text is null or empty, or the path is null or empty or names no supported format</exception>
        /// <exception cref="InvalidOperationException">the document did not rasterize</exception>
        void ExportToFile(string svg, string path, RasterOptions? options = null);
    }
}
