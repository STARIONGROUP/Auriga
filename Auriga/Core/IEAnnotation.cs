// ------------------------------------------------------------------------------------------------
// <copyright file="IEAnnotation.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Core
{
    /// <summary>
    /// An Ecore <c>EAnnotation</c>: a <c>source</c>-keyed bag of string key/value <c>details</c> that EMF
    /// attaches to a model element to carry information outside the metamodel proper. Capella add-ons use
    /// it as an extension point — the Requirements viewpoint, for instance, stores its label and content
    /// queries in an <c>EAnnotation</c> held by a Sirius <c>DAnalysisCustomData</c> keyed
    /// <c>REQUIREMENTS_VP_QUERIES</c>, and GMF <c>Note</c> shapes carry one sourced
    /// <c>specificStyles</c>.
    /// </summary>
    /// <remarks>
    /// Like <see cref="IEStringToStringMapEntry"/>, <c>EAnnotation</c> is an Ecore built-in that belongs to
    /// no vendored metamodel package, so it is modeled here in the shared core rather than generated per
    /// metamodel, and the generated reader and writer facades route its type key to the hand-written
    /// runtime reader and writer.
    /// </remarks>
    public interface IEAnnotation : IAurigaElement
    {
        /// <summary>
        /// Gets or sets the annotation's source: the URI-like key identifying which tool or viewpoint owns
        /// this annotation (e.g. <c>specificStyles</c>). It is absent on annotations whose owner is
        /// identified by other means, such as the containing <c>DAnalysisCustomData</c>'s key.
        /// </summary>
        string? Source { get; set; }

        /// <summary>
        /// Gets the annotation's details: the contained key/value entries, serialized inline as
        /// <c>ecore:EStringToStringMapEntry</c> child elements.
        /// </summary>
        IContainerList<IAurigaElement> Details { get; }
    }
}
