// ------------------------------------------------------------------------------------------------
// <copyright file="BehaviorTool.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Tool
{
    /// <summary>
    /// A tool that can be launched by the user.
    /// </summary>
    public partial class BehaviorTool : Auriga.AurigaElement, Auriga.Sirius.Diagram.Description.Tool.IBehaviorTool
    {
        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// The type of elements on which we want to appy the tool.
        /// </summary>
        public string DomainClass { get; set; }

        /// <summary>
        /// An expression used to define the selected elements after the tool execution.
        /// </summary>
        public string ElementsToSelect { get; set; }

        /// <summary>
        /// Gets the filters.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> Filters => this.backingFilters ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription>(this);

        /// <summary>
        /// Backing field for <see cref="Filters"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> backingFilters;

        /// <summary>
        /// If true then a refresh for the whole representation is executed after every execution of the tool.
        /// </summary>
        public bool? ForceRefresh { get; set; }

        /// <summary>
        /// The first operation.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IInitialOperation InitialOperation
        {
            get => this.backingInitialOperation;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingInitialOperation = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="InitialOperation"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IInitialOperation backingInitialOperation;

        /// <summary>
        /// By default the elements to select are listed in the creation order. If true, the order is inverted.
        /// </summary>
        public bool? InverseSelectionOrder { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        public string Precondition { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>BehaviorTool</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Filters)
            {
                yield return element;
            }

            if (this.InitialOperation != null)
            {
                yield return this.InitialOperation;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
