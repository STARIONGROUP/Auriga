// ------------------------------------------------------------------------------------------------
// <copyright file="IToolSection.cs" company="Starion Group S.A.">
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
    public partial interface IToolSection : Auriga.Sirius.Viewpoint.Description.IDocumentedElement, Auriga.Sirius.Viewpoint.Description.IIdentifiedElement
    {
        /// <summary>
        /// Gets the group extensions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Diagram.Description.Tool.IToolGroupExtension> GroupExtensions { get; }

        /// <summary>
        /// Groups available on this layer.
        /// </summary>
        IEnumerable<Auriga.Sirius.Viewpoint.Description.Tool.IGroupMenu> Groups { get; }

        /// <summary>
        /// image path used for presenting the section with this icon in the palette
        /// </summary>
        string Icon { get; set; }

        /// <summary>
        /// All tools of the section.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry> OwnedTools { get; }

        /// <summary>
        /// Popup menus available on this layer.
        /// </summary>
        IEnumerable<Auriga.Sirius.Viewpoint.Description.Tool.IPopupMenu> PopupMenus { get; }

        /// <summary>
        /// Tools that are reused by this viewpoint.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.Description.Tool.IToolEntry> ReusedTools { get; }

        /// <summary>
        /// All sub sections
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Diagram.Description.Tool.IToolSection> SubSections { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
