// ------------------------------------------------------------------------------------------------
// <copyright file="LibraryReference.cs" company="Starion Group S.A.">
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

namespace Auriga.Libraries
{
    /// <summary>
    /// Definition of the <c>LibraryReference</c> class.
    /// </summary>
    public partial class LibraryReference : Auriga.AurigaElement, Auriga.Libraries.ILibraryReference
    {
        /// <summary>
        /// Gets or sets the access policy.
        /// </summary>
        public Auriga.Libraries.AccessPolicy AccessPolicy { get; set; }

        /// <summary>
        /// Gets or sets the library.
        /// </summary>
        public Auriga.Libraries.IModelInformation Library { get; set; }

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public Auriga.Libraries.IModelVersion Version { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
