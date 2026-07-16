// ------------------------------------------------------------------------------------------------
// <copyright file="ITBasicMessageMapping.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Sequence.Template
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>TBasicMessageMapping</c> interface.
    /// </summary>
    public partial interface ITBasicMessageMapping : Auriga.Diagram.Sequence.Template.ITSourceTargetMessageMapping
    {
        /// <summary>
        /// Gets or sets the oblique.
        /// </summary>
        bool Oblique { get; set; }

        /// <summary>
        /// Gets the target.
        /// </summary>
        List<Auriga.Diagram.Sequence.Template.ITMessageExtremity> Target { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
