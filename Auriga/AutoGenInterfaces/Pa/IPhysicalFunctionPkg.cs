// ------------------------------------------------------------------------------------------------
// <copyright file="IPhysicalFunctionPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Pa
{
    /// <summary>
    /// Definition of the <c>PhysicalFunctionPkg</c> interface.
    /// </summary>
    public partial interface IPhysicalFunctionPkg : Auriga.Fa.IFunctionPkg
    {
        /// <summary>
        /// Gets the owned physical function pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Pa.IPhysicalFunctionPkg> OwnedPhysicalFunctionPkgs { get; }

        /// <summary>
        /// Gets the owned physical functions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Pa.IPhysicalFunction> OwnedPhysicalFunctions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
