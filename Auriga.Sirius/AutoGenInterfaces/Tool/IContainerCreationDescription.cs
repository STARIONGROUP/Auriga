// ------------------------------------------------------------------------------------------------
// <copyright file="IContainerCreationDescription.cs" company="Starion Group S.A.">
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
    /// Tool to create a Container (ViewNodeContainer or ViewNodeList).
    /// </summary>
    public partial interface IContainerCreationDescription : Auriga.Sirius.Viewpoint.Description.Tool.IMappingBasedToolDescription
    {
        /// <summary>
        /// The ContainerMapping to use.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IContainerMapping> ContainerMappings { get; }

        /// <summary>
        /// All mappings that create views that are able to received a request to manage this creation
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IAbstractNodeMapping> ExtraMappings { get; }

        /// <summary>
        /// The path of the icon to display in the palette. If unset, the icon corresponding to the semantic
        /// element associated with the mapping will be displayed.
        /// </summary>
        string IconPath { get; set; }

        /// <summary>
        /// The first operation.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IInitialNodeCreationOperation InitialOperation { get; set; }

        /// <summary>
        /// The semantic element of the cicked view.
        /// </summary>
        Auriga.Sirius.Diagram.Description.Tool.INodeCreationVariable Variable { get; set; }

        /// <summary>
        /// The clicked view (instance of ViewPoint or ViewNodeContainer).
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.Tool.IContainerViewVariable ViewVariable { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
