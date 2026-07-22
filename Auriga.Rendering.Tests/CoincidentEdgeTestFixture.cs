// ------------------------------------------------------------------------------------------------
// <copyright file="CoincidentEdgeTestFixture.cs" company="Starion Group S.A.">
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

    using Auriga.Xmi;

    using NUnit.Framework;

    /// <summary>
    /// The coincident-edge acceptance tests (issue #96): two exchanges between the same pair of
    /// boxes with no distinguishing bendpoints resolve to the same polyline, stacking their labels.
    /// The builder fans a coincident group into distinct parallel routes, offset perpendicular to
    /// the run, so each exchange and its label is legible. Verified on the In-Flight
    /// <c>[OAIB] Listen to Audio</c>, whose three <c>Music Selection</c> / <c>Ambiance Music</c> /
    /// <c>Chosen Music</c> exchanges ride one chord.
    /// </summary>
    [TestFixture]
    public class CoincidentEdgeTestFixture
    {
        private const string ListenToAudioOaibUid = "_8XjTwLLlEeSVmfu1BIQISw";

        private Diagram diagram = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagram = new DiagramBuilder().BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == ListenToAudioOaibUid);
        }

        [Test]
        public void Verify_that_coincident_exchanges_occupy_distinct_routes_with_separated_labels()
        {
            var chord = new[] { "Music Selection", "Ambiance Music", "Chosen Music" }
                .Select(name => this.diagram.Edges.Single(edge => edge.Label?.Text == name))
                .ToList();

            Assert.Multiple(() =>
            {
                // Each of the three exchanges now traces its own route, no two coincident.
                foreach (var pair in Pairs(chord))
                {
                    Assert.That(SameRoute(pair.First.Route, pair.Second.Route), Is.False, $"'{pair.First.Label!.Text}' and '{pair.Second.Label!.Text}' still coincide");
                }

                // Their labels ride the route midpoints, so the separated routes carry the labels
                // apart — no two land on the same point.
                foreach (var pair in Pairs(chord))
                {
                    var gap = Distance(Midpoint(pair.First), Midpoint(pair.Second));
                    Assert.That(gap, Is.GreaterThan(5), $"the labels of '{pair.First.Label!.Text}' and '{pair.Second.Label!.Text}' overlap (gap {gap:0.#})");
                }
            });
        }

        private static Point Midpoint(Edge edge)
        {
            return new Point(edge.Route.Average(point => point.X), edge.Route.Average(point => point.Y));
        }

        private static double Distance(Point a, Point b)
        {
            return Math.Sqrt(((a.X - b.X) * (a.X - b.X)) + ((a.Y - b.Y) * (a.Y - b.Y)));
        }

        private static bool SameRoute(System.Collections.Generic.IReadOnlyList<Point> a, System.Collections.Generic.IReadOnlyList<Point> b)
        {
            return a.Count == b.Count && a.Zip(b, (x, y) => Distance(x, y) < 0.001).All(equal => equal);
        }

        private static System.Collections.Generic.IEnumerable<(Edge First, Edge Second)> Pairs(System.Collections.Generic.IReadOnlyList<Edge> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                for (var j = i + 1; j < items.Count; j++)
                {
                    yield return (items[i], items[j]);
                }
            }
        }
    }
}
