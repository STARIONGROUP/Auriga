// ------------------------------------------------------------------------------------------------
// <copyright file="MetamodelLoader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using ECoreNetto;
    using ECoreNetto.Resource;

    /// <summary>
    /// Loads the vendored Capella <c>.ecore</c> files into a single <see cref="ResourceSet"/> (the graph
    /// is cyclic and cannot be loaded file-by-file) and exposes the package tree. Shared by the model and
    /// XMI-reader generators so they see exactly the same metamodel.
    /// </summary>
    public static class MetamodelLoader
    {
        /// <summary>
        /// Loads every <c>.ecore</c> file in the supplied directory and returns their root packages.
        /// </summary>
        /// <param name="ecoreDirectory">the directory containing the vendored <c>.ecore</c> files</param>
        /// <returns>the root <see cref="EPackage"/>s</returns>
        public static List<EPackage> Load(string ecoreDirectory)
        {
            var resourceSet = new ResourceSet(null);
            var rootPackages = new List<EPackage>();

            foreach (var file in Directory.GetFiles(ecoreDirectory, "*.ecore").OrderBy(f => f, StringComparer.Ordinal))
            {
                var uri = new Uri(file);
                var resource = resourceSet.Resources.SingleOrDefault(x => x.URI == uri) ?? resourceSet.CreateResource(uri);
                var root = resource.IsLoaded()
                    ? resource.Contents.OfType<EPackage>().FirstOrDefault()
                      ?? resource.GetEObject($"{Path.GetFileNameWithoutExtension(file)}.ecore#/") as EPackage
                    : resource.Load(null);

                if (root != null)
                {
                    rootPackages.Add(root);
                }
            }

            return rootPackages;
        }

        /// <summary>
        /// Returns a package and all of its nested sub-packages, depth-first.
        /// </summary>
        /// <param name="package">the root package</param>
        /// <returns>the package and its descendants</returns>
        public static IEnumerable<EPackage> AllPackages(EPackage package)
        {
            yield return package;

            foreach (var nested in package.ESubPackages.SelectMany(AllPackages))
            {
                yield return nested;
            }
        }
    }
}
