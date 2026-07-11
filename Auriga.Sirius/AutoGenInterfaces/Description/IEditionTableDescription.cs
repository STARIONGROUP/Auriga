// ------------------------------------------------------------------------------------------------
// <copyright file="IEditionTableDescription.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>EditionTableDescription</c> interface.
    /// </summary>
    public partial interface IEditionTableDescription : Auriga.Sirius.Table.Description.ITableDescription
    {
        /// <summary>
        /// Gets the all column mappings.
        /// </summary>
        IEnumerable<Auriga.Sirius.Table.Description.IFeatureColumnMapping> AllColumnMappings { get; }

        /// <summary>
        /// Gets the owned column mappings.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.IFeatureColumnMapping> OwnedColumnMappings { get; }

        /// <summary>
        /// Gets the reused column mappings.
        /// </summary>
        List<Auriga.Sirius.Table.Description.IFeatureColumnMapping> ReusedColumnMappings { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
