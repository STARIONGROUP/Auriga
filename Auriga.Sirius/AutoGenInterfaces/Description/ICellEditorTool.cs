// ------------------------------------------------------------------------------------------------
// <copyright file="ICellEditorTool.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>CellEditorTool</c> interface.
    /// </summary>
    public partial interface ICellEditorTool : Auriga.Sirius.Table.Description.ITableTool
    {
        /// <summary>
        /// The qualified name of the CellEditorFactory class to provide a CellEditor. This class must implement
        /// "org.eclipse.sirius.table.ui.tools.api.editor.ITableCellEditorFactory".
        /// </summary>
        string QualifiedClassName { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
