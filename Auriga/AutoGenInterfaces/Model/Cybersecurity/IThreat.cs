// ------------------------------------------------------------------------------------------------
// <copyright file="IThreat.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Threat</c> interface.
    /// </summary>
    public partial interface IThreat : Auriga.Model.Interaction.IAbstractCapability
    {
        /// <summary>
        /// Gets the addressed by.
        /// </summary>
        List<Auriga.Model.Cs.IComponent> AddressedBy { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        Auriga.Model.Capellacore.IEnumerationPropertyLiteral Kind { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        int? Level { get; set; }

        /// <summary>
        /// Gets the owned threat applications.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cybersecurity.IThreatApplication> OwnedThreatApplications { get; }

        /// <summary>
        /// Gets the owned threat involvements.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Cybersecurity.IThreatInvolvement> OwnedThreatInvolvements { get; }

        /// <summary>
        /// Gets or sets the rationale.
        /// </summary>
        string Rationale { get; set; }

        /// <summary>
        /// Gets the realized threats.
        /// </summary>
        IEnumerable<Auriga.Model.Cybersecurity.IThreat> RealizedThreats { get; }

        /// <summary>
        /// Gets the realizing threats.
        /// </summary>
        IEnumerable<Auriga.Model.Cybersecurity.IThreat> RealizingThreats { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
