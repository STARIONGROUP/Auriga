// ------------------------------------------------------------------------------------------------
// <copyright file="INamespaceResolver.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Namespaces
{
    /// <summary>
    /// Resolves a Capella XML namespace URI (e.g. <c>http://www.polarsys.org/capella/core/pa/7.0.0</c>)
    /// to the Ecore package name (e.g. <c>pa</c>) whose generated types it identifies. Together with a
    /// simple type name this yields the package-qualified reader key <c>package:TypeName</c>, which is
    /// unique even where a simple type name occurs in more than one package (e.g. <c>Folder</c>).
    /// </summary>
    public interface INamespaceResolver
    {
        /// <summary>
        /// Resolves the supplied namespace URI to its Ecore package name.
        /// </summary>
        /// <param name="namespaceUri">the XML namespace URI</param>
        /// <param name="package">the resolved Ecore package name, or <c>null</c> when unresolved</param>
        /// <returns>true when the namespace URI is known</returns>
        bool TryResolvePackage(string namespaceUri, out string? package);
    }
}
