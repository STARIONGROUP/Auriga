// ------------------------------------------------------------------------------------------------
// <copyright file="IModelVersion.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ModelVersion</c> interface.
    /// </summary>
    public partial interface IModelVersion : Auriga.Model.Libraries.ILibraryAbstractElement
    {
        /// <summary>
        /// Gets or sets the last modified file stamp.
        /// </summary>
        long? LastModifiedFileStamp { get; set; }

        /// <summary>
        /// Gets or sets the major version number.
        /// </summary>
        int MajorVersionNumber { get; set; }

        /// <summary>
        /// Gets or sets the minor version number.
        /// </summary>
        int MinorVersionNumber { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
