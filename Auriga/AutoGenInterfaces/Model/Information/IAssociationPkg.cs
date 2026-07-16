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

namespace Auriga.Model.Information
{
    /// <summary>
    /// Definition of the <c>AssociationPkg</c> interface.
    /// </summary>
    public partial interface IAssociationPkg : Auriga.Model.Capellacore.IStructure
    {
        /// <summary>
        /// Gets the owned associations.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Model.Information.IAssociation> OwnedAssociations { get; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        Auriga.Model.Capellacore.VisibilityKind? Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
