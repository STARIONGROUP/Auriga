// ------------------------------------------------------------------------------------------------
// <copyright file="EmptyProjectImageRegistry.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Icons
{
    /// <summary>
    /// The <see cref="IProjectImageRegistry"/> a scope carries until a caller supplies one: it
    /// resolves nothing, so the composed chain degrades to the vendored artwork alone. Filling the
    /// slot with an empty registry rather than leaving it unregistered keeps the composition of the
    /// default <see cref="IIconRegistry"/> the same shape whether or not project images are served.
    /// </summary>
    internal sealed class EmptyProjectImageRegistry : IProjectImageRegistry
    {
        /// <summary>
        /// The single instance: the registry holds no state.
        /// </summary>
        internal static readonly EmptyProjectImageRegistry Instance = new EmptyProjectImageRegistry();

        /// <summary>
        /// Prevents a second instance being created.
        /// </summary>
        private EmptyProjectImageRegistry()
        {
        }

        /// <summary>
        /// Resolves nothing: no model project's artwork is registered.
        /// </summary>
        /// <param name="imagePath">the persisted workspace-image path</param>
        /// <returns><c>null</c></returns>
        public string? Resolve(string imagePath)
        {
            return null;
        }
    }
}
