// ------------------------------------------------------------------------------------------------
// <copyright file="NamespaceResolver.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Namespaces
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The default <see cref="INamespaceResolver"/>. It is seeded with the namespace-URI-to-package map
    /// generated from the metamodel (<c>AutoGenNamespaceRegistry</c>) and resolves an exact URI first,
    /// then falls back to a version-stripped match (the trailing <c>/x.y.z</c> segment is removed) so a
    /// document produced by a different Capella minor version still resolves.
    /// </summary>
    public sealed class NamespaceResolver : INamespaceResolver
    {
        private static readonly Regex TrailingVersion = new Regex(@"/\d+(\.\d+)*/?$", RegexOptions.Compiled);

        private readonly IReadOnlyDictionary<string, string> namespaceToPackage;

        private readonly Dictionary<string, string> versionStrippedToPackage;

        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceResolver"/> class.
        /// </summary>
        /// <param name="namespaceToPackage">the namespace-URI-to-package-name map (from the metamodel)</param>
        public NamespaceResolver(IReadOnlyDictionary<string, string> namespaceToPackage)
        {
            this.namespaceToPackage = namespaceToPackage ?? throw new ArgumentNullException(nameof(namespaceToPackage));

            this.versionStrippedToPackage = new Dictionary<string, string>(StringComparer.Ordinal);
            foreach (var pair in namespaceToPackage)
            {
                this.versionStrippedToPackage[StripVersion(pair.Key)] = pair.Value;
            }
        }

        /// <inheritdoc/>
        public bool TryResolvePackage(string namespaceUri, out string? package)
        {
            if (namespaceUri == null)
            {
                throw new ArgumentNullException(nameof(namespaceUri));
            }

            if (this.namespaceToPackage.TryGetValue(namespaceUri, out var exact))
            {
                package = exact;
                return true;
            }

            return this.versionStrippedToPackage.TryGetValue(StripVersion(namespaceUri), out package);
        }

        private static string StripVersion(string namespaceUri)
        {
            return TrailingVersion.Replace(namespaceUri, string.Empty);
        }
    }
}
