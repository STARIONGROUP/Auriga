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

namespace Auriga.Model.La
{
    /// <summary>
    /// Definition of the <c>LogicalComponentPkg</c> interface.
    /// </summary>
    public partial interface ILogicalComponentPkg : Auriga.Model.Cs.IComponentPkg
    {
        /// <summary>
        /// Gets the owned logical component pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.La.ILogicalComponentPkg> OwnedLogicalComponentPkgs { get; }

        /// <summary>
        /// Gets the owned logical components.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.La.ILogicalComponent> OwnedLogicalComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
