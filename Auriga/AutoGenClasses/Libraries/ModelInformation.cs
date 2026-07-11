// ------------------------------------------------------------------------------------------------
// <copyright file="ModelInformation.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ModelInformation</c> class.
    /// </summary>
    public partial class ModelInformation : Auriga.Core.AurigaElement, Auriga.Libraries.IModelInformation
    {
        /// <summary>
        /// Gets the owned extensions.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> OwnedExtensions => this.backingOwnedExtensions ??= new Auriga.Core.ContainerList<Auriga.Emde.IElementExtension>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedExtensions"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Emde.IElementExtension> backingOwnedExtensions;

        /// <summary>
        /// Gets the owned references.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Libraries.ILibraryReference> OwnedReferences => this.backingOwnedReferences ??= new Auriga.Core.ContainerList<Auriga.Libraries.ILibraryReference>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedReferences"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Libraries.ILibraryReference> backingOwnedReferences;

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public Auriga.Libraries.IModelVersion Version { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>ModelInformation</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.OwnedExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedReferences)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
