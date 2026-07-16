// ------------------------------------------------------------------------------------------------
// <copyright file="ILibraryReference.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>LibraryReference</c> interface.
    /// </summary>
    public partial interface ILibraryReference : Auriga.Model.Libraries.ILibraryAbstractElement
    {
        /// <summary>
        /// Gets or sets the access policy.
        /// </summary>
        Auriga.Model.Libraries.AccessPolicy AccessPolicy { get; set; }

        /// <summary>
        /// Gets or sets the library.
        /// </summary>
        Auriga.Model.Libraries.IModelInformation Library { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        Auriga.Model.Libraries.IModelVersion Version { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
