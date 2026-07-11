// ------------------------------------------------------------------------------------------------
// <copyright file="ICrossTableDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Table.Description
{
    /// <summary>
    /// Definition of the <c>CrossTableDescription</c> interface.
    /// </summary>
    public partial interface ICrossTableDescription : Auriga.Sirius.Table.Description.ITableDescription
    {
        /// <summary>
        /// Gets the create column.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Table.Description.ICreateCrossColumnTool> CreateColumn { get; }

        /// <summary>
        /// Gets the intersection.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Table.Description.IIntersectionMapping> Intersection { get; }

        /// <summary>
        /// Gets the owned column mappings.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Table.Description.IElementColumnMapping> OwnedColumnMappings { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
