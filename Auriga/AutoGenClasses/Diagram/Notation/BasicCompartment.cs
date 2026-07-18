// ------------------------------------------------------------------------------------------------
// <copyright file="BasicCompartment.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>BasicCompartment</c> class.
    /// </summary>
    public partial class BasicCompartment : Auriga.Core.AurigaElement, Auriga.Diagram.Notation.IBasicCompartment
    {
        /// <summary>
        /// Gets or sets the collapsed.
        /// </summary>
        public bool? Collapsed { get; set; } = false;

        /// <summary>
        /// Gets the diagram.
        /// </summary>
        public Auriga.Diagram.Notation.IDiagram Diagram_ => default;

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        public object Element { get; set; }

        /// <summary>
        /// Gets or sets the layout constraint.
        /// </summary>
        public Auriga.Diagram.Notation.ILayoutConstraint LayoutConstraint
        {
            get => this.backingLayoutConstraint;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingLayoutConstraint = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="LayoutConstraint"/>.
        /// </summary>
        private Auriga.Diagram.Notation.ILayoutConstraint backingLayoutConstraint;

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
        public string Type { get; set; } = "";

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        public bool? Visible { get; set; } = true;

        /// <summary>
        /// Gets the elements directly contained by this <c>BasicCompartment</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.LayoutConstraint != null)
            {
                yield return this.LayoutConstraint;
            }

            foreach (var element in this.PersistedChildren)
            {
                yield return element;
            }

            foreach (var element in this.Styles)
            {
                yield return element;
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
