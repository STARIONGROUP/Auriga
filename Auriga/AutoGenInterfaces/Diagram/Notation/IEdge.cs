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

namespace Auriga.Diagram.Notation
{
    /// <summary>
    /// Definition of the <c>Edge</c> interface.
    /// </summary>
    public partial interface IEdge : Auriga.Diagram.Notation.IView
    {
        /// <summary>
        /// Gets or sets the bendpoints.
        /// </summary>
        Auriga.Diagram.Notation.IBendpoints Bendpoints { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        Auriga.Diagram.Notation.IView Source { get; set; }

        /// <summary>
        /// Gets or sets the source anchor.
        /// </summary>
        Auriga.Diagram.Notation.IAnchor SourceAnchor { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        Auriga.Diagram.Notation.IView Target { get; set; }

        /// <summary>
        /// Gets or sets the target anchor.
        /// </summary>
        Auriga.Diagram.Notation.IAnchor TargetAnchor { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
