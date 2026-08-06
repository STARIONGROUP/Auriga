// ------------------------------------------------------------------------------------------------
// <copyright file="ResourceLoader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Resources
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Resources;

    /// <summary>
    /// Loads the resources embedded in the tool — the splash screen, and the version it carries.
    /// </summary>
    public static class ResourceLoader
    {
        /// <summary>
        /// The placeholder the splash screen carries in place of the version, so the art is a
        /// static resource rather than a formatted string.
        /// </summary>
        private const string VersionPlaceholder = "aurigaToolsVersion";

        /// <summary>
        /// Loads an embedded resource.
        /// </summary>
        /// <param name="path">the fully qualified name of the embedded resource</param>
        /// <returns>the contents of the resource</returns>
        /// <exception cref="ArgumentException">the path is null or empty</exception>
        /// <exception cref="MissingManifestResourceException">the assembly carries no such resource</exception>
        public static string LoadEmbeddedResource(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The resource path must be provided.", nameof(path));
            }

            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(path)
                               ?? throw new MissingManifestResourceException($"The assembly carries no resource named '{path}'.");

            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        /// <summary>
        /// The version of the tool.
        /// </summary>
        /// <returns>the version</returns>
        public static string QueryVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "unknown";
        }

        /// <summary>
        /// The splash screen, with the running version substituted into it.
        /// </summary>
        /// <returns>the splash screen</returns>
        public static string QueryLogo()
        {
            return LoadEmbeddedResource("Auriga.Tools.Resources.ascii-art.txt")
                .Replace(VersionPlaceholder, QueryVersion(), StringComparison.Ordinal);
        }
    }
}
