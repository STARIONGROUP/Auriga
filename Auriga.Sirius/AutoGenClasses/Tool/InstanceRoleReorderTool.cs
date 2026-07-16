// ------------------------------------------------------------------------------------------------
// <copyright file="InstanceRoleReorderTool.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>InstanceRoleReorderTool</c> class.
    /// </summary>
    public partial class InstanceRoleReorderTool : Auriga.Core.AurigaElement, Auriga.Sirius.Sequence.Description.Tool.IInstanceRoleReorderTool
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
        /// Gets or sets the instance role moved.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IInitialOperation InstanceRoleMoved
        {
            get => this.backingInstanceRoleMoved;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingInstanceRoleMoved = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="InstanceRoleMoved"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IInitialOperation backingInstanceRoleMoved;

        /// <summary>
        /// By default the elements to select are listed in the creation order. If true, the order is inverted.
        /// </summary>
        public bool? InverseSelectionOrder { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets the mappings.
        /// </summary>
        public List<Auriga.Sirius.Sequence.Description.IInstanceRoleMapping> Mappings { get; } = new List<Auriga.Sirius.Sequence.Description.IInstanceRoleMapping>();

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        public string Precondition { get; set; }

        /// <summary>
        /// Gets or sets the predecessor after.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IElementVariable PredecessorAfter
        {
            get => this.backingPredecessorAfter;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingPredecessorAfter = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="PredecessorAfter"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IElementVariable backingPredecessorAfter;

        /// <summary>
        /// Gets or sets the predecessor before.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IElementVariable PredecessorBefore
        {
            get => this.backingPredecessorBefore;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingPredecessorBefore = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="PredecessorBefore"/>.
        /// </summary>
        private Auriga.Sirius.Viewpoint.Description.Tool.IElementVariable backingPredecessorBefore;

        /// <summary>
        /// Gets the elements directly contained by this <c>InstanceRoleReorderTool</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Filters)
            {
                yield return element;
            }

            if (this.InstanceRoleMoved != null)
            {
                yield return this.InstanceRoleMoved;
            }

            if (this.PredecessorAfter != null)
            {
                yield return this.PredecessorAfter;
            }

            if (this.PredecessorBefore != null)
            {
                yield return this.PredecessorBefore;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
