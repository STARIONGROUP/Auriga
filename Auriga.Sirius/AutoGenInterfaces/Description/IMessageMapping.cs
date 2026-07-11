// ------------------------------------------------------------------------------------------------
// <copyright file="IMessageMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence.Description
{
    /// <summary>
    /// Definition of the <c>MessageMapping</c> interface.
    /// </summary>
    public partial interface IMessageMapping : Auriga.Sirius.Diagram.Description.IEdgeMapping, Auriga.Sirius.Sequence.Description.IEventMapping
    {
        /// <summary>
        /// Gets or sets the receiving end finder expression.
        /// </summary>
        string ReceivingEndFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the sending end finder expression.
        /// </summary>
        string SendingEndFinderExpression { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
