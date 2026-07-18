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

namespace Auriga.Diagram.Notation
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>StandardDiagram</c> class.
    /// </summary>
    public partial class StandardDiagram : Auriga.Core.AurigaElement, Auriga.Diagram.Notation.IStandardDiagram
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// Gets the diagram.
        /// </summary>
        public Auriga.Diagram.Notation.IDiagram Diagram_ => default;

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        public object Element { get; set; }

        /// <summary>
        /// Gets the horizontal guides.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Notation.IGuide> HorizontalGuides => this.backingHorizontalGuides ??= new Auriga.Core.ContainerList<Auriga.Diagram.Notation.IGuide>(this);

        /// <summary>
        /// Backing field for <see cref="HorizontalGuides"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Notation.IGuide> backingHorizontalGuides;

        /// <summary>
        /// Gets or sets the measurement unit.
        /// </summary>
        public Auriga.Diagram.Notation.MeasurementUnit? MeasurementUnit { get; set; } = Auriga.Diagram.Notation.MeasurementUnit.Himetric;

        /// <summary>
        /// Gets the mutable.
        /// </summary>
        public bool? Mutable => default;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Gets or sets the page height.
        /// </summary>
        public int? PageHeight { get; set; } = 100;

        /// <summary>
        /// Gets or sets the page width.
        /// </summary>
        public int? PageWidth { get; set; } = 100;

        /// <summary>
        /// Gets or sets the page x.
        /// </summary>
        public int? PageX { get; set; } = 0;

        /// <summary>
        /// Gets or sets the page y.
        /// </summary>
        public int? PageY { get; set; } = 0;

        /// <summary>
        /// Gets the persisted children.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Notation.INode> PersistedChildren => this.backingPersistedChildren ??= new Auriga.Core.ContainerList<Auriga.Diagram.Notation.INode>(this);

        /// <summary>
        /// Backing field for <see cref="PersistedChildren"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Notation.INode> backingPersistedChildren;

        /// <summary>
        /// Gets the persisted edges.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Notation.IEdge> PersistedEdges => this.backingPersistedEdges ??= new Auriga.Core.ContainerList<Auriga.Diagram.Notation.IEdge>(this);

        /// <summary>
        /// Backing field for <see cref="PersistedEdges"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Notation.IEdge> backingPersistedEdges;

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
        /// Gets the transient edges.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Notation.IEdge> TransientEdges => Enumerable.Empty<Auriga.Diagram.Notation.IEdge>();

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; } = "";

        /// <summary>
        /// Gets the vertical guides.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Notation.IGuide> VerticalGuides => this.backingVerticalGuides ??= new Auriga.Core.ContainerList<Auriga.Diagram.Notation.IGuide>(this);

        /// <summary>
        /// Backing field for <see cref="VerticalGuides"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Notation.IGuide> backingVerticalGuides;

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        public bool? Visible { get; set; } = true;

        /// <summary>
        /// Gets the elements directly contained by this <c>StandardDiagram</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
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
