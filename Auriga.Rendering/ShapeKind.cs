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
    /// diagram's lifelines), every other style as a rectangle.
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
    }
}
