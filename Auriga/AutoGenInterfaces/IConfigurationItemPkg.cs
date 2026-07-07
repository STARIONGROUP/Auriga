// ------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationItemPkg.cs" company="Starion Group S.A.">
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Epbs
{
    public partial interface IConfigurationItemPkg : global::Auriga.Cs.IComponentPkg
    {
        global::Auriga.IContainerList<global::Auriga.Epbs.IConfigurationItem> OwnedConfigurationItems { get; }

        global::Auriga.IContainerList<global::Auriga.Epbs.IConfigurationItemPkg> OwnedConfigurationItemPkgs { get; }

    }
}
