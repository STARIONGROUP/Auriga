// ------------------------------------------------------------------------------------------------
// <copyright file="IEnterprisePrimaryAsset.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>EnterprisePrimaryAsset</c> interface.
    /// </summary>
    public partial interface IEnterprisePrimaryAsset : Auriga.Model.Cybersecurity.IPrimaryAsset
    {
        /// <summary>
        /// Gets the primary assets.
        /// </summary>
        IEnumerable<Auriga.Model.Cybersecurity.IPrimaryAsset> PrimaryAssets { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
