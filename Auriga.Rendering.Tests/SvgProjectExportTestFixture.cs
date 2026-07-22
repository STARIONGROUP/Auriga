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
    /// Exports every diagram of every readable fixture model to SVG, one folder per model named
    /// after the model and one file per diagram named after the diagram's Capella name (from its
    /// <c>DRepresentationDescriptor</c>, resolved by <see cref="DiagramBuilder.BuildAll"/>). The
    /// output lands under <c>svg-exports/&lt;model&gt;/</c> in the test work directory, so the
    /// rendered diagrams can be compared side-by-side with the same diagrams opened in Capella —
    /// the visual acceptance check of issue #57. The Level Crossing model is absent: its
    /// <c>.aird</c> carries an illegal raw U+001A character (a fixture defect) and cannot be read.
    /// </summary>
    [TestFixture]
    public class SvgProjectExportTestFixture
    {
        /// <summary>
        /// The builder under test, composed with the default per-kind builders.
        /// </summary>
        private readonly DiagramBuilder diagramBuilder = new();

        [Test]
        [TestCase("coffee-machine-demo.aird", "coffee-machine")]
        [TestCase("Crowd_Surveillance_System_in_DARC.aird", "crowd-surveillance-system-in-darc")]
        [TestCase("In-Flight Entertainment System.aird", "in-flight-entertainment-system")]
        [TestCase("fragmented-sysmodel/sysmodel.aird", "fragmented-sysmodel")]
        public void Verify_that_every_diagram_of_the_model_exports_to_svg(string airdFile, string modelFolder)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", airdFile);
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            var diagrams = this.diagramBuilder.BuildAll(result.Elements.Values);

            // Serve the vendored plugin artwork, then the model's own project-local images (an
            // actor's custom glyph) from the directory the .aird was loaded from.
            var svgExporter = new SvgExporter(new CompositeIconRegistry(new CapellaIconRegistry(), new WorkspaceImageRegistry(Path.GetDirectoryName(path)!)));

            var outputDirectory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "svg-exports", modelFolder);
            Directory.CreateDirectory(outputDirectory);

            Assert.That(diagrams, Is.Not.Empty, "the model carries GMF-backed representations");
            TestContext.Out.WriteLine($"{modelFolder}: exporting {diagrams.Count} diagrams to {outputDirectory}");

            Assert.Multiple(() =>
            {
                foreach (var diagram in diagrams)
                {
                    Assert.That(diagram.Name, Is.Not.Null.And.Not.Empty, $"representation {diagram.Identifier} has a descriptor name");

                    var file = Path.Combine(outputDirectory, FileName(diagram));
                    svgExporter.ExportToFile(diagram, file);

                    Assert.That(File.Exists(file), Is.True, file);
                    Assert.That(XDocument.Load(file).Root!.Name.LocalName, Is.EqualTo("svg"), file);
                }
            });
        }

        /// <summary>
        /// The export file name of a diagram: its Capella name with filesystem-hostile characters
        /// replaced, suffixed with the uid when names collide within a model (Capella allows two
        /// diagrams with the same name), and the uid alone when no descriptor named it.
        /// </summary>
        /// <param name="diagram">the diagram</param>
        /// <returns>the file name</returns>
        private static string FileName(Diagram diagram)
        {
            var name = string.IsNullOrEmpty(diagram.Name)
                ? diagram.Identifier.TrimStart('_')
                : $"{diagram.Name} ({diagram.Identifier.TrimStart('_')})";

            var invalid = Path.GetInvalidFileNameChars();
            var safe = new string(name.Select(character => invalid.Contains(character) ? '_' : character).ToArray());

            return safe + ".svg";
        }
    }
}
