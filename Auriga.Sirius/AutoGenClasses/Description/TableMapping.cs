// ------------------------------------------------------------------------------------------------
// <copyright file="TableMapping.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// Definition of the <c>TableMapping</c> class.
    /// </summary>
    public partial class TableMapping : Auriga.Core.AurigaElement, Auriga.Sirius.Table.Description.ITableMapping
    {
        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationCreationDescription> DetailDescriptions { get; } = new List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationCreationDescription>();

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// All details that can be created from this node.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationNavigationDescription> NavigationDescriptions { get; } = new List<Auriga.Sirius.Viewpoint.Description.Tool.IRepresentationNavigationDescription>();

        /// <summary>
        /// The elements that are represented by this mapping.
        /// </summary>
        public string SemanticElements { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
