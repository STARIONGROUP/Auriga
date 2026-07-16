// ------------------------------------------------------------------------------------------------
// <copyright file="IBackgroundConditionalStyle.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Table.Description
{
    /// <summary>
    /// Definition of the <c>BackgroundConditionalStyle</c> interface.
    /// </summary>
    public partial interface IBackgroundConditionalStyle : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets or sets the predicate expression.
        /// </summary>
        string PredicateExpression { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        Auriga.Sirius.Table.Description.IBackgroundStyleDescription Style { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
