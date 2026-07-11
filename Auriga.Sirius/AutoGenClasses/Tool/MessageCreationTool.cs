// ------------------------------------------------------------------------------------------------
// <copyright file="MessageCreationTool.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>MessageCreationTool</c> class.
    /// </summary>
    public partial class MessageCreationTool : Auriga.AurigaElement, Auriga.Sirius.Sequence.Description.Tool.IMessageCreationTool
    {
        /// <summary>
        /// The start precondition of the tool.
        /// </summary>
        public string ConnectionStartPrecondition { get; set; }

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// All EdgeMappings used by this tool.
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IEdgeMapping> EdgeMappings { get; } = new List<Auriga.Sirius.Diagram.Description.IEdgeMapping>();

        /// <summary>
        /// An expression used to define the selected elements after the tool execution.
        /// </summary>
        public string ElementsToSelect { get; set; }

        /// <summary>
        /// All mappings that create views that are able to received a request to manage this creation
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> ExtraSourceMappings { get; } = new List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping>();

        /// <summary>
        /// All mappings that create views that are able to received a request to manage this creation
        /// </summary>
        public List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> ExtraTargetMappings { get; } = new List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping>();

        /// <summary>
        /// Gets the filters.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> Filters => this.backingFilters ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription>(this);

        /// <summary>
        /// Backing field for <see cref="Filters"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> backingFilters;

        /// <summary>
        /// Gets or sets the finishing end predecessor.
        /// </summary>
        public Auriga.Sirius.Sequence.Description.IMessageEndVariable FinishingEndPredecessor
        {
            get => this.backingFinishingEndPredecessor;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingFinishingEndPredecessor = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="FinishingEndPredecessor"/>.
        /// </summary>
        private Auriga.Sirius.Sequence.Description.IMessageEndVariable backingFinishingEndPredecessor;

        /// <summary>
        /// If true then a refresh for the whole representation is executed after every execution of the tool.
        /// </summary>
        public bool? ForceRefresh { get; set; }

        /// <summary>
        /// The path of the icon to display in the palette. If unset, the icon corresponding to the semantic
        /// element associated with the mapping will be displayed.
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// The first operation.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IInitEdgeCreationOperation InitialOperation
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
        private Auriga.Sirius.Viewpoint.Description.Tool.IInitEdgeCreationOperation backingInitialOperation;

        /// <summary>
        /// By default the elements to select are listed in the creation order. If true, the order is inverted.
        /// </summary>
        public bool? InverseSelectionOrder { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user
        /// models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        public string Precondition { get; set; }

        /// <summary>
        /// The semantic element of the source view.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Tool.ISourceEdgeCreationVariable SourceVariable
        {
            get => this.backingSourceVariable;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingSourceVariable = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="SourceVariable"/>.
        /// </summary>
        private Auriga.Sirius.Diagram.Description.Tool.ISourceEdgeCreationVariable backingSourceVariable;

        /// <summary>
        /// The source view (instance of EdgeTarget)
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Tool.ISourceEdgeViewCreationVariable SourceViewVariable
        {
            get => this.backingSourceViewVariable;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingSourceViewVariable = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="SourceViewVariable"/>.
        /// </summary>
        private Auriga.Sirius.Diagram.Description.Tool.ISourceEdgeViewCreationVariable backingSourceViewVariable;

        /// <summary>
        /// Gets or sets the starting end predecessor.
        /// </summary>
        public Auriga.Sirius.Sequence.Description.IMessageEndVariable StartingEndPredecessor
        {
            get => this.backingStartingEndPredecessor;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingStartingEndPredecessor = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="StartingEndPredecessor"/>.
        /// </summary>
        private Auriga.Sirius.Sequence.Description.IMessageEndVariable backingStartingEndPredecessor;

        /// <summary>
        /// The semantic element of the target view.
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Tool.ITargetEdgeCreationVariable TargetVariable
        {
            get => this.backingTargetVariable;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingTargetVariable = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="TargetVariable"/>.
        /// </summary>
        private Auriga.Sirius.Diagram.Description.Tool.ITargetEdgeCreationVariable backingTargetVariable;

        /// <summary>
        /// The target view (instance of EdgeTarget)
        /// </summary>
        public Auriga.Sirius.Diagram.Description.Tool.ITargetEdgeViewCreationVariable TargetViewVariable
        {
            get => this.backingTargetViewVariable;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingTargetViewVariable = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="TargetViewVariable"/>.
        /// </summary>
        private Auriga.Sirius.Diagram.Description.Tool.ITargetEdgeViewCreationVariable backingTargetViewVariable;

        /// <summary>
        /// Gets the elements directly contained by this <c>MessageCreationTool</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Filters)
            {
                yield return element;
            }

            if (this.FinishingEndPredecessor != null)
            {
                yield return this.FinishingEndPredecessor;
            }

            if (this.InitialOperation != null)
            {
                yield return this.InitialOperation;
            }

            if (this.SourceVariable != null)
            {
                yield return this.SourceVariable;
            }

            if (this.SourceViewVariable != null)
            {
                yield return this.SourceViewVariable;
            }

            if (this.StartingEndPredecessor != null)
            {
                yield return this.StartingEndPredecessor;
            }

            if (this.TargetVariable != null)
            {
                yield return this.TargetVariable;
            }

            if (this.TargetViewVariable != null)
            {
                yield return this.TargetViewVariable;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
