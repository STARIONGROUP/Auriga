// ------------------------------------------------------------------------------------------------
// <copyright file="NamespaceResolver.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Namespaces
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
        /// <summary>
        /// Matches a trailing version segment (e.g. <c>/7.0.0</c>, optionally followed by a slash) at the
        /// end of a namespace URI, so it can be stripped for version-tolerant matching.
        /// </summary>
        private static readonly Regex TrailingVersion = new Regex(@"/\d+(\.\d+)*/?$", RegexOptions.Compiled);

        /// <summary>
        /// The exact namespace-URI-to-package-name map, seeded from the metamodel and extendable via
        /// <see cref="RegisterNamespace"/>.
        /// </summary>
        private readonly Dictionary<string, string> namespaceToPackage;

        /// <summary>
        /// The version-stripped namespace-to-package map, used as a fallback when an exact URI match fails.
        /// </summary>
        private readonly Dictionary<string, string> versionStrippedToPackage;

        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceResolver"/> class.
        /// </summary>
        /// <param name="namespaceToPackage">the namespace-URI-to-package-name map (from the metamodel)</param>
        public NamespaceResolver(IReadOnlyDictionary<string, string> namespaceToPackage)
        {
            if (namespaceToPackage == null)
            {
                throw new ArgumentNullException(nameof(namespaceToPackage));
            }

            this.namespaceToPackage = new Dictionary<string, string>(StringComparer.Ordinal);
            this.versionStrippedToPackage = new Dictionary<string, string>(StringComparer.Ordinal);

            foreach (var pair in namespaceToPackage)
            {
                this.RegisterNamespace(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Registers a known namespace URI and the Ecore package it identifies, so it can subsequently be
        /// resolved by an exact or version-stripped match.
        /// </summary>
        /// <param name="namespaceUri">the XML namespace URI</param>
        /// <param name="package">the Ecore package name it identifies</param>
        public void RegisterNamespace(string namespaceUri, string package)
        {
            if (namespaceUri == null)
            {
                throw new ArgumentNullException(nameof(namespaceUri));
            }

            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            this.namespaceToPackage[namespaceUri] = package;
            this.versionStrippedToPackage[StripVersion(namespaceUri)] = package;
        }

        /// <summary>
        /// Resolves the supplied namespace URI to its Ecore package name.
        /// </summary>
        /// <param name="namespaceUri">the XML namespace URI</param>
        /// <param name="package">the resolved Ecore package name, or <c>null</c> when unresolved</param>
        /// <returns>true when the namespace URI is known</returns>
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

        /// <summary>
        /// Removes a trailing version segment from a namespace URI (e.g.
        /// <c>.../capella/core/pa/7.0.0</c> becomes <c>.../capella/core/pa</c>) so that documents
        /// produced by a different Capella minor version still resolve.
        /// </summary>
        /// <param name="namespaceUri">the namespace URI to normalize</param>
        /// <returns>the URI with any trailing version segment removed</returns>
        private static string StripVersion(string namespaceUri)
        {
            return TrailingVersion.Replace(namespaceUri, string.Empty);
        }
    }
}
