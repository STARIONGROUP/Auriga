// ------------------------------------------------------------------------------------------------
// <copyright file="INamedRelationship.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>NamedRelationship</c> interface.
    /// </summary>
    public partial interface INamedRelationship : Auriga.Model.Capellacore.IRelationship, Auriga.Model.Capellacore.INamedElement
    {
        /// <summary>
        /// Gets the naming rules.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Capellacore.INamingRule> NamingRules { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
