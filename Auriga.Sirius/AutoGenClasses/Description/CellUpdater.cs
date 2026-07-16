// ------------------------------------------------------------------------------------------------
// <copyright file="CellUpdater.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>CellUpdater</c> class.
    /// </summary>
    public partial class CellUpdater : Auriga.Core.AurigaElement, Auriga.Sirius.Table.Description.ICellUpdater
    {
        /// <summary>
        /// Gets or sets the can edit.
        /// </summary>
        public string CanEdit { get; set; }

        /// <summary>
        /// Gets or sets the cell editor.
        /// </summary>
        public Auriga.Sirius.Table.Description.ICellEditorTool CellEditor
        {
            get => this.backingCellEditor;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingCellEditor = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="CellEditor"/>.
        /// </summary>
        private Auriga.Sirius.Table.Description.ICellEditorTool backingCellEditor;

        /// <summary>
        /// Gets or sets the direct edit.
        /// </summary>
        public Auriga.Sirius.Table.Description.ILabelEditTool DirectEdit
        {
            get => this.backingDirectEdit;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingDirectEdit = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="DirectEdit"/>.
        /// </summary>
        private Auriga.Sirius.Table.Description.ILabelEditTool backingDirectEdit;

        /// <summary>
        /// Gets the elements directly contained by this <c>CellUpdater</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.CellEditor != null)
            {
                yield return this.CellEditor;
            }

            if (this.DirectEdit != null)
            {
                yield return this.DirectEdit;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
