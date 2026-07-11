// ------------------------------------------------------------------------------------------------
// <copyright file="ILayer.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Diagram.Description
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Definition of the <c>Layer</c> interface.
    /// </summary>
    public partial interface ILayer : Auriga.Sirius.Viewpoint.Description.IDocumentedElement, Auriga.Sirius.Viewpoint.Description.IEndUserDocumentedElement, Auriga.Sirius.Viewpoint.Description.IIdentifiedElement
    {
        /// <summary>
        /// All tools of the viewpoint.
        /// </summary>
        IEnumerable<Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription> AllTools { get; }

        /// <summary>
        /// container mappings that are owned by this simple mapping.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IContainerMapping> ContainerMappings { get; }

        /// <summary>
        /// Gets or sets the customization.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.ICustomization Customization { get; set; }

        /// <summary>
        /// Gets or sets the decoration descriptions set.
        /// </summary>
        Auriga.Sirius.Viewpoint.Description.IDecorationDescriptionsSet DecorationDescriptionsSet { get; set; }

        /// <summary>
        /// Edge mapping imports that are owned by this simple mapping.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IEdgeMappingImport> EdgeMappingImports { get; }

        /// <summary>
        /// Edge mappings that are owned by this simple mapping.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.IEdgeMapping> EdgeMappings { get; }

        /// <summary>
        /// image path to use as an icon for the layer
        /// </summary>
        string Icon { get; set; }

        /// <summary>
        /// Node mappings that are owned by this simple mapping.
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.INodeMapping> NodeMappings { get; }

        /// <summary>
        /// Add here any mapping you want to reuse from another layer or diagram.
        /// </summary>
        List<Auriga.Sirius.Diagram.Description.IDiagramElementMapping> ReusedMappings { get; }

        /// <summary>
        /// Tools that are reused by this viewpoint.
        /// </summary>
        List<Auriga.Sirius.Viewpoint.Description.Tool.IAbstractToolDescription> ReusedTools { get; }

        /// <summary>
        /// A tool section encloses many tools
        /// </summary>
        Auriga.IContainerList<Auriga.Sirius.Diagram.Description.Tool.IToolSection> ToolSections { get; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
