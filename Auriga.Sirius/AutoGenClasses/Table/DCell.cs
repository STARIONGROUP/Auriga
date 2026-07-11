// ------------------------------------------------------------------------------------------------
// <copyright file="DCell.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Table
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>DCell</c> class.
    /// </summary>
    public partial class DCell : Auriga.AurigaElement, Auriga.Sirius.Table.IDCell
    {
        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        public Auriga.Sirius.Table.IDColumn Column { get; set; }

        /// <summary>
        /// Stores the best style of the IntersectionMapping style updater and ColumnMapping style updater :
        /// *
        /// Foreground
        /// ** The first conditional foreground style of the cell (with predicate expression that
        /// returns true). In this case the foregroundStyleOrigin references the intersection mapping and the
        /// defaultForegroundStyle is equal false.
        /// ** Otherwise the first conditional foreground style of the
        /// column (with predicate expression that returns true). In this case the foregroundStyleOrigin
        /// references the column mapping and the defaultForegroundStyle is equal false.
        /// ** Otherwise, if it
        /// exists, the default foreground style of the cell. In this case the foregroundStyleOrigin references
        /// the intersection mapping and the defaultForegroundStyle is equal true.
        /// ** Otherwise, if the default
        /// foreground style of the column uses variable color, the default foreground style of the column. In
        /// this case the foregroundStyleOrigin references the column mapping and the defaultForegroundStyle is
        /// equal true.
        /// * Background
        /// ** The first conditional background style of the cell (with predicate
        /// expression that returns true). In this case the backgroundStyleOrigin references the intersection
        /// mapping and the defaultBackgroundStyle is equal false.
        /// ** Otherwise the first conditional background
        /// style of the column (with predicate expression that returns true). In this case the
        /// backgroundStyleOrigin references the column mapping and the defaultBackgroundStyle is equal
        /// false.
        /// ** Otherwise, if it exists, the default background style of the cell. In this case the
        /// backgroundStyleOrigin references the intersection mapping and the defaultBackgroundStyle is equal
        /// true.
        /// ** Otherwise, if the default background style of the column uses variable color, the default
        /// background style of the column. In this case the backgroundStyleOrigin references the column mapping
        /// and the defaultBackgroundStyle is equal true.
        /// </summary>
        public Auriga.Sirius.Table.IDCellStyle CurrentStyle
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
        private Auriga.Sirius.Table.IDCellStyle backingCurrentStyle;

        /// <summary>
        /// Gets or sets the intersection mapping.
        /// </summary>
        public Auriga.Sirius.Table.Description.IIntersectionMapping IntersectionMapping { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the line.
        /// </summary>
        public Auriga.Sirius.Table.IDLine Line { get; set; }

        /// <summary>
        /// The name of the element. It is the name that is displayed on the diagram.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The semantic elements to show that represents this view point element.
        /// </summary>
        public List<object> SemanticElements { get; } = new List<object>();

        /// <summary>
        /// The mapping of the element.
        /// </summary>
        public Auriga.Sirius.Table.Description.ITableMapping TableElementMapping => default;

        /// <summary>
        /// The referenced EObject.
        /// </summary>
        public object Target { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Gets the updater.
        /// </summary>
        public Auriga.Sirius.Table.Description.ICellUpdater Updater => default;

        /// <summary>
        /// Gets the elements directly contained by this <c>DCell</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
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
