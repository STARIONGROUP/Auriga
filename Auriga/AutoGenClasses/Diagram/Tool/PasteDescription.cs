// ------------------------------------------------------------------------------------------------
// <copyright file="PasteDescription.cs" company="Starion Group S.A.">
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
    /// Tool that describes a paste operation.
    /// </summary>
    public partial class PasteDescription : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.Description.Tool.IPasteDescription
    {
        /// <summary>
        /// The new view container (DRepresentation of DRepresentationElement).
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
        /// The copied semantic element.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IElementVariable CopiedElement
        {
            get => this.backingCopiedElement;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingCopiedElement = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="CopiedElement"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Tool.IElementVariable backingCopiedElement;

        /// <summary>
        /// The copied view.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IElementViewVariable CopiedView
        {
            get => this.backingCopiedView;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingCopiedView = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="CopiedView"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Tool.IElementViewVariable backingCopiedView;

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
        /// The first operation.
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
        /// Gets the elements directly contained by this <c>PasteDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.ContainerView != null)
            {
                yield return this.ContainerView;
            }

            if (this.CopiedElement != null)
            {
                yield return this.CopiedElement;
            }

            if (this.CopiedView != null)
            {
                yield return this.CopiedView;
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
