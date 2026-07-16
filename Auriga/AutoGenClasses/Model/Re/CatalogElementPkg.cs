// ------------------------------------------------------------------------------------------------
// <copyright file="CatalogElementPkg.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>CatalogElementPkg</c> class.
    /// </summary>
    public partial class CatalogElementPkg : Auriga.Core.AurigaElement, Auriga.Model.Re.ICatalogElementPkg
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the owned element pkgs.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Re.ICatalogElementPkg> OwnedElementPkgs => this.backingOwnedElementPkgs ??= new Auriga.Core.ContainerList<Auriga.Model.Re.ICatalogElementPkg>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedElementPkgs"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Re.ICatalogElementPkg> backingOwnedElementPkgs;

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
        /// Gets the elements directly contained by this <c>CatalogElementPkg</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedElementPkgs)
            {
                yield return element;
            }

            foreach (var element in this.OwnedElements)
            {
                yield return element;
            }

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
