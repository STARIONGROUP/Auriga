// ------------------------------------------------------------------------------------------------
// <copyright file="IDLine.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DLine</c> interface.
    /// </summary>
    public partial interface IDLine : Auriga.Sirius.Table.ILineContainer, Auriga.Sirius.Table.IDTableElement
    {
        /// <summary>
        /// List of cells of this line. This list does not necessarily have as many cells as there are columns. Indeed, the «blank cells» are not created.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Table.IDCell> Cells { get; }

        /// <summary>
        /// Gets or sets the collapsed.
        /// </summary>
        bool Collapsed { get; set; }

        /// <summary>
        /// Stores the best style of the LineMapping style updater :
        /// * The first conditional foreground style (with predicate expression that returns true), otherwise the default foreground style.
        /// * The first conditional background style (with predicate expression that returns true), otherwise the default background style.
        /// </summary>
        Auriga.Sirius.Table.IDTableElementStyle CurrentStyle { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Same list as "cells" but sorted according to the order of columns.
        /// </summary>
        IEnumerable<Auriga.Sirius.Table.IDCell> OrderedCells { get; }

        /// <summary>
        /// Gets or sets the origin mapping.
        /// </summary>
        Auriga.Sirius.Table.Description.ILineMapping OriginMapping { get; set; }

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        bool Visible { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
