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
    using System.Linq;

    using ECoreNetto;

    /// <summary>
    /// Resolves the XML name a structural feature serializes under. EMF renames a feature's XML
    /// element/attribute via an <c>ExtendedMetaData</c> annotation carrying a <c>name</c> detail —
    /// GMF's notation metamodel serializes <c>View.persistedChildren</c> as <c>&lt;children&gt;</c>
    /// and <c>Diagram.persistedEdges</c> as <c>&lt;edges&gt;</c> this way. The generated readers'
    /// <c>case</c> labels and attribute reads, and the generated writers' element/attribute names,
    /// use this resolution; a feature without the annotation keeps its Ecore feature name, so
    /// metamodels without ExtendedMetaData (all of Capella) generate identically.
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
        /// The XML element/attribute name the feature serializes under: the <c>name</c> detail of its
        /// <c>ExtendedMetaData</c> annotation when present and non-empty, the Ecore feature name
        /// otherwise.
        /// </summary>
        /// <param name="feature">the structural feature</param>
        /// <returns>the serialized XML name</returns>
        public static string XmlName(EStructuralFeature feature)
        {
            var annotation = feature.EAnnotations?.FirstOrDefault(a => a.Source == ExtendedMetaDataAnnotationSource);

            return annotation != null && annotation.Details.TryGetValue("name", out var name) && !string.IsNullOrEmpty(name)
                ? name
                : feature.Name;
        }
    }
}
