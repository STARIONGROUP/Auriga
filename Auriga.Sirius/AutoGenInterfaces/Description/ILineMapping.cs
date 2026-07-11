// ------------------------------------------------------------------------------------------------
// <copyright file="ILineMapping.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>LineMapping</c> interface.
    /// </summary>
    public partial interface ILineMapping : Auriga.Sirius.Table.Description.ITableMapping, Auriga.Sirius.Table.Description.IStyleUpdater
    {
        /// <summary>
        /// Gets the all sub lines.
        /// </summary>
        IEnumerable<Auriga.Sirius.Table.Description.ILineMapping> AllSubLines { get; }

        /// <summary>
        /// Gets the create.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.ICreateLineTool> Create { get; }

        /// <summary>
        /// Gets or sets the delete.
        /// </summary>
        Auriga.Sirius.Table.Description.IDeleteLineTool Delete { get; set; }

        /// <summary>
        /// Gets or sets the domain class.
        /// </summary>
        string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the header label expression.
        /// </summary>
        string HeaderLabelExpression { get; set; }

        /// <summary>
        /// Gets the owned sub lines.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.ILineMapping> OwnedSubLines { get; }

        /// <summary>
        /// Gets the reused in mappings.
        /// </summary>
        List<Auriga.Sirius.Table.Description.ILineMapping> ReusedInMappings { get; }

        /// <summary>
        /// Gets the reused sub lines.
        /// </summary>
        List<Auriga.Sirius.Table.Description.ILineMapping> ReusedSubLines { get; }

        /// <summary>
        /// Gets or sets the semantic candidates expression.
        /// </summary>
        string SemanticCandidatesExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
