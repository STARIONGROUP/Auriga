// ------------------------------------------------------------------------------------------------
// <copyright file="RasterExportTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Auriga.Xmi;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using SkiaSharp;

    /// <summary>
    /// Tests the <see cref="SkiaRasterExporter"/>: that a real diagram encodes to PNG and JPEG at
    /// the size its SVG asks for, that what comes out is a drawn picture rather than an empty
    /// canvas, that the scale, background and quality options take effect, and that the file
    /// overloads take their format from the extension. The drawn-picture assertions are also what
    /// proves the SkiaSharp native asset resolved on whichever platform the suite is running.
    /// </summary>
    [TestFixture]
    public class RasterExportTestFixture : RenderingTestFixtureBase
    {
        /// <summary>
        /// An SVG whose geometry is known exactly, for the assertions about size and color: a
        /// 200x100 view box whose top-left is not the origin, so a rasterizer that forgets to
        /// translate the picture back drops the content off the canvas.
        /// </summary>
        private const string Svg =
            "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"-20 -10 200 100\" width=\"200\" height=\"100\">" +
            "<rect x=\"-20\" y=\"-10\" width=\"200\" height=\"100\" fill=\"#FF0000\"/>" +
            "</svg>";

        /// <summary>
        /// The diagram every end-to-end assertion rasterizes: the first representation of the real
        /// coffee-machine project.
        /// </summary>
        private Diagram diagram = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "coffee-machine-demo.aird");

            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagram = this.DiagramBuilder.BuildAll(result.Elements.Values).First();
        }

        [Test]
        public void Verify_that_the_exporter_guards_its_arguments()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => new SkiaRasterExporter(null!, NullLoggerFactory.Instance), Throws.ArgumentNullException);
                Assert.That(() => new SkiaRasterExporter(this.SvgExporter, null!), Throws.ArgumentNullException);

                Assert.That(() => this.RasterExporter.Export((Diagram)null!, RasterFormat.Png), Throws.ArgumentNullException);
                Assert.That(() => this.RasterExporter.Export((Diagram)null!, new MemoryStream(), RasterFormat.Png), Throws.ArgumentNullException);
                Assert.That(() => this.RasterExporter.ExportToFile((Diagram)null!, "diagram.png"), Throws.ArgumentNullException);
                Assert.That(() => this.RasterExporter.Export(this.diagram, (Stream)null!, RasterFormat.Png), Throws.ArgumentNullException);

                Assert.That(() => this.RasterExporter.Export(string.Empty, RasterFormat.Png), Throws.ArgumentException);
                Assert.That(() => this.RasterExporter.Export((string)null!, new MemoryStream(), RasterFormat.Png), Throws.ArgumentException);
                Assert.That(() => this.RasterExporter.ExportToFile(Svg, string.Empty), Throws.ArgumentException);
            });
        }

        [Test]
        public void Verify_that_a_diagram_encodes_to_a_png_of_the_size_its_svg_asks_for()
        {
            var png = this.RasterExporter.Export(this.diagram, RasterFormat.Png);
            var expected = ViewBoxOf(this.SvgExporter.Export(this.diagram));

            using var bitmap = SKBitmap.Decode(png);

            Assert.Multiple(() =>
            {
                Assert.That(png.Take(4), Is.EqualTo(new byte[] { 0x89, 0x50, 0x4E, 0x47 }), "the PNG signature");

                // The view box of a diagram is fractional wherever a label widened it; the raster
                // is the viewport rounded to whole pixels.
                Assert.That(bitmap.Width, Is.EqualTo((int)Math.Round(expected.Width, MidpointRounding.AwayFromZero)));
                Assert.That(bitmap.Height, Is.EqualTo((int)Math.Round(expected.Height, MidpointRounding.AwayFromZero)));
            });
        }

        [Test]
        public void Verify_that_a_diagram_encodes_to_a_jpeg()
        {
            var jpeg = this.RasterExporter.Export(this.diagram, RasterFormat.Jpeg);

            using var bitmap = SKBitmap.Decode(jpeg);

            Assert.Multiple(() =>
            {
                Assert.That(jpeg.Take(3), Is.EqualTo(new byte[] { 0xFF, 0xD8, 0xFF }), "the JPEG signature");
                Assert.That(bitmap.Width, Is.GreaterThan(0));
                Assert.That(
                    Pixels(bitmap).All(pixel => pixel.Alpha == 0xFF),
                    Is.True,
                    "JPEG carries no alpha, so the diagram is composited onto an opaque background");
            });
        }

        [Test]
        public void Verify_that_the_raster_carries_a_drawn_diagram_rather_than_an_empty_canvas()
        {
            var png = this.RasterExporter.Export(this.diagram, RasterFormat.Png, new RasterOptions { Background = new Color(255, 255, 255) });

            using var bitmap = SKBitmap.Decode(png);
            var distinct = Pixels(bitmap).Distinct().Count();

            Assert.Multiple(() =>
            {
                Assert.That(distinct, Is.GreaterThan(10), "a drawn diagram has many colors; an empty canvas has one");
                Assert.That(
                    Pixels(bitmap).Any(pixel => pixel != SKColors.White),
                    Is.True,
                    "something was drawn over the background");
            });
        }

        [Test]
        public void Verify_that_the_scale_multiplies_both_dimensions()
        {
            using var single = SKBitmap.Decode(this.RasterExporter.Export(Svg, RasterFormat.Png));
            using var doubled = SKBitmap.Decode(this.RasterExporter.Export(Svg, RasterFormat.Png, new RasterOptions { Scale = 2 }));
            using var byDpi = SKBitmap.Decode(this.RasterExporter.Export(Svg, RasterFormat.Png, RasterOptions.FromDpi(192)));

            Assert.Multiple(() =>
            {
                Assert.That(single.Width, Is.EqualTo(200));
                Assert.That(single.Height, Is.EqualTo(100));
                Assert.That(doubled.Width, Is.EqualTo(400));
                Assert.That(doubled.Height, Is.EqualTo(200));
                Assert.That(byDpi.Width, Is.EqualTo(doubled.Width), "192 dpi is twice the nominal 96");
                Assert.That(byDpi.Height, Is.EqualTo(doubled.Height));
            });
        }

        [Test]
        public void Verify_that_the_view_box_origin_is_translated_onto_the_canvas()
        {
            using var bitmap = SKBitmap.Decode(this.RasterExporter.Export(Svg, RasterFormat.Png));

            Assert.Multiple(() =>
            {
                Assert.That(bitmap.GetPixel(0, 0), Is.EqualTo(new SKColor(0xFF, 0x00, 0x00)), "the rect starts at the view box origin, not at the SVG origin");
                Assert.That(bitmap.GetPixel(199, 99), Is.EqualTo(new SKColor(0xFF, 0x00, 0x00)), "and fills it to the far corner");
            });
        }

        [Test]
        public void Verify_that_the_background_defaults_per_format_and_is_overridable()
        {
            var empty = "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 10 10\" width=\"10\" height=\"10\"></svg>";

            using var transparent = SKBitmap.Decode(this.RasterExporter.Export(empty, RasterFormat.Png));
            using var white = SKBitmap.Decode(this.RasterExporter.Export(empty, RasterFormat.Jpeg));
            using var chosen = SKBitmap.Decode(this.RasterExporter.Export(empty, RasterFormat.Png, new RasterOptions { Background = new Color(0, 128, 255) }));

            Assert.Multiple(() =>
            {
                Assert.That(transparent.GetPixel(5, 5).Alpha, Is.EqualTo(0), "PNG defaults to transparency");
                Assert.That(white.GetPixel(5, 5), Is.EqualTo(SKColors.White), "JPEG has no alpha, so it defaults to white");
                Assert.That(chosen.GetPixel(5, 5), Is.EqualTo(new SKColor(0, 128, 255)), "the requested background wins");
            });
        }

        [Test]
        public void Verify_that_the_stream_overload_writes_the_same_bytes()
        {
            using var stream = new MemoryStream();
            this.RasterExporter.Export(this.diagram, stream, RasterFormat.Png);

            Assert.That(stream.ToArray(), Is.EqualTo(this.RasterExporter.Export(this.diagram, RasterFormat.Png)));
        }

        [Test]
        public void Verify_that_the_file_overload_takes_its_format_from_the_extension()
        {
            var png = Path.Combine(TestContext.CurrentContext.WorkDirectory, "raster-export.png");
            var jpg = Path.Combine(TestContext.CurrentContext.WorkDirectory, "raster-export.JPG");

            this.RasterExporter.ExportToFile(this.diagram, png);
            this.RasterExporter.ExportToFile(Svg, jpg);

            Assert.Multiple(() =>
            {
                Assert.That(File.ReadAllBytes(png).Take(4), Is.EqualTo(new byte[] { 0x89, 0x50, 0x4E, 0x47 }));
                Assert.That(File.ReadAllBytes(jpg).Take(3), Is.EqualTo(new byte[] { 0xFF, 0xD8, 0xFF }), "the extension is matched case-insensitively");
                Assert.That(() => this.RasterExporter.ExportToFile(Svg, "diagram.bmp"), Throws.ArgumentException);
                Assert.That(() => this.RasterExporter.ExportToFile(Svg, "diagram"), Throws.ArgumentException);
            });
        }

        [Test]
        public void Verify_that_a_document_that_is_not_svg_is_reported_rather_than_encoded_empty()
        {
            Assert.That(
                () => this.RasterExporter.Export("<not-svg/>", RasterFormat.Png),
                Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void Verify_that_the_options_reject_values_that_cannot_rasterize()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => new RasterOptions { Scale = 0 }, Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => new RasterOptions { Scale = -1 }, Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => new RasterOptions { Scale = double.NaN }, Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => new RasterOptions { Quality = 0 }, Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => new RasterOptions { Quality = 101 }, Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => RasterOptions.FromDpi(0), Throws.InstanceOf<ArgumentOutOfRangeException>());

                Assert.That(new RasterOptions().Scale, Is.EqualTo(1));
                Assert.That(new RasterOptions().Quality, Is.EqualTo(90));
                Assert.That(new RasterOptions().Background, Is.Null);
                Assert.That(new RasterOptions { Background = new Color(1, 2, 3) }.ToString(), Does.Contain("#010203"));
            });
        }

        [Test]
        public void Verify_that_a_lower_quality_encodes_a_smaller_jpeg()
        {
            var high = this.RasterExporter.Export(this.diagram, RasterFormat.Jpeg, new RasterOptions { Quality = 95 });
            var low = this.RasterExporter.Export(this.diagram, RasterFormat.Jpeg, new RasterOptions { Quality = 10 });

            Assert.That(low.Length, Is.LessThan(high.Length));
        }

        /// <summary>
        /// The width and height the SVG document's view box declares.
        /// </summary>
        /// <param name="svg">the SVG document text</param>
        /// <returns>the view box size</returns>
        private static (double Width, double Height) ViewBoxOf(string svg)
        {
            var viewBox = ((string?)XDocument.Parse(svg).Root!.Attribute("viewBox"))!
                .Split(' ')
                .Select(value => double.Parse(value, System.Globalization.CultureInfo.InvariantCulture))
                .ToArray();

            return (viewBox[2], viewBox[3]);
        }

        /// <summary>
        /// Every pixel of the bitmap, for the assertions about what was drawn.
        /// </summary>
        /// <param name="bitmap">the decoded bitmap</param>
        /// <returns>the pixels</returns>
        private static System.Collections.Generic.IEnumerable<SKColor> Pixels(SKBitmap bitmap)
        {
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    yield return bitmap.GetPixel(x, y);
                }
            }
        }
    }
}
