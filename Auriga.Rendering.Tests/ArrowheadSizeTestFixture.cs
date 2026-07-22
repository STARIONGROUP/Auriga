// ------------------------------------------------------------------------------------------------
// <copyright file="ArrowheadSizeTestFixture.cs" company="Starion Group S.A.">
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
    /// The arrowhead-size acceptance test (issue #114): SVG markers default to
    /// <c>markerUnits="strokeWidth"</c>, so a thick edge (a component exchange's width-4 stroke)
    /// would render an arrowhead scaled four times over. The exporter pins the marker to
    /// <c>userSpaceOnUse</c> so the arrowhead stays a fixed size. Verified on the In-Flight
    /// <c>[LAB][CTX] Watch Imposed Video on Cabin Screen FC</c>, whose exchanges carry a width-4
    /// stroke.
    /// </summary>
    [TestFixture]
    public class ArrowheadSizeTestFixture
    {
        private const string WatchImposedVideoLabUid = "_nzxH0LL_EeSGuvnnapXBhA";

        private static readonly System.Xml.Linq.XNamespace Svg = "http://www.w3.org/2000/svg";

        [Test]
        public void Verify_that_arrowheads_do_not_scale_with_the_stroke_width()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);
            var diagram = new DiagramBuilder().BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == WatchImposedVideoLabUid);

            var document = System.Xml.Linq.XDocument.Parse(new SvgExporter().Export(diagram));
            var markers = document.Descendants(Svg + "marker").ToList();

            Assert.Multiple(() =>
            {
                // The exchanges carry a thick (width-4) stroke and a filled arrowhead.
                Assert.That(diagram.Edges, Has.Some.Matches<Edge>(edge => edge.Style.Resolved.StrokeWidth >= 4 && edge.Style.Resolved.TargetArrow != null), "the diagram has thick arrowed edges");
                Assert.That(markers, Is.Not.Empty, "the arrowheads render as markers");
                Assert.That(markers, Has.All.Matches<System.Xml.Linq.XElement>(marker => (string?)marker.Attribute("markerUnits") == "userSpaceOnUse"), "every arrowhead is a fixed size, not scaled by the stroke width");
            });
        }
    }
}
