// ------------------------------------------------------------------------------------------------
// <copyright file="IPrimaryAsset.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Cybersecurity
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>PrimaryAsset</c> interface.
    /// </summary>
    public partial interface IPrimaryAsset : Auriga.Model.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the owned members.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cybersecurity.IPrimaryAssetMember> OwnedMembers { get; }

        /// <summary>
        /// Gets the realized primary assets.
        /// </summary>
        IEnumerable<Auriga.Model.Cybersecurity.IPrimaryAsset> RealizedPrimaryAssets { get; }

        /// <summary>
        /// Gets the realizing primary assets.
        /// </summary>
        IEnumerable<Auriga.Model.Cybersecurity.IPrimaryAsset> RealizingPrimaryAssets { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
