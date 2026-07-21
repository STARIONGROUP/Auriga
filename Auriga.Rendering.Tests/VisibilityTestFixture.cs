// ------------------------------------------------------------------------------------------------
// <copyright file="VisibilityTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Auriga.Xmi;

    using NUnit.Framework;

    using NotationModel = Auriga.Diagram.Notation;

    /// <summary>
    /// The visibility acceptance tests (issue #92): Capella hides diagram elements (a
    /// <c>HideFilter</c>) and folds a collapsed container's children away (a <c>CollapseFilter</c>)
    /// by persisting the GMF view <c>visible="false"</c>. The builder must skip those views — else
    /// their stale layout piles the hidden subtree at the origin and inflates the canvas. Verified
    /// on the In-Flight <c>[PCBD] Behavioural Components</c>, whose sibling diagram's
    /// implementation-component subtree is persisted hidden.
    /// </summary>
    [TestFixture]
    public class VisibilityTestFixture
    {
        private const string BehaviouralComponentsUid = "_o27AcKO1EeSgDIOKB3Rd0g";

        /// <summary>
        /// The builder under test, composed with the default per-kind builders.
        /// </summary>
        private readonly DiagramBuilder diagramBuilder = new();

        private Diagram diagram = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagram = this.diagramBuilder.BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == BehaviouralComponentsUid);
        }

        [Test]
        public void Verify_that_hidden_elements_and_edges_are_excluded()
        {
            var boxes = this.diagram.QueryAllBoxes().ToList();

            // The persisted notation carries the sibling diagram's implementation-component subtree
            // as hidden element nodes (visible="false"); the builder must have skipped every one.
            var hiddenElementNodes = Flatten(this.diagram.NotationDiagram.PersistedChildren)
                .Where(node => node.Element != null && node.Visible == false)
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.That(hiddenElementNodes, Is.Not.Empty, "the diagram genuinely persists hidden element nodes to exclude");
                Assert.That(boxes, Is.Not.Empty, "the diagram still renders its visible behaviour components");
                Assert.That(boxes, Has.All.Matches<Box>(box => box.NotationView.Visible != false), "no hidden node is built into a box");
                Assert.That(this.diagram.Edges, Has.All.Matches<Edge>(edge => edge.NotationView.Visible != false), "no hidden edge is built");
            });
        }

        /// <summary>
        /// Flattens a notation node forest depth-first into every node it contains.
        /// </summary>
        /// <param name="nodes">the root notation nodes</param>
        /// <returns>every node, roots and descendants</returns>
        private static IEnumerable<NotationModel.INode> Flatten(IEnumerable<NotationModel.INode> nodes)
        {
            foreach (var node in nodes)
            {
                yield return node;

                foreach (var descendant in Flatten(node.PersistedChildren))
                {
                    yield return descendant;
                }
            }
        }
    }
}
