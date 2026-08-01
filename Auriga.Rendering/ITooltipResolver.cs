// ------------------------------------------------------------------------------------------------
// <copyright file="ITooltipResolver.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    /// <summary>
    /// The service that resolves a built item's hover text — what the item represents, and what the
    /// model says about it — from the back-links the item carries. The default implementation,
    /// <see cref="TooltipResolver"/>, states the Capella metaclass and name, what a relationship
    /// connects, and the element's description; register another through
    /// <see cref="RenderingBuilder.UsingTooltipResolver"/> to say something else entirely (an
    /// element's property values, a translated text, nothing at all). The resolved text lands on
    /// <see cref="Box.Tooltip"/> and <see cref="Edge.Tooltip"/>, which
    /// <see cref="SvgExporter"/> emits as the item's SVG <c>title</c>.
    /// </summary>
    public interface ITooltipResolver
    {
        /// <summary>
        /// Resolves the hover text of a box.
        /// </summary>
        /// <param name="box">the box to resolve, its labels and back-links in place</param>
        /// <returns>the hover text, or <c>null</c> when the box has nothing to say about itself</returns>
        string? Resolve(Box box);

        /// <summary>
        /// Resolves the hover text of an edge.
        /// </summary>
        /// <param name="edge">the edge to resolve, its ends and back-links in place</param>
        /// <returns>the hover text, or <c>null</c> when the edge has nothing to say about itself</returns>
        string? Resolve(Edge edge);
    }
}
