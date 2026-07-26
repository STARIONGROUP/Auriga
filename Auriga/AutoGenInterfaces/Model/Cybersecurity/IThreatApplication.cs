// ------------------------------------------------------------------------------------------------
// <copyright file="IThreatApplication.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ThreatApplication</c> interface.
    /// </summary>
    public partial interface IThreatApplication : Auriga.Model.Capellacore.IRelationship, Auriga.Model.Emde.IElementExtension
    {
        /// <summary>
        /// Gets or sets the asset.
        /// </summary>
        Auriga.Model.Cybersecurity.IPrimaryAsset Asset { get; set; }

        /// <summary>
        /// Gets the threat obj.
        /// </summary>
        Auriga.Model.Cybersecurity.IThreat ThreatObj { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
