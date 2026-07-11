// ------------------------------------------------------------------------------------------------
// <copyright file="ITSourceTargetMessageMapping.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>TSourceTargetMessageMapping</c> interface.
    /// </summary>
    public partial interface ITSourceTargetMessageMapping : Auriga.Sirius.Sequence.Template.ITMessageMapping
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        List<Auriga.Sirius.Sequence.Template.ITMessageExtremity> Source { get; }

        /// <summary>
        /// The elements that are represented by this connection.
        /// </summary>
        string SourceFinderExpression { get; set; }

        /// <summary>
        /// The elements that are represented by this connection.
        /// </summary>
        string TargetFinderExpression { get; set; }

        /// <summary>
        /// Gets or sets the use domain element.
        /// </summary>
        bool? UseDomainElement { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
