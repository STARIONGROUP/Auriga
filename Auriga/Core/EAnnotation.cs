// ------------------------------------------------------------------------------------------------
// <copyright file="EAnnotation.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// The default <see cref="IEAnnotation"/>: a <c>source</c>-keyed bag of string key/value
    /// <c>details</c> read from an inline <c>ecore:EAnnotation</c> element.
    /// </summary>
    public sealed class EAnnotation : AurigaElement, IEAnnotation
    {
        /// <summary>
        /// Backing field for <see cref="Details"/>.
        /// </summary>
        private IContainerList<IAurigaElement>? backingDetails;

        /// <summary>
        /// Gets or sets the annotation's source: the URI-like key identifying which tool or viewpoint owns
        /// this annotation, or <c>null</c> when the source attribute is absent.
        /// </summary>
        public string? Source { get; set; }

        /// <summary>
        /// Gets the annotation's details: the contained key/value entries.
        /// </summary>
        public IContainerList<IAurigaElement> Details => this.backingDetails ??= new ContainerList<IAurigaElement>(this);

        /// <summary>
        /// Gets the elements directly contained by this annotation, namely its <see cref="Details"/>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override IEnumerable<IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Details)
            {
                yield return element;
            }
        }
    }
}
