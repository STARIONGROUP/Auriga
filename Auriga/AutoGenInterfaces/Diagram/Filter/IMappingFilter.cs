// ------------------------------------------------------------------------------------------------
// <copyright file="IMappingFilter.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Filter
{
    using System.Collections.Generic;

    /// <summary>
    /// A filter that filters mappings.
    /// </summary>
    public partial interface IMappingFilter : Auriga.Diagram.Diagram.Description.Filter.IFilter
    {
        /// <summary>
        /// All mappings to filter.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.IDiagramElementMapping> Mappings { get; }

        /// <summary>
        /// The condition to apply on the semantic element, if true the element is filtered.
        /// </summary>
        string SemanticConditionExpression { get; set; }

        /// <summary>
        /// The condition to apply on the view element.
        /// </summary>
        string ViewConditionExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
