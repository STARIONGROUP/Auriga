// ------------------------------------------------------------------------------------------------
// <copyright file="IForegroundConditionalStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Table.Description
{
    /// <summary>
    /// Definition of the <c>ForegroundConditionalStyle</c> interface.
    /// </summary>
    public partial interface IForegroundConditionalStyle : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets or sets the predicate expression.
        /// </summary>
        string PredicateExpression { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        Auriga.Diagram.Table.Description.IForegroundStyleDescription Style { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
