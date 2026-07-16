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

namespace Auriga.Model.Libraries
{
    /// <summary>
    /// Definition of the <c>LibraryReference</c> class.
    /// </summary>
    public partial class LibraryReference : Auriga.Core.AurigaElement, Auriga.Model.Libraries.ILibraryReference
    {
        /// <summary>
        /// Gets or sets the access policy.
        /// </summary>
        public Auriga.Model.Libraries.AccessPolicy AccessPolicy { get; set; }

        /// <summary>
        /// Gets or sets the library.
        /// </summary>
        public Auriga.Model.Libraries.IModelInformation Library { get; set; }

        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Model.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Model.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public Auriga.Model.Libraries.IModelVersion Version { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>LibraryReference</c>.
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
