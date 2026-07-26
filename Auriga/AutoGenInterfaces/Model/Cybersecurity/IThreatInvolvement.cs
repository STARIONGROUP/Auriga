// ------------------------------------------------------------------------------------------------
// <copyright file="IThreatInvolvement.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>ThreatInvolvement</c> interface.
    /// </summary>
    public partial interface IThreatInvolvement : Auriga.Model.Capellacore.IRelationship, Auriga.Model.Emde.IElementExtension
    {
        /// <summary>
        /// Gets or sets the component.
        /// </summary>
        Auriga.Model.Cs.IComponent Component { get; set; }

        /// <summary>
        /// Gets the threat obj.
        /// </summary>
        Auriga.Model.Cybersecurity.IThreat ThreatObj { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
