// ------------------------------------------------------------------------------------------------
// <copyright file="IEntityPkg.cs" company="Starion Group S.A.">
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
    public partial interface IEntityPkg : Auriga.Cs.IComponentPkg
    {
        Auriga.IContainerList<Auriga.Oa.IEntity> OwnedEntities { get; }

        Auriga.IContainerList<Auriga.Oa.IEntityPkg> OwnedEntityPkgs { get; }

        Auriga.IContainerList<Auriga.Oa.ILocation> OwnedLocations { get; }

        Auriga.IContainerList<Auriga.Oa.ICommunicationMean> OwnedCommunicationMeans { get; }

    }
}
