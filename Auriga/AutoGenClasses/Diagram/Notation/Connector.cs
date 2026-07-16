// ------------------------------------------------------------------------------------------------
// <copyright file="Connector.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Notation
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Connector</c> class.
    /// </summary>
    public partial class Connector : Auriga.Core.AurigaElement, Auriga.Diagram.Notation.IConnector
    {
        /// <summary>
        /// Gets or sets the avoid obstructions.
        /// </summary>
        public bool? AvoidObstructions { get; set; }

        /// <summary>
        /// Gets or sets the bendpoints.
        /// </summary>
        public Auriga.Diagram.Notation.IBendpoints Bendpoints
        {
            get => this.backingBendpoints;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingBendpoints = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Bendpoints"/>.
        /// </summary>
        private Auriga.Diagram.Notation.IBendpoints backingBendpoints;

        /// <summary>
        /// Gets or sets the closest distance.
        /// </summary>
        public bool? ClosestDistance { get; set; }

        /// <summary>
        /// Gets the diagram.
        /// </summary>
        public Auriga.Diagram.Notation.IDiagram Diagram_ => default;

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        public object Element { get; set; }

        /// <summary>
        /// Gets or sets the jump link status.
        /// </summary>
        public Auriga.Diagram.Notation.JumpLinkStatus? JumpLinkStatus { get; set; }

        /// <summary>
        /// Gets or sets the jump link type.
        /// </summary>
        public Auriga.Diagram.Notation.JumpLinkType? JumpLinkType { get; set; }

        /// <summary>
        /// Gets or sets the jump links reverse.
        /// </summary>
        public bool? JumpLinksReverse { get; set; }

        /// <summary>
        /// Gets or sets the line color.
        /// </summary>
        public int? LineColor { get; set; }

        /// <summary>
        /// Gets or sets the line width.
        /// </summary>
        public int? LineWidth { get; set; }

        /// <summary>
        /// Gets the mutable.
        /// </summary>
        public bool? Mutable => default;

        /// <summary>
        /// Gets the persisted children.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Notation.INode> PersistedChildren => this.backingPersistedChildren ??= new Auriga.Core.ContainerList<Auriga.Diagram.Notation.INode>(this);

        /// <summary>
        /// Backing field for <see cref="PersistedChildren"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Notation.INode> backingPersistedChildren;

        /// <summary>
        /// Gets or sets the rounded bendpoints radius.
        /// </summary>
        public int? RoundedBendpointsRadius { get; set; }

        /// <summary>
        /// Gets or sets the routing.
        /// </summary>
        public Auriga.Diagram.Notation.Routing? Routing { get; set; }

        /// <summary>
        /// Gets or sets the smoothness.
        /// </summary>
        public Auriga.Diagram.Notation.Smoothness? Smoothness { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public Auriga.Diagram.Notation.IView Source { get; set; }

        /// <summary>
        /// Gets or sets the source anchor.
        /// </summary>
        public Auriga.Diagram.Notation.IAnchor SourceAnchor
        {
            get => this.backingSourceAnchor;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingSourceAnchor = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="SourceAnchor"/>.
        /// </summary>
        private Auriga.Diagram.Notation.IAnchor backingSourceAnchor;

        /// <summary>
        /// Gets the source edges.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Notation.IEdge> SourceEdges => Enumerable.Empty<Auriga.Diagram.Notation.IEdge>();

        /// <summary>
        /// Gets the styles.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Notation.IStyle> Styles => this.backingStyles ??= new Auriga.Core.ContainerList<Auriga.Diagram.Notation.IStyle>(this);

        /// <summary>
        /// Backing field for <see cref="Styles"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Notation.IStyle> backingStyles;

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public Auriga.Diagram.Notation.IView Target { get; set; }

        /// <summary>
        /// Gets or sets the target anchor.
        /// </summary>
        public Auriga.Diagram.Notation.IAnchor TargetAnchor
        {
            get => this.backingTargetAnchor;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingTargetAnchor = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="TargetAnchor"/>.
        /// </summary>
        private Auriga.Diagram.Notation.IAnchor backingTargetAnchor;

        /// <summary>
        /// Gets the target edges.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Notation.IEdge> TargetEdges => Enumerable.Empty<Auriga.Diagram.Notation.IEdge>();

        /// <summary>
        /// Gets the transient children.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Notation.INode> TransientChildren => Enumerable.Empty<Auriga.Diagram.Notation.INode>();

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        public bool? Visible { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>Connector</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.Bendpoints != null)
            {
                yield return this.Bendpoints;
            }

            foreach (var element in this.PersistedChildren)
            {
                yield return element;
            }

            if (this.SourceAnchor != null)
            {
                yield return this.SourceAnchor;
            }

            foreach (var element in this.Styles)
            {
                yield return element;
            }

            if (this.TargetAnchor != null)
            {
                yield return this.TargetAnchor;
            }

            foreach (var element in this.TransientChildren)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
