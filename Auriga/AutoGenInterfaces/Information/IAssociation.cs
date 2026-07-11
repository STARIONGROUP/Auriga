// ------------------------------------------------------------------------------------------------
// <copyright file="IAssociation.cs" company="Starion Group S.A.">
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

namespace Auriga.Information
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>Association</c> interface.
    /// </summary>
    public partial interface IAssociation : Auriga.Capellacore.INamedRelationship
    {
        /// <summary>
        /// Gets the navigable members.
        /// </summary>
        List<Auriga.Information.IProperty> NavigableMembers { get; }

        /// <summary>
        /// Gets the owned members.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Information.IProperty> OwnedMembers { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
