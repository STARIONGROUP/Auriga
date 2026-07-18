// ------------------------------------------------------------------------------------------------
// <copyright file="DLine.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Table
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>DLine</c> class.
    /// </summary>
    public partial class DLine : Auriga.Core.AurigaElement, Auriga.Diagram.Table.IDLine
    {
        /// <summary>
        /// List of cells of this line. This list does not necessarily have as many cells as there are columns. Indeed, the «blank cells» are not created.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Table.IDCell> Cells => this.backingCells ??= new Auriga.Core.ContainerList<Auriga.Diagram.Table.IDCell>(this);

        /// <summary>
        /// Backing field for <see cref="Cells"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Table.IDCell> backingCells;

        /// <summary>
        /// Gets or sets the collapsed.
        /// </summary>
        public bool Collapsed { get; set; } = false;

        /// <summary>
        /// Stores the best style of the LineMapping style updater :
        /// * The first conditional foreground style (with predicate expression that returns true), otherwise the default foreground style.
        /// * The first conditional background style (with predicate expression that returns true), otherwise the default background style.
        /// </summary>
        public Auriga.Diagram.Table.IDTableElementStyle CurrentStyle
        {
            get => this.backingCurrentStyle;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingCurrentStyle = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="CurrentStyle"/>.
        /// </summary>
        private Auriga.Diagram.Table.IDTableElementStyle backingCurrentStyle;

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets the lines.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Table.IDLine> Lines => this.backingLines ??= new Auriga.Core.ContainerList<Auriga.Diagram.Table.IDLine>(this);

        /// <summary>
        /// Backing field for <see cref="Lines"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Table.IDLine> backingLines;

        /// <summary>
        /// The name of the element. It is the name that is displayed on the diagram.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Same list as "cells" but sorted according to the order of columns.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Table.IDCell> OrderedCells => Enumerable.Empty<Auriga.Diagram.Table.IDCell>();

        /// <summary>
        /// Gets or sets the origin mapping.
        /// </summary>
        public Auriga.Diagram.Table.Description.ILineMapping OriginMapping { get; set; }

        /// <summary>
        /// The semantic elements to show that represents this view point element.
        /// </summary>
        public List<object> SemanticElements { get; } = new List<object>();

        /// <summary>
        /// The mapping of the element.
        /// </summary>
        public Auriga.Diagram.Table.Description.ITableMapping TableElementMapping => default;

        /// <summary>
        /// The referenced EObject.
        /// </summary>
        public object Target { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Gets the elements directly contained by this <c>DLine</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Cells)
            {
                yield return element;
            }

            if (this.CurrentStyle != null)
            {
                yield return this.CurrentStyle;
            }

            foreach (var element in this.Lines)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
