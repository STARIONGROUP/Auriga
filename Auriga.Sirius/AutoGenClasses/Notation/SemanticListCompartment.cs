// ------------------------------------------------------------------------------------------------
// <copyright file="SemanticListCompartment.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>SemanticListCompartment</c> class.
    /// </summary>
    public partial class SemanticListCompartment : Auriga.Core.AurigaElement, Auriga.Sirius.Notation.ISemanticListCompartment
    {
        /// <summary>
        /// Gets or sets the collapsed.
        /// </summary>
        public bool? Collapsed { get; set; }

        /// <summary>
        /// Gets the diagram.
        /// </summary>
        public Auriga.Sirius.Notation.IDiagram Diagram_ => default;

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        public object Element { get; set; }

        /// <summary>
        /// Gets the filtered objects.
        /// </summary>
        public List<object> FilteredObjects { get; } = new List<object>();

        /// <summary>
        /// Gets or sets the filtering.
        /// </summary>
        public Auriga.Sirius.Notation.Filtering? Filtering { get; set; }

        /// <summary>
        /// Gets or sets the filtering keys.
        /// </summary>
        public string FilteringKeys { get; set; }

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
        /// Gets the mutable.
        /// </summary>
        public bool? Mutable => default;

        /// <summary>
        /// Gets the persisted children.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Notation.INode> PersistedChildren => this.backingPersistedChildren ??= new Auriga.Core.ContainerList<Auriga.Sirius.Notation.INode>(this);

        /// <summary>
        /// Backing field for <see cref="PersistedChildren"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Notation.INode> backingPersistedChildren;

        /// <summary>
        /// Gets or sets the show title.
        /// </summary>
        public bool? ShowTitle { get; set; }

        /// <summary>
        /// Gets the sorted objects.
        /// </summary>
        public List<object> SortedObjects { get; } = new List<object>();

        /// <summary>
        /// Gets or sets the sorting.
        /// </summary>
        public Auriga.Sirius.Notation.Sorting? Sorting { get; set; }

        /// <summary>
        /// Gets or sets the sorting keys.
        /// </summary>
        public string SortingKeys { get; set; }

        /// <summary>
        /// Gets the source edges.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Notation.IEdge> SourceEdges => Enumerable.Empty<Auriga.Sirius.Notation.IEdge>();

        /// <summary>
        /// Gets the styles.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Notation.IStyle> Styles => this.backingStyles ??= new Auriga.Core.ContainerList<Auriga.Sirius.Notation.IStyle>(this);

        /// <summary>
        /// Backing field for <see cref="Styles"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Notation.IStyle> backingStyles;

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
        /// Gets the elements directly contained by this <c>SemanticListCompartment</c>.
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
