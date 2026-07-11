// ------------------------------------------------------------------------------------------------
// <copyright file="StandardDiagram.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>StandardDiagram</c> class.
    /// </summary>
    public partial class StandardDiagram : Auriga.AurigaElement, Auriga.Sirius.Notation.IStandardDiagram
    {
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
        /// Gets the horizontal guides.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Notation.IGuide> HorizontalGuides => this.backingHorizontalGuides ??= new Auriga.ContainerList<Auriga.Sirius.Notation.IGuide>(this);

        /// <summary>
        /// Backing field for <see cref="HorizontalGuides"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Notation.IGuide> backingHorizontalGuides;

        /// <summary>
        /// Gets or sets the measurement unit.
        /// </summary>
        public Auriga.Sirius.Notation.MeasurementUnit? MeasurementUnit { get; set; }

        /// <summary>
        /// Gets the mutable.
        /// </summary>
        public bool? Mutable => default;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the page height.
        /// </summary>
        public int? PageHeight { get; set; }

        /// <summary>
        /// Gets or sets the page width.
        /// </summary>
        public int? PageWidth { get; set; }

        /// <summary>
        /// Gets or sets the page x.
        /// </summary>
        public int? PageX { get; set; }

        /// <summary>
        /// Gets or sets the page y.
        /// </summary>
        public int? PageY { get; set; }

        /// <summary>
        /// Gets the persisted children.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Notation.INode> PersistedChildren => this.backingPersistedChildren ??= new Auriga.ContainerList<Auriga.Sirius.Notation.INode>(this);

        /// <summary>
        /// Backing field for <see cref="PersistedChildren"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Notation.INode> backingPersistedChildren;

        /// <summary>
        /// Gets the persisted edges.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Notation.IEdge> PersistedEdges => this.backingPersistedEdges ??= new Auriga.ContainerList<Auriga.Sirius.Notation.IEdge>(this);

        /// <summary>
        /// Backing field for <see cref="PersistedEdges"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Notation.IEdge> backingPersistedEdges;

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
        /// Gets the target edges.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Notation.IEdge> TargetEdges => Enumerable.Empty<Auriga.Sirius.Notation.IEdge>();

        /// <summary>
        /// Gets the transient children.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Notation.INode> TransientChildren => Enumerable.Empty<Auriga.Sirius.Notation.INode>();

        /// <summary>
        /// Gets the transient edges.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Notation.IEdge> TransientEdges => Enumerable.Empty<Auriga.Sirius.Notation.IEdge>();

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets the vertical guides.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Notation.IGuide> VerticalGuides => this.backingVerticalGuides ??= new Auriga.ContainerList<Auriga.Sirius.Notation.IGuide>(this);

        /// <summary>
        /// Backing field for <see cref="VerticalGuides"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Notation.IGuide> backingVerticalGuides;

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        public bool? Visible { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>StandardDiagram</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.HorizontalGuides)
            {
                yield return element;
            }

            foreach (var element in this.PersistedChildren)
            {
                yield return element;
            }

            foreach (var element in this.PersistedEdges)
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

            foreach (var element in this.TransientEdges)
            {
                yield return element;
            }

            foreach (var element in this.VerticalGuides)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
