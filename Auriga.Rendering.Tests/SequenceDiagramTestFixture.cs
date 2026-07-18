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
                Assert.That(lifeline.Style.Resolved.Pattern, Is.EqualTo(LinePattern.LongDash), "the calmer long-dash stroke Capella uses");
                Assert.That(lifeline.Style.Resolved.StrokeColor, Is.EqualTo(new Color(128, 128, 128)));
                Assert.That(lifeline.Style.Resolved.FillColor, Is.Null);

                // The end-of-life mark renders as a short horizontal tick centered at the
                // lifeline's bottom end, not as the persisted small square.
                var tick = lifeline.Children.Single(child => child.Label == null && !child.HasAbsoluteBounds && ReferenceEquals(child.SemanticElement, lifeline.SemanticElement));
                Assert.That(tick.Style.Resolved.Shape, Is.EqualTo(ShapeKind.Line));
                Assert.That(tick.Height, Is.EqualTo(0), "a horizontal line, not a box");
                Assert.That(tick.Position.X + ((tick.Width ?? 0) / 2), Is.EqualTo(100).Within(0.0001), "centered on the lifeline");
                Assert.That(tick.Position.Y, Is.EqualTo(lifeline.Position.Y + lifeline.Height), "at the lifeline's end");
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
        public void Verify_that_notes_render_and_self_messages_keep_their_hook()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            var performAudio = DiagramBuilder.BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == "_5o4FkLD5EeSk6sURco8jXw");

            var notes = performAudio.QueryAllBoxes()
                .Where(box => box.SiriusElement == null && box.NotationView is Auriga.Diagram.Notation.IShape)
                .ToList();

            var vodMovie = performAudio.Edges.Single(edge => edge.Label?.Text == "VOD Movie");

            Assert.Multiple(() =>
            {
                // The two yellow GMF notes carry their text as wrapped, positioned labels.
                Assert.That(notes, Has.Count.EqualTo(2));
                Assert.That(notes, Has.Some.Matches<Box>(note => note.Label!.Text.StartsWith("Tips and tricks")));
                Assert.That(notes, Has.All.Matches<Box>(note => note.Label!.Position != null && note.Label.Width != null));

                // The self-message between two occurrences on the same lifeline keeps its persisted
                // rectangular hook instead of collapsing to a degenerate horizontal line.
                Assert.That(vodMovie.Route, Has.Count.EqualTo(4));
                Assert.That(vodMovie.Route.Select(point => point.Y).Distinct().Count(), Is.EqualTo(2), "out, down, and back");
                Assert.That(vodMovie.Route.Max(point => point.X), Is.GreaterThan(vodMovie.Route[0].X), "the hook extends sideways");
                Assert.That(
                    vodMovie.Route[3].X,
                    Is.EqualTo(vodMovie.Target!.Position.X + vodMovie.Target.Width).Within(0.0001),
                    "the arrow ends at the execution's facing edge instead of overshooting");
            });
        }

        [Test]
        public void Verify_that_note_attachments_stay_dotted_point_to_point_lines()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            var scenario = DiagramBuilder.BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == "_duRY4JiwEeSFKIU85IonOQ");

            var attachment = scenario.Edges.Single(edge => edge.Identifier == "_25tm0KfIEeSfJNzMtsfIDg");
            var note = scenario.QueryAllBoxes().Single(box => box.Identifier == "_xPpnAKfIEeSfJNzMtsfIDg");

            Assert.Multiple(() =>
            {
                Assert.That(attachment.Style.Resolved.Pattern, Is.EqualTo(LinePattern.Dot), "a note attachment renders dotted");
                Assert.That(attachment.Style.Resolved.TargetArrow, Is.Null, "and carries no arrowhead");

                // The message router must leave it alone: its persisted anchors and bendpoints
                // resolve against the note's own geometry — the first route point is the persisted
                // (-25, -5) offset from the anchor on the note's left edge.
                Assert.That(attachment.Source, Is.SameAs(note));
                Assert.That(attachment.Route[0].X, Is.EqualTo(note.Position.X + (0.06965174129353234 * note.Width!.Value) - 25).Within(0.001));
                Assert.That(attachment.Route[0].Y, Is.Not.EqualTo(attachment.Route[attachment.Route.Count - 1].Y), "not flattened to a horizontal message");
            });
        }

        [Test]
        public void Verify_that_a_constraint_centers_its_text_and_keeps_its_dotted_link()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "In-Flight Entertainment System.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            var scenario = DiagramBuilder.BuildAll(result.Elements.Values).Single(candidate => candidate.Identifier == "_pHpF4LEPEeSk6sURco8jXw");

            var constraint = scenario.QueryAllBoxes().Single(box => box.Label?.Text == "Profile = CORE SERVICES ONLY");
            var link = scenario.Edges.Single(edge => edge.SiriusElement?.Id == "_khfXMIoOEeaQmcRqIfTB6w");

            Assert.Multiple(() =>
            {
                // A constraint is not a combined fragment: its label centers in the box instead of
                // being pinned into an operator tab.
                Assert.That(constraint.Label!.Position, Is.Null, "centered, not pinned top-left");
                Assert.That(constraint.Label.Framed, Is.False);

                // Its link keeps the persisted dotted amber style and the generic point-to-point
                // route — the message router must not flatten it.
                Assert.That(link.Style.Resolved.Pattern, Is.EqualTo(LinePattern.Dot));
                Assert.That(link.Style.Resolved.StrokeColor, Is.EqualTo(new Color(253, 206, 137)));
                Assert.That(link.Target, Is.SameAs(constraint));
                Assert.That(link.Route[link.Route.Count - 1].Y, Is.Not.EqualTo(link.Route[0].Y).Within(0.0001), "not flattened to a horizontal message");
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
