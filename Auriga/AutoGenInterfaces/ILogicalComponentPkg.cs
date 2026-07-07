// ------------------------------------------------------------------------------------------------
// <copyright file="ILogicalComponentPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.La
{
    /// <summary>
    /// Definition of the <c>LogicalComponentPkg</c> interface.
    /// </summary>
    public partial interface ILogicalComponentPkg : Auriga.Cs.IComponentPkg
    {
        /// <summary>
        /// Gets the owned logical component pkgs.
        /// </summary>
        Auriga.IContainerList<Auriga.La.ILogicalComponentPkg> OwnedLogicalComponentPkgs { get; }

        /// <summary>
        /// Gets the owned logical components.
        /// </summary>
        Auriga.IContainerList<Auriga.La.ILogicalComponent> OwnedLogicalComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
