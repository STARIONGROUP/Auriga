// ------------------------------------------------------------------------------------------------
// <copyright file="IThreatSourceUse.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ThreatSourceUse</c> interface.
    /// </summary>
    public partial interface IThreatSourceUse : Auriga.Model.Capellacore.IRelationship, Auriga.Model.Emde.IElementExtension
    {
        /// <summary>
        /// Gets the threat source.
        /// </summary>
        Auriga.Model.Cs.IComponent ThreatSource { get; }

        /// <summary>
        /// Gets or sets the used.
        /// </summary>
        Auriga.Model.Cs.IComponent Used { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
