// ------------------------------------------------------------------------------------------------
// <copyright file="IModelInformation.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ModelInformation</c> interface.
    /// </summary>
    public partial interface IModelInformation : Auriga.Libraries.ILibraryAbstractElement, Auriga.Emde.IElementExtension
    {
        /// <summary>
        /// Gets the owned references.
        /// </summary>
        Auriga.IContainerList<Auriga.Libraries.ILibraryReference> OwnedReferences { get; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        Auriga.Libraries.IModelVersion Version { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
