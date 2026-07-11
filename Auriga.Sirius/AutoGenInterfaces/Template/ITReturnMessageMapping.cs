// ------------------------------------------------------------------------------------------------
// <copyright file="ITReturnMessageMapping.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TReturnMessageMapping</c> interface.
    /// </summary>
    public partial interface ITReturnMessageMapping : Auriga.Sirius.Sequence.Template.ITMessageMapping
    {
        /// <summary>
        /// Gets or sets the invocation mapping.
        /// </summary>
        Auriga.Sirius.Sequence.Template.ITBasicMessageMapping InvocationMapping { get; set; }

        /// <summary>
        /// Gets or sets the invocation message finder expression.
        /// </summary>
        string InvocationMessageFinderExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
