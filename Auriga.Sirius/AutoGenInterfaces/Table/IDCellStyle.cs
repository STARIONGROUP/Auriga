// ------------------------------------------------------------------------------------------------
// <copyright file="IDCellStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>DCellStyle</c> interface.
    /// </summary>
    public partial interface IDCellStyle : Auriga.Sirius.Table.IDTableElementStyle
    {
        /// <summary>
        /// Needed to know the origin of the background part of this DCellStyle to respect the style priority rules between Cell, Line and Column.
        /// This TableMapping can be only an IntersectionMapping or a  ColumnMapping.
        /// </summary>
        Auriga.Sirius.Table.Description.ITableMapping BackgroundStyleOrigin { get; set; }

        /// <summary>
        /// Needed to know the origin of the foreground part of this DCellStyle to respect the style priority rules between Cell, Line and Column.
        /// This TableMapping can be only an IntersectionMapping or a  ColumnMapping.
        /// </summary>
        Auriga.Sirius.Table.Description.ITableMapping ForegroundStyleOrigin { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
