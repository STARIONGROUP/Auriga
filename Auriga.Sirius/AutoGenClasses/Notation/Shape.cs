// ------------------------------------------------------------------------------------------------
// <copyright file="Shape.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Shape</c> class.
    /// </summary>
    public partial class Shape : Auriga.AurigaElement, Auriga.Sirius.Notation.IShape
    {
        /// <summary>
        /// Gets or sets the bold.
        /// </summary>
        public bool? Bold { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the diagram.
        /// </summary>
        public Auriga.Sirius.Notation.IDiagram Diagram_ => default;

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        public object Element { get; set; }

        /// <summary>
        /// Gets or sets the fill color.
        /// </summary>
        public int? FillColor { get; set; }

        /// <summary>
        /// Gets or sets the font color.
        /// </summary>
        public int? FontColor { get; set; }

        /// <summary>
        /// Gets or sets the font height.
        /// </summary>
        public int? FontHeight { get; set; }

        /// <summary>
        /// Gets or sets the font name.
        /// </summary>
        public string FontName { get; set; }

        /// <summary>
        /// Gets or sets the gradient.
        /// </summary>
        public string Gradient { get; set; }

        /// <summary>
        /// Gets or sets the italic.
        /// </summary>
        public bool? Italic { get; set; }

        /// <summary>
        /// Gets or sets the layout constraint.
        /// </summary>
        public Auriga.Sirius.Notation.ILayoutConstraint LayoutConstraint
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
        private Auriga.Sirius.Notation.ILayoutConstraint backingLayoutConstraint;

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
        /// Gets the source edges.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Notation.IEdge> SourceEdges => Enumerable.Empty<Auriga.Sirius.Notation.IEdge>();

        /// <summary>
        /// Gets or sets the strike through.
        /// </summary>
        public bool? StrikeThrough { get; set; }

        /// <summary>
        /// Gets the styles.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Notation.IStyle> Styles => this.backingStyles ??= new Auriga.ContainerList<Auriga.Sirius.Notation.IStyle>(this);

        /// <summary>
        /// Backing field for <see cref="Styles"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Notation.IStyle> backingStyles;

        /// <summary>
        /// Gets the target edges.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Notation.IEdge> TargetEdges => Enumerable.Empty<Auriga.Sirius.Notation.IEdge>();

        /// <summary>
        /// Gets the transient children.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Notation.INode> TransientChildren => Enumerable.Empty<Auriga.Sirius.Notation.INode>();

        /// <summary>
        /// Gets or sets the transparency.
        /// </summary>
        public int? Transparency { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the underline.
        /// </summary>
        public bool? Underline { get; set; }

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        public bool? Visible { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>Shape</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
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
