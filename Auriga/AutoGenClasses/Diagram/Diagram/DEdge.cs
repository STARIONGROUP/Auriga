// ------------------------------------------------------------------------------------------------
// <copyright file="DEdge.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable disable

namespace Auriga.Diagram.Diagram
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A view edge. It is a connection between two EdgeTarget.
    /// </summary>
    public partial class DEdge : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.IDEdge
    {
        /// <summary>
        /// The mapping that has created the view edge.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.IIEdgeMapping ActualMapping { get; set; }

        /// <summary>
        /// Gets the arrange constraints.
        /// </summary>
        public List<Auriga.Diagram.Diagram.ArrangeConstraint> ArrangeConstraints { get; } = new List<Auriga.Diagram.Diagram.ArrangeConstraint>();

        /// <summary>
        /// The name of the representation.
        /// </summary>
        public string BeginLabel { get; set; }

        /// <summary>
        /// Gets the decorations.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IDecoration> Decorations => this.backingDecorations ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.IDecoration>(this);

        /// <summary>
        /// Backing field for <see cref="Decorations"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IDecoration> backingDecorations;

        /// <summary>
        /// The mapping of the element.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.IDiagramElementMapping DiagramElementMapping => default;

        /// <summary>
        /// The name of the representation.
        /// </summary>
        public string EndLabel { get; set; }

        /// <summary>
        /// Graphical filters allowing to handle this element.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IGraphicalFilter> GraphicalFilters => this.backingGraphicalFilters ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.IGraphicalFilter>(this);

        /// <summary>
        /// Backing field for <see cref="GraphicalFilters"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IGraphicalFilter> backingGraphicalFilters;

        /// <summary>
        /// The incoming view edges.
        /// </summary>
        public List<Auriga.Diagram.Diagram.IDEdge> IncomingEdges { get; } = new List<Auriga.Diagram.Diagram.IDEdge>();

        /// <summary>
        /// <code>true</code> if the view edge is folded.
        /// </summary>
        public bool? IsFold { get; set; }

        /// <summary>
        /// <code>true</code> if the edge is an edge that is displayed only to have the plus image to decollapse a branch.
        /// </summary>
        public bool? IsMockEdge { get; set; }

        /// <summary>
        /// The name of the element. It is the name that is displayed on the diagram.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The instance of style that is contained by the mapping. The ownedStyle reference should be a copy of this style.
        /// </summary>
        public Auriga.Diagram.Viewpoint.IStyle OriginalStyle { get; set; }

        /// <summary>
        /// The outgoing view edges.
        /// </summary>
        public List<Auriga.Diagram.Diagram.IDEdge> OutgoingEdges { get; } = new List<Auriga.Diagram.Diagram.IDEdge>();

        /// <summary>
        /// The style of the connection.
        /// </summary>
        public Auriga.Diagram.Diagram.IEdgeStyle OwnedStyle
        {
            get => this.backingOwnedStyle;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedStyle = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedStyle"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.IEdgeStyle backingOwnedStyle;

        /// <summary>
        /// Gets the parent layers.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.ILayer> ParentLayers { get; } = new List<Auriga.Diagram.Diagram.Description.ILayer>();

        /// <summary>
        /// Gets the path.
        /// </summary>
        public List<Auriga.Diagram.Diagram.IEdgeTarget> Path { get; } = new List<Auriga.Diagram.Diagram.IEdgeTarget>();

        /// <summary>
        /// The routing style of the edge.
        /// </summary>
        public Auriga.Diagram.Diagram.EdgeRouting RoutingStyle { get; set; }

        /// <summary>
        /// The semantic elements to show that represents this view point element.
        /// </summary>
        public List<object> SemanticElements { get; } = new List<object>();

        /// <summary>
        /// The line width.
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// The source of the connection.
        /// </summary>
        public Auriga.Diagram.Diagram.IEdgeTarget SourceNode { get; set; }

        /// <summary>
        /// The referenced EObject.
        /// </summary>
        public object Target { get; set; }

        /// <summary>
        /// The target of the connection.
        /// </summary>
        public Auriga.Diagram.Diagram.IEdgeTarget TargetNode { get; set; }

        /// <summary>
        /// The text to show in the element's tooltip.
        /// </summary>
        public string TooltipText { get; set; }

        /// <summary>
        /// Gets the transient decorations.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Viewpoint.IDecoration> TransientDecorations => Enumerable.Empty<Auriga.Diagram.Viewpoint.IDecoration>();

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// True if the element is visible, false otherwise.
        /// </summary>
        public bool? Visible { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DEdge</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Decorations)
            {
                yield return element;
            }

            foreach (var element in this.GraphicalFilters)
            {
                yield return element;
            }

            if (this.OwnedStyle != null)
            {
                yield return this.OwnedStyle;
            }

            foreach (var element in this.TransientDecorations)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
