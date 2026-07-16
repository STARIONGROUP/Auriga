// ------------------------------------------------------------------------------------------------
// <copyright file="IRoutingStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>RoutingStyle</c> interface.
    /// </summary>
    public partial interface IRoutingStyle : Auriga.Diagram.Notation.IRoundedCornersStyle
    {
        /// <summary>
        /// Gets or sets the avoid obstructions.
        /// </summary>
        bool? AvoidObstructions { get; set; }

        /// <summary>
        /// Gets or sets the closest distance.
        /// </summary>
        bool? ClosestDistance { get; set; }

        /// <summary>
        /// Gets or sets the jump link status.
        /// </summary>
        Auriga.Diagram.Notation.JumpLinkStatus? JumpLinkStatus { get; set; }

        /// <summary>
        /// Gets or sets the jump link type.
        /// </summary>
        Auriga.Diagram.Notation.JumpLinkType? JumpLinkType { get; set; }

        /// <summary>
        /// Gets or sets the jump links reverse.
        /// </summary>
        bool? JumpLinksReverse { get; set; }

        /// <summary>
        /// Gets or sets the routing.
        /// </summary>
        Auriga.Diagram.Notation.Routing? Routing { get; set; }

        /// <summary>
        /// Gets or sets the smoothness.
        /// </summary>
        Auriga.Diagram.Notation.Smoothness? Smoothness { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
