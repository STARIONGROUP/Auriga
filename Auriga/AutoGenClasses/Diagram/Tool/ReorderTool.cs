// ------------------------------------------------------------------------------------------------
// <copyright file="ReorderTool.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Sequence.Description.Tool
{
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the <c>ReorderTool</c> class.
    /// </summary>
    public partial class ReorderTool : Auriga.Core.AurigaElement, Auriga.Diagram.Sequence.Description.Tool.IReorderTool
    {
        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; } = "";

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
        /// Gets or sets the finishing end predecessor after.
        /// </summary>
        public Auriga.Diagram.Sequence.Description.IMessageEndVariable FinishingEndPredecessorAfter
        {
            get => this.backingFinishingEndPredecessorAfter;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingFinishingEndPredecessorAfter = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="FinishingEndPredecessorAfter"/>.
        /// </summary>
        private Auriga.Diagram.Sequence.Description.IMessageEndVariable backingFinishingEndPredecessorAfter;

        /// <summary>
        /// Gets or sets the finishing end predecessor before.
        /// </summary>
        public Auriga.Diagram.Sequence.Description.IMessageEndVariable FinishingEndPredecessorBefore
        {
            get => this.backingFinishingEndPredecessorBefore;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingFinishingEndPredecessorBefore = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="FinishingEndPredecessorBefore"/>.
        /// </summary>
        private Auriga.Diagram.Sequence.Description.IMessageEndVariable backingFinishingEndPredecessorBefore;

        /// <summary>
        /// If true then a refresh for the whole representation is executed after every execution of the tool.
        /// </summary>
        public bool? ForceRefresh { get; set; } = false;

        /// <summary>
        /// By default the elements to select are listed in the creation order. If true, the order is inverted.
        /// </summary>
        public bool? InverseSelectionOrder { get; set; } = false;

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets the mappings.
        /// </summary>
        public List<Auriga.Diagram.Sequence.Description.IEventMapping> Mappings { get; } = new List<Auriga.Diagram.Sequence.Description.IEventMapping>();

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Gets or sets the on event moved operation.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation OnEventMovedOperation
        {
            get => this.backingOnEventMovedOperation;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingOnEventMovedOperation = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="OnEventMovedOperation"/>.
        /// </summary>
        private Auriga.Diagram.Viewpoint.Description.Tool.IInitialOperation backingOnEventMovedOperation;

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        public string Precondition { get; set; } = "";

        /// <summary>
        /// Gets or sets the starting end predecessor after.
        /// </summary>
        public Auriga.Diagram.Sequence.Description.IMessageEndVariable StartingEndPredecessorAfter
        {
            get => this.backingStartingEndPredecessorAfter;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingStartingEndPredecessorAfter = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="StartingEndPredecessorAfter"/>.
        /// </summary>
        private Auriga.Diagram.Sequence.Description.IMessageEndVariable backingStartingEndPredecessorAfter;

        /// <summary>
        /// Gets or sets the starting end predecessor before.
        /// </summary>
        public Auriga.Diagram.Sequence.Description.IMessageEndVariable StartingEndPredecessorBefore
        {
            get => this.backingStartingEndPredecessorBefore;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingStartingEndPredecessorBefore = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="StartingEndPredecessorBefore"/>.
        /// </summary>
        private Auriga.Diagram.Sequence.Description.IMessageEndVariable backingStartingEndPredecessorBefore;

        /// <summary>
        /// Gets the elements directly contained by this <c>ReorderTool</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Filters)
            {
                yield return element;
            }

            if (this.FinishingEndPredecessorAfter != null)
            {
                yield return this.FinishingEndPredecessorAfter;
            }

            if (this.FinishingEndPredecessorBefore != null)
            {
                yield return this.FinishingEndPredecessorBefore;
            }

            if (this.OnEventMovedOperation != null)
            {
                yield return this.OnEventMovedOperation;
            }

            if (this.StartingEndPredecessorAfter != null)
            {
                yield return this.StartingEndPredecessorAfter;
            }

            if (this.StartingEndPredecessorBefore != null)
            {
                yield return this.StartingEndPredecessorBefore;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
