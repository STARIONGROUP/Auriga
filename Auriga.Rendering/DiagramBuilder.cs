// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramBuilder.cs" company="Starion Group S.A.">
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
    using System.Globalization;
    using System.Linq;

    using NotationModel = Auriga.Diagram.Notation;
    using SiriusDiagramModel = Auriga.Diagram.Diagram;
    using SiriusViewpoint = Auriga.Diagram.Viewpoint;

    /// <summary>
    /// Builds the intermediate <see cref="Diagram"/> model from a parsed Sirius representation by
    /// walking its persisted GMF notation tree (stored in the representation's <c>GMF_DIAGRAMS</c>
    /// annotation entry) and pairing each notation view with the Sirius representation element it
    /// displays (the view's <c>element</c> reference) and that element's resolved Capella semantic
    /// <c>target</c>. Layout is consumed from the persisted coordinates — positions are accumulated
    /// to absolute, never computed.
    /// </summary>
    public static class DiagramBuilder
    {
        /// <summary>
        /// The default anchor fraction: GMF anchors default to the center of the view when no
        /// <c>IdentityAnchor</c> is persisted.
        /// </summary>
        private static readonly Point CenterAnchor = new(0.5, 0.5);

        /// <summary>
        /// Builds the intermediate model of the supplied Sirius representation.
        /// </summary>
        /// <param name="siriusDiagram">the parsed Sirius representation (e.g. a <c>DSemanticDiagram</c>)</param>
        /// <param name="name">
        /// the diagram name, or <c>null</c>; the name lives on the <c>DRepresentationDescriptor</c>
        /// in the <c>DAnalysis</c> rather than on the representation, so the caller supplies it
        /// </param>
        /// <returns>the intermediate diagram model</returns>
        /// <exception cref="ArgumentNullException">the representation is null</exception>
        /// <exception cref="InvalidOperationException">the representation carries no GMF notation diagram</exception>
        public static Diagram Build(SiriusDiagramModel.IDDiagram siriusDiagram, string? name = null)
        {
            if (siriusDiagram == null)
            {
                throw new ArgumentNullException(nameof(siriusDiagram));
            }

            var notationDiagram = FindNotationDiagram(siriusDiagram);

            if (notationDiagram == null)
            {
                throw new InvalidOperationException(
                    $"The representation '{siriusDiagram.Id}' carries no GMF notation diagram (GMF_DIAGRAMS annotation entry), so there is no persisted layout to build from.");
            }

            var viewToBox = new Dictionary<NotationModel.IView, Box>();
            var rootBoxes = new List<Box>();

            foreach (var child in notationDiagram.PersistedChildren)
            {
                BuildNode(child, new Point(0, 0), null, siriusDiagram, rootBoxes, viewToBox);
            }

            var edges = notationDiagram.PersistedEdges
                .Select(notationEdge => BuildEdge(notationEdge, viewToBox))
                .ToList();

            if (siriusDiagram is Auriga.Diagram.Sequence.ISequenceDDiagram)
            {
                ApplySequenceLifelines(rootBoxes, edges);
            }

            return new Diagram(siriusDiagram.Id ?? string.Empty, rootBoxes, edges, siriusDiagram, notationDiagram)
            {
                Name = name,
                SemanticElement = (siriusDiagram as SiriusViewpoint.IDSemanticDecorator)?.Target,
            };
        }

        /// <summary>
        /// Builds the intermediate model of every representation in a parsed <c>.aird</c> session
        /// that carries a persisted GMF layout, naming each diagram from its
        /// <c>DRepresentationDescriptor</c> — the descriptor in the <c>DAnalysis</c> owns the
        /// human-readable name (<c>DRepresentation</c> itself does not serialize one) and points at
        /// its representation via <c>repPath</c>. A representation without a notation diagram or a
        /// descriptor without a resolvable representation is skipped, not an error.
        /// </summary>
        /// <param name="elements">
        /// the elements of the parsed session (e.g. the loader result's element index values),
        /// providing both the representations and their descriptors
        /// </param>
        /// <returns>the intermediate models, in element order</returns>
        /// <exception cref="ArgumentNullException">the element collection is null</exception>
        public static IReadOnlyList<Diagram> BuildAll(IEnumerable<Auriga.Core.IAurigaElement> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            var snapshot = elements.ToList();

            var names = new Dictionary<string, string>(StringComparer.Ordinal);
            foreach (var descriptor in snapshot
                .OfType<SiriusViewpoint.IDRepresentationDescriptor>()
                .Where(descriptor => !string.IsNullOrEmpty(descriptor.RepPath) && !string.IsNullOrEmpty(descriptor.Name)))
            {
                names[descriptor.RepPath!.TrimStart('#')] = descriptor.Name!;
            }

            var diagrams = new List<Diagram>();
            foreach (var representation in snapshot.OfType<SiriusDiagramModel.IDDiagram>())
            {
                if (FindNotationDiagram(representation) == null)
                {
                    continue;
                }

                var name = representation.Id != null && names.TryGetValue(representation.Id, out var descriptorName)
                    ? descriptorName
                    : null;

                diagrams.Add(Build(representation, name));
            }

            return diagrams;
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
        /// Applies the sequence-diagram layout rules the generic pass cannot know. A lifeline (the
        /// unnamed child sharing its instance role's semantic target) becomes the dashed gray
        /// centerline under its header, running down to the diagram's lowest content. A message
        /// between two boxes is flattened to the horizontal line sequence semantics demand, at the
        /// anchor height of an end whose box has persisted absolute bounds (an execution) — the
        /// anchor fractions persisted on the lifelines themselves are stale render artifacts, so an
        /// execution end is always the better vertical truth.
        /// </summary>
        /// <param name="rootBoxes">the top-level boxes: instance-role headers and combined fragments</param>
        /// <param name="edges">the message edges</param>
        private static void ApplySequenceLifelines(List<Box> rootBoxes, IReadOnlyList<Edge> edges)
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

            foreach (var fragment in rootBoxes.Where(box => !headers.Contains(box)))
            {
                PinLabelTopLeft(fragment);

                foreach (var operand in fragment.Children)
                {
                    PinLabelTopLeft(operand);
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

            RouteMessagesHorizontally(edges);

            var bottom = ContentBottom(rootBoxes, lifelines.Select(pair => pair.Lifeline), edges);

            foreach (var (_, lifeline) in lifelines)
            {
                lifeline.Height = Math.Max(0, bottom - lifeline.Position.Y);

                lifeline.Style.Resolved.FillColor = null;
                lifeline.Style.Resolved.GradientColor = null;
                lifeline.Style.Resolved.StrokeColor = LifelineGray;
                lifeline.Style.Resolved.StrokeWidth = 1;
                lifeline.Style.Resolved.Pattern = LinePattern.Dash;

                // The end-of-life mark persists at a stale relative position; Capella draws it as a
                // small horizontal tick terminating the lifeline.
                var lifelineCenter = lifeline.Position.X + 0.5;
                foreach (var mark in lifeline.Children.Where(child => child.SemanticElement?.GetType().Name == "EndOfLife"))
                {
                    var tickWidth = mark.Width ?? 10;
                    mark.Position = new Point(lifelineCenter - (tickWidth / 2), bottom);
                    mark.Height = 1;
                    mark.Style.Resolved.FillColor = null;
                    mark.Style.Resolved.StrokeColor = LifelineGray;
                    mark.Style.Resolved.Pattern = LinePattern.Solid;
                }
            }
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
        private static void RouteMessagesHorizontally(IReadOnlyList<Edge> edges)
        {
            foreach (var edge in edges)
            {
                if (edge.Source == null || edge.Target == null || ReferenceEquals(edge.Source, edge.Target))
                {
                    continue;
                }

                double y;
                if (edge.Target.HasAbsoluteBounds)
                {
                    // The receiving end triggers the target execution, so the message arrives at the
                    // execution's top edge — persisted anchor fractions on receiving ends are stale
                    // render artifacts (Capella recomputes them from the event order).
                    y = edge.Target.Position.Y;
                }
                else if (edge.Source.HasAbsoluteBounds)
                {
                    y = SequenceAnchorPoint(edge.Source, edge.NotationView.SourceAnchor).Y;
                }
                else
                {
                    continue;
                }

                var sourceCenter = edge.Source.Position.X + ((edge.Source.Width ?? 0) / 2);
                var targetCenter = edge.Target.Position.X + ((edge.Target.Width ?? 0) / 2);
                var direction = targetCenter >= sourceCenter ? 1 : -1;

                var start = sourceCenter + (direction * ((edge.Source.Width ?? 0) / 2));
                var end = targetCenter - (direction * ((edge.Target.Width ?? 0) / 2));

                edge.Route = new List<Point> { new(start, y), new(end, y) };
            }
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

        /// <summary>
        /// Finds the GMF notation diagram persisted in the representation's <c>GMF_DIAGRAMS</c>
        /// annotation entry.
        /// </summary>
        /// <param name="siriusDiagram">the Sirius representation</param>
        /// <returns>the notation diagram, or <c>null</c> when the representation carries none</returns>
        private static NotationModel.IDiagram? FindNotationDiagram(SiriusDiagramModel.IDDiagram siriusDiagram)
        {
            return ((SiriusViewpoint.IDRepresentation)siriusDiagram).OwnedAnnotationEntries
                .Select(entry => entry.Data)
                .OfType<NotationModel.IDiagram>()
                .FirstOrDefault();
        }

        /// <summary>
        /// Builds the box for a notation node — or folds an auxiliary node (a label or compartment,
        /// recognizable by carrying no Sirius element of its own) into the enclosing box: a label
        /// node contributes its geometry to the box's label, and a compartment's children keep
        /// nesting into the box, with the auxiliary node's offset accumulated either way.
        /// </summary>
        /// <param name="node">the notation node</param>
        /// <param name="origin">the absolute position of the parent view's top-left corner</param>
        /// <param name="parentBox">the enclosing box, or <c>null</c> at the diagram level</param>
        /// <param name="parentSiriusElement">the Sirius element the parent view displays</param>
        /// <param name="siblings">the list a new box is added to when there is no enclosing box</param>
        /// <param name="viewToBox">the notation-view-to-box map the edges resolve their ends against</param>
        private static void BuildNode(NotationModel.INode node, Point origin, Box? parentBox, object? parentSiriusElement, List<Box> siblings, Dictionary<NotationModel.IView, Box> viewToBox)
        {
            var position = origin + Offset(node.LayoutConstraint);
            var (width, height) = Size(node.LayoutConstraint);

            var siriusElement = node.Element as SiriusDiagramModel.IDDiagramElement;

            // Sirius persists the layout of sequence-diagram elements (instance roles, executions,
            // states, fragments) in an AbsoluteBoundsFilter, in absolute coordinates — the GMF child
            // coordinates are only render-time artifacts there. When the filter is present it is the
            // layout truth and replaces the accumulated relative geometry.
            var absoluteBounds = siriusElement?.GraphicalFilters.OfType<SiriusDiagramModel.IAbsoluteBoundsFilter>().FirstOrDefault();
            if (absoluteBounds != null)
            {
                position = new Point(absoluteBounds.X ?? position.X, absoluteBounds.Y ?? position.Y);
                width = Dimension(absoluteBounds.Width) ?? width;
                height = Dimension(absoluteBounds.Height) ?? height;
            }

            if (siriusElement == null || ReferenceEquals(siriusElement, parentSiriusElement))
            {
                if (parentBox != null)
                {
                    // A childless auxiliary node holding a location is the persisted label geometry.
                    if (node.PersistedChildren.Count == 0 && node.LayoutConstraint is NotationModel.ILocation && parentBox.Label is { Position: null } label)
                    {
                        label.Position = position;
                        label.Width = width;
                        label.Height = height;
                    }

                    // Edges may attach to the auxiliary view; route them to the enclosing box.
                    viewToBox[node] = parentBox;
                }

                foreach (var child in node.PersistedChildren)
                {
                    BuildNode(child, position, parentBox, parentSiriusElement, siblings, viewToBox);
                }

                return;
            }

            var box = new Box(siriusElement.Id ?? node.Id ?? string.Empty, position, node, BuildStyle(siriusElement, node.Styles))
            {
                Width = width,
                Height = height,
                HasAbsoluteBounds = absoluteBounds != null,
                SiriusElement = siriusElement,
                SemanticElement = siriusElement.Target,
            };

            var elementName = siriusElement.Name;
            if (!string.IsNullOrEmpty(elementName))
            {
                box.Label = new Label(elementName);
            }

            box.Style.Resolved = StyleResolver.Resolve(box);

            if (parentBox != null)
            {
                parentBox.Add(box);
            }
            else
            {
                siblings.Add(box);
            }

            viewToBox[node] = box;

            foreach (var child in node.PersistedChildren)
            {
                BuildNode(child, position, box, siriusElement, siblings, viewToBox);
            }

            // A label whose persisted geometry lies inside a leaf box is Capella's inside label,
            // rendered centered in the shape — the persisted text bounds are a render artifact, so
            // they are dropped in favor of centering. An outside label (an icon caption, a border
            // label) and a container title keep their persisted geometry.
            if (box.Children.Count == 0 && box.Label is { Position: { } labelPosition } insideLabel && Contains(box, labelPosition))
            {
                insideLabel.Position = null;
                insideLabel.Width = null;
                insideLabel.Height = null;
            }
        }

        /// <summary>
        /// Whether a point lies within the box's bounds.
        /// </summary>
        /// <param name="box">the box</param>
        /// <param name="point">the point to test</param>
        /// <returns>true when the point is inside the box</returns>
        private static bool Contains(Box box, Point point)
        {
            return point.X >= box.Position.X
                && point.Y >= box.Position.Y
                && point.X <= box.Position.X + (box.Width ?? 0)
                && point.Y <= box.Position.Y + (box.Height ?? 0);
        }

        /// <summary>
        /// Builds the edge for a notation edge: its ends resolve through the view-to-box map, and
        /// its absolute route comes from the persisted relative bendpoints resolved against the
        /// source anchor (falling back to the target anchor when only the target end is known).
        /// </summary>
        /// <param name="notationEdge">the notation edge</param>
        /// <param name="viewToBox">the notation-view-to-box map</param>
        /// <returns>the edge</returns>
        private static Edge BuildEdge(NotationModel.IEdge notationEdge, Dictionary<NotationModel.IView, Box> viewToBox)
        {
            var siriusEdge = notationEdge.Element as SiriusDiagramModel.IDEdge;

            var source = FindBox(notationEdge.Source, viewToBox);
            var target = FindBox(notationEdge.Target, viewToBox);

            var sourceAnchor = source == null ? (Point?)null : AnchorPoint(source, notationEdge.SourceAnchor);
            var targetAnchor = target == null ? (Point?)null : AnchorPoint(target, notationEdge.TargetAnchor);

            var route = BuildRoute(notationEdge.Bendpoints, sourceAnchor, targetAnchor);

            var edge = new Edge(siriusEdge?.Id ?? notationEdge.Id ?? string.Empty, route, notationEdge, BuildStyle(siriusEdge, notationEdge.Styles))
            {
                Source = source,
                Target = target,
                SiriusElement = siriusEdge,
                SemanticElement = siriusEdge?.Target,
            };

            var edgeName = siriusEdge?.Name;
            if (!string.IsNullOrEmpty(edgeName))
            {
                edge.Label = new Label(edgeName!);
            }

            edge.Style.Resolved = StyleResolver.Resolve(edge);

            return edge;
        }

        /// <summary>
        /// The persisted position offset of a view relative to its parent: the location part of its
        /// layout constraint, with an unpersisted coordinate contributing zero.
        /// </summary>
        /// <param name="constraint">the view's layout constraint, or <c>null</c></param>
        /// <returns>the relative offset</returns>
        private static Point Offset(NotationModel.ILayoutConstraint? constraint)
        {
            return constraint is NotationModel.ILocation location
                ? new Point(location.X ?? 0, location.Y ?? 0)
                : new Point(0, 0);
        }

        /// <summary>
        /// The persisted size of a view: the size part of its layout constraint, with GMF's
        /// <c>-1</c> sentinel (and an absent value) mapping to <c>null</c> (no persisted size).
        /// </summary>
        /// <param name="constraint">the view's layout constraint, or <c>null</c></param>
        /// <returns>the persisted width and height</returns>
        private static (double? Width, double? Height) Size(NotationModel.ILayoutConstraint? constraint)
        {
            return constraint is NotationModel.ISize size
                ? (Dimension(size.Width), Dimension(size.Height))
                : (null, null);
        }

        /// <summary>
        /// Maps a persisted dimension to its model value: <c>null</c> for an absent value or GMF's
        /// <c>-1</c> "not set" sentinel.
        /// </summary>
        /// <param name="value">the raw persisted dimension</param>
        /// <returns>the dimension, or <c>null</c> when not persisted</returns>
        private static double? Dimension(int? value)
        {
            return value is null or -1 ? null : value.Value;
        }

        /// <summary>
        /// Builds the absolute route polyline. GMF persists each bendpoint as offsets from both end
        /// anchors; the source-relative offsets are resolved when the source end is known, else the
        /// target-relative ones. Without bendpoints the route is the straight anchor-to-anchor line;
        /// without any resolvable end the route is empty.
        /// </summary>
        /// <param name="bendpoints">the notation edge's persisted bendpoints</param>
        /// <param name="sourceAnchor">the absolute source anchor point, when the source box is known</param>
        /// <param name="targetAnchor">the absolute target anchor point, when the target box is known</param>
        /// <returns>the absolute route polyline</returns>
        private static IReadOnlyList<Point> BuildRoute(NotationModel.IBendpoints? bendpoints, Point? sourceAnchor, Point? targetAnchor)
        {
            var relativeBendpoints = ParseBendpoints((bendpoints as NotationModel.IRelativeBendpoints)?.Points);

            if (relativeBendpoints.Count > 0)
            {
                if (sourceAnchor is { } fromSource)
                {
                    return relativeBendpoints.Select(bendpoint => fromSource + bendpoint.SourceRelative).ToList();
                }

                if (targetAnchor is { } fromTarget)
                {
                    return relativeBendpoints.Select(bendpoint => fromTarget + bendpoint.TargetRelative).ToList();
                }
            }

            if (sourceAnchor is { } start && targetAnchor is { } end)
            {
                return new List<Point> { start, end };
            }

            return Array.Empty<Point>();
        }

        /// <summary>
        /// The absolute anchor point on a box: the box position plus the anchor fraction of its
        /// persisted size. A missing or non-identity anchor is the GMF default, the view's center;
        /// an unpersisted dimension contributes no offset.
        /// </summary>
        /// <param name="box">the box the edge end attaches to</param>
        /// <param name="anchor">the persisted anchor, or <c>null</c></param>
        /// <returns>the absolute anchor point</returns>
        private static Point AnchorPoint(Box box, NotationModel.IAnchor? anchor)
        {
            return FractionPoint(box, ParseAnchorFraction(anchor) ?? CenterAnchor);
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
        /// The absolute point at a fraction of the box's persisted size; an unpersisted dimension
        /// contributes no offset.
        /// </summary>
        /// <param name="box">the box</param>
        /// <param name="fraction">the fraction of the box's size</param>
        /// <returns>the absolute point</returns>
        private static Point FractionPoint(Box box, Point fraction)
        {
            return box.Position + new Point(fraction.X * (box.Width ?? 0), fraction.Y * (box.Height ?? 0));
        }

        /// <summary>
        /// Parses a GMF <c>IdentityAnchor</c> id of the form <c>(0.25,0.5)</c> into its fraction,
        /// or <c>null</c> when no identity anchor is persisted or the value is malformed.
        /// </summary>
        /// <param name="anchor">the persisted anchor, or <c>null</c></param>
        /// <returns>the anchor fraction of the view's size, or <c>null</c></returns>
        private static Point? ParseAnchorFraction(NotationModel.IAnchor? anchor)
        {
            var anchorId = (anchor as NotationModel.IIdentityAnchor)?.Id;

            if (string.IsNullOrEmpty(anchorId))
            {
                return null;
            }

            var parts = anchorId!.Trim('(', ')').Split(',');
            if (parts.Length == 2
                && double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var x)
                && double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var y))
            {
                return new Point(x, y);
            }

            return null;
        }

        /// <summary>
        /// Parses a GMF <c>RelativeBendpointList</c> of the form
        /// <c>[sx, sy, tx, ty]$[sx, sy, tx, ty]…</c> — per bendpoint the offsets from the source
        /// and the target anchor — skipping malformed entries.
        /// </summary>
        /// <param name="points">the raw persisted bendpoint list</param>
        /// <returns>the parsed bendpoints</returns>
        private static List<(Point SourceRelative, Point TargetRelative)> ParseBendpoints(string? points)
        {
            var result = new List<(Point, Point)>();

            if (string.IsNullOrEmpty(points))
            {
                return result;
            }

            foreach (var segment in points!.Split('$'))
            {
                var values = segment.Trim().Trim('[', ']').Split(',');
                if (values.Length == 4
                    && double.TryParse(values[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var sourceX)
                    && double.TryParse(values[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var sourceY)
                    && double.TryParse(values[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var targetX)
                    && double.TryParse(values[3], NumberStyles.Float, CultureInfo.InvariantCulture, out var targetY))
                {
                    result.Add((new Point(sourceX, sourceY), new Point(targetX, targetY)));
                }
            }

            return result;
        }

        /// <summary>
        /// Resolves the box an edge end attaches to, walking the view-to-box map (auxiliary views
        /// are mapped to their enclosing box).
        /// </summary>
        /// <param name="view">the notation view the edge end references, or <c>null</c></param>
        /// <param name="viewToBox">the notation-view-to-box map</param>
        /// <returns>the box, or <c>null</c> when the end does not resolve to one</returns>
        private static Box? FindBox(NotationModel.IView? view, Dictionary<NotationModel.IView, Box> viewToBox)
        {
            return view != null && viewToBox.TryGetValue(view, out var box) ? box : null;
        }

        /// <summary>
        /// Builds the styling sources of an item: the Sirius element's owned style (declared on the
        /// concrete <c>DNode</c> / <c>DNodeListElement</c> / container / <c>DEdge</c> types) and the
        /// notation view's styles.
        /// </summary>
        /// <param name="siriusElement">the Sirius element the view displays, or <c>null</c></param>
        /// <param name="notationStyles">the notation view's styles</param>
        /// <returns>the styling sources</returns>
        private static Style BuildStyle(object? siriusElement, IEnumerable<NotationModel.IStyle> notationStyles)
        {
            SiriusViewpoint.IStyle? siriusStyle = siriusElement switch
            {
                SiriusDiagramModel.IDNode node => node.OwnedStyle,
                SiriusDiagramModel.IDNodeListElement listElement => listElement.OwnedStyle,
                SiriusDiagramModel.IDDiagramElementContainer container => container.OwnedStyle,
                SiriusDiagramModel.IDEdge edge => edge.OwnedStyle,
                _ => null,
            };

            return new Style(siriusStyle, notationStyles.ToList());
        }
    }
}
