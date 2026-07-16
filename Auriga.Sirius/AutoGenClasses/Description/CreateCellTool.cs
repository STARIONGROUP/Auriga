// ------------------------------------------------------------------------------------------------
// <copyright file="CreateCellTool.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>CreateCellTool</c> class.
    /// </summary>
    public partial class CreateCellTool : Auriga.Core.AurigaElement, Auriga.Sirius.Table.Description.ICreateCellTool
    {
        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// An expression used to define the selected elements after the tool execution.
        /// </summary>
        public string ElementsToSelect { get; set; }

        /// <summary>
        /// Gets the filters.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> Filters => this.backingFilters ??= new Auriga.Core.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription>(this);

        /// <summary>
        /// Backing field for <see cref="Filters"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> backingFilters;

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
        /// If true then a refresh for the whole representation is executed after every execution of the tool.
        /// </summary>
        public bool? ForceRefresh { get; set; }

        /// <summary>
        /// By default the elements to select are listed in the creation order. If true, the order is inverted.
        /// </summary>
        public bool? InverseSelectionOrder { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the mapping.
        /// </summary>
        public Auriga.Sirius.Table.Description.IIntersectionMapping Mapping { get; set; }

        /// <summary>
        /// The edit mask.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IEditMaskVariables Mask
        {
            get => this.backingMask;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingMask = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Mask"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IEditMaskVariables backingMask;

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        public string Precondition { get; set; }

        /// <summary>
        /// Gets the variables.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.ITableVariable> Variables => this.backingVariables ??= new Auriga.Core.ContainerList<Auriga.Sirius.Table.Description.ITableVariable>(this);

        /// <summary>
        /// Backing field for <see cref="Variables"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Table.Description.ITableVariable> backingVariables;

        /// <summary>
        /// Gets the elements directly contained by this <c>CreateCellTool</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Filters)
            {
                yield return element;
            }

            if (this.FirstModelOperation != null)
            {
                yield return this.FirstModelOperation;
            }

            if (this.Mask != null)
            {
                yield return this.Mask;
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
