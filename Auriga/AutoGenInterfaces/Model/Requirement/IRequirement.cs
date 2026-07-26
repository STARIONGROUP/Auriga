// ------------------------------------------------------------------------------------------------
// <copyright file="IRequirement.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Requirement
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Requirement</c> interface.
    /// </summary>
    public partial interface IRequirement : Auriga.Model.Capellacore.INamespace
    {
        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        string AdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets the feature.
        /// </summary>
        string Feature { get; set; }

        /// <summary>
        /// Gets or sets the implementation version.
        /// </summary>
        string ImplementationVersion { get; set; }

        /// <summary>
        /// Gets or sets the is obsolete.
        /// </summary>
        bool? IsObsolete { get; set; }

        /// <summary>
        /// Gets the related capella elements.
        /// </summary>
        IEnumerable<Auriga.Model.Capellacore.ICapellaElement> RelatedCapellaElements { get; }

        /// <summary>
        /// Gets or sets the requirement id.
        /// </summary>
        string RequirementId { get; set; }

        /// <summary>
        /// Gets or sets the verification method.
        /// </summary>
        string VerificationMethod { get; set; }

        /// <summary>
        /// Gets or sets the verification phase.
        /// </summary>
        string VerificationPhase { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
