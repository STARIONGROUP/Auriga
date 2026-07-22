// ------------------------------------------------------------------------------------------------
// <copyright file="StateMachineTestFixture.cs" company="Starion Group S.A.">
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
    /// The mode/state-machine acceptance tests (issue #97): a choice pseudo-state renders as a
    /// diamond (a Sirius lozenge style), pseudo-states and the final state render as their glyph
    /// with no name label drawn over it, and a region is an unnamed compartment whose
    /// <c>[Region1]</c> placeholder must not sit in the owning state's title band — while a mode
    /// keeps its name. The state sizes and transition routing come from the size-synthesis (#94)
    /// and routing (#95/#96) work. Verified on the In-Flight <c>[MSM] IFE Operating Modes</c> and
    /// <c>[MSM] Seat TV Modes</c>.
    /// </summary>
    [TestFixture]
    public class StateMachineTestFixture
    {
        private const string OperatingModesMsmUid = "_ZlrrsPhmEeyYD7A3qrV3tA";

        private const string SeatTvModesMsmUid = "_8Rf4kPhoEeyYD7A3qrV3tA";

        private static readonly System.Xml.Linq.XNamespace Svg = "http://www.w3.org/2000/svg";

        private readonly SvgExporter svgExporter = new();

        private System.Collections.Generic.List<Diagram> diagrams = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagrams = new DiagramBuilder().BuildAll(result.Elements.Values).ToList();
        }

        [Test]
        public void Verify_that_choice_pseudo_states_render_as_labelless_diamonds()
        {
            var diagram = this.diagrams.Single(d => d.Identifier == OperatingModesMsmUid);
            var choices = diagram.QueryAllBoxes().Where(box => box.SemanticElement?.GetType().Name == "ChoicePseudoState").ToList();

            var document = System.Xml.Linq.XDocument.Parse(this.svgExporter.Export(diagram));

            Assert.Multiple(() =>
            {
                Assert.That(choices, Is.Not.Empty, "the state machine has choice pseudo-states");
                Assert.That(choices, Has.All.Matches<Box>(choice => choice.Style.Resolved.Shape == ShapeKind.Diamond), "a choice resolves to a diamond");
                Assert.That(choices, Has.All.Matches<Box>(choice => choice.Label == null), "a choice carries no name label");

                // The rendered SVG draws a diamond path, never a 'Choice' label on top of it.
                Assert.That(document.Descendants(Svg + "path"), Has.Some.Matches<System.Xml.Linq.XElement>(path => ((string?)path.Attribute("d"))!.EndsWith("Z") && ((string?)path.Attribute("fill")) != "none"), "a filled diamond path renders");
                Assert.That(document.Descendants(Svg + "text").Select(text => text.Value), Has.None.EqualTo("Choice"));
            });
        }

        [Test]
        public void Verify_that_regions_are_unnamed_and_modes_keep_their_title()
        {
            var diagram = this.diagrams.Single(d => d.Identifier == OperatingModesMsmUid);
            var boxes = diagram.QueryAllBoxes().ToList();
            var regions = boxes.Where(box => box.SemanticElement?.GetType().Name == "Region").ToList();
            var modes = boxes.Where(box => box.SemanticElement?.GetType().Name == "Mode").ToList();

            var labels = System.Xml.Linq.XDocument.Parse(this.svgExporter.Export(diagram)).Descendants(Svg + "text").Select(text => text.Value).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(regions, Is.Not.Empty, "the modes own regions");
                Assert.That(regions, Has.All.Matches<Box>(region => region.Label == null), "a region compartment carries no title");
                Assert.That(modes, Has.All.Matches<Box>(mode => mode.Label != null), "a mode keeps its state name");
                Assert.That(modes, Has.Some.Matches<Box>(mode => mode.Label!.Text == "Start Up"), "the mode names render");

                // No '[Region1]' placeholder survives in the owning state's title band.
                Assert.That(labels, Has.None.Contains("Region1"));
            });
        }

        [Test]
        public void Verify_that_history_pseudo_state_text_is_not_drawn_over_its_glyph()
        {
            var diagram = this.diagrams.Single(d => d.Identifier == SeatTvModesMsmUid);
            var history = diagram.QueryAllBoxes().Where(box => box.SemanticElement is Auriga.Model.Capellacommon.IPseudostate).ToList();

            var texts = System.Xml.Linq.XDocument.Parse(this.svgExporter.Export(diagram)).Descendants(Svg + "text").Select(text => text.Value).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(history, Is.Not.Empty, "the state machine has pseudo-states");
                Assert.That(history, Has.All.Matches<Box>(pseudo => pseudo.Label == null), "a pseudo-state renders glyph-only");
                Assert.That(texts, Has.None.EqualTo("Deep History"), "the 'Deep History' text no longer draws over the H* glyph");
            });
        }
    }
}
