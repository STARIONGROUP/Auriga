// ------------------------------------------------------------------------------------------------
// <copyright file="IPrimaryAssetMember.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>PrimaryAssetMember</c> interface.
    /// </summary>
    public partial interface IPrimaryAssetMember : Auriga.Model.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets the asset.
        /// </summary>
        Auriga.Model.Cybersecurity.IPrimaryAsset Asset { get; }

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        Auriga.Model.Modellingcore.IModelElement Member { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
