// ------------------------------------------------------------------------------------------------
// <copyright file="OrthogonalExchangeTestFixture.cs" company="Starion Group S.A.">
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
    /// The orthogonal-routing acceptance tests (issue #95, part 2): an exchange edge carrying
    /// <c>routingStyle="manhattan"</c> with no real bendpoints is rectilinear — Capella routes it
    /// between the facing side centres, not the anchor-reference line that clips to a diagonal
    /// corner. Verified on the In-Flight <c>[LFCD] Start Playing VOD Movie</c>, whose functional
    /// chain stacks its functions in one column so every link is a clean vertical instead of the
    /// centre-line skew the generic route produced.
    /// </summary>
    [TestFixture]
    public class OrthogonalExchangeTestFixture
    {
        private const string StartPlayingVodMovieLfcdUid = "_IjNiALFqEeSsWZm7HcO6OQ";

        private Diagram diagram = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagram = new DiagramBuilder().BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == StartPlayingVodMovieLfcdUid);
        }

        [Test]
        public void Verify_that_bendpointless_manhattan_edges_route_orthogonally()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.diagram.Edges, Is.Not.Empty, "the functional chain renders its links");

                // Every segment of every link is axis-aligned — no diagonals.
                foreach (var edge in this.diagram.Edges)
                {
                    for (var i = 1; i < edge.Route.Count; i++)
                    {
                        var horizontal = Math.Abs(edge.Route[i].Y - edge.Route[i - 1].Y) < 0.001;
                        var vertical = Math.Abs(edge.Route[i].X - edge.Route[i - 1].X) < 0.001;
                        Assert.That(horizontal || vertical, Is.True, $"a segment is neither horizontal nor vertical: {edge.Route[i - 1]} -> {edge.Route[i]}");
                    }
                }

                // The functions stack in one column, so the links whose anchors align collapse to a
                // single straight vertical segment (no redundant turn); a link with an off-centre
                // anchor steps rectilinearly instead — never the corner-to-corner diagonal skew.
                var straightVerticals = this.diagram.Edges.Count(edge => edge.Route.Count == 2 && Math.Abs(edge.Route[0].X - edge.Route[^1].X) < 0.001);
                Assert.That(straightVerticals, Is.GreaterThanOrEqualTo(this.diagram.Edges.Count / 2), "the aligned links are clean straight verticals");
            });
        }
    }
}
