// ------------------------------------------------------------------------------------------------
// <copyright file="ToolSection.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description.Tool
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A tool section enclosed some tools.
    /// </summary>
    public partial class ToolSection : Auriga.AurigaElement, Auriga.Sirius.Diagram.Description.Tool.IToolSection
    {
        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets the group extensions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Diagram.Description.Tool.IToolGroupExtension> GroupExtensions => this.backingGroupExtensions ??= new Auriga.ContainerList<Auriga.Sirius.Diagram.Description.Tool.IToolGroupExtension>(this);

        /// <summary>
        /// Backing field for <see cref="GroupExtensions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Diagram.Description.Tool.IToolGroupExtension> backingGroupExtensions;

        /// <summary>
        /// Groups available on this layer.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Viewpoint.Description.Tool.IGroupMenu> Groups => Enumerable.Empty<Auriga.Sirius.Viewpoint.Description.Tool.IGroupMenu>();

        /// <summary>
        /// image path used for presenting the section with this icon in the palette
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// All tools of the section.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry> OwnedTools => this.backingOwnedTools ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry>(this);

        /// <summary>
        /// Backing field for <see cref="OwnedTools"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry> backingOwnedTools;

        /// <summary>
        /// Popup menus available on this layer.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Viewpoint.Description.Tool.IPopupMenu> PopupMenus => Enumerable.Empty<Auriga.Sirius.Viewpoint.Description.Tool.IPopupMenu>();

        /// <summary>
        /// Tools that are reused by this viewpoint.
        /// </summary>
        public List<Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry> ReusedTools { get; } = new List<Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry>();

        /// <summary>
        /// All sub sections
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Diagram.Description.Tool.IToolSection> SubSections => this.backingSubSections ??= new Auriga.ContainerList<Auriga.Sirius.Diagram.Description.Tool.IToolSection>(this);

        /// <summary>
        /// Backing field for <see cref="SubSections"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Diagram.Description.Tool.IToolSection> backingSubSections;

        /// <summary>
        /// Gets the elements directly contained by this <c>ToolSection</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.GroupExtensions)
            {
                yield return element;
            }

            foreach (var element in this.OwnedTools)
            {
                yield return element;
            }

            foreach (var element in this.SubSections)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
