// ------------------------------------------------------------------------------------------------
// <copyright file="IGenericPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Sharedmodel
{
    /// <summary>
    /// Definition of the <c>GenericPkg</c> interface.
    /// </summary>
    public partial interface IGenericPkg : Auriga.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the capella elements.
        /// </summary>
        Auriga.IContainerList<Auriga.Capellacore.ICapellaElement> CapellaElements { get; }

        /// <summary>
        /// Gets the sub generic pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.Sharedmodel.IGenericPkg> SubGenericPkgs { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
