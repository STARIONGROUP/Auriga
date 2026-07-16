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

namespace Auriga.Sirius.Table.Description
{
    /// <summary>
    /// Definition of the <c>CreateCellTool</c> interface.
    /// </summary>
    public partial interface ICreateCellTool : Auriga.Sirius.Table.Description.ITableTool, Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription
    {
        /// <summary>
        /// Gets or sets the mapping.
        /// </summary>
        Auriga.Sirius.Table.Description.IIntersectionMapping Mapping { get; set; }

        /// <summary>
        /// The edit mask.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IEditMaskVariables Mask { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
