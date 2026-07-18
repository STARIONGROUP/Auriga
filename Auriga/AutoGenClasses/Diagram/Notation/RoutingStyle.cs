// ------------------------------------------------------------------------------------------------
// <copyright file="RoutingStyle.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>RoutingStyle</c> class.
    /// </summary>
    public partial class RoutingStyle : Auriga.Core.AurigaElement, Auriga.Diagram.Notation.IRoutingStyle
    {
        /// <summary>
        /// Gets or sets the avoid obstructions.
        /// </summary>
        public bool? AvoidObstructions { get; set; } = false;

        /// <summary>
        /// Gets or sets the closest distance.
        /// </summary>
        public bool? ClosestDistance { get; set; } = false;

        /// <summary>
        /// Gets or sets the jump link status.
        /// </summary>
        public Auriga.Diagram.Notation.JumpLinkStatus? JumpLinkStatus { get; set; } = Auriga.Diagram.Notation.JumpLinkStatus.None;

        /// <summary>
        /// Gets or sets the jump link type.
        /// </summary>
        public Auriga.Diagram.Notation.JumpLinkType? JumpLinkType { get; set; } = Auriga.Diagram.Notation.JumpLinkType.Semicircle;

        /// <summary>
        /// Gets or sets the jump links reverse.
        /// </summary>
        public bool? JumpLinksReverse { get; set; } = false;

        /// <summary>
        /// Gets or sets the rounded bendpoints radius.
        /// </summary>
        public int? RoundedBendpointsRadius { get; set; } = 0;

        /// <summary>
        /// Gets or sets the routing.
        /// </summary>
        public Auriga.Diagram.Notation.Routing? Routing { get; set; } = Auriga.Diagram.Notation.Routing.Manual;

        /// <summary>
        /// Gets or sets the smoothness.
        /// </summary>
        public Auriga.Diagram.Notation.Smoothness? Smoothness { get; set; } = Auriga.Diagram.Notation.Smoothness.None;

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
