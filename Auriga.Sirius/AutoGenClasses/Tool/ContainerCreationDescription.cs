// ------------------------------------------------------------------------------------------------
// <copyright file="ContainerCreationDescription.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Tool to create a Container (ViewNodeContainer or ViewNodeList).
    /// </summary>
    public partial class ContainerCreationDescription : Auriga.Core.AurigaElement, Auriga.Sirius.Diagram.Description.Tool.IContainerCreationDescription
    {
        /// <summary>
        /// The ContainerMapping to use.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IContainerMapping> ContainerMappings { get; } = new List<Auriga.Sirius.Diagram.Description.IContainerMapping>();

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// An expression used to define the selected elements after the tool execution.
        /// </summary>
        public string ElementsToSelect { get; set; }

        /// <summary>
        /// All mappings that create views that are able to received a request to manage this creation
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping> ExtraMappings { get; } = new List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping>();

        /// <summary>
        /// Gets the filters.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> Filters => this.backingFilters ??= new Auriga.Core.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription>(this);

        /// <summary>
        /// Backing field for <see cref="Filters"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> backingFilters;

        /// <summary>
        /// If true then a refresh for the whole representation is executed after every execution of the tool.
        /// </summary>
        public bool? ForceRefresh { get; set; }

        /// <summary>
        /// The path of the icon to display in the palette. If unset, the icon corresponding to the semantic element associated with the mapping will be displayed.
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// The first operation.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IInitialNodeCreationOperation InitialOperation
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
        private Auriga.Sirius.Viewpoint.Description.Tool.IInitialNodeCreationOperation backingInitialOperation;

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
        /// The semantic element of the cicked view.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Tool.INodeCreationVariable Variable
        {
            get => this.backingVariable;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingVariable = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Variable"/>.
        /// </summary>
        private Auriga.Sirius.Diagram.Description.Tool.INodeCreationVariable backingVariable;

        /// <summary>
        /// The clicked view (instance of ViewPoint or ViewNodeContainer).
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IContainerViewVariable ViewVariable
        {
            get => this.backingViewVariable;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingViewVariable = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="ViewVariable"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IContainerViewVariable backingViewVariable;

        /// <summary>
        /// Gets the elements directly contained by this <c>ContainerCreationDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Filters)
            {
                yield return element;
            }

            if (this.InitialOperation != null)
            {
                yield return this.InitialOperation;
            }

            if (this.Variable != null)
            {
                yield return this.Variable;
            }

            if (this.ViewVariable != null)
            {
                yield return this.ViewVariable;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
