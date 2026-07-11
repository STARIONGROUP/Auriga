// ------------------------------------------------------------------------------------------------
// <copyright file="IProject.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Project</c> interface.
    /// </summary>
    public partial interface IProject : Auriga.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the key value pairs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Capellacore.IKeyValue> KeyValuePairs { get; }

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
