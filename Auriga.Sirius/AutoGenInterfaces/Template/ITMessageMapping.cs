// ------------------------------------------------------------------------------------------------
// <copyright file="ITMessageMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence.Template
{
    /// <summary>
    /// Definition of the <c>TMessageMapping</c> interface.
    /// </summary>
    public partial interface ITMessageMapping : Auriga.Sirius.Sequence.Template.ITAbstractMapping
    {
        /// <summary>
        /// Gets the conditional style.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Sequence.Template.ITConditionalMessageStyle> ConditionalStyle { get; }

        /// <summary>
        /// Gets or sets the receiving end finder expression.
        /// </summary>
        string ReceivingEndFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the sending end finder expression.
        /// </summary>
        string SendingEndFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        Auriga.Sirius.Sequence.Template.ITMessageStyle Style { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
