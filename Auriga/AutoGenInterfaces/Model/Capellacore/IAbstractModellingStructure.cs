// ------------------------------------------------------------------------------------------------
// <copyright file="IAbstractModellingStructure.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Capellacore
{
    /// <summary>
    /// Definition of the <c>AbstractModellingStructure</c> interface.
    /// </summary>
    public partial interface IAbstractModellingStructure : Auriga.Model.Capellacore.IReuserStructure
    {
        /// <summary>
        /// Gets the owned architecture pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacore.IModellingArchitecturePkg> OwnedArchitecturePkgs { get; }

        /// <summary>
        /// Gets the owned architectures.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacore.IModellingArchitecture> OwnedArchitectures { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
