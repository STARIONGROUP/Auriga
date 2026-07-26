// ------------------------------------------------------------------------------------------------
// <copyright file="ICybersecurityConfiguration.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>CybersecurityConfiguration</c> interface.
    /// </summary>
    public partial interface ICybersecurityConfiguration : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Emde.IElementExtension
    {
        /// <summary>
        /// Gets or sets the availability.
        /// </summary>
        Auriga.Model.Capellacore.IEnumerationPropertyType Availability { get; set; }

        /// <summary>
        /// Gets or sets the confidentiality.
        /// </summary>
        Auriga.Model.Capellacore.IEnumerationPropertyType Confidentiality { get; set; }

        /// <summary>
        /// Gets or sets the integrity.
        /// </summary>
        Auriga.Model.Capellacore.IEnumerationPropertyType Integrity { get; set; }

        /// <summary>
        /// Gets or sets the threat kind.
        /// </summary>
        Auriga.Model.Capellacore.IEnumerationPropertyType ThreatKind { get; set; }

        /// <summary>
        /// Gets or sets the traceability.
        /// </summary>
        Auriga.Model.Capellacore.IEnumerationPropertyType Traceability { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
