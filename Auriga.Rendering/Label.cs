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
    }
}
