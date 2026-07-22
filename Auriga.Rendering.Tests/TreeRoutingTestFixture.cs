// ------------------------------------------------------------------------------------------------
// <copyright file="TreeRoutingTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using Auriga.Xmi;

    using NUnit.Framework;

    /// <summary>
    /// The tree-routing acceptance tests (issue #95, part 1): a breakdown diagram's containment
    /// edges carry <c>routingStyle="tree"</c>, and Capella draws them rectilinearly — a vertical
    /// stub from each child onto a horizontal bus shared by its siblings, then a single stub into
    /// the parent. Their persisted bendpoints are stale artifacts that resolve far outside the
    /// canvas; the builder discards them and rebuilds the bus. Verified on the In-Flight
    /// <c>[LFBD] All Functions</c>, whose generic route inflated the canvas to ~8749px wide.
    /// </summary>
    [TestFixture]
    public class TreeRoutingTestFixture
    {
        private const string AllFunctionsLfbdUid = "_XUQUUJqIEeS8H_8qEOr5gg";

        private readonly SvgExporter svgExporter = new();

        private Diagram diagram = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagram = new DiagramBuilder().BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == AllFunctionsLfbdUid);
        }

        [Test]
        public void Verify_that_tree_connectors_are_rectilinear_and_the_canvas_is_bounded()
        {
            var viewBox = ((string)System.Xml.Linq.XDocument.Parse(this.svgExporter.Export(this.diagram)).Root!.Attribute("viewBox")!)
                .Split(' ')
                .Select(part => double.Parse(part, CultureInfo.InvariantCulture))
                .ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(this.diagram.Edges, Is.Not.Empty, "the breakdown renders its containment connectors");

                // Every segment of every connector is axis-aligned — no diagonals.
                foreach (var edge in this.diagram.Edges)
                {
                    for (var i = 1; i < edge.Route.Count; i++)
                    {
                        var horizontal = System.Math.Abs(edge.Route[i].Y - edge.Route[i - 1].Y) < 0.001;
                        var vertical = System.Math.Abs(edge.Route[i].X - edge.Route[i - 1].X) < 0.001;
                        Assert.That(horizontal || vertical, Is.True, $"segment {i} of an edge is neither horizontal nor vertical: {edge.Route[i - 1]} -> {edge.Route[i]}");
                    }
                }

                // The stale bendpoints inflated the canvas to viewBox [-2204 -202 8749 1252]; the
                // rebuilt bus keeps it to the real content extent.
                Assert.That(viewBox[0], Is.GreaterThan(-200), "the canvas no longer starts far to the left");
                Assert.That(viewBox[1], Is.GreaterThan(-200), "the canvas no longer starts far above");
                Assert.That(viewBox[2], Is.LessThan(6000), "the canvas width is bounded");
                Assert.That(viewBox[3], Is.LessThan(3000), "the canvas height is bounded");
            });
        }

        [Test]
        public void Verify_that_siblings_share_a_bus_into_their_parent()
        {
            // The children of one parent form the largest group of connectors sharing a target.
            var siblings = this.diagram.Edges
                .Where(edge => edge.Target != null && edge.Route.Count == 4)
                .GroupBy(edge => edge.Target)
                .OrderByDescending(group => group.Count())
                .First()
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.That(siblings, Has.Count.GreaterThan(1), "a parent with several children");

                // Every sibling drops onto the same horizontal bus (route[1..2].Y) and rises into
                // the parent along the same vertical stub (route[2..3].X) — the org-chart shape.
                var busY = siblings[0].Route[1].Y;
                var parentStubX = siblings[0].Route[3].X;

                Assert.That(siblings, Has.All.Matches<Edge>(edge =>
                    System.Math.Abs(edge.Route[1].Y - busY) < 0.001
                    && System.Math.Abs(edge.Route[2].Y - busY) < 0.001), "every sibling shares the bus height");
                Assert.That(siblings, Has.All.Matches<Edge>(edge =>
                    System.Math.Abs(edge.Route[2].X - parentStubX) < 0.001
                    && System.Math.Abs(edge.Route[3].X - parentStubX) < 0.001), "every sibling rises into the parent along the shared stub");
            });
        }
    }
}
