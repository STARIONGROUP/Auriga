// ------------------------------------------------------------------------------------------------
// <copyright file="Box.cs" company="Starion Group S.A.">
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
    /// A rectangular diagram item — a node, container or port — with its absolute persisted
    /// position, its persisted size when one is stored, and back-links to the GMF notation view it
    /// was built from, the Sirius representation element that styles and names it, and the resolved
    /// Capella semantic element it represents.
    /// </summary>
    public sealed class Box
    {
        /// <summary>
        /// The nested boxes, in document order.
        /// </summary>
        private readonly List<Box> children = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="Box"/> class.
        /// </summary>
        /// <param name="identifier">the stable identifier (the Sirius element's uid, falling back to the notation view's id)</param>
        /// <param name="position">the absolute position of the top-left corner</param>
        /// <param name="notationView">the GMF notation node the box was built from</param>
        /// <param name="style">the styling sources of the box</param>
        public Box(string identifier, Point position, Auriga.Diagram.Notation.INode notationView, Style style)
        {
            this.Identifier = identifier;
            this.Position = position;
            this.NotationView = notationView;
            this.Style = style;
        }

        /// <summary>
        /// Gets the stable identifier of the box: the Sirius representation element's uid, falling
        /// back to the notation view's id when the view carries no Sirius element.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Gets the absolute position of the box's top-left corner. Persisted coordinates are
        /// relative to the parent view; the builder accumulates them so every box is absolute (a
        /// sequence diagram's lifelines are the one case the builder repositions after the fact).
        /// </summary>
        public Point Position { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the box's geometry came from a Sirius
        /// <c>AbsoluteBoundsFilter</c> — the persisted absolute layout of sequence-diagram elements,
        /// which the sequence route pass treats as the vertical truth.
        /// </summary>
        public bool HasAbsoluteBounds { get; internal set; }

        /// <summary>
        /// Gets or sets the persisted width, or <c>null</c> when the diagram stores no width (the
        /// renderer computes a default).
        /// </summary>
        public double? Width { get; set; }

        /// <summary>
        /// Gets or sets the persisted height, or <c>null</c> when the diagram stores no height.
        /// </summary>
        public double? Height { get; set; }

        /// <summary>
        /// Gets or sets the label, or <c>null</c> when the Sirius element carries no name.
        /// </summary>
        public Label? Label { get; set; }

        /// <summary>
        /// Gets the box that contains this box, or <c>null</c> for a top-level box of the diagram.
        /// </summary>
        public Box? Parent { get; internal set; }

        /// <summary>
        /// Gets the nested boxes, in document order.
        /// </summary>
        public IReadOnlyList<Box> Children => this.children;

        /// <summary>
        /// Gets the styling sources of the box.
        /// </summary>
        public Style Style { get; }

        /// <summary>
        /// Gets the GMF notation node the box was built from (geometry source).
        /// </summary>
        public Auriga.Diagram.Notation.INode NotationView { get; }

        /// <summary>
        /// Gets or sets the Sirius representation element the view displays (name, style, semantic
        /// target), or <c>null</c> when the view carries none.
        /// </summary>
        public Auriga.Diagram.Diagram.IDDiagramElement? SiriusElement { get; set; }

        /// <summary>
        /// Gets or sets the resolved Capella semantic element the Sirius element represents (its
        /// <c>target</c>), or <c>null</c> when the diagram session did not co-load the semantic
        /// model or the target is unresolved.
        /// </summary>
        public object? SemanticElement { get; set; }

        /// <summary>
        /// Adds a nested box and sets its <see cref="Parent"/>.
        /// </summary>
        /// <param name="child">the box to nest</param>
        internal void Add(Box child)
        {
            child.Parent = this;
            this.children.Add(child);
        }
    }
}
