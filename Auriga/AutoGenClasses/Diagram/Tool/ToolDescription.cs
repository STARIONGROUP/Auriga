// ------------------------------------------------------------------------------------------------
// <copyright file="ToolDescription.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description.Tool
{
    /// <summary>
    /// Definition of the <c>ToolDescription</c> class.
    /// </summary>
    public partial class ToolDescription : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.Tool.IToolDescription
    {
        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// The variable container that represents the semantic element of the clicked view.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IElementVariable Element
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
        private Auriga.Diagram.Viewpoint.Description.Tool.IElementVariable backingElement;

        /// <summary>
        /// The variable that represents the clicked view.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IElementViewVariable ElementView
        {
            get => this.backingElementView;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingElementView = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="ElementView"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Tool.IElementViewVariable backingElementView;

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
        /// The path of the icon to display in the palette. If unset, the icon corresponding to the semantic element associated with the mapping will be displayed.
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// The first operation to execute.
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
        /// Gets the elements directly contained by this <c>ToolDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.Element != null)
            {
                yield return this.Element;
            }

            if (this.ElementView != null)
            {
                yield return this.ElementView;
            }

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
