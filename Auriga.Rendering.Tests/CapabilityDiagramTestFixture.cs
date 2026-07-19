// ------------------------------------------------------------------------------------------------
// <copyright file="CapabilityDiagramTestFixture.cs" company="Starion Group S.A.">
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
    /// The visual-acceptance tests for the <c>[CC] Provide Audio and Video Intercommunication
    /// Means</c> Contextual Capability diagram of the In-Flight Entertainment System: its
    /// mission/capability/actor nodes are pure <c>WorkspaceImage</c> figures, and its edges pin
    /// the GMF slidable-anchor endpoint rule — the persisted first/last bendpoint entries are
    /// stale artifacts, and each endpoint is recomputed as the crossing of the anchor-reference
    /// line with the node's bounds, exactly as Capella renders.
    /// </summary>
    [TestFixture]
    public class CapabilityDiagramTestFixture
    {
        /// <summary>
        /// The builder under test, composed with the default per-kind builders.
        /// </summary>
        private readonly DiagramBuilder diagramBuilder = new();

        /// <summary>
        /// The built <c>[CC] Provide Audio and Video Intercommunication Means</c> diagram.
        /// </summary>
        private Diagram diagram = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagram = this.diagramBuilder.BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == "_yh-l8LweEeSJUNJMyfAosg");
        }

        [Test]
        public void Verify_that_the_mission_exploitation_runs_boundary_to_boundary()
        {
            // Mission box (156, 34) 70x46, source anchor (0.5, 0.0) → reference (191, 34);
            // capability box (150, 154) 70x46, target anchor (0.5, 1.0) → reference (185, 200).
            // The rendered line is the segment between the two anchor-line/bounds crossings:
            // out of the mission's bottom edge, into the capability's top edge.
            var exploitation = this.diagram.Edges.Single(edge => edge.SiriusElement?.Id == "_oZSvMIoOEeaQmcRqIfTB6w");

            Assert.Multiple(() =>
            {
                Assert.That(exploitation.Route, Has.Count.EqualTo(2));
                Assert.That(exploitation.Route[0].X, Is.EqualTo(189.337).Within(0.01), "leaves the mission bottom near its center");
                Assert.That(exploitation.Route[0].Y, Is.EqualTo(80).Within(0.01));
                Assert.That(exploitation.Route[1].X, Is.EqualTo(186.663).Within(0.01), "arrives at the capability top near its center");
                Assert.That(exploitation.Route[1].Y, Is.EqualTo(154).Within(0.01));
            });
        }

        [Test]
        public void Verify_that_the_actor_involvement_leaves_the_capability_boundary()
        {
            // Capability source anchor (0.5, 0.0) → reference (185, 154); Cabin Crew actor box
            // (20, 274) 70x61, target anchor (0.5, 1.0) → reference (55, 335). The line toward the
            // actor exits the capability's bottom edge — not its raw top-center anchor point — and
            // enters the actor box on its right edge.
            var involvement = this.diagram.Edges.Single(edge => edge.SiriusElement?.Id == "_oZJlQIoOEeaQmcRqIfTB6w");

            Assert.Multiple(() =>
            {
                Assert.That(involvement.Route, Has.Count.EqualTo(2));
                Assert.That(involvement.Route[0].X, Is.EqualTo(151.967).Within(0.01), "exits the capability's bottom-left");
                Assert.That(involvement.Route[0].Y, Is.EqualTo(200).Within(0.01));
                Assert.That(involvement.Route[1].X, Is.EqualTo(90).Within(0.01), "enters the actor's right edge");
                Assert.That(involvement.Route[1].Y, Is.EqualTo(286.271).Within(0.01));
            });
        }
    }
}
