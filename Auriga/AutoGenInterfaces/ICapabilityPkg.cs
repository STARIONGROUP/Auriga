// ------------------------------------------------------------------------------------------------
// <copyright file="ICapabilityPkg.cs" company="Starion Group S.A.">
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

namespace Auriga.Ctx
{
    public partial interface ICapabilityPkg : Auriga.Capellacommon.IAbstractCapabilityPkg
    {
        Auriga.IContainerList<Auriga.Ctx.ICapability> OwnedCapabilities { get; }

        Auriga.IContainerList<Auriga.Ctx.ICapabilityPkg> OwnedCapabilityPkgs { get; }

    }
}
