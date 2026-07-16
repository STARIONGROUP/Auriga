// ------------------------------------------------------------------------------------------------
// <copyright file="IRuleAudit.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// The validation expression.
    /// </summary>
    public partial interface IRuleAudit : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// An expression checked on the model, if the audit fails (return false) then the rule fail.
        /// </summary>
        string AuditExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
