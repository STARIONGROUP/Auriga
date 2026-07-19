// ------------------------------------------------------------------------------------------------
// <copyright file="IIconRegistry.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    /// <summary>
    /// The service that resolves a Sirius workspace-image path (the
    /// <see cref="ResolvedStyle.ImagePath"/> a <c>WorkspaceImage</c> style carries, e.g.
    /// <c>/org.polarsys.capella.core.sirius.analysis/description/images/Capability.svg</c>) to
    /// image content an exported document can embed. The default implementation,
    /// <see cref="CapellaIconRegistry"/>, serves the vendored Capella artwork; inject a different
    /// implementation to serve project-local images or a custom icon set.
    /// </summary>
    public interface IIconRegistry
    {
        /// <summary>
        /// Resolves a workspace-image path to a self-contained <c>data:</c> URI.
        /// </summary>
        /// <param name="imagePath">the persisted workspace-image path</param>
        /// <returns>the <c>data:</c> URI, or <c>null</c> when the image is not known</returns>
        string? Resolve(string imagePath);
    }
}
