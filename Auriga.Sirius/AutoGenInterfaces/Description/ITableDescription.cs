// ------------------------------------------------------------------------------------------------
// <copyright file="ITableDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TableDescription</c> interface.
    /// </summary>
    public partial interface ITableDescription : Auriga.Sirius.Viewpoint.Description.IRepresentationDescription, Auriga.Sirius.Viewpoint.Description.IDocumentedElement, Auriga.Sirius.Viewpoint.Description.IEndUserDocumentedElement
    {
        /// <summary>
        /// Gets the all create line.
        /// </summary>
        IEnumerable<Auriga.Sirius.Table.Description.ICreateLineTool> AllCreateLine { get; }

        /// <summary>
        /// Gets the all line mappings.
        /// </summary>
        IEnumerable<Auriga.Sirius.Table.Description.ILineMapping> AllLineMappings { get; }

        /// <summary>
        /// All tools of the section.
        /// </summary>
        IEnumerable<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationCreationDescription> AllRepresentationCreationDescriptions { get; }

        /// <summary>
        /// All navigation tools.
        /// </summary>
        IEnumerable<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationNavigationDescription> AllRepresentationNavigationDescriptions { get; }

        /// <summary>
        /// Gets or sets the domain class.
        /// </summary>
        string DomainClass { get; set; }

        /// <summary>
        /// Gets the imported elements.
        /// </summary>
        Auriga.IContainerList<Auriga.IAurigaElement> ImportedElements { get; }

        /// <summary>
        /// The initial width of the column header (calculated if not available).
        /// </summary>
        int? InitialHeaderColumnWidth { get; set; }

        /// <summary>
        /// Gets the owned create line.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Table.Description.ICreateLineTool> OwnedCreateLine { get; }

        /// <summary>
        /// Gets the owned line mappings.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Table.Description.ILineMapping> OwnedLineMappings { get; }

        /// <summary>
        /// All tools of the section.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationCreationDescription> OwnedRepresentationCreationDescriptions { get; }

        /// <summary>
        /// All navigation tools.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationNavigationDescription> OwnedRepresentationNavigationDescriptions { get; }

        /// <summary>
        /// The precondition (Acceleo Expression).
        /// </summary>
        string PreconditionExpression { get; set; }

        /// <summary>
        /// Gets the reused create line.
        /// </summary>
        List<Auriga.Sirius.Table.Description.ICreateLineTool> ReusedCreateLine { get; }

        /// <summary>
        /// Gets the reused line mappings.
        /// </summary>
        List<Auriga.Sirius.Table.Description.ILineMapping> ReusedLineMappings { get; }

        /// <summary>
        /// All tools of the section.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationCreationDescription> ReusedRepresentationCreationDescriptions { get; }

        /// <summary>
        /// All navigation tools.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationNavigationDescription> ReusedRepresentationNavigationDescriptions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
