// ------------------------------------------------------------------------------------------------
// <copyright file="CapellaIconRegistry.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The default <see cref="IIconRegistry"/>: serves the Capella diagram artwork vendored into
    /// this assembly (<c>Assets/CapellaIcons</c>, redistributed from eclipse-capella under
    /// EPL-2.0 — see the README there). A workspace-image path resolves by its file name — the
    /// path's plugin prefix varies per Capella install and carries no information the file name
    /// does not — and the content is returned as a <c>data:</c> URI, so exported documents stay
    /// self-contained. An unknown file name resolves to <c>null</c>. Resolved URIs are cached per
    /// instance.
    /// </summary>
    public sealed class CapellaIconRegistry : IIconRegistry
    {
        /// <summary>
        /// The manifest-resource prefix the vendored artwork is embedded under.
        /// </summary>
        private const string ResourcePrefix = "Auriga.Rendering.Assets.CapellaIcons.";

        /// <summary>
        /// The embedded artwork's manifest resource names, indexed by file name.
        /// </summary>
        private static readonly Dictionary<string, string> ResourceNamesByFileName =
            typeof(CapellaIconRegistry).Assembly.GetManifestResourceNames()
                .Where(name => name.StartsWith(ResourcePrefix, StringComparison.Ordinal))
                .ToDictionary(name => name.Substring(ResourcePrefix.Length), name => name, StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// The resolved <c>data:</c> URIs (or <c>null</c> for unknown images), by requested path.
        /// </summary>
        private readonly ConcurrentDictionary<string, string?> cache = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Resolves a workspace-image path to a <c>data:</c> URI of the vendored Capella artwork
        /// with the same file name.
        /// </summary>
        /// <param name="imagePath">the persisted workspace-image path</param>
        /// <returns>the <c>data:</c> URI, or <c>null</c> when no vendored file matches</returns>
        public string? Resolve(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return null;
            }

            return this.cache.GetOrAdd(imagePath, Load);
        }

        /// <summary>
        /// Loads the embedded artwork matching the path's file name and encodes it as a
        /// <c>data:</c> URI.
        /// </summary>
        /// <param name="imagePath">the persisted workspace-image path</param>
        /// <returns>the <c>data:</c> URI, or <c>null</c> when no vendored file matches</returns>
        private static string? Load(string imagePath)
        {
            var fileName = imagePath.Substring(imagePath.LastIndexOfAny(new[] { '/', '\\' }) + 1);

            if (!ResourceNamesByFileName.TryGetValue(fileName, out var resourceName))
            {
                return null;
            }

            using var stream = typeof(CapellaIconRegistry).Assembly.GetManifestResourceStream(resourceName)!;
            using var buffer = new MemoryStream();
            stream.CopyTo(buffer);

            return $"data:{MimeType(fileName)};base64,{Convert.ToBase64String(buffer.ToArray())}";
        }

        /// <summary>
        /// The MIME type of a vendored image file. The vendored set contains SVG artwork, GIF
        /// artwork and the PNG metaclass icons; extend it alongside the set if other formats are
        /// ever vendored.
        /// </summary>
        /// <param name="fileName">the image file name</param>
        /// <returns>the MIME type</returns>
        private static string MimeType(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            if (extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
            {
                return "image/png";
            }

            return extension.Equals(".gif", StringComparison.OrdinalIgnoreCase)
                ? "image/gif"
                : "image/svg+xml";
        }
    }
}
