// ------------------------------------------------------------------------------------------------
// <copyright file="IViewValidationRule.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// A validation rule that is applied on a view element.
    /// </summary>
    public partial interface IViewValidationRule : Auriga.Sirius.Viewpoint.Description.Validation.IValidationRule
    {
        /// <summary>
        /// The mapping to validate.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.Description.IRepresentationElementMapping> Targets { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
