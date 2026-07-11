// ------------------------------------------------------------------------------------------------
// <copyright file="IEdge.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Notation
{
    /// <summary>
    /// Definition of the <c>Edge</c> interface.
    /// </summary>
    public partial interface IEdge : Auriga.Sirius.Notation.IView
    {
        /// <summary>
        /// Gets or sets the bendpoints.
        /// </summary>
        Auriga.Sirius.Notation.IBendpoints Bendpoints { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Sirius.Notation.IView Source { get; set; }

        /// <summary>
        /// Gets or sets the source anchor.
        /// </summary>
        Auriga.Sirius.Notation.IAnchor SourceAnchor { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Sirius.Notation.IView Target { get; set; }

        /// <summary>
        /// Gets or sets the target anchor.
        /// </summary>
        Auriga.Sirius.Notation.IAnchor TargetAnchor { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
