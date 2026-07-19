// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramBuilderBase.cs" company="Starion Group S.A.">
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
    /// The representation-kind-agnostic core of diagram building: walks a representation's
    /// persisted GMF notation tree (stored in its <c>GMF_DIAGRAMS</c> annotation entry), pairing
    /// each notation view with the Sirius representation element it displays (the view's
    /// <c>element</c> reference) and that element's resolved Capella semantic <c>target</c>.
    /// Layout is consumed from the persisted coordinates — positions are accumulated to absolute,
    /// never computed. A concrete builder contributes the layout rules of its representation kind
    /// through <see cref="ApplyRepresentationRules"/>; all kind-specific knowledge lives in the
    /// builders, expressed as intermediate-model data (<see cref="ShapeKind"/>, framed labels,
    /// line patterns), so <see cref="SvgExporter"/> and <see cref="StyleResolver"/> stay
    /// kind-agnostic.
    /// </summary>
    public abstract class DiagramBuilderBase
    {
        /// <summary>
        /// The default anchor fraction: GMF anchors default to the center of the view when no
        /// <c>IdentityAnchor</c> is persisted.
        /// </summary>
        private static readonly Point CenterAnchor = new(0.5, 0.5);

        /// <summary>
        /// The resolver producing each built item's <see cref="ResolvedStyle"/>.
        /// </summary>
        private readonly IStyleResolver styleResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramBuilderBase"/> class.
        /// </summary>
        /// <param name="styleResolver">the resolver producing each built item's resolved style</param>
        /// <exception cref="ArgumentNullException">the resolver is null</exception>
        protected DiagramBuilderBase(IStyleResolver styleResolver)
        {
            this.styleResolver = styleResolver ?? throw new ArgumentNullException(nameof(styleResolver));
        }

        /// <summary>
        /// Builds the intermediate model of the supplied Sirius representation: the generic
        /// notation walk followed by the builder's representation-kind rules.
        /// </summary>
        /// <param name="siriusDiagram">the parsed Sirius representation (e.g. a <c>DSemanticDiagram</c>)</param>
        /// <param name="name">
        /// the diagram name, or <c>null</c>; the name lives on the <c>DRepresentationDescriptor</c>
        /// in the <c>DAnalysis</c> rather than on the representation, so the caller supplies it
        /// </param>
        /// <returns>the intermediate diagram model</returns>
        /// <exception cref="ArgumentNullException">the representation is null</exception>
        /// <exception cref="InvalidOperationException">the representation carries no GMF notation diagram</exception>
        public Diagram Build(SiriusDiagramModel.IDDiagram siriusDiagram, string? name = null)
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
                this.BuildNode(child, new Point(0, 0), null, siriusDiagram, rootBoxes, viewToBox);
            }

            var edges = notationDiagram.PersistedEdges
                .Select(notationEdge => this.BuildEdge(notationEdge, viewToBox))
                .ToList();

            this.ApplyRepresentationRules(rootBoxes, edges);

            return new Diagram(siriusDiagram.Id ?? string.Empty, rootBoxes, edges, siriusDiagram, notationDiagram)
            {
                Name = name,
                SemanticElement = (siriusDiagram as SiriusViewpoint.IDSemanticDecorator)?.Target,
            };
        }

        /// <summary>
        /// Applies the layout rules of the builder's representation kind, after the generic
        /// notation walk has produced the boxes and edges. The rules mutate the built model in
        /// place — repositioning boxes, rerouting edges, adding synthetic edges — and express every
        /// kind difference as intermediate-model data, keeping the exporter kind-agnostic.
        /// </summary>
        /// <param name="rootBoxes">the top-level boxes, in notation order</param>
        /// <param name="edges">the built edges, to which synthetic edges may be added</param>
        protected abstract void ApplyRepresentationRules(List<Box> rootBoxes, List<Edge> edges);

        /// <summary>
        /// Finds the GMF notation diagram persisted in the representation's <c>GMF_DIAGRAMS</c>
        /// annotation entry.
        /// </summary>
        /// <param name="siriusDiagram">the Sirius representation</param>
        /// <returns>the notation diagram, or <c>null</c> when the representation carries none</returns>
        internal static NotationModel.IDiagram? FindNotationDiagram(SiriusDiagramModel.IDDiagram siriusDiagram)
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
        private void BuildNode(NotationModel.INode node, Point origin, Box? parentBox, object? parentSiriusElement, List<Box> siblings, Dictionary<NotationModel.IView, Box> viewToBox)
        {
            var position = origin + Offset(node.LayoutConstraint);
            var (width, height) = Size(node.LayoutConstraint);

            var siriusElement = node.Element as SiriusDiagramModel.IDDiagramElement;
            var absoluteBounds = ApplyAbsoluteBounds(siriusElement, ref position, ref width, ref height);

            // A GMF note is a pure notation element with no Sirius counterpart: a sticky box whose
            // text lives in the shape's own description and whose colors are the shape's own styles.
            if (siriusElement == null && node is NotationModel.IShape noteShape && !string.IsNullOrEmpty(noteShape.Description))
            {
                Attach(this.BuildNote(node, noteShape, position, width, height), node, parentBox, siblings, viewToBox);
                return;
            }

            if (siriusElement == null || ReferenceEquals(siriusElement, parentSiriusElement))
            {
                this.FoldAuxiliaryNode(node, position, width, height, parentBox, parentSiriusElement, siblings, viewToBox);
                return;
            }

            var box = new Box(siriusElement.Id ?? node.Id ?? string.Empty, position, node, BuildStyle(siriusElement, node.Styles))
            {
                Width = width,
                Height = height,
                HasAbsoluteBounds = absoluteBounds,
                SiriusElement = siriusElement,
                SemanticElement = siriusElement.Target,
            };

            var elementName = siriusElement.Name;
            if (!string.IsNullOrEmpty(elementName))
            {
                box.Label = new Label(elementName);
            }

            box.Style.Resolved = this.styleResolver.Resolve(box);

            Attach(box, node, parentBox, siblings, viewToBox);

            foreach (var child in node.PersistedChildren)
            {
                this.BuildNode(child, position, box, siriusElement, siblings, viewToBox);
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
        /// Applies a Sirius <c>AbsoluteBoundsFilter</c> when the element carries one: Sirius
        /// persists the layout of sequence-diagram elements (instance roles, executions, states,
        /// fragments) in the filter, in absolute coordinates — the GMF child coordinates are only
        /// render-time artifacts there, so the filter is the layout truth.
        /// </summary>
        /// <param name="siriusElement">the Sirius element the view displays, or <c>null</c></param>
        /// <param name="position">the accumulated relative position, replaced by the filter's</param>
        /// <param name="width">the persisted width, replaced by the filter's</param>
        /// <param name="height">the persisted height, replaced by the filter's</param>
        /// <returns>true when a filter applied</returns>
        private static bool ApplyAbsoluteBounds(SiriusDiagramModel.IDDiagramElement? siriusElement, ref Point position, ref double? width, ref double? height)
        {
            var absoluteBounds = siriusElement?.GraphicalFilters.OfType<SiriusDiagramModel.IAbsoluteBoundsFilter>().FirstOrDefault();
            if (absoluteBounds == null)
            {
                return false;
            }

            position = new Point(absoluteBounds.X ?? position.X, absoluteBounds.Y ?? position.Y);
            width = Dimension(absoluteBounds.Width) ?? width;
            height = Dimension(absoluteBounds.Height) ?? height;
            return true;
        }

        /// <summary>
        /// Builds the box of a GMF note: its own shape styles supply the fill and font, and its
        /// description text becomes a left-aligned label wrapped to the note's width.
        /// </summary>
        /// <param name="node">the notation node</param>
        /// <param name="noteShape">the same node, as the shape carrying the note's description and styles</param>
        /// <param name="position">the absolute position</param>
        /// <param name="width">the persisted width</param>
        /// <param name="height">the persisted height</param>
        /// <returns>the note box, style resolved</returns>
        private Box BuildNote(NotationModel.INode node, NotationModel.IShape noteShape, Point position, double? width, double? height)
        {
            var note = new Box(node.Id ?? string.Empty, position, node, BuildStyle(null, node.Styles.Concat(new NotationModel.IStyle[] { noteShape })))
            {
                Width = width,
                Height = height,
                Label = new Label(noteShape.Description!)
                {
                    Position = position + new Point(4, 2),
                    Width = Math.Max(1, (width ?? 100) - 8),
                },
            };

            note.Style.Resolved = this.styleResolver.Resolve(note);
            return note;
        }

        /// <summary>
        /// Folds an auxiliary node — a label or compartment, recognizable by carrying no Sirius
        /// element of its own — into the enclosing box: a childless label node contributes its
        /// geometry to the box's label, a compartment's children keep nesting into the box, and
        /// edges attaching to the auxiliary view route to the enclosing box.
        /// </summary>
        /// <param name="node">the auxiliary notation node</param>
        /// <param name="position">the node's absolute position</param>
        /// <param name="width">the node's persisted width</param>
        /// <param name="height">the node's persisted height</param>
        /// <param name="parentBox">the enclosing box, or <c>null</c> at the diagram level</param>
        /// <param name="parentSiriusElement">the Sirius element the parent view displays</param>
        /// <param name="siblings">the list a nested real box is added to when there is no enclosing box</param>
        /// <param name="viewToBox">the notation-view-to-box map</param>
        private void FoldAuxiliaryNode(NotationModel.INode node, Point position, double? width, double? height, Box? parentBox, object? parentSiriusElement, List<Box> siblings, Dictionary<NotationModel.IView, Box> viewToBox)
        {
            if (parentBox != null)
            {
                if (node.PersistedChildren.Count == 0 && node.LayoutConstraint is NotationModel.ILocation && parentBox.Label is { Position: null } label)
                {
                    label.Position = position;
                    label.Width = width;
                    label.Height = height;
                }

                viewToBox[node] = parentBox;
            }

            foreach (var child in node.PersistedChildren)
            {
                this.BuildNode(child, position, parentBox, parentSiriusElement, siblings, viewToBox);
            }
        }

        /// <summary>
        /// Attaches a built box to its enclosing box (or the top level) and registers its notation
        /// view for edge-end resolution.
        /// </summary>
        /// <param name="box">the built box</param>
        /// <param name="node">the notation node the box was built from</param>
        /// <param name="parentBox">the enclosing box, or <c>null</c> at the diagram level</param>
        /// <param name="siblings">the top-level list used when there is no enclosing box</param>
        /// <param name="viewToBox">the notation-view-to-box map</param>
        private static void Attach(Box box, NotationModel.INode node, Box? parentBox, List<Box> siblings, Dictionary<NotationModel.IView, Box> viewToBox)
        {
            if (parentBox != null)
            {
                parentBox.Add(box);
            }
            else
            {
                siblings.Add(box);
            }

            viewToBox[node] = box;
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
        private Edge BuildEdge(NotationModel.IEdge notationEdge, Dictionary<NotationModel.IView, Box> viewToBox)
        {
            var siriusEdge = notationEdge.Element as SiriusDiagramModel.IDEdge;

            var source = FindBox(notationEdge.Source, viewToBox);
            var target = FindBox(notationEdge.Target, viewToBox);

            var route = BuildRoute(notationEdge, source, target);

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

            edge.Style.Resolved = this.styleResolver.Resolve(edge);

            // A note attachment is not a model relationship: Capella draws it as a thin dotted
            // line between the note and the element it annotates.
            if (string.Equals(notationEdge.Type, "NoteAttachment", StringComparison.Ordinal))
            {
                edge.Style.Resolved.Pattern = LinePattern.Dot;
            }

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
        /// Builds the absolute route polyline. GMF persists the connection's two endpoints as the
        /// first and last entries of the bendpoint list but recomputes them at render time — an
        /// endpoint is the intersection of the line from the anchor's reference point (the
        /// persisted anchor ratio, center by default) toward the adjacent route point with the
        /// node's bounds (GMF's slidable-anchor rule), so the persisted first and last entries are
        /// stale artifacts. Only the entries between them are real bends, resolved against the
        /// source reference. When only one end resolves to a box, the artifact offsets are kept
        /// for the unknown end and the known end is clipped to its box; without any resolvable
        /// end the route is empty.
        /// </summary>
        /// <param name="notationEdge">the notation edge carrying the anchors and bendpoints</param>
        /// <param name="source">the source box, or <c>null</c> when the end does not resolve to one</param>
        /// <param name="target">the target box, or <c>null</c> when the end does not resolve to one</param>
        /// <returns>the absolute route polyline</returns>
        private static IReadOnlyList<Point> BuildRoute(NotationModel.IEdge notationEdge, Box? source, Box? target)
        {
            var bendpoints = ParseBendpoints((notationEdge.Bendpoints as NotationModel.IRelativeBendpoints)?.Points);
            var sourceReference = source == null ? (Point?)null : AnchorPoint(source, notationEdge.SourceAnchor);
            var targetReference = target == null ? (Point?)null : AnchorPoint(target, notationEdge.TargetAnchor);

            if (sourceReference is { } refSource && targetReference is { } refTarget)
            {
                var intermediates = new List<Point>();
                for (var i = 1; i < bendpoints.Count - 1; i++)
                {
                    intermediates.Add(refSource + bendpoints[i].SourceRelative);
                }

                var route = new List<Point>
                {
                    ClipToBoundary(source!, refSource, intermediates.Count > 0 ? intermediates[0] : refTarget),
                };
                route.AddRange(intermediates);
                route.Add(ClipToBoundary(target!, refTarget, intermediates.Count > 0 ? intermediates[^1] : refSource));

                return route;
            }

            if (bendpoints.Count > 0 && sourceReference is { } soleSource)
            {
                var route = bendpoints.Select(bendpoint => soleSource + bendpoint.SourceRelative).ToList();
                route[0] = route.Count > 1 ? ClipToBoundary(source!, soleSource, route[1]) : route[0];
                return route;
            }

            if (bendpoints.Count > 0 && targetReference is { } soleTarget)
            {
                var route = bendpoints.Select(bendpoint => soleTarget + bendpoint.TargetRelative).ToList();
                route[^1] = route.Count > 1 ? ClipToBoundary(target!, soleTarget, route[^2]) : route[^1];
                return route;
            }

            return Array.Empty<Point>();
        }

        /// <summary>
        /// The point where the segment from an anchor reference point toward the adjacent route
        /// point crosses the box's boundary — the endpoint GMF's slidable anchor computes at
        /// render time. When the segment never crosses the boundary (the reference sits on the
        /// boundary already facing outward, the adjacent point lies inside the box, or the
        /// geometry is degenerate) the reference point itself stands.
        /// </summary>
        /// <param name="box">the box the edge end attaches to</param>
        /// <param name="reference">the anchor reference point, on or in the box</param>
        /// <param name="toward">the adjacent route point the edge heads to</param>
        /// <returns>the boundary crossing, or the reference point</returns>
        private static Point ClipToBoundary(Box box, Point reference, Point toward)
        {
            var deltaX = toward.X - reference.X;
            var deltaY = toward.Y - reference.Y;

            double exitX;
            if (deltaX > 0)
            {
                exitX = (box.Position.X + (box.Width ?? 0) - reference.X) / deltaX;
            }
            else if (deltaX < 0)
            {
                exitX = (box.Position.X - reference.X) / deltaX;
            }
            else
            {
                exitX = double.PositiveInfinity;
            }

            double exitY;
            if (deltaY > 0)
            {
                exitY = (box.Position.Y + (box.Height ?? 0) - reference.Y) / deltaY;
            }
            else if (deltaY < 0)
            {
                exitY = (box.Position.Y - reference.Y) / deltaY;
            }
            else
            {
                exitY = double.PositiveInfinity;
            }

            var exit = Math.Min(exitX, exitY);

            if (double.IsInfinity(exit) || exit < 0 || exit >= 1)
            {
                return reference;
            }

            return reference + new Point(exit * deltaX, exit * deltaY);
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
        /// The absolute point at a fraction of the box's persisted size; an unpersisted dimension
        /// contributes no offset.
        /// </summary>
        /// <param name="box">the box</param>
        /// <param name="fraction">the fraction of the box's size</param>
        /// <returns>the absolute point</returns>
        protected static Point FractionPoint(Box box, Point fraction)
        {
            return box.Position + new Point(fraction.X * (box.Width ?? 0), fraction.Y * (box.Height ?? 0));
        }

        /// <summary>
        /// Parses a GMF <c>IdentityAnchor</c> id of the form <c>(0.25,0.5)</c> into its fraction,
        /// or <c>null</c> when no identity anchor is persisted or the value is malformed.
        /// </summary>
        /// <param name="anchor">the persisted anchor, or <c>null</c></param>
        /// <returns>the anchor fraction of the view's size, or <c>null</c></returns>
        protected static Point? ParseAnchorFraction(NotationModel.IAnchor? anchor)
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
        protected static List<(Point SourceRelative, Point TargetRelative)> ParseBendpoints(string? points)
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
