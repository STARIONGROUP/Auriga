// ------------------------------------------------------------------------------------------------
// <copyright file="ValidationSet.cs" company="Starion Group S.A.">
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
    using System.Linq;

    /// <summary>
    /// A set of validation rules.
    /// </summary>
    public partial class ValidationSet : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.Validation.IValidationSet
    {
        /// <summary>
        /// All rules of the set.
        /// </summary>
        public IEnumerable<Auriga.Diagram.Viewpoint.Description.Validation.IValidationRule> AllRules => Enumerable.Empty<Auriga.Diagram.Viewpoint.Description.Validation.IValidationRule>();

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// The name of the set.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The validation rules owned by this set.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Validation.IValidationRule> OwnedRules => this.backingOwnedRules ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.Validation.IValidationRule>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedRules"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Validation.IValidationRule> backingOwnedRules;

        /// <summary>
        /// The validations rules that are reused by this set.
        /// </summary>
        public List<Auriga.Diagram.Viewpoint.Description.Validation.IValidationRule> ReusedRules { get; } = new List<Auriga.Diagram.Viewpoint.Description.Validation.IValidationRule>();

        /// <summary>
        /// Gets the elements directly contained by this <c>ValidationSet</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedRules)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
