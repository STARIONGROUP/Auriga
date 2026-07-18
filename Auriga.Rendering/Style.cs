// ------------------------------------------------------------------------------------------------
// <copyright file="Style.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System.Collections.Generic;

    /// <summary>
    /// The styling sources of a diagram item, carried as references into the parsed object graph:
    /// the Sirius owned style (colors, line style, label format — the primary source) and the GMF
    /// notation styles attached to the view (fonts, routing). Resolving these into concrete colors
    /// and strokes is the style-resolution phase (issue #56); the intermediate model only keeps the
    /// pointers so a renderer can resolve without re-walking the <c>.aird</c>.
    /// </summary>
    public sealed class Style
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Style"/> class.
        /// </summary>
        /// <param name="siriusStyle">the Sirius owned style, or <c>null</c> when the element has none</param>
        /// <param name="notationStyles">the GMF notation styles attached to the view</param>
        public Style(Auriga.Diagram.Viewpoint.IStyle? siriusStyle, IReadOnlyList<Auriga.Diagram.Notation.IStyle> notationStyles)
        {
            this.SiriusStyle = siriusStyle;
            this.NotationStyles = notationStyles;
        }

        /// <summary>
        /// Gets the Sirius owned style of the representation element (e.g. a <c>NodeStyle</c> with
        /// fill/border colors), or <c>null</c> when the element carries none.
        /// </summary>
        public Auriga.Diagram.Viewpoint.IStyle? SiriusStyle { get; }

        /// <summary>
        /// Gets the GMF notation styles attached to the view (e.g. <c>FontStyle</c>,
        /// <c>RoutingStyle</c>); empty when none are persisted.
        /// </summary>
        public IReadOnlyList<Auriga.Diagram.Notation.IStyle> NotationStyles { get; }

        /// <summary>
        /// Gets or sets the concrete visual properties the <see cref="StyleResolver"/> resolved
        /// from these sources; set by the <see cref="DiagramBuilder"/> for every built item.
        /// </summary>
        public ResolvedStyle Resolved { get; set; } = new ResolvedStyle();
    }
}
