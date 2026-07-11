// ------------------------------------------------------------------------------------------------
// <copyright file="IGroupMenu.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Viewpoint.Description.Tool
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>GroupMenu</c> interface.
    /// </summary>
    public partial interface IGroupMenu : Auriga.Sirius.Viewpoint.Description.Tool.IMenuItemDescription
    {
        /// <summary>
        /// Gets the item descriptions.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IGroupMenuItem> ItemDescriptions { get; }

        /// <summary>
        /// A URI specification that defines the insertion point at which the group will be added.The format for
        /// the URI is comprised of two basic parts:* Scheme: One of "menu", "tabbar". Indicates the type of the
        /// manager used to handle the contributions.* Id: This is either the id of an existing menu or tabbar
        /// menu
        /// </summary>
        string LocationURI { get; set; }

        /// <summary>
        /// Gets the popup menus.
        /// </summary>
        IEnumerable<Auriga.Sirius.Viewpoint.Description.Tool.IPopupMenu> PopupMenus { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
