// ------------------------------------------------------------------------------------------------
// <copyright file="SelectionWizardDescription.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>SelectionWizardDescription</c> class.
    /// </summary>
    public partial class SelectionWizardDescription : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.Tool.ISelectionWizardDescription
    {
        /// <summary>
        /// Gets or sets the candidates expression.
        /// </summary>
        public string CandidatesExpression { get; set; }

        /// <summary>
        /// Gets or sets the children expression.
        /// </summary>
        public string ChildrenExpression { get; set; }

        /// <summary>
        /// Gets or sets the container view.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IContainerViewVariable ContainerView
        {
            get => this.backingContainerView;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingContainerView = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="ContainerView"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Tool.IContainerViewVariable backingContainerView;

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; } = "";

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IElementSelectVariable Element
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
        private Auriga.Diagram.Viewpoint.Description.Tool.IElementSelectVariable backingElement;

        /// <summary>
        /// An expression used to define the selected elements after the tool execution.
        /// </summary>
        public string ElementsToSelect { get; set; } = "";

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
        public bool? ForceRefresh { get; set; } = false;

        /// <summary>
        /// Gets or sets the icon path.
        /// </summary>
        public string IconPath { get; set; } = "/org.eclipse.sirius.ui/icons/full/obj16/SelectionWizardDescription.gif";

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
        public bool? InverseSelectionOrder { get; set; } = false;

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the multiple.
        /// </summary>
        public bool Multiple { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        public string Precondition { get; set; } = "";

        /// <summary>
        /// Gets or sets the root expression.
        /// </summary>
        public string RootExpression { get; set; }

        /// <summary>
        /// Set to true if you want a tree representation of the selection candidates.
        /// </summary>
        public bool Tree { get; set; }

        /// <summary>
        /// Gets or sets the window image path.
        /// </summary>
        public string WindowImagePath { get; set; }

        /// <summary>
        /// Title of the dialog.
        /// </summary>
        public string WindowTitle { get; set; } = "Selection Wizard";

        /// <summary>
        /// Gets the elements directly contained by this <c>SelectionWizardDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.ContainerView != null)
            {
                yield return this.ContainerView;
            }

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
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
