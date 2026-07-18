// ------------------------------------------------------------------------------------------------
// <copyright file="ReconnectEdgeDescription.cs" company="Starion Group S.A.">
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
    /// A tool that describes how to reconnect a ViewEdge.
    /// </summary>
    public partial class ReconnectEdgeDescription : Auriga.Core.AurigaElement, Auriga.Diagram.Diagram.Description.Tool.IReconnectEdgeDescription
    {
        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; } = "";

        /// <summary>
        /// Gets or sets the edge view.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IElementSelectVariable EdgeView
        {
            get => this.backingEdgeView;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingEdgeView = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="EdgeView"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Tool.IElementSelectVariable backingEdgeView;

        /// <summary>
        /// The semantic element of the ViewEdge.
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
        public bool? InverseSelectionOrder { get; set; } = false;

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        public string Precondition { get; set; } = "";

        /// <summary>
        /// The kind of reconnection :
        /// SOURCE : the source of the ViewEdge can be reconnected but not the target.
        /// TARGET : the target of the ViewEdge can be reconnected but not the source.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Tool.ReconnectionKind ReconnectionKind { get; set; } = Auriga.Diagram.Diagram.Description.Tool.ReconnectionKind.RECONNECT_TARGET;

        /// <summary>
        /// The semantic element of the source view of the reconnection operation.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Tool.ISourceEdgeCreationVariable Source
        {
            get => this.backingSource;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingSource = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Source"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.Tool.ISourceEdgeCreationVariable backingSource;

        /// <summary>
        /// The source view of the reconnection operation.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Tool.ISourceEdgeViewCreationVariable SourceView
        {
            get => this.backingSourceView;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingSourceView = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="SourceView"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.Tool.ISourceEdgeViewCreationVariable backingSourceView;

        /// <summary>
        /// The semantic element of the target view of the reconnection operation.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Tool.ITargetEdgeCreationVariable Target
        {
            get => this.backingTarget;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingTarget = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Target"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.Tool.ITargetEdgeCreationVariable backingTarget;

        /// <summary>
        /// The target view of the reconnection operation.
        /// </summary>
        public Auriga.Diagram.Diagram.Description.Tool.ITargetEdgeViewCreationVariable TargetView
        {
            get => this.backingTargetView;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingTargetView = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="TargetView"/>.
        /// </summary>
        private Auriga.Diagram.Diagram.Description.Tool.ITargetEdgeViewCreationVariable backingTargetView;

        /// <summary>
        /// Gets the elements directly contained by this <c>ReconnectEdgeDescription</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.EdgeView != null)
            {
                yield return this.EdgeView;
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

            if (this.Source != null)
            {
                yield return this.Source;
            }

            if (this.SourceView != null)
            {
                yield return this.SourceView;
            }

            if (this.Target != null)
            {
                yield return this.Target;
            }

            if (this.TargetView != null)
            {
                yield return this.TargetView;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
