// ------------------------------------------------------------------------------------------------
// <copyright file="XmlNames.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using ECoreNetto;

    /// <summary>
    /// Resolves the XML name a structural feature serializes under. Two sources can rename a feature:
    /// an EMF <c>ExtendedMetaData</c> annotation carrying a <c>name</c> detail (the standard,
    /// in-model mechanism), or the built-in override table below for metamodels that rename outside
    /// their <c>.ecore</c> — GMF serializes <c>View.persistedChildren</c> as <c>&lt;children&gt;</c>
    /// and <c>Diagram.persistedEdges</c> as <c>&lt;edges&gt;</c> by hard-coding the runtime feature
    /// names in its generated package initialization (<c>PackageClass.javajet</c>), so its upstream
    /// <c>notation.ecore</c> carries no annotation to read and the vendored copy is kept pristine.
    /// The generated readers' <c>case</c> labels and attribute reads, and the generated writers'
    /// element/attribute names, use this resolution; every other feature keeps its Ecore feature
    /// name, so metamodels without renames (all of Capella) generate identically.
    /// </summary>
    public static class XmlNames
    {
        /// <summary>
        /// The EMF <c>ExtendedMetaData</c> annotation source URI
        /// (<c>ExtendedMetaData.ANNOTATION_URI</c>), under which the <c>name</c> detail declares the
        /// feature's serialized XML name.
        /// </summary>
        private const string ExtendedMetaDataAnnotationSource = "http:///org/eclipse/emf/ecore/util/ExtendedMetaData";

        /// <summary>
        /// Serialization renames that upstream metamodels apply outside their <c>.ecore</c> file,
        /// keyed by <c>package:DeclaringClass.featureName</c>. Keeping the table here — exactly where
        /// GMF keeps its own — leaves the vendored <c>.ecore</c> files byte-faithful to upstream, so
        /// a re-vendor cannot silently drop the renames.
        /// </summary>
        private static readonly Dictionary<string, string> SerializationNameOverrides = new(StringComparer.Ordinal)
        {
            ["notation:View.persistedChildren"] = "children",
            ["notation:Diagram.persistedEdges"] = "edges",
        };

        /// <summary>
        /// The XML element/attribute name the feature serializes under: the <c>name</c> detail of its
        /// <c>ExtendedMetaData</c> annotation when present and non-empty, else the built-in override
        /// for the declaring <c>package:Class.feature</c>, else the Ecore feature name.
        /// </summary>
        /// <param name="feature">the structural feature</param>
        /// <returns>the serialized XML name</returns>
        public static string XmlName(EStructuralFeature feature)
        {
            var annotation = feature.EAnnotations?.FirstOrDefault(a => a.Source == ExtendedMetaDataAnnotationSource);

            if (annotation != null && annotation.Details.TryGetValue("name", out var name) && !string.IsNullOrEmpty(name))
            {
                return name;
            }

            var declaringClass = feature.EContainingClass;
            if (declaringClass?.EPackage != null
                && SerializationNameOverrides.TryGetValue($"{declaringClass.EPackage.Name}:{declaringClass.Name}.{feature.Name}", out var overridden))
            {
                return overridden;
            }

            return feature.Name;
        }
    }
}
