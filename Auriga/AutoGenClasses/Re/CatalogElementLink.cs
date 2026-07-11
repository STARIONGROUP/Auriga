// ------------------------------------------------------------------------------------------------
// <copyright file="CatalogElementLink.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable disable

namespace Auriga.Re
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>CatalogElementLink</c> class.
    /// </summary>
    public partial class CatalogElementLink : Auriga.Core.AurigaElement, Auriga.Re.ICatalogElementLink
    {
        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        public Auriga.Re.ICatalogElementLink Origin { get; set; }

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public Auriga.Re.ICatalogElement Source { get; set; }

        /// <summary>
        /// Gets or sets the suffixed.
        /// </summary>
        public bool? Suffixed { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public object Target { get; set; }

        /// <summary>
        /// Gets the unsynchronized features.
        /// </summary>
        public List<string> UnsynchronizedFeatures { get; } = new List<string>();

        /// <summary>
        /// Gets the elements directly contained by this <c>CatalogElementLink</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedExtensions)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
