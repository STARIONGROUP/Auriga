// ------------------------------------------------------------------------------------------------
// <copyright file="IElementColumnMapping.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ElementColumnMapping</c> interface.
    /// </summary>
    public partial interface IElementColumnMapping : Auriga.Sirius.Table.Description.IColumnMapping, Auriga.Sirius.Table.Description.IStyleUpdater
    {
        /// <summary>
        /// Gets the create.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Table.Description.ICreateColumnTool> Create { get; }

        /// <summary>
        /// Gets or sets the delete.
        /// </summary>
        Auriga.Sirius.Table.Description.IDeleteColumnTool Delete { get; set; }

        /// <summary>
        /// Gets or sets the domain class.
        /// </summary>
        string DomainClass { get; set; }

        /// <summary>
        /// Gets or sets the semantic candidates expression.
        /// </summary>
        string SemanticCandidatesExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
