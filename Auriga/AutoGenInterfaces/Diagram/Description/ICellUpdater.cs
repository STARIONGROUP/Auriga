// ------------------------------------------------------------------------------------------------
// <copyright file="ICellUpdater.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>CellUpdater</c> interface.
    /// </summary>
    public partial interface ICellUpdater : Auriga.Core.IAurigaElement
    {
        /// <summary>
        /// Gets or sets the can edit.
        /// </summary>
        string CanEdit { get; set; }

        /// <summary>
        /// Gets or sets the cell editor.
        /// </summary>
        Auriga.Diagram.Table.Description.ICellEditorTool CellEditor { get; set; }

        /// <summary>
        /// Gets or sets the direct edit.
        /// </summary>
        Auriga.Diagram.Table.Description.ILabelEditTool DirectEdit { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
