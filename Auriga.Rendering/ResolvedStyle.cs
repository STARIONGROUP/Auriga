// ------------------------------------------------------------------------------------------------
// <copyright file="ResolvedStyle.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    /// <summary>
    /// The concrete visual properties of a diagram item, resolved by the <see cref="StyleResolver"/>
    /// from the persisted Sirius owned style, the GMF notation styles and the Capella default
    /// palette — everything a renderer needs without touching the parsed <c>.aird</c> graph again.
    /// </summary>
    public sealed class ResolvedStyle
    {
        /// <summary>
        /// Gets or sets the fill color, or <c>null</c> for an unfilled item (an edge, or a box the
        /// diagram renders without a fill).
        /// </summary>
        public Color? FillColor { get; set; }

        /// <summary>
        /// Gets or sets the second fill color of a gradient (a <c>FlatContainerStyle</c>'s
        /// foreground color), or <c>null</c> for a plain fill.
        /// </summary>
        public Color? GradientColor { get; set; }

        /// <summary>
        /// Gets or sets the stroke color of the border or edge line.
        /// </summary>
        public Color StrokeColor { get; set; }

        /// <summary>
        /// Gets or sets the stroke width of the border or edge line, in pixels.
        /// </summary>
        public double StrokeWidth { get; set; } = 1;

        /// <summary>
        /// Gets or sets the stroke pattern of the border or edge line.
        /// </summary>
        public LinePattern Pattern { get; set; }

        /// <summary>
        /// Gets or sets the font family name of the item's label.
        /// </summary>
        public string FontName { get; set; } = "Arial";

        /// <summary>
        /// Gets or sets the font size of the item's label, in points.
        /// </summary>
        public double FontSize { get; set; } = 8;

        /// <summary>
        /// Gets or sets the font color of the item's label.
        /// </summary>
        public Color FontColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the label renders bold.
        /// </summary>
        public bool Bold { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the label renders italic.
        /// </summary>
        public bool Italic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the label renders underlined.
        /// </summary>
        public bool Underline { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the label renders struck through.
        /// </summary>
        public bool StrikeThrough { get; set; }

        /// <summary>
        /// Gets or sets the workspace path of the image the item renders as (a Sirius
        /// <c>WorkspaceImage</c> style, e.g. the Capella actor/capability icons), or <c>null</c>
        /// when the item is a plain shape.
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the arrow decoration at the source end of an edge, or <c>null</c> for a
        /// box or an edge without a persisted style.
        /// </summary>
        public Auriga.Diagram.Diagram.EdgeArrows? SourceArrow { get; set; }

        /// <summary>
        /// Gets or sets the arrow decoration at the target end of an edge, or <c>null</c> for a
        /// box or an edge without a persisted style.
        /// </summary>
        public Auriga.Diagram.Diagram.EdgeArrows? TargetArrow { get; set; }
    }
}
