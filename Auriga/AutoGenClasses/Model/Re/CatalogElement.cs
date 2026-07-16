// ------------------------------------------------------------------------------------------------
// <copyright file="CatalogElement.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Re
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>CatalogElement</c> class.
    /// </summary>
    public partial class CatalogElement : Auriga.Core.AurigaElement, Auriga.Model.Re.ICatalogElement
    {
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the current compliancy.
        /// </summary>
        public Auriga.Model.Re.ICompliancyDefinition CurrentCompliancy { get; set; }

        /// <summary>
        /// Gets or sets the default replica compliancy.
        /// </summary>
        public Auriga.Model.Re.ICompliancyDefinition DefaultReplicaCompliancy { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the environment.
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public Auriga.Model.Re.CatalogElementKind? Kind { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        public Auriga.Model.Re.ICatalogElement Origin { get; set; }

        /// <summary>
        /// Gets the owned elements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Re.ICatalogElement> OwnedElements => this.backingOwnedElements ??= new Auriga.Core.ContainerList<Auriga.Model.Re.ICatalogElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Re.ICatalogElement> backingOwnedElements;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Model.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned links.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Re.ICatalogElementLink> OwnedLinks => this.backingOwnedLinks ??= new Auriga.Core.ContainerList<Auriga.Model.Re.ICatalogElementLink>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedLinks"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Re.ICatalogElementLink> backingOwnedLinks;

        /// <summary>
        /// Gets or sets the purpose.
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// Gets or sets the read only.
        /// </summary>
        public bool? ReadOnly { get; set; }

        /// <summary>
        /// Gets the referenced elements.
        /// </summary>
        public IEnumerable<object> ReferencedElements => Enumerable.Empty<object>();

        /// <summary>
        /// Gets the replicated elements.
        /// </summary>
        public IEnumerable<Auriga.Model.Re.ICatalogElement> ReplicatedElements => Enumerable.Empty<Auriga.Model.Re.ICatalogElement>();

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        public List<string> Tags { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>CatalogElement</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedElements)
            {
                yield return element;
            }

            foreach (var element in this.OwnedExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedLinks)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
