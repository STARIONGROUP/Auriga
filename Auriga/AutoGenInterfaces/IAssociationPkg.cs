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

namespace Auriga.Information
{
    /// <summary>
    /// Definition of the <c>AssociationPkg</c> interface.
    /// </summary>
    public partial interface IAssociationPkg : Auriga.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned associations.
        /// </summary>
        Auriga.IContainerList<Auriga.Information.IAssociation> OwnedAssociations { get; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        Auriga.Capellacore.VisibilityKind? Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
