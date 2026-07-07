// ------------------------------------------------------------------------------------------------
// <copyright file="IOperationalActivityPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Oa
{
    public partial interface IOperationalActivityPkg : global::Auriga.Fa.IFunctionPkg
    {
        global::Auriga.IContainerList<global::Auriga.Oa.IOperationalActivity> OwnedOperationalActivities { get; }

        global::Auriga.IContainerList<global::Auriga.Oa.IOperationalActivityPkg> OwnedOperationalActivityPkgs { get; }

    }
}
