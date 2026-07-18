// ------------------------------------------------------------------------------------------------
// <copyright file="IStyleResolver.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;

    /// <summary>
    /// The service that resolves an item's styling sources into the concrete
    /// <see cref="ResolvedStyle"/> — the injectable styling stage of the rendering pipeline. The
    /// default implementation, <see cref="StyleResolver"/>, layers the Capella default palette,
    /// the GMF notation styles and the Sirius owned style in fixed precedence. The resolver is
    /// representation-kind agnostic: kind differences are expressed by the builders on the
    /// intermediate model.
    /// </summary>
    public interface IStyleResolver
    {
        /// <summary>
        /// Resolves the visual properties of a box.
        /// </summary>
        /// <param name="box">the box to resolve</param>
        /// <returns>the resolved style</returns>
        /// <exception cref="ArgumentNullException">the box is null</exception>
        ResolvedStyle Resolve(Box box);

        /// <summary>
        /// Resolves the visual properties of an edge.
        /// </summary>
        /// <param name="edge">the edge to resolve</param>
        /// <returns>the resolved style</returns>
        /// <exception cref="ArgumentNullException">the edge is null</exception>
        ResolvedStyle Resolve(Edge edge);
    }
}
