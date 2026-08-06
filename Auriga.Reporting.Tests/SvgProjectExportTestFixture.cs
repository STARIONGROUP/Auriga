// ------------------------------------------------------------------------------------------------
// <copyright file="SvgProjectExportTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Tests
{
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Auriga.Reporting.Drawing;
    using Auriga.Reporting.Generators;
    using Auriga.Reporting.Model;

    using NUnit.Framework;

    /// <summary>
    /// Exports every diagram of every readable fixture model to SVG and to PNG beside it, through
    /// the one call a consumer makes — <see cref="IDiagramReportGenerator.Generate"/> — so this
    /// fixture is both the visual acceptance check and the end-to-end test of the generator over
    /// four real models. The output lands under <c>diagram-exports/&lt;model&gt;/</c> in the test
    /// work directory, one folder per model and one pair of files per diagram named after the
    /// diagram's Capella name, so the rendered diagrams can be compared side-by-side with the same
    /// diagrams opened in Capella. The PNG is what makes that check quick: it opens in any viewer
    /// and in a preview pane, where the SVG needs a browser. The Level Crossing model is absent:
    /// its <c>.aird</c> carries an illegal raw U+001A character (a fixture defect) and cannot be
    /// read.
    /// </summary>
    [TestFixture]
    public class SvgProjectExportTestFixture
    {
        /// <summary>
        /// The first bytes of a PNG file, asserted so that a raster which failed to encode is a
        /// test failure rather than an empty file nobody opens.
        /// </summary>
        private static readonly byte[] PngSignature = { 0x89, 0x50, 0x4E, 0x47 };

        /// <summary>
        /// The generator under test, which loads each model and composes the pipeline itself.
        /// </summary>
        private readonly DiagramReportGenerator generator = new();

        [Test]
        [TestCase("coffee-machine-demo.aird", "coffee-machine")]
        [TestCase("Crowd_Surveillance_System_in_DARC.aird", "crowd-surveillance-system-in-darc")]
        [TestCase("In-Flight Entertainment System.aird", "in-flight-entertainment-system")]
        [TestCase("fragmented-sysmodel/sysmodel.aird", "fragmented-sysmodel")]
        public void Verify_that_every_diagram_of_the_model_exports_to_svg_and_png(string airdFile, string modelFolder)
        {
            var aird = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", airdFile));
            var output = new DirectoryInfo(Path.Combine(TestContext.CurrentContext.WorkDirectory, "diagram-exports", modelFolder));

            // A diagram exported on PNG's default transparency reads differently in every viewer —
            // checkerboard here, black there — which is no use for comparing against what Capella
            // shows on white.
            var written = this.generator.Generate(
                aird,
                output,
                new DiagramReportOptions
                {
                    Formats = DiagramFormats.Svg | DiagramFormats.Png,
                    Raster = new RasterOptions { Background = new Color(255, 255, 255) },
                });

            var diagrams = this.generator.Query(aird);

            TestContext.Out.WriteLine($"{modelFolder}: exported {diagrams.Count} diagrams to {output.FullName}");

            Assert.Multiple(() =>
            {
                Assert.That(diagrams, Is.Not.Empty, "the model carries GMF-backed representations");
                Assert.That(written, Has.Count.EqualTo(diagrams.Count * 2), "an SVG and a PNG per representation");

                foreach (var diagram in diagrams)
                {
                    Assert.That(diagram.Name, Is.Not.Null.And.Not.Empty, $"representation {diagram.Identifier} has a descriptor name");
                }

                foreach (var svg in written.Where(file => file.Extension == ".svg"))
                {
                    Assert.That(svg.Exists, Is.True, svg.FullName);
                    Assert.That(XDocument.Load(svg.FullName).Root!.Name.LocalName, Is.EqualTo("svg"), svg.FullName);
                }

                foreach (var png in written.Where(file => file.Extension == ".png"))
                {
                    Assert.That(png.Exists, Is.True, png.FullName);
                    Assert.That(File.ReadAllBytes(png.FullName).Take(PngSignature.Length), Is.EqualTo(PngSignature), png.FullName);
                }
            });
        }
    }
}
