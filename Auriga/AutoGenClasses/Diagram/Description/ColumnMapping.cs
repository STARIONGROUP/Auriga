// ------------------------------------------------------------------------------------------------
// <copyright file="ColumnMapping.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ColumnMapping</c> class.
    /// </summary>
    public partial class ColumnMapping : Auriga.Core.AurigaElement, Auriga.Diagram.Table.Description.IColumnMapping
    {
        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription> DetailDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationCreationDescription>();

        /// <summary>
        /// Gets or sets the header label expression.
        /// </summary>
        public string HeaderLabelExpression { get; set; }

        /// <summary>
        /// The initial width of the column (calculated if not available).
        /// </summary>
        public int? InitialWidth { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription> NavigationDescriptions { get; } = new List<Auriga.Diagram.Viewpoint.Description.Tool.IRepresentationNavigationDescription>();

        /// <summary>
        /// The elements that are represented by this mapping.
        /// </summary>
        public string SemanticElements { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
