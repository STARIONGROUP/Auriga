// ------------------------------------------------------------------------------------------------
// <copyright file="InstanceRoleCreationTool.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Sequence.Description.Tool
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>InstanceRoleCreationTool</c> class.
    /// </summary>
    public partial class InstanceRoleCreationTool : Auriga.AurigaElement, Auriga.Sirius.Sequence.Description.Tool.IInstanceRoleCreationTool
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
        /// Add here any mapping in which you want to allow the tool execution.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping> ExtraMappings { get; } = new List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping>();

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
        /// The path of the icon to display in the palette. If unset, the icon corresponding to the semantic element associated with the mapping will be displayed.
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// The first operation to execute.
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
        /// Node mappings used by this tool.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.INodeMapping> NodeMappings { get; } = new List<Auriga.Sirius.Diagram.Description.INodeMapping>();

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        public string Precondition { get; set; }

        /// <summary>
        /// Gets or sets the predecessor.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IElementVariable Predecessor
        {
            get => this.backingPredecessor;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingPredecessor = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Predecessor"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IElementVariable backingPredecessor;

        /// <summary>
        /// The variable container that represents the semantic element of the clicked view.
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
        /// The variable containerView that represents the clickedView (instance of ViewPoint or ViewPointElement).
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
        /// Gets the elements directly contained by this <c>InstanceRoleCreationTool</c>.
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

            if (this.Predecessor != null)
            {
                yield return this.Predecessor;
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
