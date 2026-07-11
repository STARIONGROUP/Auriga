// ------------------------------------------------------------------------------------------------
// <copyright file="IDColumn.cs" company="Starion Group S.A.">
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
    using System.Linq;

    /// <summary>
    /// Definition of the <c>DColumn</c> interface.
    /// </summary>
    public partial interface IDColumn : Auriga.Sirius.Table.IDTableElement
    {
        /// <summary>
        /// List of cells of this column. This list does not necessarily have as many cells as there are lines.
        /// Indeed, the «blank cells» are not created.
        /// </summary>
        List<Auriga.Sirius.Table.IDCell> Cells { get; }

        /// <summary>
        /// Stores the best style of the ColumnMapping style updater :
        /// * The best style is only the default
        /// foreground style and the default background style (and only if the color use for it is not with
        /// variable parts: ComputedColor or InterpolatedColor). 
        /// * We can not store the result of the
        /// conditional styles (foreground and background) because the predicateExpression depend on the
        /// semantic element of each line.
        /// </summary>
        Auriga.Sirius.Table.IDTableElementStyle CurrentStyle { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Same list as a"cells" but sorted according to the order of lines.
        /// </summary>
        IEnumerable<Auriga.Sirius.Table.IDCell> OrderedCells { get; }

        /// <summary>
        /// Gets or sets the origin mapping.
        /// </summary>
        Auriga.Sirius.Table.Description.IColumnMapping OriginMapping { get; set; }

        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        Auriga.Sirius.Table.IDTable Table { get; set; }

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        int? Width { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
