// ------------------------------------------------------------------------------------------------
// <copyright file="StyleResolver.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;

    using NotationModel = Auriga.Diagram.Notation;
    using SiriusDiagramModel = Auriga.Diagram.Diagram;
    using SiriusViewpoint = Auriga.Diagram.Viewpoint;

    /// <summary>
    /// The default <see cref="IStyleResolver"/>: resolves an item's styling sources into the
    /// concrete <see cref="ResolvedStyle"/>. Values layer in fixed precedence: the injected
    /// default palette (by the semantic element's type) seeds every property, the GMF notation
    /// styles (fonts, packed-integer colors, line widths) override the seeds, and the Sirius owned
    /// style — the style Capella actually persists per element — wins over both. A missing,
    /// partial or unknown style therefore degrades to sane defaults instead of throwing.
    /// </summary>
    public sealed class StyleResolver : IStyleResolver
    {
        /// <summary>
        /// The palette seeding the defaults of every resolved property.
        /// </summary>
        private readonly ICapellaDefaultPalette palette;

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleResolver"/> class with the default
        /// Capella palette, for direct use without a container.
        /// </summary>
        public StyleResolver()
            : this(new CapellaDefaultPalette())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleResolver"/> class with the supplied
        /// palette — the constructor a container injects through.
        /// </summary>
        /// <param name="palette">the palette seeding the defaults of every resolved property</param>
        /// <exception cref="ArgumentNullException">the palette is null</exception>
        public StyleResolver(ICapellaDefaultPalette palette)
        {
            this.palette = palette ?? throw new ArgumentNullException(nameof(palette));
        }

        /// <summary>
        /// Resolves the visual properties of a box.
        /// </summary>
        /// <param name="box">the box to resolve</param>
        /// <returns>the resolved style</returns>
        /// <exception cref="ArgumentNullException">the box is null</exception>
        public ResolvedStyle Resolve(Box box)
        {
            if (box == null)
            {
                throw new ArgumentNullException(nameof(box));
            }

            var (fill, stroke) = this.palette.ForBox(box.SemanticElement?.GetType().Name);

            var resolved = new ResolvedStyle
            {
                FillColor = fill,
                StrokeColor = stroke,
            };

            ApplyNotationStyles(box.Style.NotationStyles, resolved);
            ApplySiriusNodeStyle(box.Style.SiriusStyle, resolved);

            return resolved;
        }

        /// <summary>
        /// Resolves the visual properties of an edge.
        /// </summary>
        /// <param name="edge">the edge to resolve</param>
        /// <returns>the resolved style</returns>
        /// <exception cref="ArgumentNullException">the edge is null</exception>
        public ResolvedStyle Resolve(Edge edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException(nameof(edge));
            }

            var (stroke, width) = this.palette.ForEdge(edge.SemanticElement?.GetType().Name);

            var resolved = new ResolvedStyle
            {
                StrokeColor = stroke,
                StrokeWidth = width,
            };

            ApplyNotationStyles(edge.Style.NotationStyles, resolved);
            ApplySiriusEdgeStyle(edge.Style.SiriusStyle, resolved);

            return resolved;
        }

        /// <summary>
        /// Applies the GMF notation styles: font properties from <c>FontStyle</c> (a
        /// <c>ShapeStyle</c> is one), fill from <c>FillStyle</c> and line color/width from
        /// <c>LineStyle</c>, each color decoded from GMF's packed-integer encoding.
        /// </summary>
        /// <param name="notationStyles">the notation styles attached to the view</param>
        /// <param name="resolved">the style being resolved</param>
        private static void ApplyNotationStyles(System.Collections.Generic.IReadOnlyList<NotationModel.IStyle> notationStyles, ResolvedStyle resolved)
        {
            foreach (var style in notationStyles)
            {
                if (style is NotationModel.IFontStyle fontStyle)
                {
                    if (!string.IsNullOrEmpty(fontStyle.FontName))
                    {
                        resolved.FontName = fontStyle.FontName;
                    }

                    if (fontStyle.FontHeight is { } fontHeight && fontHeight > 0)
                    {
                        resolved.FontSize = fontHeight;
                    }

                    if (fontStyle.FontColor is { } fontColor)
                    {
                        resolved.FontColor = Color.FromNotationColor(fontColor);
                    }

                    resolved.Bold = fontStyle.Bold ?? resolved.Bold;
                    resolved.Italic = fontStyle.Italic ?? resolved.Italic;
                    resolved.Underline = fontStyle.Underline ?? resolved.Underline;
                    resolved.StrikeThrough = fontStyle.StrikeThrough ?? resolved.StrikeThrough;
                }

                if (style is NotationModel.IFillStyle { FillColor: { } fillColor })
                {
                    resolved.FillColor = Color.FromNotationColor(fillColor);
                }

                if (style is NotationModel.ILineStyle lineStyle)
                {
                    if (lineStyle.LineColor is { } lineColor)
                    {
                        resolved.StrokeColor = Color.FromNotationColor(lineColor);
                    }

                    if (lineStyle.LineWidth is { } lineWidth && lineWidth > 0)
                    {
                        resolved.StrokeWidth = lineWidth;
                    }
                }
            }
        }

        /// <summary>
        /// Applies a Sirius node/container style: the shape fill (every concrete style names its
        /// fill differently), the gradient of a <c>FlatContainerStyle</c>, the border, the
        /// workspace image path and the label font properties.
        /// </summary>
        /// <param name="siriusStyle">the Sirius owned style, or <c>null</c></param>
        /// <param name="resolved">the style being resolved</param>
        private static void ApplySiriusNodeStyle(SiriusViewpoint.IStyle? siriusStyle, ResolvedStyle resolved)
        {
            switch (siriusStyle)
            {
                case SiriusDiagramModel.ISquare square:
                    ApplyFill(square.Color, resolved);
                    break;
                case SiriusDiagramModel.IEllipse ellipse:
                    ApplyFill(ellipse.Color, resolved);
                    resolved.Shape = ShapeKind.Ellipse;
                    break;
                case SiriusDiagramModel.ILozenge lozenge:
                    ApplyFill(lozenge.Color, resolved);
                    break;
                case SiriusDiagramModel.IBundledImage bundledImage:
                    ApplyFill(bundledImage.Color, resolved);
                    break;
                case SiriusDiagramModel.INote note:
                    ApplyFill(note.Color, resolved);
                    break;
                case SiriusDiagramModel.IDot dot:
                    ApplyFill(dot.BackgroundColor, resolved);
                    resolved.Shape = ShapeKind.Ellipse;
                    break;
                case SiriusDiagramModel.IShapeContainerStyle shapeContainer:
                    ApplyFill(shapeContainer.BackgroundColor, resolved);
                    break;
                case SiriusDiagramModel.IFlatContainerStyle flatContainer:
                    ApplyFill(flatContainer.BackgroundColor, resolved);
                    if (Color.TryParse(flatContainer.ForegroundColor, out var foreground))
                    {
                        resolved.GradientColor = foreground;
                    }

                    break;
                case SiriusDiagramModel.IWorkspaceImage workspaceImage:
                    resolved.ImagePath = workspaceImage.WorkspacePath;
                    break;
            }

            if (siriusStyle is SiriusDiagramModel.IBorderedStyle borderedStyle)
            {
                if (Color.TryParse(borderedStyle.BorderColor, out var borderColor))
                {
                    resolved.StrokeColor = borderColor;
                }

                if (borderedStyle.BorderSize > 0)
                {
                    resolved.StrokeWidth = borderedStyle.BorderSize;
                }

                if (borderedStyle.BorderLineStyle is { } borderLineStyle)
                {
                    resolved.Pattern = MapPattern(borderLineStyle);
                }
            }

            ApplyLabelStyle(siriusStyle as SiriusViewpoint.IBasicLabelStyle, resolved);
        }

        /// <summary>
        /// Applies a Sirius edge style: stroke color, line width, pattern, the arrow decorations,
        /// and the center label's font properties.
        /// </summary>
        /// <param name="siriusStyle">the Sirius owned style, or <c>null</c></param>
        /// <param name="resolved">the style being resolved</param>
        private static void ApplySiriusEdgeStyle(SiriusViewpoint.IStyle? siriusStyle, ResolvedStyle resolved)
        {
            if (siriusStyle is not SiriusDiagramModel.IEdgeStyle edgeStyle)
            {
                return;
            }

            if (Color.TryParse(edgeStyle.StrokeColor, out var strokeColor))
            {
                resolved.StrokeColor = strokeColor;
            }

            if (edgeStyle.Size is { } size && size > 0)
            {
                resolved.StrokeWidth = size;
            }

            if (edgeStyle.LineStyle is { } lineStyle)
            {
                resolved.Pattern = MapPattern(lineStyle);
            }

            resolved.SourceArrow = edgeStyle.SourceArrow;

            // The Sirius metamodel defaults an unpersisted targetArrow to the open InputArrow
            // chevron, but Capella renders these edges with a solid filled arrowhead and never
            // persists an open arrow — so the open default resolves to the filled closed arrow
            // Capella actually draws, while every persisted decoration passes through unchanged.
            resolved.TargetArrow = edgeStyle.TargetArrow == SiriusDiagramModel.EdgeArrows.InputArrow
                ? SiriusDiagramModel.EdgeArrows.InputFillClosedArrow
                : edgeStyle.TargetArrow;

            ApplyLabelStyle(edgeStyle.CenterLabelStyle, resolved);
        }

        /// <summary>
        /// Applies a Sirius label style — the label color (an <c>"r,g,b"</c> string), size and
        /// format flags — over whatever the notation font style contributed.
        /// </summary>
        /// <param name="labelStyle">the Sirius label style, or <c>null</c></param>
        /// <param name="resolved">the style being resolved</param>
        private static void ApplyLabelStyle(SiriusViewpoint.IBasicLabelStyle? labelStyle, ResolvedStyle resolved)
        {
            if (labelStyle == null)
            {
                return;
            }

            if (Color.TryParse(labelStyle.LabelColor, out var labelColor))
            {
                resolved.FontColor = labelColor;
            }

            if (labelStyle.LabelSize is { } labelSize && labelSize > 0)
            {
                resolved.FontSize = labelSize;
            }

            foreach (var format in labelStyle.LabelFormat)
            {
                switch (format)
                {
                    case SiriusViewpoint.FontFormat.Bold:
                        resolved.Bold = true;
                        break;
                    case SiriusViewpoint.FontFormat.Italic:
                        resolved.Italic = true;
                        break;
                    case SiriusViewpoint.FontFormat.Underline:
                        resolved.Underline = true;
                        break;
                    case SiriusViewpoint.FontFormat.Strike_through:
                        resolved.StrikeThrough = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Parses a Sirius fill color and applies it when well-formed.
        /// </summary>
        /// <param name="rgbValues">the raw persisted <c>"r,g,b"</c> value</param>
        /// <param name="resolved">the style being resolved</param>
        private static void ApplyFill(string? rgbValues, ResolvedStyle resolved)
        {
            if (Color.TryParse(rgbValues, out var color))
            {
                resolved.FillColor = color;
            }
        }

        /// <summary>
        /// Maps the Sirius line-style enumeration to the resolved pattern.
        /// </summary>
        /// <param name="lineStyle">the Sirius line style</param>
        /// <returns>the resolved pattern</returns>
        private static LinePattern MapPattern(SiriusDiagramModel.LineStyle lineStyle)
        {
            return lineStyle switch
            {
                SiriusDiagramModel.LineStyle.Dash => LinePattern.Dash,
                SiriusDiagramModel.LineStyle.Dot => LinePattern.Dot,
                SiriusDiagramModel.LineStyle.Dash_dot => LinePattern.DashDot,
                _ => LinePattern.Solid,
            };
        }
    }
}
