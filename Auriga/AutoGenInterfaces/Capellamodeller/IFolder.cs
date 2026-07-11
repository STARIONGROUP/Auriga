// ------------------------------------------------------------------------------------------------
// <copyright file="IFolder.cs" company="Starion Group S.A.">
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

namespace Auriga.Capellamodeller
{
    /// <summary>
    /// Definition of the <c>Folder</c> interface.
    /// </summary>
    public partial interface IFolder : Auriga.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned folders.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Capellamodeller.IFolder> OwnedFolders { get; }

        /// <summary>
        /// Gets the owned model roots.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Capellamodeller.IModelRoot> OwnedModelRoots { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
