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

            // Fill the sizes Capella auto-computes and never persists — before the edges route, so
            // an edge clips to its box's synthesized bounds instead of a collapsed footprint.
            this.SynthesizeUnpersistedSizes(rootBoxes);

            // A hidden edge (its GMF view persists visible="false") is excluded like a hidden node,
            // so a hidden component-exchange or communication-means relationship draws no stray line.
            var edges = notationDiagram.PersistedEdges
                .Where(notationEdge => notationEdge.Visible != false)
                .Select(notationEdge => this.BuildEdge(notationEdge, viewToBox))
                .ToList();

            this.ApplyRepresentationRules(rootBoxes, edges);

            // Two exchanges between the same boxes with no distinguishing bendpoints resolve to one
            // coincident line with their labels stacked; fan them into distinct parallel routes.
            SeparateCoincidentEdges(edges);

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

            // A diagram element Capella hides — its GMF view persists visible="false", whether it is
            // hidden from the diagram (a HideFilter) or a child folded away by a collapsed container
            // (a CollapseFilter) — must not render: skip the node and its whole subtree. The layout
            // persisted for it is stale, piling the subtree at the origin and inflating the canvas.
            if (siriusElement != null && node.Visible == false)
            {
                return;
            }

            var absoluteBounds = ApplyAbsoluteBounds(siriusElement, ref position, ref width, ref height);

            // A GMF note is a pure notation element with no Sirius counterpart: a sticky box whose
            // text lives in the shape's own description and whose colors are the shape's own styles.
            // A GMF note — a Shape carrying a description, or (as an [LCBD]'s annotation notes) a
            // plain Node of type "Note" whose text lives on its ShapeStyle — becomes a note box.
            var isNote = string.Equals(node.Type, "Note", StringComparison.Ordinal)
                || (node is NotationModel.IShape noteShape && !string.IsNullOrEmpty(noteShape.Description));

            if (siriusElement == null && isNote && NoteText(node) is { } noteText)
            {
                Attach(this.BuildNote(node, noteText, position, width, height), node, parentBox, siblings, viewToBox);
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

            // A glyph-only element carries no name label. A port (a function/component/physical
            // port) is suppressed so the FIP/FOP/CP/PP text never renders beside its border glyph;
            // a state machine's pseudo-states and final state render as their glyph or diamond, and
            // a region is an unnamed compartment whose "[Region1]" placeholder must not sit in the
            // owning state's title band. A Mode/State keeps its name — it is not glyph-only.
            var glyphOnly = box.SemanticElement is Auriga.Model.Information.IPort
                or Auriga.Model.Capellacommon.IPseudostate
                or Auriga.Model.Capellacommon.IFinalState
                or Auriga.Model.Capellacommon.IRegion;

            var elementName = siriusElement.Name;
            if (!glyphOnly && !string.IsNullOrEmpty(elementName))
            {
                box.Label = new Label(elementName)
                {
                    IconPath = TypeIconPath(box.SemanticElement, box.Style.SiriusStyle as SiriusViewpoint.IBasicLabelStyle),
                };
            }

            box.Style.Resolved = this.styleResolver.Resolve(box);

            Attach(box, node, parentBox, siblings, viewToBox);

            foreach (var child in node.PersistedChildren)
            {
                this.BuildNode(child, position, box, siriusElement, siblings, viewToBox);
            }

            PlaceTitle(box);

            if (siriusElement is SiriusDiagramModel.IDNodeList)
            {
                ApplyListContainerLayout(box);
            }
        }

        /// <summary>
        /// Positions a box's title. An outside label (a caption below an icon, a border label)
        /// keeps its persisted geometry. A childless box centers its title in the shape — Capella's
        /// inside label, whose persisted text bounds are a render artifact. A box with children —
        /// a container or a ported function — pins its title to the top band, centered
        /// horizontally, so it sits above the children instead of overlapping them.
        /// </summary>
        /// <param name="box">the box whose title is placed</param>
        private static void PlaceTitle(Box box)
        {
            if (box.Label is not { } label)
            {
                return;
            }

            if (label.Position is { } labelPosition && !Contains(box, labelPosition))
            {
                return;
            }

            label.Position = null;
            label.Width = null;
            label.Height = null;
            label.PinTop = box.Children.Count > 0;
        }

        /// <summary>
        /// The trimmed text of an edge's begin/end label when it carries a real value, or
        /// <c>null</c> when it is absent or Capella's <c>"."</c> placeholder (persisted for an
        /// end label a mapping declares but the element leaves empty — it must not render).
        /// </summary>
        /// <param name="label">the raw persisted begin/end label, or <c>null</c></param>
        /// <returns>the meaningful label text, or <c>null</c></returns>
        private static string? MeaningfulLabel(string? label)
        {
            var trimmed = label?.Trim();
            return string.IsNullOrEmpty(trimmed) || trimmed == "." ? null : trimmed;
        }

        /// <summary>
        /// The metaclass-icon path of a label — Capella prefixes labels with the small icon of
        /// the semantic element's type — or <c>null</c> when there is no semantic element or the
        /// Sirius label style suppresses the icon (<c>showIcon="false"</c>, as workspace-image
        /// styles persist).
        /// </summary>
        /// <param name="semanticElement">the resolved Capella semantic element, or <c>null</c></param>
        /// <param name="labelStyle">the Sirius label style governing the label, or <c>null</c></param>
        /// <returns>the icon path (e.g. <c>Class.png</c>), or <c>null</c></returns>
        private static string? TypeIconPath(object? semanticElement, SiriusViewpoint.IBasicLabelStyle? labelStyle)
        {
            if (semanticElement == null || labelStyle?.ShowIcon == false)
            {
                return null;
            }

            return $"{semanticElement.GetType().Name}.png";
        }

        /// <summary>
        /// The horizontal space a label's metaclass icon occupies before the text (the icon plus
        /// its gap), mirrored by the exporter.
        /// </summary>
        internal const double LabelIconSpace = 14;

        /// <summary>
        /// The height of a list container's title compartment above the title font size.
        /// </summary>
        private const double ListTitlePadding = 12;

        /// <summary>
        /// The horizontal inset of a list item row from the container's edge.
        /// </summary>
        private const double ListItemIndent = 6;

        /// <summary>
        /// The estimated width of a glyph as a fraction of the font size, matching the exporter's
        /// wrapping estimate.
        /// </summary>
        private const double GlyphWidthRatio = 0.6;

        /// <summary>
        /// Lays out a list container (a <c>DNodeList</c> — a class, enumeration or interface):
        /// Capella auto-sizes these from their content, persisting only a position, and stacks the
        /// <c>DNodeListElement</c> children as left-aligned rows in a compartment below the title.
        /// The size is estimated from the title and item texts when unpersisted (a persisted size
        /// is kept), the title centers in its compartment above a separator rule, and the item
        /// rows become transparent single-line boxes.
        /// </summary>
        /// <param name="box">the list container's built box, its children in place</param>
        private static void ApplyListContainerLayout(Box box)
        {
            var titleFontSize = box.Style.Resolved.FontSize;
            var titleHeight = titleFontSize + ListTitlePadding;
            var items = box.Children.Where(child => child.SiriusElement is SiriusDiagramModel.IDNodeListElement).ToList();

            if (box.Width == null)
            {
                var width = ((box.Label?.Text.Length ?? 0) * titleFontSize * GlyphWidthRatio) + (4 * ListItemIndent) + IconSpace(box.Label);
                foreach (var item in items)
                {
                    width = Math.Max(width, ((item.Label?.Text.Length ?? 0) * item.Style.Resolved.FontSize * GlyphWidthRatio) + (2 * ListItemIndent) + IconSpace(item.Label));
                }

                box.Width = Math.Max(50, width);
            }

            var rowTop = box.Position.Y + titleHeight;
            foreach (var item in items)
            {
                var rowHeight = item.Style.Resolved.FontSize + 6;
                item.Position = new Point(box.Position.X + ListItemIndent, rowTop);
                item.Width = box.Width - (2 * ListItemIndent);
                item.Height = rowHeight;
                item.Style.Resolved.FillColor = null;
                item.Style.Resolved.GradientColor = null;
                item.Style.Resolved.StrokeWidth = 0;

                if (item.Label is { } itemLabel)
                {
                    itemLabel.Position = new Point(item.Position.X, rowTop + ((rowHeight - item.Style.Resolved.FontSize) / 2));
                    itemLabel.Width = null;
                    itemLabel.Height = null;
                }

                rowTop += rowHeight;
            }

            box.Height ??= (rowTop - box.Position.Y) + (items.Count == 0 ? ListTitlePadding : 4);

            // The title centers in its own compartment (not the whole box); without a measured
            // text width the centering is estimated from the glyph ratio, the icon included.
            if (box.Label is { } title)
            {
                var estimatedWidth = (title.Text.Length * titleFontSize * GlyphWidthRatio) + IconSpace(title);
                title.Position = new Point(box.Position.X + ((box.Width.Value - estimatedWidth) / 2), box.Position.Y + ((titleHeight - titleFontSize) / 2));
                title.Width = null;
                title.Height = null;
            }

            // The separator rule between the title and the list compartment, drawn as a synthetic
            // horizontal line child in the container's stroke color.
            var separator = new Box($"{box.Identifier}-title-separator", new Point(box.Position.X, box.Position.Y + titleHeight), new NotationModel.Node(), new Style(null, new List<NotationModel.IStyle>()))
            {
                Width = box.Width,
                Height = 0,
            };
            separator.Style.Resolved.Shape = ShapeKind.Line;
            separator.Style.Resolved.FillColor = null;
            separator.Style.Resolved.StrokeColor = box.Style.Resolved.StrokeColor;
            separator.Style.Resolved.StrokeWidth = 1;
            box.Add(separator);
        }

        /// <summary>
        /// The horizontal space a label's icon will occupy in the exporter: the icon slot when the
        /// label carries one, nothing otherwise.
        /// </summary>
        /// <param name="label">the label, or <c>null</c></param>
        /// <returns>the icon space</returns>
        private static double IconSpace(Label? label)
        {
            return label?.IconPath == null ? 0 : LabelIconSpace;
        }

        /// <summary>
        /// The GMF default footprint of a border port. Capella persists an unsized port as the
        /// <c>1×1</c> sentinel (or nothing) but renders its glyph at this size; giving the port
        /// this footprint keeps the glyph visible and its attached edges anchored.
        /// </summary>
        private const double PortFootprint = 10;

        /// <summary>
        /// The floor a synthesized node size never drops below, so a box with neither children nor
        /// a label still occupies the default footprint rather than collapsing.
        /// </summary>
        private const double MinNodeSize = 10;

        /// <summary>
        /// Synthesizes the unpersisted sizes of the built boxes. Overridden to a no-op by a
        /// representation kind whose layout keeps unpersisted sizes meaningful — a sequence diagram
        /// persists every element's absolute bounds and routes a self-message against a target left
        /// unsized on purpose, so it must not synthesize.
        /// </summary>
        /// <param name="rootBoxes">the top-level boxes, with their children</param>
        protected virtual void SynthesizeUnpersistedSizes(IReadOnlyList<Box> rootBoxes)
        {
            SynthesizeSizes(rootBoxes);
        }

        /// <summary>
        /// Synthesizes the sizes Capella auto-computes and never persists (the GMF <c>-1</c>
        /// sentinel), depth-first so a container sizes after its children: a border port takes the
        /// default footprint, and any other auto-sized box grows to the extent of its children and
        /// its own label, so a function, component or state renders at its content size instead of
        /// the collapsed default footprint. A persisted size is always kept, per dimension.
        /// </summary>
        /// <param name="boxes">the boxes to size, with their children</param>
        private static void SynthesizeSizes(IEnumerable<Box> boxes)
        {
            foreach (var box in boxes)
            {
                SynthesizeSizes(box.Children);
                EnsureSize(box);
            }
        }

        /// <summary>
        /// Fills a box's unpersisted width and height. A border port takes the GMF default
        /// footprint, replacing the <c>1×1</c> sentinel. Any other auto-sized box takes, per
        /// dimension, the greater of its children's extent and its own label's estimated size (and
        /// never less than the floor), so its title and children stay inside.
        /// </summary>
        /// <param name="box">the box to size</param>
        private static void EnsureSize(Box box)
        {
            if (box.SemanticElement is Auriga.Model.Information.IPort)
            {
                box.Width = box.Width is null or <= 1 ? PortFootprint : box.Width;
                box.Height = box.Height is null or <= 1 ? PortFootprint : box.Height;
                return;
            }

            if (box.Width == null)
            {
                var childrenRight = box.Children.Count == 0 ? box.Position.X : box.Children.Max(child => child.Position.X + (child.Width ?? 0));
                var fromLabel = box.Label == null ? 0 : (box.Label.Text.Length * box.Style.Resolved.FontSize * GlyphWidthRatio) + (2 * ListItemIndent) + IconSpace(box.Label);
                box.Width = Math.Max(Math.Max(childrenRight - box.Position.X, fromLabel), MinNodeSize);
            }

            if (box.Height == null)
            {
                var childrenBottom = box.Children.Count == 0 ? box.Position.Y : box.Children.Max(child => child.Position.Y + (child.Height ?? 0));
                var fromLabel = box.Label == null ? 0 : box.Style.Resolved.FontSize + ListTitlePadding;
                box.Height = Math.Max(Math.Max(childrenBottom - box.Position.Y, fromLabel), MinNodeSize);
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
        /// The text of a GMF note (a node of type <c>Note</c>): the note shape's own
        /// <c>description</c>, or — when the note is a plain <c>Node</c> rather than a <c>Shape</c>,
        /// as an <c>[LCBD]</c>'s annotation notes persist it — the description carried by its
        /// <c>ShapeStyle</c>. <c>null</c> when neither carries text (an empty note).
        /// </summary>
        /// <param name="node">the notation node</param>
        /// <returns>the note text, or <c>null</c></returns>
        private static string? NoteText(NotationModel.INode node)
        {
            if (node is NotationModel.IShape shape && !string.IsNullOrEmpty(shape.Description))
            {
                return shape.Description;
            }

            return node.Styles
                .OfType<NotationModel.IShapeStyle>()
                .Select(style => style.Description)
                .FirstOrDefault(description => !string.IsNullOrEmpty(description));
        }

        /// <summary>
        /// Builds the box of a GMF note: its shape styles (and, when the note is a <c>Shape</c>, its
        /// own fill/font attributes) supply the styling, and its text becomes a left-aligned label
        /// wrapped to the note's width.
        /// </summary>
        /// <param name="node">the notation node</param>
        /// <param name="noteText">the resolved note text</param>
        /// <param name="position">the absolute position</param>
        /// <param name="width">the persisted width</param>
        /// <param name="height">the persisted height</param>
        /// <returns>the note box, style resolved</returns>
        private Box BuildNote(NotationModel.INode node, string noteText, Point position, double? width, double? height)
        {
            var styleSources = node is NotationModel.IShape noteShape
                ? node.Styles.Concat(new NotationModel.IStyle[] { noteShape })
                : node.Styles;

            var note = new Box(node.Id ?? string.Empty, position, node, BuildStyle(null, styleSources))
            {
                Width = width,
                Height = height,
                Label = new Label(noteText)
                {
                    Position = position + new Point(4, 2),
                    Width = Math.Max(1, (width ?? 100) - 8),
                },
            };

            note.Style.Resolved = this.styleResolver.Resolve(note);
            note.Style.Resolved.Shape = ShapeKind.Note;
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
        /// The perpendicular distance between the fanned-out routes of a coincident group. It is
        /// wide enough that the labels — which ride each route's midpoint — clear a line height when
        /// the run is near-horizontal (the offset then falls mostly along the vertical, spreading
        /// the stacked labels apart), so both the routes and their labels stay legible.
        /// </summary>
        private const double CoincidentEdgeGap = 16;

        /// <summary>
        /// Separates edges whose routes coincide: two exchanges between the same pair of boxes with
        /// no distinguishing bendpoints resolve to the same polyline and print their labels on top
        /// of one another. Each edge of a coincident group is shifted perpendicular to the run by a
        /// centred increment, fanning the group into distinct parallel routes; the labels follow,
        /// each riding its route's midpoint. A route and its reverse count as coincident, so a pair
        /// drawn in opposite directions along one chord is separated too.
        /// </summary>
        /// <param name="edges">the built edges, shifted in place</param>
        private static void SeparateCoincidentEdges(IReadOnlyList<Edge> edges)
        {
            foreach (var group in edges.Where(edge => edge.Route.Count >= 2).GroupBy(edge => RouteKey(edge.Route)))
            {
                var members = group.ToList();
                if (members.Count < 2)
                {
                    continue;
                }

                var route = members[0].Route;
                var perpendicular = Perpendicular(route[0], route[^1]);
                for (var i = 0; i < members.Count; i++)
                {
                    var offset = (i - ((members.Count - 1) / 2.0)) * CoincidentEdgeGap;
                    var shift = new Point(perpendicular.X * offset, perpendicular.Y * offset);
                    members[i].Route = members[i].Route.Select(point => point + shift).ToList();
                }
            }
        }

        /// <summary>
        /// A direction-independent key for a route: its points rounded to the pixel and ordered so
        /// that a route and its reverse share the key.
        /// </summary>
        /// <param name="route">the route points</param>
        /// <returns>the coincidence key</returns>
        private static string RouteKey(IReadOnlyList<Point> route)
        {
            var forward = string.Join(";", route.Select(point => $"{Math.Round(point.X)},{Math.Round(point.Y)}"));
            var reverse = string.Join(";", route.Reverse().Select(point => $"{Math.Round(point.X)},{Math.Round(point.Y)}"));
            return string.CompareOrdinal(forward, reverse) <= 0 ? forward : reverse;
        }

        /// <summary>
        /// The unit vector perpendicular to the run from one point to another, or zero when the
        /// points coincide.
        /// </summary>
        /// <param name="from">the run's start</param>
        /// <param name="to">the run's end</param>
        /// <returns>the perpendicular unit vector</returns>
        private static Point Perpendicular(Point from, Point to)
        {
            var deltaX = to.X - from.X;
            var deltaY = to.Y - from.Y;
            var length = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            return length < 0.001 ? new Point(0, 0) : new Point(-deltaY / length, deltaX / length);
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

            var route = BuildRoute(notationEdge, source, target, (siriusEdge?.OwnedStyle as SiriusDiagramModel.IEdgeStyle)?.RoutingStyle);

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
                edge.Label = new Label(edgeName!)
                {
                    IconPath = TypeIconPath(edge.SemanticElement, (siriusEdge?.OwnedStyle as SiriusDiagramModel.IEdgeStyle)?.CenterLabelStyle),
                };
            }

            // Association multiplicities and similar end texts persist as the DEdge's begin/end
            // labels, rendered near the respective route ends.
            if (MeaningfulLabel(siriusEdge?.BeginLabel) is { } beginLabel)
            {
                edge.BeginLabel = new Label(beginLabel);
            }

            if (MeaningfulLabel(siriusEdge?.EndLabel) is { } endLabel)
            {
                edge.EndLabel = new Label(endLabel);
            }

            edge.Style.Resolved = this.styleResolver.Resolve(edge);

            // A note attachment is not a model relationship: Capella draws it as a thin dotted
            // line between the note and the element it annotates.
            if (string.Equals(notationEdge.Type, "NoteAttachment", StringComparison.Ordinal))
            {
                edge.Style.Resolved.Pattern = LinePattern.Dot;
            }

            // A breakdown-tree containment connector is a plain line: Capella draws no arrowhead on
            // it, so the filled default the metamodel would give it is cleared.
            if ((siriusEdge?.OwnedStyle as SiriusDiagramModel.IEdgeStyle)?.RoutingStyle == SiriusDiagramModel.EdgeRouting.Tree)
            {
                edge.Style.Resolved.SourceArrow = null;
                edge.Style.Resolved.TargetArrow = null;
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
        /// <param name="routing">the persisted routing style of the edge, or <c>null</c></param>
        /// <returns>the absolute route polyline</returns>
        private static IReadOnlyList<Point> BuildRoute(NotationModel.IEdge notationEdge, Box? source, Box? target, SiriusDiagramModel.EdgeRouting? routing)
        {
            // A tree connector (a breakdown-diagram containment edge) is rectilinear: Capella
            // discards the persisted bendpoints — stale artifacts that resolve far outside the
            // canvas — and routes the child onto a shared horizontal bus between the two rows,
            // then into the parent. Both ends must resolve to a box for the bus geometry to exist.
            if (routing == SiriusDiagramModel.EdgeRouting.Tree && source != null && target != null && TreeRoute(source, target) is { } treeRoute)
            {
                return treeRoute;
            }

            var bendpoints = ParseBendpoints((notationEdge.Bendpoints as NotationModel.IRelativeBendpoints)?.Points);
            var sourceReference = source == null ? (Point?)null : AnchorPoint(source, notationEdge.SourceAnchor);
            var targetReference = target == null ? (Point?)null : AnchorPoint(target, notationEdge.TargetAnchor);

            if (sourceReference is { } refSource && targetReference is { } refTarget)
            {
                // A Manhattan edge with no real bendpoints is rectilinear: Capella routes it between
                // the facing side centres, not the anchor-reference line that clips to a diagonal
                // corner. Only bendpoint-less edges take this — a Manhattan edge with its own bends
                // keeps them.
                if (routing == SiriusDiagramModel.EdgeRouting.Manhattan && bendpoints.Count <= 2 && OrthogonalRoute(source!, target!, refSource, refTarget) is { } orthogonal)
                {
                    return orthogonal;
                }

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
        /// The rectilinear route of a breakdown-tree containment edge: a vertical stub from the
        /// child's facing edge onto a horizontal bus midway between the two rows, along the bus to
        /// the parent's centre, then a vertical stub into the parent's facing edge — the org-chart
        /// shape Capella draws, with every sibling of a parent sharing the bus and the parent stub.
        /// The child is the source and the parent the target (the folding arrow lands on it).
        /// Returns <c>null</c> when the boxes overlap vertically, so the caller keeps the generic
        /// route rather than an ill-defined bus.
        /// </summary>
        /// <param name="source">the child box (the edge's source)</param>
        /// <param name="target">the parent box (the edge's target)</param>
        /// <returns>the tree route, or <c>null</c> when no vertical bus is well-defined</returns>
        private static IReadOnlyList<Point>? TreeRoute(Box source, Box target)
        {
            var childCentreX = source.Position.X + ((source.Width ?? 0) / 2);
            var parentCentreX = target.Position.X + ((target.Width ?? 0) / 2);
            var childTop = source.Position.Y;
            var childBottom = source.Position.Y + (source.Height ?? 0);
            var parentTop = target.Position.Y;
            var parentBottom = target.Position.Y + (target.Height ?? 0);

            double childEdge;
            double parentEdge;
            if (parentBottom <= childTop)
            {
                // The parent sits above the child: the bus runs between them.
                childEdge = childTop;
                parentEdge = parentBottom;
            }
            else if (childBottom <= parentTop)
            {
                // The parent sits below the child.
                childEdge = childBottom;
                parentEdge = parentTop;
            }
            else
            {
                return null;
            }

            var busY = (childEdge + parentEdge) / 2;

            return SimplifyRoute(new[]
            {
                new Point(childCentreX, childEdge),
                new Point(childCentreX, busY),
                new Point(parentCentreX, busY),
                new Point(parentCentreX, parentEdge),
            });
        }

        /// <summary>
        /// The rectilinear route of a bendpoint-less Manhattan edge: the connector leaves the
        /// source's facing side and enters the target's facing side — the side chosen by which gap
        /// the boxes sit across — at each end's persisted anchor position along that side, turning
        /// once on the mid-line between them. So a stacked pair with aligned anchors joins by a
        /// clean vertical (or a side-by-side pair by a horizontal), a pair with offset anchors by a
        /// rectilinear step, and neither by a diagonal corner-to-corner line — while the persisted
        /// anchor (an off-centre connection) is honoured. Returns <c>null</c> when the boxes overlap
        /// on both axes, so the caller keeps the generic route.
        /// </summary>
        /// <param name="source">the source box</param>
        /// <param name="target">the target box</param>
        /// <param name="sourceAnchor">the source anchor reference point, positioning the exit along its side</param>
        /// <param name="targetAnchor">the target anchor reference point, positioning the entry along its side</param>
        /// <returns>the orthogonal route, or <c>null</c> when no facing corridor is well-defined</returns>
        private static IReadOnlyList<Point>? OrthogonalRoute(Box source, Box target, Point sourceAnchor, Point targetAnchor)
        {
            var sourceRight = source.Position.X + (source.Width ?? 0);
            var sourceBottom = source.Position.Y + (source.Height ?? 0);
            var targetRight = target.Position.X + (target.Width ?? 0);
            var targetBottom = target.Position.Y + (target.Height ?? 0);

            if (target.Position.Y >= sourceBottom)
            {
                return Elbow(sourceAnchor.X, sourceBottom, targetAnchor.X, target.Position.Y, vertical: true);
            }

            if (source.Position.Y >= targetBottom)
            {
                return Elbow(sourceAnchor.X, source.Position.Y, targetAnchor.X, targetBottom, vertical: true);
            }

            if (target.Position.X >= sourceRight)
            {
                return Elbow(sourceRight, sourceAnchor.Y, target.Position.X, targetAnchor.Y, vertical: false);
            }

            if (source.Position.X >= targetRight)
            {
                return Elbow(source.Position.X, sourceAnchor.Y, targetRight, targetAnchor.Y, vertical: false);
            }

            return null;
        }

        /// <summary>
        /// A one-turn orthogonal connector between two side points: it runs out of the first point
        /// along the facing axis to the mid-line, across, then into the second point. A pair whose
        /// facing centres align on the crossing axis collapses to a single straight segment.
        /// </summary>
        /// <param name="fromX">the exit point's x</param>
        /// <param name="fromY">the exit point's y</param>
        /// <param name="toX">the entry point's x</param>
        /// <param name="toY">the entry point's y</param>
        /// <param name="vertical">true when the boxes are stacked (the corridor runs vertically)</param>
        /// <returns>the orthogonal route</returns>
        private static IReadOnlyList<Point> Elbow(double fromX, double fromY, double toX, double toY, bool vertical)
        {
            if (vertical)
            {
                var midY = (fromY + toY) / 2;
                return SimplifyRoute(new[] { new Point(fromX, fromY), new Point(fromX, midY), new Point(toX, midY), new Point(toX, toY) });
            }

            var midX = (fromX + toX) / 2;
            return SimplifyRoute(new[] { new Point(fromX, fromY), new Point(midX, fromY), new Point(midX, toY), new Point(toX, toY) });
        }

        /// <summary>
        /// Simplifies a rectilinear route: drops consecutive duplicate points and axis-aligned
        /// collinear midpoints, so a connector whose facing centres align on the crossing axis
        /// collapses to a single straight segment rather than carrying a redundant turn.
        /// </summary>
        /// <param name="points">the route points</param>
        /// <returns>the simplified route</returns>
        private static IReadOnlyList<Point> SimplifyRoute(IReadOnlyList<Point> points)
        {
            var result = new List<Point> { points[0] };
            for (var i = 1; i < points.Count; i++)
            {
                var point = points[i];
                if (Math.Abs(point.X - result[^1].X) < 0.001 && Math.Abs(point.Y - result[^1].Y) < 0.001)
                {
                    continue;
                }

                if (result.Count >= 2)
                {
                    var previous = result[^2];
                    var last = result[^1];
                    var collinearVertical = Math.Abs(previous.X - last.X) < 0.001 && Math.Abs(last.X - point.X) < 0.001;
                    var collinearHorizontal = Math.Abs(previous.Y - last.Y) < 0.001 && Math.Abs(last.Y - point.Y) < 0.001;
                    if (collinearVertical || collinearHorizontal)
                    {
                        result[^1] = point;
                        continue;
                    }
                }

                result.Add(point);
            }

            return result;
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
