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

namespace Auriga.Sirius.Notation
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Connector</c> class.
    /// </summary>
    public partial class Connector : Auriga.AurigaElement, Auriga.Sirius.Notation.IConnector
    {
        /// <summary>
        /// Gets or sets the avoid obstructions.
        /// </summary>
        public bool? AvoidObstructions { get; set; }

        /// <summary>
        /// Gets or sets the bendpoints.
        /// </summary>
        public Auriga.Sirius.Notation.IBendpoints Bendpoints
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
        private Auriga.Sirius.Notation.IBendpoints backingBendpoints;

        /// <summary>
        /// Gets or sets the closest distance.
        /// </summary>
        public bool? ClosestDistance { get; set; }

        /// <summary>
        /// Gets the diagram.
        /// </summary>
        public Auriga.Sirius.Notation.IDiagram Diagram_ => default;

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        public object Element { get; set; }

        /// <summary>
        /// Gets or sets the jump link status.
        /// </summary>
        public Auriga.Sirius.Notation.JumpLinkStatus? JumpLinkStatus { get; set; }

        /// <summary>
        /// Gets or sets the jump link type.
        /// </summary>
        public Auriga.Sirius.Notation.JumpLinkType? JumpLinkType { get; set; }

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
        public Auriga.IContainerList<Auriga.Sirius.Notation.INode> PersistedChildren => this.backingPersistedChildren ??= new Auriga.ContainerList<Auriga.Sirius.Notation.INode>(this);

        /// <summary>
        /// Backing field for <see cref="PersistedChildren"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Notation.INode> backingPersistedChildren;

        /// <summary>
        /// Gets or sets the rounded bendpoints radius.
        /// </summary>
        public int? RoundedBendpointsRadius { get; set; }

        /// <summary>
        /// Gets or sets the routing.
        /// </summary>
        public Auriga.Sirius.Notation.Routing? Routing { get; set; }

        /// <summary>
        /// Gets or sets the smoothness.
        /// </summary>
        public Auriga.Sirius.Notation.Smoothness? Smoothness { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public Auriga.Sirius.Notation.IView Source { get; set; }

        /// <summary>
        /// Gets or sets the source anchor.
        /// </summary>
        public Auriga.Sirius.Notation.IAnchor SourceAnchor
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
        private Auriga.Sirius.Notation.IAnchor backingSourceAnchor;

        /// <summary>
        /// Gets the source edges.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Notation.IEdge> SourceEdges => Enumerable.Empty<Auriga.Sirius.Notation.IEdge>();

        /// <summary>
        /// Gets the styles.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Notation.IStyle> Styles => this.backingStyles ??= new Auriga.ContainerList<Auriga.Sirius.Notation.IStyle>(this);

        /// <summary>
        /// Backing field for <see cref="Styles"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Notation.IStyle> backingStyles;

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public Auriga.Sirius.Notation.IView Target { get; set; }

        /// <summary>
        /// Gets or sets the target anchor.
        /// </summary>
        public Auriga.Sirius.Notation.IAnchor TargetAnchor
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
        private Auriga.Sirius.Notation.IAnchor backingTargetAnchor;

        /// <summary>
        /// Gets the target edges.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Notation.IEdge> TargetEdges => Enumerable.Empty<Auriga.Sirius.Notation.IEdge>();

        /// <summary>
        /// Gets the transient children.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Notation.INode> TransientChildren => Enumerable.Empty<Auriga.Sirius.Notation.INode>();

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
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
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
