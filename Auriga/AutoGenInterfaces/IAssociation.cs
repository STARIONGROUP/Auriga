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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Auriga.Information
{
    using System.Collections.Generic;

    public partial interface IAssociation : Auriga.Capellacore.INamedRelationship
    {
        Auriga.IContainerList<Auriga.Information.IProperty> OwnedMembers { get; }

        List<Auriga.Information.IProperty> NavigableMembers { get; }

    }
}
