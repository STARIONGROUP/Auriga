// ------------------------------------------------------------------------------------------------
// <copyright file="ConcernDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Concern
{
    using System.Collections.Generic;

    /// <summary>
    /// Describe a concern. A concern could be seen as an aspect. It allows to enable some filters, validation rules or behaviors in one click.
    /// </summary>
    public partial class ConcernDescription : Auriga.AurigaElement, Auriga.Sirius.Diagram.Description.Concern.IConcernDescription
    {
        /// <summary>
        /// All behaviors of the concern.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.Tool.IBehaviorTool> Behaviors { get; } = new List<Auriga.Sirius.Diagram.Description.Tool.IBehaviorTool>();

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// All filters of this concern.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.Filter.IFilterDescription> Filters { get; } = new List<Auriga.Sirius.Diagram.Description.Filter.IFilterDescription>();

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// All rules of this concern.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.Description.Validation.IValidationRule> Rules { get; } = new List<Auriga.Sirius.Viewpoint.Description.Validation.IValidationRule>();

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
