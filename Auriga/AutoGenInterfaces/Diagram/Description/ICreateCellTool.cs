// ------------------------------------------------------------------------------------------------
// <copyright file="ICreateCellTool.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Table.Description
{
    /// <summary>
    /// Definition of the <c>CreateCellTool</c> interface.
    /// </summary>
    public partial interface ICreateCellTool : Auriga.Diagram.Table.Description.ITableTool, Auriga.Diagram.Viewpoint.Description.Tool.IAbstractToolDescription
    {
        /// <summary>
        /// Gets or sets the mapping.
        /// </summary>
        Auriga.Diagram.Table.Description.IIntersectionMapping Mapping { get; set; }

        /// <summary>
        /// The edit mask.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.Tool.IEditMaskVariables Mask { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
