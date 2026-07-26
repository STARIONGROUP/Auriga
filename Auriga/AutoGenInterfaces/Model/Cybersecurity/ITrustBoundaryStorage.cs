// ------------------------------------------------------------------------------------------------
// <copyright file="ITrustBoundaryStorage.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TrustBoundaryStorage</c> interface.
    /// </summary>
    public partial interface ITrustBoundaryStorage : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Emde.IElementExtension
    {
        /// <summary>
        /// Gets or sets the rationale.
        /// </summary>
        string Rationale { get; set; }

        /// <summary>
        /// Gets or sets the threat source.
        /// </summary>
        bool? ThreatSource { get; set; }

        /// <summary>
        /// Gets or sets the threat source profile.
        /// </summary>
        int? ThreatSourceProfile { get; set; }

        /// <summary>
        /// Gets or sets the trusted.
        /// </summary>
        bool? Trusted { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
