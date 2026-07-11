// ------------------------------------------------------------------------------------------------
// <copyright file="SemanticValidationRule.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description.Validation
{
    /// <summary>
    /// A validation rule that is applied on a semantic element.
    /// </summary>
    public partial class SemanticValidationRule : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.Validation.ISemanticValidationRule
    {
        /// <summary>
        /// Gets the audits.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Validation.IRuleAudit> Audits => this.backingAudits ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Validation.IRuleAudit>(this);

        /// <summary>
        /// Backing field for <see cref="Audits"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Validation.IRuleAudit> backingAudits;

        /// <summary>
        /// Gets the fixes.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Validation.IValidationFix> Fixes => this.backingFixes ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Validation.IValidationFix>(this);

        /// <summary>
        /// Backing field for <see cref="Fixes"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Validation.IValidationFix> backingFixes;

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Validation.ERROR_LEVEL Level { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the domain class of the element.
        /// </summary>
        public string TargetClass { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>SemanticValidationRule</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
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
