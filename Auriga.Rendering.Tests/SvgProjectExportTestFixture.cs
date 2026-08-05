// ------------------------------------------------------------------------------------------------
// <copyright file="SvgProjectExportTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Auriga.Xmi;

    using NUnit.Framework;

    /// <summary>
    /// Exports every diagram of every readable fixture model to SVG and to PNG beside it, one
    /// folder per model named after the model and one pair of files per diagram named after the
    /// diagram's Capella name (from its <c>DRepresentationDescriptor</c>, resolved by
    /// <see cref="DiagramBuilder.BuildAll"/>). The output lands under
    /// <c>svg-exports/&lt;model&gt;/</c> in the test work directory, so the rendered diagrams can be
    /// compared side-by-side with the same diagrams opened in Capella — the visual acceptance
    /// check. The PNG is what makes that check quick: it opens in any viewer and in a preview pane,
    /// where the SVG needs a browser. Exporting both also runs <see cref="IRasterExporter"/> over
    /// every fixture model rather than over the single model its own fixture uses. The Level
    /// Crossing model is absent: its <c>.aird</c> carries an illegal raw U+001A character (a
    /// fixture defect) and cannot be read.
    /// </summary>
    [TestFixture]
    public class SvgProjectExportTestFixture : RenderingTestFixtureBase
    {
        /// <summary>
        /// The first bytes of a PNG file, asserted so that a raster which failed to encode is a
        /// test failure rather than an empty file nobody opens.
        /// </summary>
        private static readonly byte[] PngSignature = { 0x89, 0x50, 0x4E, 0x47 };

        /// <summary>
        /// The background the rasters are drawn on. A diagram exported on PNG's default
        /// transparency reads differently in every viewer — checkerboard here, black there — which
        /// is no use for comparing against what Capella shows on white.
        /// </summary>
        private static readonly RasterOptions RasterExport = new() { Background = new Color(255, 255, 255) };

        [Test]
        [TestCase("coffee-machine-demo.aird", "coffee-machine")]
        [TestCase("Crowd_Surveillance_System_in_DARC.aird", "crowd-surveillance-system-in-darc")]
        [TestCase("In-Flight Entertainment System.aird", "in-flight-entertainment-system")]
        [TestCase("fragmented-sysmodel/sysmodel.aird", "fragmented-sysmodel")]
        public void Verify_that_every_diagram_of_the_model_exports_to_svg_and_png(string airdFile, string modelFolder)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", airdFile);
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            var diagrams = this.DiagramBuilder.BuildAll(result.Elements.Values);

            // Serve the vendored plugin artwork, then the model's own project-local images (an
            // actor's custom glyph) from the directory the .aird was loaded from — the registry
            // override is why this export composes its own scope rather than using the fixture's.
            using var renderingScope = RenderingBuilder.Create()
                .UsingProjectImages(Path.GetDirectoryName(path)!);
            var svgExporter = renderingScope.BuildSvgExporter();
            var rasterExporter = renderingScope.BuildRasterExporter();

            var outputDirectory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "svg-exports", modelFolder);
            Directory.CreateDirectory(outputDirectory);

            Assert.That(diagrams, Is.Not.Empty, "the model carries GMF-backed representations");
            TestContext.Out.WriteLine($"{modelFolder}: exporting {diagrams.Count} diagrams to {outputDirectory}");

            Assert.Multiple(() =>
            {
                foreach (var diagram in diagrams)
                {
                    Assert.That(diagram.Name, Is.Not.Null.And.Not.Empty, $"representation {diagram.Identifier} has a descriptor name");

                    var name = FileName(diagram);
                    var svg = Path.Combine(outputDirectory, name + ".svg");
                    var png = Path.Combine(outputDirectory, name + ".png");

                    svgExporter.ExportToFile(diagram, svg);
                    rasterExporter.ExportToFile(diagram, png, RasterExport);

                    Assert.That(File.Exists(svg), Is.True, svg);
                    Assert.That(XDocument.Load(svg).Root!.Name.LocalName, Is.EqualTo("svg"), svg);

                    Assert.That(File.Exists(png), Is.True, png);
                    Assert.That(File.ReadAllBytes(png).Take(PngSignature.Length), Is.EqualTo(PngSignature), png);
                }
            });
        }

        /// <summary>
        /// The export file name of a diagram, without an extension — the SVG and the PNG share it,
        /// so a diagram's two exports sort next to each other. It is the diagram's Capella name
        /// with filesystem-hostile characters replaced, suffixed with the uid because names collide
        /// within a model (Capella allows two diagrams with the same name), and the uid alone when
        /// no descriptor named it.
        /// </summary>
        /// <param name="diagram">the diagram</param>
        /// <returns>the file name, without an extension</returns>
        private static string FileName(Diagram diagram)
        {
            var name = string.IsNullOrEmpty(diagram.Name)
                ? diagram.Identifier.TrimStart('_')
                : $"{diagram.Name} ({diagram.Identifier.TrimStart('_')})";

            var invalid = Path.GetInvalidFileNameChars();

            return new string(name.Select(character => invalid.Contains(character) ? '_' : character).ToArray());
        }
    }
}
