// ------------------------------------------------------------------------------------------------
// <copyright file="IAssociationPkg.cs" company="Starion Group S.A.">
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
    public partial interface IAssociationPkg : Auriga.Capellacore.IStructure
    {
        Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

        Auriga.IContainerList<Auriga.Information.IAssociation> OwnedAssociations { get; }

    }
}
