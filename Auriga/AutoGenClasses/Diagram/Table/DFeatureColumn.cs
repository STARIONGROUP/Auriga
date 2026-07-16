// ------------------------------------------------------------------------------------------------
// <copyright file="DFeatureColumn.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DFeatureColumn</c> class.
    /// </summary>
    public partial class DFeatureColumn : Auriga.Core.AurigaElement, Auriga.Diagram.Table.IDFeatureColumn
    {
        /// <summary>
        /// List of cells of this column. This list does not necessarily have as many cells as there are lines. Indeed, the «blank cells» are not created.
        /// </summary>
        public List<Auriga.Diagram.Table.IDCell> Cells { get; } = new List<Auriga.Diagram.Table.IDCell>();

        /// <summary>
        /// Stores the best style of the ColumnMapping style updater :
        /// * The best style is only the default foreground style and the default background style (and only if the color use for it is not with variable parts: ComputedColor or InterpolatedColor).
        /// * We can not store the result of the conditional styles (foreground and background) because the predicateExpression depend on the semantic element of each line.
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
        /// Gets or sets the feature name.
        /// </summary>
        public string FeatureName { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The name of the element. It is the name that is displayed on the diagram.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Same list as a"cells" but sorted according to the order of lines.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Table.IDCell> OrderedCells => Enumerable.Empty<Auriga.Diagram.Table.IDCell>();

        /// <summary>
        /// Gets or sets the origin mapping.
        /// </summary>
        public Auriga.Diagram.Table.Description.IColumnMapping OriginMapping { get; set; }

        /// <summary>
        /// The semantic elements to show that represents this view point element.
        /// </summary>
        public List<object> SemanticElements { get; } = new List<object>();

        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        public Auriga.Diagram.Table.IDTable Table { get; set; }

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
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DFeatureColumn</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.CurrentStyle != null)
            {
                yield return this.CurrentStyle;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
