// ------------------------------------------------------------------------------------------------
// <copyright file="IValidationRule.cs" company="Starion Group S.A.">
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
    /// A validation rule.
    /// </summary>
    public partial interface IValidationRule : Auriga.Sirius.Viewpoint.Description.IIdentifiedElement
    {
        /// <summary>
        /// Gets the audits.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Validation.IRuleAudit> Audits { get; }

        /// <summary>
        /// Gets the fixes.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Validation.IValidationFix> Fixes { get; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Validation.ERROR_LEVEL Level { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
