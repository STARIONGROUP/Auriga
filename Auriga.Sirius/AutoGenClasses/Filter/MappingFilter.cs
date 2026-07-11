// ------------------------------------------------------------------------------------------------
// <copyright file="MappingFilter.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Filter
{
    using System.Collections.Generic;

    /// <summary>
    /// A filter that filters mappings.
    /// </summary>
    public partial class MappingFilter : Auriga.AurigaElement, Auriga.Sirius.Diagram.Description.Filter.IMappingFilter
    {
        /// <summary>
        /// A filter might hide elements or just shrink them. In the case of the shrink, the edges going to this element will be kept.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Filter.FilterKind? FilterKind { get; set; }

        /// <summary>
        /// All mappings to filter.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> Mappings { get; } = new List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping>();

        /// <summary>
        /// The condition to apply on the semantic element, if true the element is filtered.
        /// </summary>
        public string SemanticConditionExpression { get; set; }

        /// <summary>
        /// The condition to apply on the view element.
        /// </summary>
        public string ViewConditionExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
