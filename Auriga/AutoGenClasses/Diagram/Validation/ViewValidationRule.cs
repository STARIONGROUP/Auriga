// ------------------------------------------------------------------------------------------------
// <copyright file="ViewValidationRule.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description.Validation
{
    using System.Collections.Generic;

    /// <summary>
    /// A validation rule that is applied on a view element.
    /// </summary>
    public partial class ViewValidationRule : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.Validation.IViewValidationRule
    {
        /// <summary>
        /// Gets the audits.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Validation.IRuleAudit> Audits => this.backingAudits ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.Validation.IRuleAudit>(this);

        /// <summary>
        /// Backing field for <see cref="Audits"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Validation.IRuleAudit> backingAudits;

        /// <summary>
        /// Gets the fixes.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Validation.IValidationFix> Fixes => this.backingFixes ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.Validation.IValidationFix>(this);

        /// <summary>
        /// Backing field for <see cref="Fixes"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Validation.IValidationFix> backingFixes;

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Validation.ERROR_LEVEL Level { get; set; } = Auriga.Diagram.Viewpoint.Description.Validation.ERROR_LEVEL.INFO;

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; } = "The element has...";

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The mapping to validate.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.IRepresentationElementMapping> Targets { get; } = new List<Auriga.Diagram.Viewpoint.Description.IRepresentationElementMapping>();

        /// <summary>
        /// Gets the elements directly contained by this <c>ViewValidationRule</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Audits)
            {
                yield return element;
            }

            foreach (var element in this.Fixes)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
