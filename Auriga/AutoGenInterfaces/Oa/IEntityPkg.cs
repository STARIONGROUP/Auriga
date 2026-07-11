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

namespace Auriga.Oa
{
    /// <summary>
    /// Definition of the <c>EntityPkg</c> interface.
    /// </summary>
    public partial interface IEntityPkg : Auriga.Cs.IComponentPkg
    {
        /// <summary>
        /// Gets the owned communication means.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Oa.ICommunicationMean> OwnedCommunicationMeans { get; }

        /// <summary>
        /// Gets the owned entities.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Oa.IEntity> OwnedEntities { get; }

        /// <summary>
        /// Gets the owned entity pkgs.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Oa.IEntityPkg> OwnedEntityPkgs { get; }

        /// <summary>
        /// Gets the owned locations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Oa.ILocation> OwnedLocations { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
