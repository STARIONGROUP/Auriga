// ------------------------------------------------------------------------------------------------
// <copyright file="NoteRenderingTestFixture.cs" company="Starion Group S.A.">
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

    using Auriga.Xmi;

    using NUnit.Framework;

    /// <summary>
    /// The note-rendering acceptance tests (issue #99): a GMF note's text is usually its shape's
    /// <c>description</c>, but an <c>[LCBD]</c>'s annotation notes persist it on the shape's
    /// <c>ShapeStyle</c> instead — so the builder falls back to that, recovering the three
    /// "ARCHITECTURE DRIVER" notes that were dropped entirely. Verified on the In-Flight
    /// <c>[LCBD] Architecture Drivers</c>.
    /// </summary>
    [TestFixture]
    public class NoteRenderingTestFixture
    {
        private const string ArchitectureDriversLcbdUid = "_3blN8KK2Ed6k26nfEmjK4A";

        private static readonly System.Xml.Linq.XNamespace Svg = "http://www.w3.org/2000/svg";

        private Diagram diagram = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagram = new DiagramBuilder().BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == ArchitectureDriversLcbdUid);
        }

        [Test]
        public void Verify_that_style_described_annotation_notes_render()
        {
            var notes = this.diagram.QueryAllBoxes()
                .Where(box => box.SemanticElement == null && box.Style.Resolved.Shape == ShapeKind.Note)
                .ToList();

            var texts = System.Xml.Linq.XDocument.Parse(new SvgExporter().Export(this.diagram)).Descendants(Svg + "text").Select(text => text.Value).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(notes, Has.Count.EqualTo(3), "the three architecture-driver notes are recovered");
                Assert.That(notes, Has.All.Matches<Box>(note => note.Label != null && note.Label.Text.Contains("ARCHITECTURE DRIVER")), "each note carries its style-described text");
                Assert.That(texts, Has.Some.Matches<string>(text => text.Contains("ARCHITECTURE DRIVER")), "the note text renders into the SVG");
            });
        }
    }
}
