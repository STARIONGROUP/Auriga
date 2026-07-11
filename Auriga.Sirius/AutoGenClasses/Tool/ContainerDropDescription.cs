// ------------------------------------------------------------------------------------------------
// <copyright file="ContainerDropDescription.cs" company="Starion Group S.A.">
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
    /// Tool that describes a Drag & Drop operation.
    /// </summary>
    public partial class ContainerDropDescription : Auriga.AurigaElement, Auriga.Sirius.Diagram.Description.Tool.IContainerDropDescription
    {
        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Authorized sources of the drag.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.DragSource DragSource { get; set; }

        /// <summary>
        /// The semantic element that is dragged and dropped.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IElementDropVariable Element
        {
            get => this.backingElement;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingElement = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Element"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IElementDropVariable backingElement;

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
        public Auriga.Sirius.Viewpoint.Description.Tool.IInitialContainerDropOperation InitialOperation
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
        private Auriga.Sirius.Viewpoint.Description.Tool.IInitialContainerDropOperation backingInitialOperation;

        /// <summary>
        /// By default the elements to select are listed in the creation order. If true, the order is inverted.
        /// </summary>
        public bool? InverseSelectionOrder { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// All mapping that can create the target view.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> Mappings { get; } = new List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping>();

        /// <summary>
        /// Set to true if you want to automatically move the edges associated with a node.
        /// </summary>
        public bool MoveEdges { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The semantic element of the new container view.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IDropContainerVariable NewContainer
        {
            get => this.backingNewContainer;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingNewContainer = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="NewContainer"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IDropContainerVariable backingNewContainer;

        /// <summary>
        /// The new view container (instance of ViewPoint or ViewPointElement).
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IContainerViewVariable NewViewContainer
        {
            get => this.backingNewViewContainer;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingNewViewContainer = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="NewViewContainer"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IContainerViewVariable backingNewViewContainer;

        /// <summary>
        /// The semantic element of the old container view.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IDropContainerVariable OldContainer
        {
            get => this.backingOldContainer;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOldContainer = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OldContainer"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IDropContainerVariable backingOldContainer;

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        public string Precondition { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>ContainerDropDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            if (this.Element != null)
            {
                yield return this.Element;
            }

            foreach (var element in this.Filters)
            {
                yield return element;
            }

            if (this.InitialOperation != null)
            {
                yield return this.InitialOperation;
            }

            if (this.NewContainer != null)
            {
                yield return this.NewContainer;
            }

            if (this.NewViewContainer != null)
            {
                yield return this.NewViewContainer;
            }

            if (this.OldContainer != null)
            {
                yield return this.OldContainer;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
