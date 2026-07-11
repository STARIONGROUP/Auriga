// ------------------------------------------------------------------------------------------------
// <copyright file="RecCatalog.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>RecCatalog</c> class.
    /// </summary>
    public partial class RecCatalog : Auriga.Core.AurigaElement, Auriga.Re.IRecCatalog
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the owned compliancy definition pkg.
        /// </summary>
        public Auriga.Re.ICompliancyDefinitionPkg OwnedCompliancyDefinitionPkg
        {
            get => this.backingOwnedCompliancyDefinitionPkg;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOwnedCompliancyDefinitionPkg = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OwnedCompliancyDefinitionPkg"/>.
        /// </summary>
        private Auriga.Re.ICompliancyDefinitionPkg backingOwnedCompliancyDefinitionPkg;

        /// <summary>
        /// Gets the owned element pkgs.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Re.ICatalogElementPkg> OwnedElementPkgs => this.backingOwnedElementPkgs ??= new Auriga.Core.ContainerList<Auriga.Re.ICatalogElementPkg>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedElementPkgs"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Re.ICatalogElementPkg> backingOwnedElementPkgs;

        /// <summary>
        /// Gets the owned elements.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Re.ICatalogElement> OwnedElements => this.backingOwnedElements ??= new Auriga.Core.ContainerList<Auriga.Re.ICatalogElement>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedElements"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Re.ICatalogElement> backingOwnedElements;

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the elements directly contained by this <c>RecCatalog</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.OwnedCompliancyDefinitionPkg != null)
            {
                yield return this.OwnedCompliancyDefinitionPkg;
            }

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
