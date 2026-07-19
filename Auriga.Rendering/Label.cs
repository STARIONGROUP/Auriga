// ------------------------------------------------------------------------------------------------
// <copyright file="Label.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    /// <summary>
    /// The text label of a diagram item. The text comes from the Sirius representation element; the
    /// optional geometry comes from the GMF label node when one is persisted (its position absolute,
    /// like every coordinate in the intermediate model).
    /// </summary>
    public sealed class Label
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        /// <param name="text">the label text</param>
        public Label(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// Gets the label text.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets or sets the absolute position of the label, or <c>null</c> when no label geometry is
        /// persisted (the renderer places it).
        /// </summary>
        public Point? Position { get; set; }

        /// <summary>
        /// Gets or sets the persisted width of the label, or <c>null</c> when unset.
        /// </summary>
        public double? Width { get; set; }

        /// <summary>
        /// Gets or sets the persisted height of the label, or <c>null</c> when unset.
        /// </summary>
        public double? Height { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the label renders inside a title tab — the
        /// pentagon Capella draws around a combined fragment's operator (<c>PAR</c>, <c>ALT</c>,
        /// <c>LOOP</c>) in the frame's top-left corner.
        /// </summary>
        public bool Framed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the label is a container title pinned to the
        /// box's top band — centered horizontally at the top rather than centered in the whole
        /// box — so it sits above the box's children (ports, nested content) instead of
        /// overlapping them. Applies only when <see cref="Position"/> is <c>null</c>.
        /// </summary>
        public bool PinTop { get; set; }

        /// <summary>
        /// Gets or sets the image the label is prefixed with — Capella's small metaclass icon,
        /// derived from the semantic element's type — as a path the icon registry resolves (e.g.
        /// <c>Class.png</c>), or <c>null</c> when the label shows no icon (suppressed by the
        /// style's <c>showIcon</c>, no semantic element, or a diagram kind that draws none).
        /// </summary>
        public string? IconPath { get; set; }
    }
}
