// ------------------------------------------------------------------------------------------------
// <copyright file="ICapellaDefaultPalette.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    /// <summary>
    /// The palette supplying the default colors applied when an item carries no persisted style
    /// values, looked up by the Capella semantic element's type name. The default implementation,
    /// <see cref="CapellaDefaultPalette"/>, carries Capella's own migration palette; inject a
    /// different implementation to retheme the defaults without touching the resolver.
    /// </summary>
    public interface ICapellaDefaultPalette
    {
        /// <summary>
        /// The default visual properties of a box representing the supplied semantic type.
        /// </summary>
        /// <param name="semanticTypeName">the Capella semantic element's type name, or <c>null</c></param>
        /// <returns>the default fill (or <c>null</c> for none) and stroke</returns>
        (Color? Fill, Color Stroke) ForBox(string? semanticTypeName);

        /// <summary>
        /// The default visual properties of an edge representing the supplied semantic type.
        /// </summary>
        /// <param name="semanticTypeName">the Capella semantic element's type name, or <c>null</c></param>
        /// <returns>the default stroke and stroke width</returns>
        (Color Stroke, double Width) ForEdge(string? semanticTypeName);
    }
}
