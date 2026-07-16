// ------------------------------------------------------------------------------------------------
// <copyright file="IGroup.cs" company="Starion Group S.A.">
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

namespace Auriga.Diagram.Viewpoint.Description
{
    /// <summary>
    /// Definition of the <c>Group</c> interface.
    /// </summary>
    public partial interface IGroup : Auriga.Diagram.Viewpoint.Description.IDModelElement, Auriga.Diagram.Viewpoint.Description.IDocumentedElement
    {
        /// <summary>
        /// Gets the extensions.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IExtension> Extensions { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the owned viewpoints.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IViewpoint> OwnedViewpoints { get; }

        /// <summary>
        /// Gets the system colors palette.
        /// </summary>
        Auriga.Diagram.Viewpoint.Description.ISytemColorsPalette SystemColorsPalette { get; }

        /// <summary>
        /// Gets the user colors palettes.
        /// </summary>
        Auriga.Core.IContainerList<Auriga.Diagram.Viewpoint.Description.IUserColorsPalette> UserColorsPalettes { get; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        string Version { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
