// ------------------------------------------------------------------------------------------------
// <copyright file="SkiaRasterExporter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Drawing
{
    using System;
    using System.Globalization;
    using System.IO;

    using Auriga.Reporting.Model;

    using Microsoft.Extensions.Logging;

    using SkiaSharp;

    using Svg.Skia;

    /// <summary>
    /// The default <see cref="IRasterExporter"/>: parses the exported SVG with Svg.Skia and draws it
    /// onto a SkiaSharp bitmap. A diagram is serialized by the injected <see cref="ISvgExporter"/>
    /// first, so a raster carries exactly what the vector export carries — the same palette, the
    /// same resolved styles and the same artwork, which the SVG embeds as <c>data:</c> URIs, leaving
    /// nothing for the rasterizer to resolve from disk.
    /// </summary>
    /// <remarks>
    /// Stateless, and safe to share. Skia's native library is loaded by the SkiaSharp package's
    /// native assets, which cover Windows, macOS and — through the explicit
    /// <c>SkiaSharp.NativeAssets.Linux</c> reference — Linux. Text is drawn with the host's fonts,
    /// so a font a diagram names but the host does not have is substituted by Skia rather than
    /// dropped.
    /// </remarks>
    public sealed class SkiaRasterExporter : IRasterExporter
    {
        /// <summary>
        /// The serializer producing the SVG document a diagram is rasterized from.
        /// </summary>
        private readonly ISvgExporter svgExporter;

        /// <summary>
        /// The logger reporting what each export produced.
        /// </summary>
        private readonly ILogger<SkiaRasterExporter> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkiaRasterExporter"/> class with the
        /// supplied SVG exporter.
        /// </summary>
        /// <param name="svgExporter">the serializer producing the SVG document a diagram is rasterized from</param>
        /// <param name="loggerFactory">the factory the exporter creates its logger from</param>
        /// <exception cref="ArgumentNullException">the SVG exporter or the logger factory is null</exception>
        public SkiaRasterExporter(ISvgExporter svgExporter, ILoggerFactory loggerFactory)
        {
            this.svgExporter = svgExporter ?? throw new ArgumentNullException(nameof(svgExporter));

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            this.logger = loggerFactory.CreateLogger<SkiaRasterExporter>();
        }

        /// <summary>
        /// Rasterizes the diagram and returns the encoded image.
        /// </summary>
        /// <param name="diagram">the diagram to rasterize</param>
        /// <param name="format">the image format to encode</param>
        /// <param name="options">how the diagram is rasterized, or <c>null</c> for the defaults</param>
        /// <returns>the encoded image bytes</returns>
        /// <exception cref="ArgumentNullException">the diagram is null</exception>
        /// <exception cref="InvalidOperationException">the diagram did not rasterize</exception>
        public byte[] Export(Diagram diagram, RasterFormat format, RasterOptions? options = null)
        {
            return this.Export(this.ToSvg(diagram), format, options);
        }

        /// <summary>
        /// Rasterizes the diagram and writes the encoded image to the supplied stream.
        /// </summary>
        /// <param name="diagram">the diagram to rasterize</param>
        /// <param name="stream">the stream the encoded image is written to</param>
        /// <param name="format">the image format to encode</param>
        /// <param name="options">how the diagram is rasterized, or <c>null</c> for the defaults</param>
        /// <exception cref="ArgumentNullException">the diagram or the stream is null</exception>
        /// <exception cref="InvalidOperationException">the diagram did not rasterize</exception>
        public void Export(Diagram diagram, Stream stream, RasterFormat format, RasterOptions? options = null)
        {
            this.Export(this.ToSvg(diagram), stream, format, options);
        }

        /// <summary>
        /// Rasterizes an SVG document and returns the encoded image.
        /// </summary>
        /// <param name="svg">the SVG document text</param>
        /// <param name="format">the image format to encode</param>
        /// <param name="options">how the document is rasterized, or <c>null</c> for the defaults</param>
        /// <returns>the encoded image bytes</returns>
        /// <exception cref="ArgumentException">the SVG text is null or empty</exception>
        /// <exception cref="InvalidOperationException">the document did not rasterize</exception>
        public byte[] Export(string svg, RasterFormat format, RasterOptions? options = null)
        {
            using var data = this.Encode(svg, format, options ?? new RasterOptions());

            return data.ToArray();
        }

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
        public void Export(string svg, Stream stream, RasterFormat format, RasterOptions? options = null)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            using var data = this.Encode(svg, format, options ?? new RasterOptions());

            data.SaveTo(stream);
        }

        /// <summary>
        /// Rasterizes the diagram to an image file, taking the format from the file extension.
        /// </summary>
        /// <param name="diagram">the diagram to rasterize</param>
        /// <param name="path">the file path the encoded image is written to, ending in <c>.png</c>, <c>.jpg</c> or <c>.jpeg</c></param>
        /// <param name="options">how the diagram is rasterized, or <c>null</c> for the defaults</param>
        /// <exception cref="ArgumentNullException">the diagram is null</exception>
        /// <exception cref="ArgumentException">the path is null or empty, or names no supported format</exception>
        /// <exception cref="InvalidOperationException">the diagram did not rasterize</exception>
        public void ExportToFile(Diagram diagram, string path, RasterOptions? options = null)
        {
            this.ExportToFile(this.ToSvg(diagram), path, options);
        }

        /// <summary>
        /// Rasterizes an SVG document to an image file, taking the format from the file extension.
        /// </summary>
        /// <param name="svg">the SVG document text</param>
        /// <param name="path">the file path the encoded image is written to, ending in <c>.png</c>, <c>.jpg</c> or <c>.jpeg</c></param>
        /// <param name="options">how the document is rasterized, or <c>null</c> for the defaults</param>
        /// <exception cref="ArgumentException">the SVG text is null or empty, or the path is null or empty or names no supported format</exception>
        /// <exception cref="InvalidOperationException">the document did not rasterize</exception>
        public void ExportToFile(string svg, string path, RasterOptions? options = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The path must be provided.", nameof(path));
            }

            var format = FormatOf(path);

            using var stream = File.Create(path);

            this.Export(svg, stream, format, options);
        }

        /// <summary>
        /// The image format the file extension names.
        /// </summary>
        /// <param name="path">the file path</param>
        /// <returns>the format</returns>
        /// <exception cref="ArgumentException">the extension names no supported format</exception>
        private static RasterFormat FormatOf(string path)
        {
            var extension = Path.GetExtension(path);

            if (string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase))
            {
                return RasterFormat.Png;
            }

            if (string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase)
                || string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase))
            {
                return RasterFormat.Jpeg;
            }

            throw new ArgumentException(
                string.Format(CultureInfo.InvariantCulture, "The extension '{0}' names no supported image format; expected .png, .jpg or .jpeg.", extension),
                nameof(path));
        }

        /// <summary>
        /// The color the diagram is composited onto: what the options ask for, or the format's own
        /// default — transparency for PNG, white for JPEG, which carries no alpha channel.
        /// </summary>
        /// <param name="format">the image format being encoded</param>
        /// <param name="options">the export options</param>
        /// <returns>the background color</returns>
        private static SKColor Background(RasterFormat format, RasterOptions options)
        {
            if (options.Background is { } color)
            {
                return new SKColor(color.Red, color.Green, color.Blue);
            }

            return format == RasterFormat.Jpeg ? SKColors.White : SKColors.Transparent;
        }

        /// <summary>
        /// The Skia encoder for the requested format.
        /// </summary>
        /// <param name="format">the requested format</param>
        /// <returns>the Skia format</returns>
        private static SKEncodedImageFormat Encoder(RasterFormat format)
        {
            return format == RasterFormat.Jpeg ? SKEncodedImageFormat.Jpeg : SKEncodedImageFormat.Png;
        }

        /// <summary>
        /// Serializes the diagram to the SVG document the raster is drawn from.
        /// </summary>
        /// <param name="diagram">the diagram to serialize</param>
        /// <returns>the SVG document text</returns>
        /// <exception cref="ArgumentNullException">the diagram is null</exception>
        private string ToSvg(Diagram diagram)
        {
            if (diagram == null)
            {
                throw new ArgumentNullException(nameof(diagram));
            }

            return this.svgExporter.Export(diagram);
        }

        /// <summary>
        /// Draws the SVG document onto a bitmap of the document's own size, scaled as the options
        /// ask, and encodes it.
        /// </summary>
        /// <param name="svg">the SVG document text</param>
        /// <param name="format">the image format to encode</param>
        /// <param name="options">how the document is rasterized</param>
        /// <returns>the encoded image data, owned by the caller</returns>
        /// <exception cref="ArgumentException">the SVG text is null or empty</exception>
        /// <exception cref="InvalidOperationException">the document did not parse, or the image did not encode</exception>
        private SKData Encode(string svg, RasterFormat format, RasterOptions options)
        {
            if (string.IsNullOrEmpty(svg))
            {
                throw new ArgumentException("The SVG document must be provided.", nameof(svg));
            }

            using var document = new SKSvg();

            SKPicture? picture;

            try
            {
                picture = document.FromSvg(svg);
            }
            catch (Exception exception) when (exception is not OutOfMemoryException)
            {
                // The parser reports a malformed document by throwing whatever its reader threw,
                // which tells a caller nothing about what it was asked to do.
                throw new InvalidOperationException("The SVG document did not parse into a drawable picture.", exception);
            }

            if (picture == null)
            {
                throw new InvalidOperationException("The SVG document did not parse into a drawable picture.");
            }

            // The cull rect is the document's viewport, rounded to whole pixels and normalized to
            // the origin — Svg.Skia has already applied the viewBox transform. The translation
            // keeps the drawing correct for a document whose picture is not at the origin.
            var bounds = picture.CullRect;
            var scale = (float)options.Scale;
            var width = Pixels(bounds.Width, scale);
            var height = Pixels(bounds.Height, scale);

            using var bitmap = new SKBitmap(width, height, format == RasterFormat.Jpeg);

            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(Background(format, options));
                canvas.Scale(scale);
                canvas.Translate(-bounds.Left, -bounds.Top);
                canvas.DrawPicture(picture);
            }

            using var image = SKImage.FromBitmap(bitmap);

            var data = image.Encode(Encoder(format), options.Quality)
                       ?? throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The {0} encoder produced no image.", format));

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(
                    "Rasterized a {Width}x{Height} SVG document to a {PixelWidth}x{PixelHeight} {Format} of {Bytes} bytes ({Options})",
                    bounds.Width,
                    bounds.Height,
                    width,
                    height,
                    format,
                    data.Size,
                    options);
            }

            return data;
        }

        /// <summary>
        /// The pixel extent a scaled document dimension occupies: rounded up, so a fractional
        /// coordinate is not cropped, and never smaller than a single pixel, which Skia refuses to
        /// allocate.
        /// </summary>
        /// <param name="extent">the document dimension</param>
        /// <param name="scale">the scale being applied</param>
        /// <returns>the pixel extent</returns>
        private static int Pixels(float extent, float scale)
        {
            return Math.Max(1, (int)Math.Ceiling(extent * scale));
        }
    }
}
