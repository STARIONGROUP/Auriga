// ------------------------------------------------------------------------------------------------
// <copyright file="IReuseLink.cs" company="Starion Group S.A.">
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

namespace Auriga.Model.Capellacore
{
    /// <summary>
    /// Definition of the <c>ReuseLink</c> interface.
    /// </summary>
    public partial interface IReuseLink : Auriga.Model.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets or sets the reused.
        /// </summary>
        Auriga.Model.Capellacore.IReuseableStructure Reused { get; set; }

        /// <summary>
        /// Gets or sets the reuser.
        /// </summary>
        Auriga.Model.Capellacore.IReuserStructure Reuser { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
