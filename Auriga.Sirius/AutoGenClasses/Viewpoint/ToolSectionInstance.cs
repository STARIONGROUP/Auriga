// ------------------------------------------------------------------------------------------------
// <copyright file="ToolSectionInstance.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint
{
    /// <summary>
    /// Definition of the <c>ToolSectionInstance</c> class.
    /// </summary>
    public partial class ToolSectionInstance : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.IToolSectionInstance
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
        /// Gets or sets the section.
        /// </summary>
        public object Section { get; set; }

        /// <summary>
        /// Gets the sub sections.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.IToolSectionInstance> SubSections => this.backingSubSections ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.IToolSectionInstance>(this);

        /// <summary>
        /// Backing field for <see cref="SubSections"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.IToolSectionInstance> backingSubSections;

        /// <summary>
        /// Gets or sets the tool entry.
        /// </summary>
        public Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry ToolEntry { get; set; }

        /// <summary>
        /// Gets the tools.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.IToolInstance> Tools => this.backingTools ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.IToolInstance>(this);

        /// <summary>
        /// Backing field for <see cref="Tools"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.IToolInstance> backingTools;

        /// <summary>
        /// Gets or sets the visible.
        /// </summary>
        public bool? Visible { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>ToolSectionInstance</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.SubSections)
            {
                yield return element;
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
