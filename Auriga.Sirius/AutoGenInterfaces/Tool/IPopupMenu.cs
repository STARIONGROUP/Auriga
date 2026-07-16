// ------------------------------------------------------------------------------------------------
// <copyright file="IPopupMenu.cs" company="Starion Group S.A.">
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
    /// <summary>
    /// Definition of the <c>PopupMenu</c> interface.
    /// </summary>
    public partial interface IPopupMenu : Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription, Auriga.Sirius.Viewpoint.Description.Tool.IGroupMenuItem
    {
        /// <summary>
        /// Gets the menu item description.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IMenuItemDescription> MenuItemDescription { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
