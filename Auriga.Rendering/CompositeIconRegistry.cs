// ------------------------------------------------------------------------------------------------
// <copyright file="CompositeIconRegistry.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An <see cref="IIconRegistry"/> that resolves a workspace-image path through an ordered chain
    /// of registries, returning the first non-<c>null</c> result. Compose the vendored
    /// <see cref="CapellaIconRegistry"/> with a <see cref="WorkspaceImageRegistry"/> — the plugin
    /// artwork resolves from the vendored set, and a path that is not vendored (a project-local
    /// image) falls through to the workspace source.
    /// </summary>
    public sealed class CompositeIconRegistry : IIconRegistry
    {
        /// <summary>
        /// The registries consulted in order.
        /// </summary>
        private readonly IReadOnlyList<IIconRegistry> registries;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeIconRegistry"/> class over the
        /// supplied registries, consulted in the order given.
        /// </summary>
        /// <param name="registries">the registries to consult in order</param>
        /// <exception cref="ArgumentNullException">the registries array, or one of its entries, is null</exception>
        public CompositeIconRegistry(params IIconRegistry[] registries)
        {
            if (registries == null)
            {
                throw new ArgumentNullException(nameof(registries));
            }

            if (registries.Any(registry => registry == null))
            {
                throw new ArgumentNullException(nameof(registries), "A composed registry is null.");
            }

            this.registries = registries.ToList();
        }

        /// <summary>
        /// Resolves a workspace-image path to the first non-<c>null</c> <c>data:</c> URI its chained
        /// registries return.
        /// </summary>
        /// <param name="imagePath">the persisted workspace-image path</param>
        /// <returns>the <c>data:</c> URI, or <c>null</c> when no registry resolves it</returns>
        public string? Resolve(string imagePath)
        {
            foreach (var registry in this.registries)
            {
                if (registry.Resolve(imagePath) is { } resolved)
                {
                    return resolved;
                }
            }

            return null;
        }
    }
}
