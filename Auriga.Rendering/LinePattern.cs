// ------------------------------------------------------------------------------------------------
// <copyright file="LinePattern.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    /// <summary>
    /// The resolved stroke pattern of a border or edge, mapped from the Sirius <c>LineStyle</c>
    /// enumeration (<c>solid</c> / <c>dash</c> / <c>dot</c> / <c>dash_dot</c>).
    /// </summary>
    public enum LinePattern
    {
        /// <summary>
        /// A continuous line.
        /// </summary>
        Solid,

        /// <summary>
        /// A dashed line.
        /// </summary>
        Dash,

        /// <summary>
        /// A dotted line.
        /// </summary>
        Dot,

        /// <summary>
        /// An alternating dash-dot line.
        /// </summary>
        DashDot,

        /// <summary>
        /// A long-dash line — the stroke Capella draws sequence-diagram lifelines with, calmer than
        /// the ordinary dash used for borders and separator rules.
        /// </summary>
        LongDash,
    }
}
