// ------------------------------------------------------------------------------------------------
// <copyright file="IIntersectionMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Table.Description
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>IntersectionMapping</c> interface.
    /// </summary>
    public partial interface IIntersectionMapping : Auriga.Diagram.Table.Description.ITableMapping, Auriga.Diagram.Table.Description.ICellUpdater, Auriga.Diagram.Table.Description.IStyleUpdater
    {
        /// <summary>
        /// Gets or sets the column finder expression.
        /// </summary>
        string ColumnFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the column mapping.
        /// </summary>
        Auriga.Diagram.Table.Description.IColumnMapping ColumnMapping { get; set; }

        /// <summary>
        /// Gets or sets the create.
        /// </summary>
        Auriga.Diagram.Table.Description.ICreateCellTool Create { get; set; }

        /// <summary>
        /// Gets or sets the domain class.
        /// </summary>
        string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the label expression.
        /// </summary>
        string LabelExpression { get; set; }

        /// <summary>
        /// Gets or sets the line finder expression.
        /// </summary>
        string LineFinderExpression { get; set; }

        /// <summary>
        /// Gets the line mapping.
        /// </summary>
        List<Auriga.Diagram.Table.Description.ILineMapping> LineMapping { get; }

        /// <summary>
        /// An expression guarding the effect if evaluated to false.
        /// </summary>
        string PreconditionExpression { get; set; }

        /// <summary>
        /// Gets or sets the semantic candidates expression.
        /// </summary>
        string SemanticCandidatesExpression { get; set; }

        /// <summary>
        /// Gets or sets the use domain class.
        /// </summary>
        bool UseDomainClass { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
