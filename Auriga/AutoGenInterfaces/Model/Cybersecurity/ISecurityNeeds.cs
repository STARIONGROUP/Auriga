// ------------------------------------------------------------------------------------------------
// <copyright file="ISecurityNeeds.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>SecurityNeeds</c> interface.
    /// </summary>
    public partial interface ISecurityNeeds : Auriga.Model.Capellacore.INamedElement, Auriga.Model.Emde.IElementExtension
    {
        /// <summary>
        /// Gets or sets the availability value.
        /// </summary>
        Auriga.Model.Capellacore.IEnumerationPropertyLiteral AvailabilityValue { get; set; }

        /// <summary>
        /// Gets or sets the confidentiality value.
        /// </summary>
        Auriga.Model.Capellacore.IEnumerationPropertyLiteral ConfidentialityValue { get; set; }

        /// <summary>
        /// Gets or sets the integrity value.
        /// </summary>
        Auriga.Model.Capellacore.IEnumerationPropertyLiteral IntegrityValue { get; set; }

        /// <summary>
        /// Gets or sets the traceability value.
        /// </summary>
        Auriga.Model.Capellacore.IEnumerationPropertyLiteral TraceabilityValue { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
