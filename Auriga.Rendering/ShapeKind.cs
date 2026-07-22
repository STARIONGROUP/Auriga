// ------------------------------------------------------------------------------------------------
// <copyright file="ShapeKind.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    /// <summary>
    /// The resolved outline shape of a box, mapped from the concrete Sirius node style: an
    /// <c>Ellipse</c> or <c>Dot</c> style renders as an ellipse (e.g. the states on a sequence
    /// diagram's lifelines), a <c>Lozenge</c> style as a diamond (a state machine's choice
    /// pseudo-state), every other style as a rectangle.
    /// </summary>
    public enum ShapeKind
    {
        /// <summary>
        /// A rectangular outline.
        /// </summary>
        Rectangle,

        /// <summary>
        /// An elliptic outline filling the box's bounds.
        /// </summary>
        Ellipse,

        /// <summary>
        /// A line through the box's center along its longer axis, without the rectangle's end
        /// caps — vertical for a sequence diagram's lifeline, horizontal for its end-of-lifeline
        /// tick.
        /// </summary>
        Line,

        /// <summary>
        /// A diamond (rhombus) inscribed in the box's bounds — a Sirius <c>Lozenge</c> style, as a
        /// state machine's choice pseudo-state.
        /// </summary>
        Diamond,
    }
}
