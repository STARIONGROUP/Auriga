// ------------------------------------------------------------------------------------------------
// <copyright file="ILogicalFunctionPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.La
{
    /// <summary>
    /// Definition of the <c>LogicalFunctionPkg</c> interface.
    /// </summary>
    public partial interface ILogicalFunctionPkg : Auriga.Model.Fa.IFunctionPkg
    {
        /// <summary>
        /// Gets the owned logical function pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.La.ILogicalFunctionPkg> OwnedLogicalFunctionPkgs { get; }

        /// <summary>
        /// Gets the owned logical functions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.La.ILogicalFunction> OwnedLogicalFunctions { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
