// ------------------------------------------------------------------------------------------------
// <copyright file="IConcernDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Concern
{
    using System.Collections.Generic;

    /// <summary>
    /// Describe a concern. A concern could be seen as an aspect. It allows to enable some filters, validation rules or behaviors in one click.
    /// </summary>
    public partial interface IConcernDescription : Auriga.Diagram.Viewpoint.Description.IDocumentedElement, Auriga.Diagram.Viewpoint.Description.IIdentifiedElement
    {
        /// <summary>
        /// All behaviors of the concern.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.Tool.IBehaviorTool> Behaviors { get; }

        /// <summary>
        /// All filters of this concern.
        /// </summary>
        List<Auriga.Diagram.Diagram.Description.Filter.IFilterDescription> Filters { get; }

        /// <summary>
        /// All rules of this concern.
        /// </summary>
        List<Auriga.Diagram.Viewpoint.Description.Validation.IValidationRule> Rules { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
