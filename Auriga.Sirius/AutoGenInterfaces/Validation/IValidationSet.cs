// ------------------------------------------------------------------------------------------------
// <copyright file="IValidationSet.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A set of validation rules.
    /// </summary>
    public partial interface IValidationSet : Auriga.Sirius.Viewpoint.Description.IDocumentedElement
    {
        /// <summary>
        /// All rules of the set.
        /// </summary>
        IEnumerable<Auriga.Sirius.Viewpoint.Description.Validation.IValidationRule> AllRules { get; }

        /// <summary>
        /// The name of the set.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The validation rules owned by this set.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Validation.IValidationRule> OwnedRules { get; }

        /// <summary>
        /// The validations rules that are reused by this set.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.Description.Validation.IValidationRule> ReusedRules { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
