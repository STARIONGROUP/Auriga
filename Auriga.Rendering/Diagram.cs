// ------------------------------------------------------------------------------------------------
// <copyright file="Diagram.cs" company="Starion Group S.A.">
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
    /// The renderer-agnostic intermediate model of one representation: the top-level <see cref="Box"/>es
    /// (nesting their children) and the <see cref="Edge"/>s connecting them. For a GMF diagram every
    /// coordinate is absolute and taken from the persisted layout — never computed — and back-links
    /// connect the diagram to the Sirius representation it was built from and the Capella semantic
    /// element it targets. A table representation carries no GMF notation diagram: its grid is
    /// synthesized from the persisted column widths and line order (see <see cref="TableBuilder"/>),
    /// so <see cref="SiriusDiagram"/> and <see cref="NotationDiagram"/> are <c>null</c>.
    /// </summary>
    public sealed class Diagram
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Diagram"/> class.
        /// </summary>
        /// <param name="identifier">the Sirius representation's uid</param>
        /// <param name="boxes">the top-level boxes, in document order</param>
        /// <param name="edges">the edges, in document order</param>
        /// <param name="siriusDiagram">the Sirius diagram the model was built from, or <c>null</c> for a table</param>
        /// <param name="notationDiagram">the GMF notation diagram that persisted the layout, or <c>null</c> for a table</param>
        public Diagram(string identifier, IReadOnlyList<Box> boxes, IReadOnlyList<Edge> edges, Auriga.Diagram.Diagram.IDDiagram? siriusDiagram, Auriga.Diagram.Notation.IDiagram? notationDiagram)
        {
            this.Identifier = identifier;
            this.Boxes = boxes;
            this.Edges = edges;
            this.SiriusDiagram = siriusDiagram;
            this.NotationDiagram = notationDiagram;
        }

        /// <summary>
        /// Gets the stable identifier of the diagram (the Sirius representation's uid).
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Gets or sets the diagram name, or <c>null</c> when the caller supplied none (the name
        /// lives on the <c>DRepresentationDescriptor</c> in the <c>DAnalysis</c>, not on the
        /// representation itself).
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets the top-level boxes of the diagram, in document order; nested boxes hang off their
        /// parent's <see cref="Box.Children"/>.
        /// </summary>
        public IReadOnlyList<Box> Boxes { get; }

        /// <summary>
        /// Gets the edges of the diagram, in document order.
        /// </summary>
        public IReadOnlyList<Edge> Edges { get; }

        /// <summary>
        /// Gets the Sirius diagram the model was built from, or <c>null</c> for a table representation
        /// (which has no GMF diagram).
        /// </summary>
        public Auriga.Diagram.Diagram.IDDiagram? SiriusDiagram { get; }

        /// <summary>
        /// Gets or sets the resolved Capella semantic element the representation targets, or
        /// <c>null</c> when the session did not co-load the semantic model.
        /// </summary>
        public object? SemanticElement { get; set; }

        /// <summary>
        /// Gets the GMF notation diagram that persisted the layout, or <c>null</c> for a table
        /// representation (whose grid is synthesized rather than persisted as notation).
        /// </summary>
        public Auriga.Diagram.Notation.IDiagram? NotationDiagram { get; }

        /// <summary>
        /// Enumerates every box of the diagram — the top-level boxes and, depth-first, all their
        /// nested boxes.
        /// </summary>
        /// <returns>every box in the diagram</returns>
        public IEnumerable<Box> QueryAllBoxes()
        {
            foreach (var box in this.Boxes)
            {
                yield return box;

                foreach (var descendant in Descendants(box))
                {
                    yield return descendant;
                }
            }
        }

        /// <summary>
        /// Enumerates the nested boxes of a box, depth-first.
        /// </summary>
        /// <param name="box">the box whose descendants are enumerated</param>
        /// <returns>the descendant boxes</returns>
        private static IEnumerable<Box> Descendants(Box box)
        {
            foreach (var child in box.Children)
            {
                yield return child;

                foreach (var descendant in Descendants(child))
                {
                    yield return descendant;
                }
            }
        }
    }
}
