// ------------------------------------------------------------------------------------------------
// <copyright file="ISystemComponentPkg.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>SystemComponentPkg</c> interface.
    /// </summary>
    public partial interface ISystemComponentPkg : Auriga.Cs.IComponentPkg
    {
        /// <summary>
        /// Gets the owned system component pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Ctx.ISystemComponentPkg> OwnedSystemComponentPkgs { get; }

        /// <summary>
        /// Gets the owned system components.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Ctx.ISystemComponent> OwnedSystemComponents { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
