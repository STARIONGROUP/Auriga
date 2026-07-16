// ------------------------------------------------------------------------------------------------
// <copyright file="CellEditorTool.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>CellEditorTool</c> class.
    /// </summary>
    public partial class CellEditorTool : Auriga.Core.AurigaElement, Auriga.Diagram.Table.Description.ICellEditorTool
    {
        /// <summary>
        /// Gets or sets the first model operation.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IModelOperation FirstModelOperation
        {
            get => this.backingFirstModelOperation;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingFirstModelOperation = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="FirstModelOperation"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Tool.IModelOperation backingFirstModelOperation;

        /// <summary>
        /// The qualified name of the CellEditorFactory class to provide a CellEditor. This class must implement "org.eclipse.sirius.table.ui.tools.api.editor.ITableCellEditorFactory".
        /// </summary>
        public string QualifiedClassName { get; set; }

        /// <summary>
        /// Gets the variables.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.ITableVariable> Variables => this.backingVariables ??= new Auriga.Core.ContainerList<Auriga.Diagram.Table.Description.ITableVariable>(this);

        /// <summary>
        /// Backing field for <see cref="Variables"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Table.Description.ITableVariable> backingVariables;

        /// <summary>
        /// Gets the elements directly contained by this <c>CellEditorTool</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.FirstModelOperation != null)
            {
                yield return this.FirstModelOperation;
            }

            foreach (var element in this.Variables)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
