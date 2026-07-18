// ------------------------------------------------------------------------------------------------
// <copyright file="SequenceDiagramTestFixture.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// The end-to-end acceptance tests for sequence-diagram rendering (issue #62), against the real
    /// <c>[ES] Select VOD Movie</c> exchange scenario of the In-Flight Entertainment System: the
    /// persisted <c>AbsoluteBoundsFilter</c> layout positions the instance-role headers, executions
    /// and state fragments; the lifelines become dashed centerlines under their headers; and the
    /// messages route horizontally at their execution-anchor heights.
    /// </summary>
    [TestFixture]
    public class SequenceDiagramTestFixture
    {
        private const string SelectVodMovieUid = "_QD67YMAFEeS91_vDABbjUA";

        private Diagram diagram = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            this.diagram = DiagramBuilder.BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == SelectVodMovieUid);
        }

        [Test]
        public void Verify_that_the_instance_role_headers_take_their_absolute_bounds()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.diagram.Name, Is.EqualTo("[ES] Select VOD Movie"));
                Assert.That(this.diagram.Boxes, Has.Count.EqualTo(3), "three instance roles");
                Assert.That(this.diagram.Boxes, Has.All.Matches<Box>(header => header.HasAbsoluteBounds));

                var passenger = this.diagram.Boxes.Single(header => header.Label?.Text == "Passenger");
                Assert.That(passenger.Position, Is.EqualTo(new Point(50, 50)), "the AbsoluteBoundsFilter position, not the notation offset");
                Assert.That(passenger.Width, Is.EqualTo(100));
                Assert.That(passenger.Height, Is.EqualTo(50));
                Assert.That(passenger.Label!.Position, Is.Null, "instance-role names render centered in their header");
            });
        }

        [Test]
        public void Verify_that_executions_and_state_fragments_take_their_absolute_bounds()
        {
            var boxes = this.diagram.QueryAllBoxes().ToList();

            var execution = boxes.Single(box => box.Identifier == "_kzbbwIoOEeaQmcRqIfTB6w");
            var stateFragment = boxes.Single(box => box.Label?.Text == "Command VOD Session");

            Assert.Multiple(() =>
            {
                // <graphicalFilters xmi:type="diagram:AbsoluteBoundsFilter" x="95" y="130" height="76" width="10"/>
                Assert.That(execution.Position, Is.EqualTo(new Point(95, 130)));
                Assert.That(execution.Width, Is.EqualTo(10));
                Assert.That(execution.Height, Is.EqualTo(76));
                Assert.That(execution.HasAbsoluteBounds, Is.True);

                // <graphicalFilters xmi:type="diagram:AbsoluteBoundsFilter" x="50" y="143" height="51" width="100"/>
                Assert.That(stateFragment.Position, Is.EqualTo(new Point(50, 143)));
                Assert.That(stateFragment.Width, Is.EqualTo(100));
                Assert.That(stateFragment.Height, Is.EqualTo(51));
            });
        }

        [Test]
        public void Verify_that_lifelines_become_dashed_centerlines()
        {
            var passenger = this.diagram.Boxes.Single(header => header.Label?.Text == "Passenger");
            var lifeline = passenger.Children.Single(child => child.Label == null && ReferenceEquals(child.SemanticElement, passenger.SemanticElement));

            Assert.Multiple(() =>
            {
                Assert.That(lifeline.Position.X, Is.EqualTo(99.5), "centered under the 50..150 header");
                Assert.That(lifeline.Position.Y, Is.EqualTo(100), "starting at the header's bottom edge");
                Assert.That(lifeline.Width, Is.EqualTo(1));
                Assert.That(lifeline.Height, Is.GreaterThan(700), "running down to the diagram's lowest content");
                Assert.That(lifeline.Style.Resolved.Pattern, Is.EqualTo(LinePattern.Dash));
                Assert.That(lifeline.Style.Resolved.StrokeColor, Is.EqualTo(new Color(128, 128, 128)));
                Assert.That(lifeline.Style.Resolved.FillColor, Is.Null);
            });
        }

        [Test]
        public void Verify_that_messages_route_horizontally_at_their_execution_anchor_height()
        {
            var horizontal = this.diagram.Edges
                .Where(edge => edge.Source != null && edge.Target != null && !ReferenceEquals(edge.Source, edge.Target))
                .ToList();

            var displayedMoviesList = this.diagram.Edges.Single(edge => edge.SiriusElement?.Id == "_kzuWsIoOEeaQmcRqIfTB6w");

            Assert.Multiple(() =>
            {
                Assert.That(horizontal, Is.Not.Empty);
                Assert.That(
                    horizontal,
                    Has.All.Matches<Edge>(edge => edge.Route.Count == 2 && edge.Route[0].Y.Equals(edge.Route[1].Y)),
                    "sequence messages are horizontal");

                // Its target is the Passenger execution at (95, 130) 10x76 with a (0.5, 0.0) anchor:
                // the message arrives at the execution's top edge, y = 130.
                Assert.That(displayedMoviesList.Route[0].Y, Is.EqualTo(130).Within(0.0001));
                Assert.That(displayedMoviesList.Route[1].X, Is.EqualTo(105).Within(0.0001), "arriving at the execution's right edge");
                Assert.That(displayedMoviesList.Label, Is.Not.Null);
            });
        }

        [Test]
        public void Verify_that_fragments_paint_behind_and_inside_labels_center()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            var performAudio = DiagramBuilder.BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == "_FremALbzEeSpk5KlhVegeg");

            var fragment = performAudio.Boxes[0];
            var state = performAudio.QueryAllBoxes().First(box => box.Label?.Text == "Play Audio-Video Stream on Seat TV");

            Assert.Multiple(() =>
            {
                // The PAR combined fragment is the diagram's largest box and paints first, so the
                // lifeline content it spans stays visible on top of its frame.
                Assert.That(fragment.Width * fragment.Height, Is.EqualTo(performAudio.Boxes.Max(box => box.Width * box.Height)));
                Assert.That(fragment.Label, Is.Not.Null, "the fragment carries its operator label");
                Assert.That(fragment.Label!.Position, Is.EqualTo(new Point(fragment.Position.X + 4, fragment.Position.Y + 2)), "pinned to the frame's top-left corner");
                Assert.That(fragment.Label.Framed, Is.True, "the operator renders in a title tab");

                // Operands are transparent regions separated by a dashed rule across the frame.
                Assert.That(fragment.Children, Has.All.Matches<Box>(operand => operand.Style.Resolved.StrokeWidth == 0 && operand.Style.Resolved.FillColor == null));
                var separator = performAudio.Edges.Single(edge => edge.Identifier == fragment.Identifier + "-separator-1");
                Assert.That(separator.Style.Resolved.Pattern, Is.EqualTo(LinePattern.Dash));
                Assert.That(separator.Route[0].Y, Is.EqualTo(separator.Route[1].Y), "the rule runs horizontally");
                Assert.That(separator.Route[1].X - separator.Route[0].X, Is.EqualTo(fragment.Width), "spanning the frame");

                // A state fragment's label geometry lies inside its box, so it renders centered.
                Assert.That(state.Label!.Position, Is.Null, "an inside label centers instead of keeping its persisted text bounds");

                // A message end without a persisted anchor connects at the triggering event — the
                // execution's top — not the GMF center default.
                var audioSignal = performAudio.Edges.First(edge => edge.Label?.Text == "Audio Signal");
                Assert.That(audioSignal.Target!.HasAbsoluteBounds, Is.True);
                Assert.That(audioSignal.Route[0].Y, Is.EqualTo(audioSignal.Target.Position.Y).Within(0.0001), "arriving at the execution's top edge");
            });
        }

        [Test]
        public void Verify_that_every_scenario_of_the_model_builds_and_exports()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            var scenarios = DiagramBuilder.BuildAll(result.Elements.Values)
                .Where(candidate => candidate.SiriusDiagram is Auriga.Diagram.Sequence.ISequenceDDiagram)
                .ToList();

            Assert.Multiple(() =>
            {
                Assert.That(scenarios, Is.Not.Empty);

                foreach (var scenario in scenarios)
                {
                    Assert.That(() => SvgExporter.Export(scenario), Throws.Nothing, scenario.Name);
                }
            });
        }
    }
}
