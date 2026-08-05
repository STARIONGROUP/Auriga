// ------------------------------------------------------------------------------------------------
// <copyright file="WorkspaceImageRegistry.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// An <see cref="IIconRegistry"/> that serves the project-local images a Capella model stores
    /// beside its <c>.aird</c> — a <c>WorkspaceImage</c> whose path points inside the model project
    /// (e.g. <c>In-Flight Entertainment System/images/Operator.svg</c>) rather than a Capella
    /// plugin. The path is Eclipse-workspace relative — its first segment is the project name — so
    /// it resolves against the loaded project's root directory both with and without that leading
    /// segment (the <c>.aird</c> sits at the project root, so the segment maps to the root). The
    /// file is inlined as a <c>data:</c> URI; a path with no matching file resolves to <c>null</c>.
    /// Compose it after <see cref="CapellaIconRegistry"/> (see <see cref="CompositeIconRegistry"/>)
    /// so plugin artwork still serves from the vendored set — the composition
    /// <see cref="RenderingBuilder.UsingProjectImages"/> performs. Resolved URIs are cached per
    /// instance.
    /// </summary>
    public sealed class WorkspaceImageRegistry : IProjectImageRegistry
    {
        /// <summary>
        /// The root directory of the loaded project the workspace paths resolve against.
        /// </summary>
        private readonly string projectRoot;

        /// <summary>
        /// The resolved <c>data:</c> URIs (or <c>null</c> for unresolved images), by requested path.
        /// </summary>
        private readonly ConcurrentDictionary<string, string?> cache = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// The logger reporting the paths that resolve to no file under the project root.
        /// </summary>
        private readonly ILogger<WorkspaceImageRegistry> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceImageRegistry"/> class rooted at
        /// the loaded project's directory.
        /// </summary>
        /// <param name="projectRoot">the root directory the workspace paths resolve against (typically the directory of the loaded <c>.aird</c>)</param>
        /// <param name="loggerFactory">the factory the registry creates its logger from</param>
        /// <exception cref="ArgumentException">the project root is null or empty</exception>
        /// <exception cref="ArgumentNullException">the logger factory is null</exception>
        public WorkspaceImageRegistry(string projectRoot, ILoggerFactory loggerFactory)
        {
            if (string.IsNullOrEmpty(projectRoot))
            {
                throw new ArgumentException("The project root must be provided.", nameof(projectRoot));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            this.projectRoot = projectRoot;
            this.logger = loggerFactory.CreateLogger<WorkspaceImageRegistry>();
        }

        /// <summary>
        /// Resolves a project-local workspace-image path to a <c>data:</c> URI of the file beside
        /// the loaded model.
        /// </summary>
        /// <param name="imagePath">the persisted workspace-image path</param>
        /// <returns>the <c>data:</c> URI, or <c>null</c> when no file matches</returns>
        public string? Resolve(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return null;
            }

            return this.cache.GetOrAdd(imagePath, this.Load);
        }

        /// <summary>
        /// Loads the project-local file a workspace path names and encodes it as a <c>data:</c> URI.
        /// The path is tried both whole and with its leading project-name segment dropped, since the
        /// project root the <c>.aird</c> sits in is that segment. Only a cache miss reaches here, so
        /// the trace of an unresolved path is emitted once per distinct path without the registry
        /// keeping any state to that effect.
        /// </summary>
        /// <param name="imagePath">the persisted workspace-image path</param>
        /// <returns>the <c>data:</c> URI, or <c>null</c> when no file matches</returns>
        private string? Load(string imagePath)
        {
            var relative = imagePath.Replace('\\', '/').TrimStart('/');
            var firstSlash = relative.IndexOf('/');

            var candidates = firstSlash < 0
                ? new[] { relative }
                : new[] { relative[(firstSlash + 1)..], relative };

            foreach (var candidate in candidates)
            {
                var file = Path.Combine(this.projectRoot, candidate.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(file))
                {
                    return $"data:{MimeType(file)};base64,{Convert.ToBase64String(File.ReadAllBytes(file))}";
                }
            }

            this.logger.LogTrace("No file under {ProjectRoot} matches the workspace image {Path}", this.projectRoot, imagePath);
            return null;
        }

        /// <summary>
        /// The MIME type of a project-local image file, by its extension — SVG, PNG, GIF or JPEG —
        /// defaulting to SVG.
        /// </summary>
        /// <param name="file">the image file path</param>
        /// <returns>the MIME type</returns>
        private static string MimeType(string file)
        {
            return Path.GetExtension(file).ToLowerInvariant() switch
            {
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".jpg" or ".jpeg" => "image/jpeg",
                _ => "image/svg+xml",
            };
        }
    }
}
