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

    using Microsoft.Extensions.Logging;

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
        /// The logger reporting the persisted style values that did not parse.
        /// </summary>
        private readonly ILogger<StyleResolver> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleResolver"/> class with the supplied
        /// palette.
        /// </summary>
        /// <param name="palette">the palette seeding the defaults of every resolved property</param>
        /// <param name="loggerFactory">the factory the resolver creates its logger from</param>
        /// <exception cref="ArgumentNullException">the palette or the logger factory is null</exception>
        public StyleResolver(ICapellaDefaultPalette palette, ILoggerFactory loggerFactory)
        {
            this.palette = palette ?? throw new ArgumentNullException(nameof(palette));

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            this.logger = loggerFactory.CreateLogger<StyleResolver>();
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
            this.ApplySiriusNodeStyle(box.Style.SiriusStyle, resolved);

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
            this.ApplySiriusEdgeStyle(edge.Style.SiriusStyle, resolved);

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
        private void ApplySiriusNodeStyle(SiriusViewpoint.IStyle? siriusStyle, ResolvedStyle resolved)
        {
            switch (siriusStyle)
            {
                case SiriusDiagramModel.ISquare square:
                    this.ApplyFill(square.Color, resolved);
                    break;
                case SiriusDiagramModel.IEllipse ellipse:
                    this.ApplyFill(ellipse.Color, resolved);
                    resolved.Shape = ShapeKind.Ellipse;
                    break;
                case SiriusDiagramModel.ILozenge lozenge:
                    this.ApplyFill(lozenge.Color, resolved);
                    resolved.Shape = ShapeKind.Diamond;
                    break;
                case SiriusDiagramModel.IBundledImage bundledImage:
                    this.ApplyFill(bundledImage.Color, resolved);
                    break;
                case SiriusDiagramModel.INote note:
                    this.ApplyFill(note.Color, resolved);
                    break;
                case SiriusDiagramModel.IDot dot:
                    this.ApplyFill(dot.BackgroundColor, resolved);
                    resolved.Shape = ShapeKind.Ellipse;
                    break;
                case SiriusDiagramModel.IShapeContainerStyle shapeContainer:
                    this.ApplyFill(shapeContainer.BackgroundColor, resolved);
                    break;
                case SiriusDiagramModel.IFlatContainerStyle flatContainer:
                    this.ApplyFill(flatContainer.BackgroundColor, resolved);
                    if (this.TryParseColor(flatContainer.ForegroundColor, "gradient", out var foreground))
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
                if (this.TryParseColor(borderedStyle.BorderColor, "border", out var borderColor))
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

            this.ApplyLabelStyle(siriusStyle as SiriusViewpoint.IBasicLabelStyle, resolved);
        }

        /// <summary>
        /// Applies a Sirius edge style: stroke color, line width, pattern, the arrow decorations,
        /// and the center label's font properties.
        /// </summary>
        /// <param name="siriusStyle">the Sirius owned style, or <c>null</c></param>
        /// <param name="resolved">the style being resolved</param>
        private void ApplySiriusEdgeStyle(SiriusViewpoint.IStyle? siriusStyle, ResolvedStyle resolved)
        {
            if (siriusStyle is not SiriusDiagramModel.IEdgeStyle edgeStyle)
            {
                return;
            }

            if (this.TryParseColor(edgeStyle.StrokeColor, "stroke", out var strokeColor))
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

            this.ApplyLabelStyle(edgeStyle.CenterLabelStyle, resolved);
        }

        /// <summary>
        /// Applies a Sirius label style — the label color (an <c>"r,g,b"</c> string), size and
        /// format flags — over whatever the notation font style contributed.
        /// </summary>
        /// <param name="labelStyle">the Sirius label style, or <c>null</c></param>
        /// <param name="resolved">the style being resolved</param>
        private void ApplyLabelStyle(SiriusViewpoint.IBasicLabelStyle? labelStyle, ResolvedStyle resolved)
        {
            if (labelStyle == null)
            {
                return;
            }

            if (this.TryParseColor(labelStyle.LabelColor, "label", out var labelColor))
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
        private void ApplyFill(string? rgbValues, ResolvedStyle resolved)
        {
            if (this.TryParseColor(rgbValues, "fill", out var color))
            {
                resolved.FillColor = color;
            }
        }

        /// <summary>
        /// Parses a persisted Sirius <c>"r,g,b"</c> value, tracing the ones that are present but
        /// malformed — those are the values whose resolved property silently keeps its palette or
        /// notation default. A value that is simply absent is not a degradation: most styles
        /// persist only the properties they override, so tracing those would put a line on every
        /// unset property of every box and edge.
        /// </summary>
        /// <param name="rgbValues">the raw persisted value, or <c>null</c></param>
        /// <param name="property">the resolved property the value would have set, named in the trace</param>
        /// <param name="color">the parsed color, or default when the value is absent or malformed</param>
        /// <returns>true when the value parsed</returns>
        private bool TryParseColor(string? rgbValues, string property, out Color color)
        {
            if (Color.TryParse(rgbValues, out color))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(rgbValues))
            {
                this.logger.LogTrace("The persisted {Property} color {RawValue} is not an \"r,g,b\" triple; the resolved style keeps its default", property, rgbValues);
            }

            return false;
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
