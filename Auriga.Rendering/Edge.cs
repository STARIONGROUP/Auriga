// ------------------------------------------------------------------------------------------------
// <copyright file="Edge.cs" company="Starion Group S.A.">
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
    /// A routed connection between two boxes, with its absolute persisted route (source anchor,
    /// bendpoints, target anchor) and back-links to the GMF notation edge it was built from, the
    /// Sirius <c>DEdge</c> that styles and names it, and the resolved Capella semantic element it
    /// represents.
    /// </summary>
    public sealed class Edge
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Edge"/> class.
        /// </summary>
        /// <param name="identifier">the stable identifier (the Sirius element's uid, falling back to the notation edge's id)</param>
        /// <param name="route">the absolute route polyline, source to target</param>
        /// <param name="notationView">the GMF notation edge the route was built from</param>
        /// <param name="style">the styling sources of the edge</param>
        public Edge(string identifier, IReadOnlyList<Point> route, Auriga.Diagram.Notation.IEdge notationView, Style style)
        {
            this.Identifier = identifier;
            this.Route = route;
            this.NotationView = notationView;
            this.Style = style;
        }

        /// <summary>
        /// Gets the stable identifier of the edge: the Sirius representation element's uid, falling
        /// back to the notation edge's id when the edge carries no Sirius element.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Gets the absolute route polyline from source to target: the source anchor point, the
        /// persisted bendpoints resolved to absolute coordinates, and the target anchor point (a
        /// sequence diagram's messages are re-routed horizontally by the builder's sequence pass).
        /// </summary>
        public IReadOnlyList<Point> Route { get; internal set; }

        /// <summary>
        /// Gets or sets the box the edge starts at, or <c>null</c> when the source view did not map
        /// to a box.
        /// </summary>
        public Box? Source { get; set; }

        /// <summary>
        /// Gets or sets the box the edge ends at, or <c>null</c> when the target view did not map
        /// to a box.
        /// </summary>
        public Box? Target { get; set; }

        /// <summary>
        /// Gets or sets the label, or <c>null</c> when the Sirius edge carries no name.
        /// </summary>
        public Label? Label { get; set; }

        /// <summary>
        /// Gets the styling sources of the edge.
        /// </summary>
        public Style Style { get; }

        /// <summary>
        /// Gets the GMF notation edge the route was built from (geometry source).
        /// </summary>
        public Auriga.Diagram.Notation.IEdge NotationView { get; }

        /// <summary>
        /// Gets or sets the Sirius <c>DEdge</c> the view displays (name, style, semantic target),
        /// or <c>null</c> when the notation edge carries none.
        /// </summary>
        public Auriga.Diagram.Diagram.IDEdge? SiriusElement { get; set; }

        /// <summary>
        /// Gets or sets the resolved Capella semantic element the Sirius edge represents (its
        /// <c>target</c>), or <c>null</c> when the diagram session did not co-load the semantic
        /// model or the target is unresolved.
        /// </summary>
        public object? SemanticElement { get; set; }
    }
}
