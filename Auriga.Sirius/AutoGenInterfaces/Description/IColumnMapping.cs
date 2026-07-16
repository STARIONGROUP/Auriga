// ------------------------------------------------------------------------------------------------
// <copyright file="IColumnMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Table.Description
{
    /// <summary>
    /// Definition of the <c>ColumnMapping</c> interface.
    /// </summary>
    public partial interface IColumnMapping : Auriga.Sirius.Table.Description.ITableMapping
    {
        /// <summary>
        /// Gets or sets the header label expression.
        /// </summary>
        string HeaderLabelExpression { get; set; }

        /// <summary>
        /// The initial width of the column (calculated if not available).
        /// </summary>
        int? InitialWidth { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
