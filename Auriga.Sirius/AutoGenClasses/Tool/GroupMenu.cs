// ------------------------------------------------------------------------------------------------
// <copyright file="GroupMenu.cs" company="Starion Group S.A.">
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
    /// Definition of the <c>GroupMenu</c> class.
    /// </summary>
    public partial class GroupMenu : Auriga.AurigaElement, Auriga.Sirius.Viewpoint.Description.Tool.IGroupMenu
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
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> Filters => this.backingFilters ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription>(this);

        /// <summary>
        /// Backing field for <see cref="Filters"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription> backingFilters;

        /// <summary>
        /// If true then a refresh for the whole representation is executed after every execution of the tool.
        /// </summary>
        public bool? ForceRefresh { get; set; }

        /// <summary>
        /// By default the elements to select are listed in the creation order. If true, the order is inverted.
        /// </summary>
        public bool? InverseSelectionOrder { get; set; }

        /// <summary>
        /// Gets the item descriptions.
        /// </summary>
        public Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IGroupMenuItem> ItemDescriptions => this.backingItemDescriptions ??= new Auriga.ContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IGroupMenuItem>(this);

        /// <summary>
        /// Backing field for <see cref="ItemDescriptions"/>.
        /// </summary>
        private Auriga.IContainerList<Auriga.Sirius.Viewpoint.Description.Tool.IGroupMenuItem> backingItemDescriptions;

        /// <summary>
        /// The label used to display this viewpoint to the end-user.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// A <code>URI</code> specification that defines the insertion point at which the group will be added.
        /// The format for the URI is comprised of two basic parts:
        /// * Scheme: One of "menu", "tabbar". Indicates the type of the manager used to handle the contributions.
        /// * Id: This is either the id of an existing menu or tabbar menu
        /// </summary>
        public string LocationURI { get; set; }

        /// <summary>
        /// The identifier of this element. Must be unique. Changing this identifier will break existing user models which reference the old identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the popup menus.
        /// </summary>
        public IEnumerable<Auriga.Sirius.Viewpoint.Description.Tool.IPopupMenu> PopupMenus => Enumerable.Empty<Auriga.Sirius.Viewpoint.Description.Tool.IPopupMenu>();

        /// <summary>
        /// The precondition of the tool.
        /// </summary>
        public string Precondition { get; set; }

        /// <summary>
        /// Gets the elements directly contained by this <c>GroupMenu</c>.
        /// </summary>
        /// <returns>the directly contained elements</returns>
        public override System.Collections.Generic.IEnumerable<Auriga.IAurigaElement> QueryContainedElements()
        {
            foreach (var element in this.Filters)
            {
                yield return element;
            }

            foreach (var element in this.ItemDescriptions)
            {
                yield return element;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
