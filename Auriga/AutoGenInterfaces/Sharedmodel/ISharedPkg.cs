// ------------------------------------------------------------------------------------------------
// <copyright file="ISharedPkg.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>SharedPkg</c> interface.
    /// </summary>
    public partial interface ISharedPkg : Auriga.Capellacore.IReuseableStructure, Auriga.Capellamodeller.IModelRoot
    {
        /// <summary>
        /// Gets or sets the owned data pkg.
        /// </summary>
        Auriga.Information.IDataPkg OwnedDataPkg { get; set; }

        /// <summary>
        /// Gets or sets the owned generic pkg.
        /// </summary>
        Auriga.Sharedmodel.IGenericPkg OwnedGenericPkg { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
