// ------------------------------------------------------------------------------------------------
// <copyright file="ToolGroupInstance.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint
{
    /// <summary>
    /// Definition of the <c>ToolGroupInstance</c> class.
    /// </summary>
    public partial class ToolGroupInstance : Auriga.Core.AurigaElement, Auriga.Diagram.Viewpoint.IToolGroupInstance
    {
        /// <summary>
        /// Gets or sets the enabled.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets the filtered.
        /// </summary>
        public bool? Filtered { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        public Auriga.Core.IAurigaElement Group
        {
            get => this.backingGroup;
            set
            {
                if (value != null)
                {
                    value.Container = this;
                }

                this.backingGroup = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="Group"/>.
        /// </summary>
        private Auriga.Core.IAurigaElement backingGroup;

        /// <summary>
        /// Gets or sets the tool entry.
        /// </summary>
        public Auriga.Diagram.Viewpoint.Description.Tool.IToolEntry ToolEntry { get; set; }

        /// <summary>
        /// Gets the tools.
        /// </summary>
        public Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IToolInstance> Tools => this.backingTools ??= new Auriga.Core.ContainerList<Auriga.Diagram.Viewpoint.IToolInstance>(this);

        /// <summary>
        /// Backing field for <see cref="Tools"/>.
        /// </summary>
        private Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.IToolInstance> backingTools;

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        public bool? Visible { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>ToolGroupInstance</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.Core.IAurigaElement> QueryContainedElements()
        {
            if (this.Group != null)
            {
                yield return this.Group;
            }

            foreach (var element in this.Tools)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
