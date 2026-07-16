// ------------------------------------------------------------------------------------------------
// <copyright file="IGeneralization.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>Generalization</c> interface.
    /// </summary>
    public partial interface IGeneralization : Auriga.Model.Capellacore.IRelationship
    {
        /// <summary>
        /// Gets or sets the sub.
        /// </summary>
        Auriga.Model.Capellacore.IGeneralizableElement Sub { get; set; }

        /// <summary>
        /// Gets or sets the super.
        /// </summary>
        Auriga.Model.Capellacore.IGeneralizableElement Super { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
