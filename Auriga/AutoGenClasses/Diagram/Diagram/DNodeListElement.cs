// ------------------------------------------------------------------------------------------------
// <copyright file="DNodeListElement.cs" company="Starion Group S.A.">
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
    /// An element of a list.
    /// </summary>
    public partial class DNodeListElement : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.IDNodeListElement
    {
        /// <summary>
        /// The actual mapping of this node.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.INodeMapping ActualMapping { get; set; }

        /// <summary>
        /// Gets the arrange constraints.
        /// </summary>
        public List<Auriga.Diagram.Diagram.ArrangeConstraint> ArrangeConstraints { get; } = new List<Auriga.Diagram.Diagram.ArrangeConstraint>();

        /// <summary>
        /// The candidates mapping of this node.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.INodeMapping> CandidatesMapping { get; } = new List<Auriga.Diagram.Diagram.Description.INodeMapping>();

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
        /// Graphical filters allowing to handle this element.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IGraphicalFilter> GraphicalFilters => this.backingGraphicalFilters ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.IGraphicalFilter>(this);

        /// <summary>
        /// Backing field for <see cref="GraphicalFilters"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IGraphicalFilter> backingGraphicalFilters;

        /// <summary>
        /// The name of the element. It is the name that is displayed on the diagram.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The instance of style that is contained by the mapping. The ownedStyle reference should be a copy of this style.
        /// </summary>
        public Auriga.Diagram.Viewpoint.IStyle OriginalStyle { get; set; }

        /// <summary>
        /// The nodes that are on the border of the container.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IDNode> OwnedBorderedNodes => this.backingOwnedBorderedNodes ??= new Auriga.Core.ContainerList<Auriga.Diagram.Diagram.IDNode>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedBorderedNodes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Diagram.IDNode> backingOwnedBorderedNodes;

        /// <summary>
        /// The style of this element.
        /// </summary>
        public Auriga.Diagram.Diagram.INodeStyle OwnedStyle
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
        private Auriga.Diagram.Diagram.INodeStyle backingOwnedStyle;

        /// <summary>
        /// Gets the parent layers.
        /// </summary>
        public List<Auriga.Diagram.Diagram.Description.ILayer> ParentLayers { get; } = new List<Auriga.Diagram.Diagram.Description.ILayer>();

        /// <summary>
        /// The semantic elements to show that represents this view point element.
        /// </summary>
        public List<object> SemanticElements { get; } = new List<object>();

        /// <summary>
        /// The referenced EObject.
        /// </summary>
        public object Target { get; set; }

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
        /// Gets the elements directly contained by this <c>DNodeListElement</c>.
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

            foreach (var element in this.OwnedBorderedNodes)
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
