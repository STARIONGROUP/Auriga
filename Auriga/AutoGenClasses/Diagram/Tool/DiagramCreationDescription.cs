// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramCreationDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Diagram.Description.Tool
{
    /// <summary>
    /// Definition of the <c>DiagramCreationDescription</c> class.
    /// </summary>
    public partial class DiagramCreationDescription : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.Tool.IDiagramCreationDescription
    {
        /// <summary>
        /// You might put here an expression to browse the semantic model to get to a new place before creating the representation.
        /// </summary>
        public string BrowseExpression { get; set; }

        /// <summary>
        /// The variable containerView that represents the clickedView (instance of ViewPoint or ViewPointElement).
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IContainerViewVariable ContainerViewVariable
        {
            get => this.backingContainerViewVariable;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingContainerViewVariable = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="ContainerViewVariable"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Tool.IContainerViewVariable backingContainerViewVariable;

        /// <summary>
        /// Gets or sets the diagram description.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.IDiagramDescription DiagramDescription { get; set; }

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
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IToolFilterDescription> Filters => this.backingFilters ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IToolFilterDescription>(this);

        /// <summary>
        /// Backing field for <see cref="Filters"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.Tool.IToolFilterDescription> backingFilters;

        /// <summary>
        /// If true then a refresh for the whole representation is executed after every execution of the tool.
        /// </summary>
        public bool? ForceRefresh { get; set; }

        /// <summary>
        /// Gets or sets the initial operation.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation InitialOperation
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
        private Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation backingInitialOperation;

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
        /// Gets the representation description.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.IRepresentationDescription RepresentationDescription => default;

        /// <summary>
        /// The variable representationName that represents the name of the created representation.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.INameVariable RepresentationNameVariable
        {
            get => this.backingRepresentationNameVariable;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingRepresentationNameVariable = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="RepresentationNameVariable"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Tool.INameVariable backingRepresentationNameVariable;

        /// <summary>
        /// The default title of the representation to create. (new + name if empty)
        /// </summary>
        public string TitleExpression { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>DiagramCreationDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.ContainerViewVariable != null)
            {
                yield return this.ContainerViewVariable;
            }

            foreach (var element in this.Filters)
            {
                yield return element;
            }

            if (this.InitialOperation != null)
            {
                yield return this.InitialOperation;
            }

            if (this.RepresentationNameVariable != null)
            {
                yield return this.RepresentationNameVariable;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
