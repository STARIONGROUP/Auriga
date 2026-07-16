// ------------------------------------------------------------------------------------------------
// <copyright file="INodeCreationDescription.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// Tool to create a ViewNode. It appears in the palette.
    /// </summary>
    public partial interface INodeCreationDescription : Auriga.Sirius.Viewpoint.Description.Tool.IMappingBasedToolDescription
    {
        /// <summary>
        /// Add here any mapping in which you want to allow the tool execution.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping> ExtraMappings { get; }

        /// <summary>
        /// The path of the icon to display in the palette. If unset, the icon corresponding to the semantic element associated with the mapping will be displayed.
        /// </summary>
        string IconPath { get; set; }

        /// <summary>
        /// The first operation to execute.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IInitialNodeCreationOperation InitialOperation { get; set; }

        /// <summary>
        /// Node mappings used by this tool.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.INodeMapping> NodeMappings { get; }

        /// <summary>
        /// The variable container that represents the semantic element of the clicked view.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.INodeCreationVariable Variable { get; set; }

        /// <summary>
        /// The variable containerView that represents the clickedView (instance of ViewPoint or ViewPointElement).
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IContainerViewVariable ViewVariable { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
