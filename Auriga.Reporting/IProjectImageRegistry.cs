// ------------------------------------------------------------------------------------------------
// <copyright file="IProjectImageRegistry.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting
{
    /// <summary>
    /// The <see cref="IIconRegistry"/> that serves the artwork a loaded model carries itself — a
    /// <c>WorkspaceImage</c> whose path points inside the model project rather than at a Capella
    /// plugin. It is a registration slot of its own, separate from <see cref="IIconRegistry"/>:
    /// the composed exporter always resolves through the vendored artwork chained with whatever
    /// fills this slot, so serving a project's own images (<see cref="WorkspaceImageRegistry"/>,
    /// registered by <see cref="RenderingBuilder.UsingProjectImages"/>) adds to the vendored set
    /// instead of replacing it. Nothing fills the slot by default, and
    /// <see cref="RenderingBuilder.UsingIconRegistry"/> still replaces the whole chain.
    /// </summary>
    public interface IProjectImageRegistry : IIconRegistry
    {
    }
}
