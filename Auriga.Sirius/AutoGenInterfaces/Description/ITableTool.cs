// ------------------------------------------------------------------------------------------------
// <copyright file="ITableTool.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TableTool</c> interface.
    /// </summary>
    public partial interface ITableTool : Auriga.IAurigaElement
    {
        /// <summary>
        /// Gets or sets the first model operation.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation FirstModelOperation { get; set; }

        /// <summary>
        /// Gets the variables.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Table.Description.ITableVariable> Variables { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
