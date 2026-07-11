// ------------------------------------------------------------------------------------------------
// <copyright file="IDCell.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>DCell</c> interface.
    /// </summary>
    public partial interface IDCell : Auriga.Sirius.Viewpoint.IDSemanticDecorator, Auriga.Sirius.Table.IDTableElement
    {
        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        Auriga.Sirius.Table.IDColumn Column { get; set; }

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
        Auriga.Sirius.Table.IDCellStyle CurrentStyle { get; set; }

        /// <summary>
        /// Gets or sets the intersection mapping.
        /// </summary>
        Auriga.Sirius.Table.Description.IIntersectionMapping IntersectionMapping { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Gets or sets the line.
        /// </summary>
        Auriga.Sirius.Table.IDLine Line { get; set; }

        /// <summary>
        /// Gets the updater.
        /// </summary>
        Auriga.Sirius.Table.Description.ICellUpdater Updater { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
