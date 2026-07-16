// ------------------------------------------------------------------------------------------------
// <copyright file="IDTable.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>DTable</c> interface.
    /// </summary>
    public partial interface IDTable : Auriga.Diagram.Viewpoint.IDRepresentation, Auriga.Diagram.Table.ILineContainer
    {
        /// <summary>
        /// Gets the columns.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Table.IDColumn> Columns { get; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        Auriga.Diagram.Table.Description.ITableDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the header column width.
        /// </summary>
        int? HeaderColumnWidth { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
