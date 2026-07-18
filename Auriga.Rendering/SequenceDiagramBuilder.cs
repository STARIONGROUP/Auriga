// ------------------------------------------------------------------------------------------------
// <copyright file="SequenceDiagramBuilder.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NotationModel = Auriga.Diagram.Notation;

    /// <summary>
    /// Builds the intermediate model of a sequence representation (a Capella scenario — ES, FS,
    /// IS), adding the layout rules the generic walk cannot know: lifelines become dashed gray
    /// centerlines under their instance-role headers, messages flatten to horizontal lines at
    /// their execution-anchor heights (self-messages become rectangular hooks), and combined
    /// fragments paint as background frames with operator tabs and dashed operand rules. Every
    /// rule is expressed as intermediate-model data, keeping the exporter kind-agnostic.
    /// </summary>
    public sealed class SequenceDiagramBuilder : DiagramBuilderBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceDiagramBuilder"/> class with the
        /// default style resolver, for direct use without a container.
        /// </summary>
        public SequenceDiagramBuilder()
            : base(new StyleResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceDiagramBuilder"/> class with the
        /// supplied style resolver — the constructor a container injects through.
        /// </summary>
        /// <param name="styleResolver">the resolver producing each built item's resolved style</param>
        /// <exception cref="System.ArgumentNullException">the resolver is null</exception>
        public SequenceDiagramBuilder(IStyleResolver styleResolver)
            : base(styleResolver)
        {
        }

        /// <summary>
        /// The stroke color of a lifeline's dashed centerline (Capella's lifeline gray).
        /// </summary>
        private static readonly Color LifelineGray = new(128, 128, 128);

        /// <summary>
        /// The distance a lifeline extends below the diagram's lowest content.
        /// </summary>
        private const double LifelineTail = 20;

        /// <summary>
        /// The minimum clearance between a message end and the box it attaches to, so a message
        /// starting from or arriving at a bare lifeline (a 1-pixel-wide box) does not touch the
        /// dashed centerline — executions provide more clearance through their own half-width.
        /// </summary>
        private const double MessageClearance = 3;

        /// <summary>
        /// The horizontal reach of a synthesized self-message hook beyond the source's edge, when
        /// the persisted bendpoints carry no horizontal extent of their own (Capella synthesizes
        /// the hook shape at render time).
        /// </summary>
        private const double SelfMessageExtent = 25;

        /// <summary>
        /// The height of a self-message hook: Capella draws every self-message as a compact staple
        /// departing one hop above its arrival, regardless of the (stale) persisted departure.
        /// </summary>
        private const double SelfMessageHop = 10;

        /// <summary>
        /// Applies the sequence-diagram layout rules the generic pass cannot know. A lifeline (the
        /// unnamed child sharing its instance role's semantic target) becomes the dashed gray
        /// centerline under its header, running down to the diagram's lowest content. A message
        /// between two boxes is flattened to the horizontal line sequence semantics demand, at the
        /// anchor height of an end whose box has persisted absolute bounds (an execution) — the
        /// anchor fractions persisted on the lifelines themselves are stale render artifacts, so an
        /// execution end is always the better vertical truth.
        /// </summary>
        /// <param name="rootBoxes">the top-level boxes: instance-role headers and combined fragments</param>
        /// <param name="edges">the message edges, to which the operand separator rules are added</param>
        protected override void ApplyRepresentationRules(List<Box> rootBoxes, List<Edge> edges)
        {
            var lifelines = rootBoxes
                .SelectMany(header => header.Children
                    .Where(child => child.Label == null && child.SemanticElement != null && ReferenceEquals(child.SemanticElement, header.SemanticElement))
                    .Select(lifeline => (Header: header, Lifeline: lifeline)))
                .ToList();

            // A combined fragment / interaction use is a background frame: it paints first (largest
            // area first, so nested frames stay visible), the lifeline content on top — and its
            // label sits in the frame's top-left corner, not centered, as do its operands' guard
            // labels.
            var headers = new HashSet<Box>(lifelines.Select(pair => pair.Header));
            var ordered = rootBoxes
                .OrderBy(box => headers.Contains(box) ? 1 : 0)
                .ThenByDescending(box => (box.Width ?? 0) * (box.Height ?? 0))
                .ToList();
            rootBoxes.Clear();
            rootBoxes.AddRange(ordered);

            foreach (var fragment in rootBoxes.Where(box => !headers.Contains(box) && IsCombinedFragment(box)))
            {
                PinLabelTopLeft(fragment);

                if (fragment.Label is { } operatorLabel)
                {
                    operatorLabel.Framed = true;
                }

                // Operands are transparent regions: no fill or outline of their own — Capella
                // separates consecutive operands with a dashed rule across the frame instead.
                var operands = fragment.Children.OrderBy(operand => operand.Position.Y).ToList();
                for (var i = 0; i < operands.Count; i++)
                {
                    PinLabelTopLeft(operands[i]);
                    operands[i].Style.Resolved.FillColor = null;
                    operands[i].Style.Resolved.GradientColor = null;
                    operands[i].Style.Resolved.StrokeWidth = 0;

                    if (i > 0)
                    {
                        edges.Add(OperandSeparator(fragment, operands[i], i));
                    }
                }
            }

            // Center each lifeline under its header first, so a message attached to the lifeline
            // itself (an instance role without executions) starts from the centerline. The header's
            // label centers in its box (Capella renders instance-role names centered), and the
            // lifeline renders as a pure line rather than a capped rectangle.
            foreach (var (header, lifeline) in lifelines)
            {
                var centerX = header.Position.X + ((header.Width ?? 0) / 2);
                lifeline.Position = new Point(centerX - 0.5, header.Position.Y + (header.Height ?? 0));
                lifeline.Width = 1;
                lifeline.Style.Resolved.Shape = ShapeKind.Line;

                if (header.Label is { } headerLabel)
                {
                    headerLabel.Position = null;
                    headerLabel.Width = null;
                    headerLabel.Height = null;
                }
            }

            RouteMessagesHorizontally(edges, headers);

            var bottom = ContentBottom(rootBoxes, lifelines.Select(pair => pair.Lifeline), edges);

            foreach (var (_, lifeline) in lifelines)
            {
                lifeline.Height = Math.Max(0, bottom - lifeline.Position.Y);

                lifeline.Style.Resolved.FillColor = null;
                lifeline.Style.Resolved.GradientColor = null;
                lifeline.Style.Resolved.StrokeColor = LifelineGray;
                lifeline.Style.Resolved.StrokeWidth = 1;
                lifeline.Style.Resolved.Pattern = LinePattern.LongDash;

                // The end-of-life mark — the unnamed, unfiltered child sharing the lifeline's own
                // instance role — persists as a small square at a stale relative position; Capella
                // draws it as a short horizontal tick terminating the lifeline.
                var lifelineCenter = lifeline.Position.X + 0.5;
                foreach (var mark in lifeline.Children.Where(child =>
                    child.Label == null && !child.HasAbsoluteBounds && ReferenceEquals(child.SemanticElement, lifeline.SemanticElement)))
                {
                    var tickWidth = Math.Max(mark.Width ?? 10, 10);
                    mark.Position = new Point(lifelineCenter - (tickWidth / 2), bottom);
                    mark.Width = tickWidth;
                    mark.Height = 0;
                    mark.Style.Resolved.Shape = ShapeKind.Line;
                    mark.Style.Resolved.FillColor = null;
                    mark.Style.Resolved.StrokeColor = LifelineGray;
                    mark.Style.Resolved.StrokeWidth = 1;
                    mark.Style.Resolved.Pattern = LinePattern.Solid;
                }
            }
        }

        /// <summary>
        /// Builds the dashed rule separating an operand from its predecessor, spanning the
        /// fragment's width at the operand's top edge.
        /// </summary>
        /// <param name="fragment">the combined fragment</param>
        /// <param name="operand">the operand whose top edge the rule runs along</param>
        /// <param name="index">the operand's index, making the rule's identifier unique</param>
        /// <returns>the separator edge</returns>
        private static Edge OperandSeparator(Box fragment, Box operand, int index)
        {
            var route = new List<Point>
            {
                new(fragment.Position.X, operand.Position.Y),
                new(fragment.Position.X + (fragment.Width ?? 0), operand.Position.Y),
            };

            var separator = new Edge($"{fragment.Identifier}-separator-{index}", route, new NotationModel.Edge(), new Style(null, new List<NotationModel.IStyle>()));
            separator.Style.Resolved.StrokeColor = new Color(0, 0, 0);
            separator.Style.Resolved.StrokeWidth = 1;
            separator.Style.Resolved.Pattern = LinePattern.Dash;

            return separator;
        }

        /// <summary>
        /// Pins a box's label to the box's top-left corner (the placement of a combined fragment's
        /// operator and an operand's guard), when the box carries a label.
        /// </summary>
        /// <param name="box">the fragment or operand box</param>
        private static void PinLabelTopLeft(Box box)
        {
            if (box.Label is { } label)
            {
                label.Position = new Point(box.Position.X + 4, box.Position.Y + 2);
                label.Width = null;
                label.Height = null;
            }
        }

        /// <summary>
        /// Flattens every message between two mapped boxes to a horizontal line from the facing edge
        /// of its source box to the facing edge of its target box, at the anchor height of an end
        /// with persisted absolute bounds (target preferred). A message without such an end — or a
        /// self-message — keeps its generic route.
        /// </summary>
        /// <param name="edges">the message edges</param>
        /// <param name="headers">the instance-role header boxes lifeline content roots in</param>
        private static void RouteMessagesHorizontally(IReadOnlyList<Edge> edges, HashSet<Box> headers)
        {
            foreach (var edge in edges)
            {
                if (edge.Source == null || edge.Target == null || ReferenceEquals(edge.Source, edge.Target))
                {
                    continue;
                }

                // Only a message between occurrences on lifelines routes horizontally. An edge with
                // an end outside the lifelines — a note attachment, a constraint link — keeps its
                // generic anchor-resolved route.
                if (!headers.Contains(Root(edge.Source)) || !headers.Contains(Root(edge.Target)))
                {
                    continue;
                }

                var y = DetermineMessageHeight(edge);
                if (y == null)
                {
                    continue;
                }

                var sourceCenter = edge.Source.Position.X + ((edge.Source.Width ?? 0) / 2);
                var targetCenter = edge.Target.Position.X + ((edge.Target.Width ?? 0) / 2);

                // Ends on the same lifeline are recognized structurally — nested executions sit a
                // few pixels off their parent's center, so comparing centers would miss them.
                if (ReferenceEquals(Root(edge.Source), Root(edge.Target)))
                {
                    RouteSelfMessage(edge, targetCenter);
                    continue;
                }

                var direction = targetCenter >= sourceCenter ? 1 : -1;

                var start = sourceCenter + (direction * Math.Max((edge.Source.Width ?? 0) / 2, MessageClearance));
                var end = targetCenter - (direction * Math.Max((edge.Target.Width ?? 0) / 2, MessageClearance));

                edge.Route = new List<Point> { new(start, y.Value), new(end, y.Value) };
            }
        }

        /// <summary>
        /// The vertical position of a message: the target execution's top edge when the target has
        /// absolute bounds — the receiving end triggers the execution, and persisted anchor
        /// fractions on receiving ends are stale render artifacts Capella recomputes from the event
        /// order — else the source's anchor height, or <c>null</c> when neither end has absolute
        /// bounds (the message keeps its generic route).
        /// </summary>
        /// <param name="edge">the message edge, with both ends mapped</param>
        /// <returns>the message's y coordinate, or <c>null</c></returns>
        private static double? DetermineMessageHeight(Edge edge)
        {
            if (edge.Target!.HasAbsoluteBounds)
            {
                return edge.Target.Position.Y;
            }

            if (edge.Source!.HasAbsoluteBounds)
            {
                return SequenceAnchorPoint(edge.Source, edge.NotationView.SourceAnchor).Y;
            }

            return null;
        }

        /// <summary>
        /// Whether a top-level box is a combined fragment or interaction use — the frames that
        /// paint behind the lifeline content with an operator tab and operand rules. Decided by the
        /// semantic element's type when the session co-loaded it; a diagram-only session falls back
        /// to the structural shape (a Sirius-backed box with operand children). A constraint or
        /// note is neither.
        /// </summary>
        /// <param name="box">the top-level box</param>
        /// <returns>true when the box is a fragment frame</returns>
        private static bool IsCombinedFragment(Box box)
        {
            if (box.SemanticElement != null)
            {
                var semanticType = box.SemanticElement.GetType().Name;
                return semanticType is "CombinedFragment" or "InteractionUse";
            }

            return box.SiriusElement != null && box.Children.Count > 0;
        }

        /// <summary>
        /// The top-level ancestor of a box (a sequence diagram's instance-role header, for any
        /// occurrence nested on its lifeline).
        /// </summary>
        /// <param name="box">the box whose root is sought</param>
        /// <returns>the top-level ancestor, or the box itself when it is top-level</returns>
        private static Box Root(Box box)
        {
            var current = box;
            while (current.Parent != null)
            {
                current = current.Parent;
            }

            return current;
        }

        /// <summary>
        /// Routes a message between two occurrences on the same lifeline as Capella's rectangular
        /// self-message hook: out from the source's right edge one hop above the arrival, sideways,
        /// down, and back into the target's facing edge. The arrival height is the target
        /// execution's top; the departure is always the compact hop above it — the persisted
        /// departure bendpoints are stale render artifacts, exactly like receiving-end anchors.
        /// The sideways reach honors the persisted extent when one exists and is synthesized
        /// otherwise.
        /// </summary>
        /// <param name="edge">the self-message edge, with both ends mapped</param>
        /// <param name="targetCenter">the target box's horizontal center</param>
        private static void RouteSelfMessage(Edge edge, double targetCenter)
        {
            var origin = SequenceAnchorPoint(edge.Source!, edge.NotationView.SourceAnchor);
            var hook = ParseBendpoints((edge.NotationView.Bendpoints as NotationModel.IRelativeBendpoints)?.Points);

            double yEnd;
            if (edge.Target!.HasAbsoluteBounds)
            {
                yEnd = edge.Target.Position.Y;
            }
            else if (hook.Count > 0)
            {
                yEnd = origin.Y + hook[hook.Count - 1].SourceRelative.Y;
            }
            else
            {
                yEnd = origin.Y + SelfMessageHop;
            }

            var yStart = yEnd - SelfMessageHop;

            var sourceCenter = edge.Source!.Position.X + ((edge.Source.Width ?? 0) / 2);
            var startX = sourceCenter + Math.Max((edge.Source.Width ?? 0) / 2, MessageClearance);
            var persistedExtent = hook.Count > 0 ? origin.X + hook.Max(bendpoint => bendpoint.SourceRelative.X) : startX;
            var hookX = Math.Max(persistedExtent, startX + SelfMessageExtent);
            var endX = targetCenter + Math.Max((edge.Target.Width ?? 0) / 2, MessageClearance);

            edge.Route = new List<Point>
            {
                new(startX, yStart),
                new(hookX, yStart),
                new(hookX, yEnd),
                new(endX, yEnd),
            };
        }

        /// <summary>
        /// The absolute anchor point of a sequence-message end: a persisted anchor fraction applies
        /// verbatim, but a missing anchor means the message connects at the triggering event — the
        /// top of the execution, not the GMF center default.
        /// </summary>
        /// <param name="box">the box the message end attaches to</param>
        /// <param name="anchor">the persisted anchor, or <c>null</c></param>
        /// <returns>the absolute anchor point</returns>
        private static Point SequenceAnchorPoint(Box box, NotationModel.IAnchor? anchor)
        {
            return FractionPoint(box, ParseAnchorFraction(anchor) ?? new Point(0.5, 0));
        }

        /// <summary>
        /// The lowest y coordinate of the diagram's content — every box except the lifelines
        /// themselves, and every route point — plus the lifeline tail margin.
        /// </summary>
        /// <param name="rootBoxes">the top-level boxes</param>
        /// <param name="lifelines">the lifeline boxes to exclude</param>
        /// <param name="edges">the message edges</param>
        /// <returns>the y coordinate lifelines run down to</returns>
        private static double ContentBottom(IReadOnlyList<Box> rootBoxes, IEnumerable<Box> lifelines, IReadOnlyList<Edge> edges)
        {
            var excluded = new HashSet<Box>(lifelines);
            var bottom = 0d;

            void Visit(Box box)
            {
                if (!excluded.Contains(box))
                {
                    bottom = Math.Max(bottom, box.Position.Y + (box.Height ?? 0));
                }

                foreach (var child in box.Children)
                {
                    Visit(child);
                }
            }

            foreach (var box in rootBoxes)
            {
                Visit(box);
            }

            foreach (var point in edges.SelectMany(edge => edge.Route))
            {
                bottom = Math.Max(bottom, point.Y);
            }

            return bottom + LifelineTail;
        }
    }
}
