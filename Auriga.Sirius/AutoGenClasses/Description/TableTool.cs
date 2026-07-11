// ------------------------------------------------------------------------------------------------
// <copyright file="TableTool.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>TableTool</c> class.
    /// </summary>
    public partial class TableTool : Auriga.AurigaElement, Auriga.Sirius.Table.Description.ITableTool
    {
        /// <summary>
        /// Gets or sets the first model operation.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation FirstModelOperation
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
        private Auriga.Sirius.Viewpoint.Description.Tool.IModelOperation backingFirstModelOperation;

        /// <summary>
        /// Gets the variables.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Table.Description.ITableVariable> Variables => this.backingVariables ??= new Auriga.ContainerList<Auriga.Sirius.Table.Description.ITableVariable>(this);

        /// <summary>
        /// Backing field for <see cref="Variables"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Table.Description.ITableVariable> backingVariables;

        /// <summary>
        /// Gets the elements directly contained by this <c>TableTool</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
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
