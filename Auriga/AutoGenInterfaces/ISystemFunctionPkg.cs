// ------------------------------------------------------------------------------------------------
// <copyright file="ISystemFunctionPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Ctx
{
    /// <summary>
    /// Definition of the <c>SystemFunctionPkg</c> interface.
    /// </summary>
    public partial interface ISystemFunctionPkg : Auriga.Fa.IFunctionPkg
    {
        /// <summary>
        /// Gets the owned system function pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.Ctx.ISystemFunctionPkg> OwnedSystemFunctionPkgs { get; }

        /// <summary>
        /// Gets the owned system functions.
        /// </summary>
        Auriga.IContainerList<Auriga.Ctx.ISystemFunction> OwnedSystemFunctions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
